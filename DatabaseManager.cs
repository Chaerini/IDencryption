using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace project2
{
    internal class DatabaseManager
    {
        private string _connectionAddress;

        // DB 연결 코드
        public DatabaseManager(string server, int port, string database, string id, string pw)
        {
            _connectionAddress = string.Format(
                "Server={0};Port={1};Database={2};Uid={3};Pwd={4};SslMode=Preferred",
                server, port, database, id, pw);
        }

        // 복호화 함수
        public static string DecryptAES(string encryptedText)
        {
            string encryptionKey = "yourEncryptionKeyHereThatIs32BytesLong!";  // 반드시 32바이트로 맞춰야 함
            encryptionKey = encryptionKey.Substring(0, 32);  // 길이가 32보다 크면 자르기

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.IV = new byte[16];  // IV는 16바이트 (제로 초기화)

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();  // 복호화된 텍스트 반환
                        }
                    }
                }
            }
        }

        // DB 연결 확인
        public bool TestDatabaseConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionAddress))
                {
                    conn.Open(); // 데이터베이스 연결

                    // 두 테이블이 존재하는지 확인하는 쿼리
                    string query = "SHOW TABLES LIKE 'idcard';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result1 = cmd.ExecuteScalar();

                    query = "SHOW TABLES LIKE 'drcard';";
                    cmd = new MySqlCommand(query, conn);
                    object result2 = cmd.ExecuteScalar();

                    // 존재 여부에 따라 결과 반환
                    if (result1 != null && result2 != null)
                    {
                        MessageBox.Show("Both tables (idcard and drcard) are present in the database!");
                        return true;
                    }
                    else if (result1 != null)
                    {
                        MessageBox.Show("Only idcard is present in the database.");
                    }
                    else if (result2 != null)
                    {
                        MessageBox.Show("Only drcard is present in the database.");
                    }
                    else
                    {
                        MessageBox.Show("Neither idcard nor drcard is present in the database.");
                    }

                    conn.Close();
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                // 연결 실패 시 오류 메시지
                MessageBox.Show("Database connection failed: " + ex.Message);
                return false;
            }
        }

        public DataTable GetDataByConditions(string table = null, string name = null, string birth = null, int id = -1)
        {
            DataTable dataTable = new DataTable();
            List<string> conditions = new List<string>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            // 이름 조건 추가
            if (!string.IsNullOrEmpty(name))
            {
                conditions.Add("name LIKE @name");
                parameters.Add(new MySqlParameter("@name", "%" + name + "%"));
            }

            // 주민등록번호 앞자리 조건 추가
            if (!string.IsNullOrEmpty(birth))
            {
                conditions.Add("pnumber LIKE @birth");
                parameters.Add(new MySqlParameter("@birth", birth + "%"));
            }

            // 아이디 조건 추가
            if (id > 0)
            {
                conditions.Add("id = @id");
                parameters.Add(new MySqlParameter("@id", id));
            }

            // 조건이 없으면 모든 데이터 반환
            if (conditions.Count == 0)
            {
                conditions.Add("1 = 1"); // 모든 데이터 반환
            }

            string query;
            // 테이블 조건 추가
            if (table == "drcard")
            {
                query = $"SELECT * FROM drcard WHERE " + string.Join(" AND ", conditions);
            }
            else if (table == "idcard")
            {
                query = $"SELECT * FROM idcard WHERE " + string.Join(" AND ", conditions);
            }
            else
            {
                query =
                    "SELECT i.id, i.pnumber, i.name, i.address, i.pdate, i.pimage, i.issuer, i.pnumber, i.idtype AS idtype, null AS dltype " +
                    "FROM idcard i WHERE " + string.Join(" AND ", conditions) + " " +
                    "UNION " +
                    "SELECT d.id, d.pnumber, d.name, d.address, d.ddate, d.dimage, d.dissuer, d.dnumber, d.dltype AS dltype, d.dtype " +
                    "FROM drcard d WHERE " + string.Join(" AND ", conditions) + " " +
                    "ORDER BY FIELD(id, 'idcard') DESC"; // idcard를 먼저 출력
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionAddress))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // 파라미터 추가
                    cmd.Parameters.AddRange(parameters.ToArray());

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
                // 복호화 처리 (menu.pass가 true일 때만)
                if (menu.pass) // 이 부분에서 menu.pass가 true일 때만 복호화
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["pnumber"] != DBNull.Value)
                        {
                            // 주민번호에서 하이픈 기준으로 분리
                            string[] parts = row["pnumber"].ToString().Split('-');
                            if (parts.Length > 1)
                            {
                                string backPart = parts[1]; // 주민번호 뒷자리 (암호화된 부분)

                                // 뒷자리 첫 번째 자리는 그대로 두고 나머지 부분만 복호화
                                string backFirstChar = backPart[0].ToString();  // 첫 번째 자리
                                string backEncryptedPart = backPart.Substring(1);  // 첫 번째 자리를 제외한 나머지 부분

                                // 나머지 부분 복호화
                                string decryptedBackPart = DecryptAES(backEncryptedPart);

                                // 복호화된 주민번호 구성 (앞 6자리 + 첫 번째 자리 + 복호화된 나머지 뒷자리)
                                row["pnumber"] = parts[0] + "-" + backFirstChar + decryptedBackPart;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Data retrieval failed: " + ex.Message);
            }

            return dataTable;
        }

    }
}
