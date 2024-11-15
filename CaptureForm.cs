using OpenCvSharp;
using Google.Cloud.Vision.V1;
using OpenCvSharp.Extensions;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using project2;
using MySql.Data.MySqlClient;
using System.Linq;
using ZXing;// QR 코드 생성 및 인식을 위한 ZXing 라이브러리
using ZXing.Common; // ZXing의 QR 코드 옵션 설정을 위한 네임스페이스
using System.Security.Cryptography;
namespace Mytrans
{
    public partial class captureForm : Form
    {
        private VideoCapture capture; // OpenCV VideoCapture 객체
        private Mat frame; // 프레임 저장을 위한 Mat 객체
        private Bitmap bitmap;
        private const string ApiKey = "AIzaSyBzlga2ex4JyhLz1QKQtRpkq-AkmMGL9YY"; // Google Vision API 키
        private const string FaceApiKey = "8kA6rSfGh7ATUOVA5gBOImVTQ67O4TRgTb2qG67865lcG4rpiUVTJQQJ99AKACNns7RXJ3w3AAAKACOGbfXL"; // Microsoft Face API Key
        private const string FaceApiEndpoint = "https://facetrue.cognitiveservices.azure.com/face/v1.0/detect"; // Microsoft Face API Endpoint
        string extractedAddress = "";
        private static readonly string encryptionKey = "yourEncryptionKeyHereThatIs32BytesLong!"; // // 32바이트 키를 사용

        public captureForm()
        {
            InitializeComponent();
            InitializeCamera(); // 카메라 초기화
        }

        // 카메라 초기화 메서드
        private void InitializeCamera()
        {
            capture = new VideoCapture(0); // 첫 번째 카메라 장치 사용

            // 카메라가 제대로 열렸는지 확인
            if (!capture.IsOpened())
            {
                MessageBox.Show("카메라 장치를 열 수 없습니다. 카메라가 연결되어 있는지 확인하세요.");
                return; // 카메라를 열 수 없으면 초기화를 중지
            }

            capture.FrameWidth = 640;  // 가로 해상도 설정
            capture.FrameHeight = 480; // 세로 해상도 설정
            frame = new Mat();

            // 타이머를 사용하여 주기적으로 프레임을 가져옵니다.
            Timer timer = new Timer();
            timer.Interval = 30; // 30ms마다 실행 (약 33FPS)
            timer.Tick += new EventHandler(ProcessFrame);
            timer.Start();
        }

        /// 프레임 처리 메서드
        private void ProcessFrame(object sender, EventArgs e)
        {
            capture.Read(frame); // 프레임을 읽어옵니다.
            if (!frame.Empty())
            {
                bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame); // Mat을 Bitmap으로 변환
                pictureBox1.Image = bitmap; // PictureBox에 이미지 설정
            }
        }

        // 사진 촬영 버튼 클릭 이벤트 핸들러
        private void captureButten_Click(object sender, EventArgs e)
        {
            try
            {
                if (bitmap != null)
                {
                    string fileName = "capture.jpg";
                    string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName); // 저장 위치 변경

                    // 이미지 저장 시 형식을 명시적으로 지정
                    bitmap.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                    MessageBox.Show($"사진이 저장되었습니다: {fullPath}");
                }
                else
                {
                    MessageBox.Show("이미지가 캡처되지 않았습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사진 저장 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 텍스트 추출 버튼 클릭 이벤트 핸들러
        private async void btn_text_Click(object sender, EventArgs e)
        {
            try
            {
                if (bitmap != null)
                {
                    // 사용자 폴더에 저장 경로 지정
                    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "capture.jpg");

                    // 이미지 저장 시 형식 명시
                    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // 이미지에서 텍스트 추출
                    string text = await ExtractTextFromImage(filePath);
                    textBox1.Text = text; // 추출된 텍스트를 textBox1에 표시
                    MessageBox.Show($"텍스트가 추출 되었습니다: {filePath}");
                }
                else
                {
                    MessageBox.Show("이미지가 캡처되지 않았습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }

        private async Task<string> ExtractTextFromImage(string imagePath)
        {
            var client = new HttpClient();
            string apiUrl = $"https://vision.googleapis.com/v1/images:annotate?key={ApiKey}";

            var requestBody = new
            {
                requests = new[]
                {
            new
            {
                image = new
                {
                    content = Convert.ToBase64String(File.ReadAllBytes(imagePath))
                },
                features = new[]
                {
                    new { type = "TEXT_DETECTION" }
                }
            }
        }
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var response = await client.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                // 텍스트 추출
                string extractedText = result.responses[0].fullTextAnnotation.text;

                // 텍스트를 \n으로 줄 단위로 나누기
                string formattedText = FormatTextWithNewLines(result.responses[0].fullTextAnnotation);

                return formattedText;
            }
            else
            {
                throw new Exception("API 요청 실패: " + response.ReasonPhrase);
            }
        }

        private string FormatTextWithNewLines(dynamic fullTextAnnotation)
        {
            var formattedText = new StringBuilder();

            // 문서의 각 페이지에서 텍스트를 추출합니다.
            if (fullTextAnnotation.pages != null)
            {
                foreach (var page in fullTextAnnotation.pages)
                {
                    // 각 페이지에서 문단을 처리합니다.
                    if (page.blocks != null)
                    {
                        foreach (var block in page.blocks)
                        {
                            // 각 블록에서 텍스트를 처리합니다.
                            if (block.paragraphs != null)
                            {
                                foreach (var paragraph in block.paragraphs)
                                {
                                    // 각 문장에서 텍스트를 처리합니다.
                                    if (paragraph.words != null)
                                    {
                                        foreach (var word in paragraph.words)
                                        {
                                            if (word.symbols != null)
                                            {
                                                foreach (var symbol in word.symbols)
                                                {
                                                    formattedText.Append(symbol.text);  // 단어의 각 문자 추가
                                                }
                                            }
                                        }
                                    }
                                    formattedText.AppendLine(); // 문단 끝에 줄 바꿈 추가
                                }
                            }
                        }
                    }
                }
            }
            return formattedText.ToString();
        }

        // 폼이 닫힐 때 호출되는 메서드
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            capture?.Release(); // 카메라 릴리즈
            base.OnFormClosing(e);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=idcard;Uid=root;Pwd=0000;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string[] lines = textBox1.Lines
                                    .Select(line => line.Trim()) // 공백 제거
                                    .Where(line => !string.IsNullOrEmpty(line)) // 공백인 라인은 제외
                                    .ToArray();

                    

                    // dtype이 숫자인지 확인하여 저장할 테이블을 선택
                    string query;
                    MySqlCommand cmd;

                    string type = lines.Length > 0 ? lines[0] : "";

                    if (string.Equals(type, "주민등록증", StringComparison.OrdinalIgnoreCase))
                    {
                        if (lines.Length < 7)
                        {
                            MessageBox.Show("주어진 데이터가 부족합니다. 7개의 항목이 모두 필요합니다.");
                            return;
                        }

                        string idtype = lines.Length > 0 ? lines[0] : "";     // 주민등록증
                        string idname = lines.Length > 1 ? lines[1] : "";     // 이름
                        string idnumber = lines.Length > 2 ? lines[2] : "";   // 주민등록번호
                        string idaddress = lines.Length > 3 ? lines[3] + (lines.Length > 4 ? " " + lines[4] : "") : "";  // 주소
                        string iddate = lines.Length > 5 ? lines[5] : "";     // 발급일
                        string idissuer = lines.Length > 6 ? lines[6] : "";   // 발급기관

                        // 주민번호 암호화
                        string encryptedPNumber2 = ProcessResidentNumber(idnumber);

                        // SQL 쿼리문 준비
                        query = "INSERT INTO idcard (idtype, name, pnumber, address, pdate, issuer, pimage) " +
                                "VALUES (@idtype, @name, @pnumber, @address, @pdate, @issuer, @pimage)";

                        // MySQLCommand 객체 준비
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@idtype", idtype);
                        cmd.Parameters.AddWithValue("@name", idname);
                        cmd.Parameters.AddWithValue("@pnumber", encryptedPNumber2);
                        cmd.Parameters.AddWithValue("@address", idaddress);
                        cmd.Parameters.AddWithValue("@pdate", iddate);
                        cmd.Parameters.AddWithValue("@issuer", idissuer);
                        cmd.Parameters.AddWithValue("@pimage", extractedAddress);  // dimage -> pimage 변경
                    }
                    else
                    {

                        string dtype = lines.Length > 0 ? lines[0] : "";
                        string dltype = lines.Length > 1 ? lines[1] : "";
                        string dnumber = lines.Length > 2 ? lines[2] : "";
                        string name = lines.Length > 3 ? lines[3] : "";
                        string pnumber = lines.Length > 4 ? lines[4] : "";
                        string address = lines.Length > 5 ? lines[5] + (lines.Length > 6 ? lines[6] : "") : "";
                        string pdate = lines.Length > 6 ? lines.Length > 6 ? lines[7] : "" : "";  // pdate로 변경
                        string issuer = lines.Length > 7 ? lines[8] : ""; // issuer로 변경

                        string encryptedPNumber1 = ProcessResidentNumber(pnumber);

                        query = "INSERT INTO drcard (dtype, dltype, dnumber, name, pnumber, address, ddate, dissuer, dimage) " +
                                "VALUES (@dtype, @dltype, @dnumber, @name, @pnumber, @address, @ddate, @dissuer, @dimage)";

                        dltype = "운전면허증";

                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@dtype", dtype);
                        cmd.Parameters.AddWithValue("@dltype", dltype);
                        cmd.Parameters.AddWithValue("@dnumber", dnumber);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@pnumber", encryptedPNumber1);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@ddate", pdate);  // pdate로 변경
                        cmd.Parameters.AddWithValue("@dissuer", issuer);  // issuer로 변경
                        cmd.Parameters.AddWithValue("@dimage", extractedAddress);  // dimage에 저장할 이미지 경로
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("데이터가 성공적으로 저장되었습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"데이터베이스 저장 오류: {ex.Message}\n\nStackTrace: {ex.StackTrace}\n\n예외 타입: {ex.GetType()}");
                }
            }
        }

        public static string EncryptAES(string plainText)
        {
            // 암호화 키를 32바이트로 맞추기 (32바이트 키 사용)
            string encryptionKey = "yourEncryptionKeyHereThatIs32BytesLong!";  // 이 키는 반드시 32바이트여야 합니다.
            encryptionKey = encryptionKey.Substring(0, 32);  // 만약 길이가 32보다 크면 잘라내기

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);  // 암호화 키 설정 (16, 24, 32 바이트)
                aesAlg.IV = new byte[16];  // IV는 16 바이트로 설정 (기본 제로 초기화)

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);  // 텍스트 암호화
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());  // 암호화된 데이터를 Base64로 인코딩하여 리턴
                }
            }
        }

        private string ProcessResidentNumber(string residentNumber)
        {
            // 공백 제거
            residentNumber = residentNumber.Trim();

            // 하이픈이 하나만 있는지 확인
            if (residentNumber.Count(c => c == '-') != 1)
            {
                throw new Exception("잘못된 주민번호 형식입니다. 하이픈이 정확히 하나여야 합니다.");
            }

            // 주민번호를 - 기준으로 분리합니다.
            var parts = residentNumber.Split('-');
            if (parts.Length != 2)
            {
                throw new Exception("잘못된 주민번호 형식입니다.");
            }

            // 앞 6자리 (변경하지 않음)
            string frontPart = parts[0];

            // 뒷 7자리 (암호화)
            string backPart = parts[1];

            // 뒷자리 첫 번째 자리는 그대로 두고 나머지 자리는 암호화 처리
            string backFirstChar = backPart[0].ToString();  // 첫 번째 자리
            string backPartToEncrypt = backPart.Substring(1);  // 첫 번째 자리를 제외한 나머지 부분

            // 나머지 뒷자리를 암호화
            string encryptedBackPart = EncryptAES(backPartToEncrypt);

            // 암호화된 주민번호 구성
            return frontPart + "-" + backFirstChar + encryptedBackPart;  // 앞 6자리 + 첫 번째 자리 + 암호화된 나머지 뒷자리
        }

        private async void btn_face_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "capture.jpg");
                bitmap.Save(filePath); // 이미지를 파일로 저장

                try
                {
                    // Face API를 사용하여 얼굴을 인식하고 분석
                    var faces = await DetectFaces(filePath); // 비동기 호출

                    if (faces.Count > 0)
                    {
                        // 얼굴이 인식되었으면, 얼굴만 잘라서 PictureBox에 표시
                        foreach (var face in faces)
                        {
                            // 얼굴 정보를 추출하여 저장 및 표시
                            SaveFaceImage(filePath, face.FaceRectangle);


                            // 주소 정보가 MessageBox로 출력됩니다.
                            MessageBox.Show($"추출된 주소: {extractedAddress}");

                            // 여기에 extractedAddress에 저장된 값을 MySQL에 저장할 수 있습니다.
                            // 예: textBox1.Text에 추출된 주소를 표시하거나 다른 작업을 할 수 있습니다.
                        }
                    }
                    else
                    {
                        MessageBox.Show("얼굴을 인식하지 못했습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"얼굴 인식 중 오류 발생: {ex.Message}");
                }
            }
        }

        private async Task<List<DetectedFace>> DetectFaces(string imagePath)
        {
            var client = new HttpClient();
            string apiUrl = $"{FaceApiEndpoint}";  // 최소화된 요청 URL

            // 헤더에 API 키 추가
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", FaceApiKey);

            // 이미지 파일을 읽어 Base64로 변환
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            var byteContent = new ByteArrayContent(imageBytes);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            // API 호출
            var response = await client.PostAsync(apiUrl, byteContent);
            if (response.IsSuccessStatusCode)
            {
                // 여기 강조해주세요.
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var faces = JsonConvert.DeserializeObject<List<DetectedFace>>(jsonResponse); // 얼굴 데이터 리스트로 반환
                // 여기 강조해주세요.
                return faces;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Face API 요청 실패: {response.ReasonPhrase}\n{errorMessage}");
            }
        }

        private void SaveFaceImage(string imagePath, FaceRectangle faceRectangle)
        {
            try
            {
                // 원본 이미지를 로드
                Bitmap originalImage = new Bitmap(imagePath);

                // 얼굴 영역을 추출 (잘라내기)
                Rectangle faceArea = new Rectangle(faceRectangle.Left, faceRectangle.Top, faceRectangle.Width, faceRectangle.Height);
                Bitmap faceImage = originalImage.Clone(faceArea, originalImage.PixelFormat);

                // 얼굴 이미지를 저장할 경로 설정
                string faceImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"face_{DateTime.Now:yyyyMMdd_HHmmss}.jpg");

                // 얼굴 이미지를 파일로 저장
                faceImage.Save(faceImagePath);

                extractedAddress = faceImagePath;

                // 얼굴 이미지를 face_pic PictureBox에 표시
                this.Invoke(new Action(() =>
                {
                    // face_pic은 PictureBox의 이름
                    face_pic.Image = faceImage; // 얼굴 이미지를 PictureBox에 설정
                }));

                MessageBox.Show($"얼굴 이미지가 저장되었습니다: {faceImagePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"얼굴 이미지를 저장하는 중 오류 발생: {ex.Message}");
            }
        }

        public class DetectedFace
        {
            public string FaceId { get; set; }
            public FaceRectangle FaceRectangle { get; set; }  // 얼굴 위치 정보만 포함
        }

        public class FaceRectangle
        {
            public int Top { get; set; }
            public int Left { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            face_pic.Image = null;
        }

        private void btn_QR_Click(object sender, EventArgs e)
        {
            // 텍스트 박스에서 QR 코드로 변환할 데이터를 가져옴
            string qrData = textBox1.Text;

            // 입력한 데이터가 비어있지 않은지 확인
            if (!string.IsNullOrEmpty(qrData))
            {
                // QRCodeEncodingOptions 객체를 생성하여 QR 코드를 작성
                var barcodeWriter = new BarcodeWriterPixelData
                {
                    Format = BarcodeFormat.QR_CODE, // QR 코드 형식으로 설정
                    Options = new ZXing.QrCode.QrCodeEncodingOptions
                    {
                        Width = 150,  // 생성할 QR 코드 이미지의 너비 설정
                        Height = 150, // 생성할 QR 코드 이미지의 높이 설정
                        Margin = 1,
                        CharacterSet = "UTF-8" // UTF-8로 설정하여 한글 지원
                    }
                };

                // 입력한 데이터(qrData)를 기반으로 QR 코드 이미지를 PixelData 형식으로 생성
                var pixelData = barcodeWriter.Write(qrData);

                // PixelData를 Bitmap 이미지로 변환
                using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat);

                    try
                    {
                        // PixelData.Pixels 배열을 Bitmap에 복사하여 이미지 데이터로 변환
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        // 이미지 데이터 복사가 끝나면 비트맵 잠금을 해제
                        bitmap.UnlockBits(bitmapData);
                    }

                    // 생성한 QR 코드 이미지를 PictureBox에 표시
                    face_pic.Image = new Bitmap(bitmap);

                    // 애플리케이션의 실행 디렉토리 경로를 가져옴 (이렇게 하면 파일 경로 수정 필요 없음)
                    string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

                    // QR 코드 이미지 파일명 생성 (날짜와 시간을 기반으로 고유한 파일명 생성)
                    string fileName = "QRCode_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

                    // 전체 경로 구성 (현재 디렉토리에 저장)
                    string filePath = System.IO.Path.Combine(directoryPath, fileName);

                    // Bitmap을 파일로 저장
                    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                    // 저장 완료 메시지 출력
                    MessageBox.Show("QR 코드 이미지가 저장되었습니다: " + filePath);
                }
            }
            else
            {
                MessageBox.Show("QR 코드에 포함할 데이터를 입력해주세요.");
            }
        }
    }
}