using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;

namespace project2
{
    public partial class Form3 : Form
    {
        private List<string> names = new List<string>(); // 이름
        private List<string> pnumber = new List<string>(); // 주민등록번호
        private List<string> dltype = new List<string>(); // 면허 종류
        private List<string> idtype = new List<string>(); // 신분증 종류
        private List<string> address = new List<string>(); // 주소
        private List<string> id = new List<string>(); // 아이디

        private List<string> selectedCardTypes = new List<string>();

        private string selectedIDType = ""; // 저장된 신분증 종류
        private DatabaseManager _dbManager;

        // 라디오 버튼 인덱스 저장 변수
        private int selectedRowIndex = -1;

        public Form3()
        {
            InitializeComponent();
            // DatabaseManager 인스턴스 생성
            _dbManager = new DatabaseManager("localhost", 3306, "idcard", "root", "0000");
        }

        private void bt_condition_Click(object sender, EventArgs e)
        {
            pn_condition.Visible = true;


            checkedListBox1.SetItemChecked(0, false); // 0번 항목인 주민등록증 체크
            checkedListBox1.SetItemChecked(1, false); // 1번 항목인 운전면허증 체크
            checkedListBox2.SetItemChecked(0, false); // 0번 항목인 남성 체크
            checkedListBox2.SetItemChecked(1, false); // 1번 항목인 여성 체크

        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            pn_condition.Visible = false;

            // 체크된 항목이 저장됨 (주민등록증 또는 운전면허증)
            selectedCardTypes.Clear();  // 기존에 선택된 카드 타입 초기화

            selectedIDType = "";

            foreach (var item in checkedListBox1.CheckedItems)
            {
                selectedCardTypes.Add(item.ToString()); // 선택된 항목 추가

                // (추가)
                if (item.ToString() == "주민등록증")
                {
                    selectedIDType = "주민등록증";
                }
                else if (item.ToString() == "운전면허증")
                {
                    selectedIDType = "운전면허증";
                }
                else
                {
                    selectedIDType = "";
                }
            }

            // checkedListBox2에서 선택된 항목을 가져옴
            string selectedGender = null;

            if (checkedListBox2.GetItemChecked(0)) // 남성 선택됨
            {
                selectedGender = "남성";
            }
            else if (checkedListBox2.GetItemChecked(1)) // 여성 선택됨
            {
                selectedGender = "여성";
            }

            // 입력된 주소를 저장
            string addressInput = tb_address.Text;
        }

        private void ConfigureTableLayoutPanel()
        {
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.RowCount = 2; // 상단 제목 행 + 데이터 행들

            // 상단 제목 행 설정
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // 제목 행 높이 고정
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));      // 데이터 행 자동 조정

            if (selectedIDType == "주민등록증")
            {
                // 주민등록증 열 구성 (5개 열)
                string[] idCardColumns = { "√", "순서", "종류", "이름", "주민등록번호", "주소" };
                SetupColumns(idCardColumns);
            }
            else if (selectedIDType == "운전면허증")
            {
                // 운전면허증 열 구성 (6개 열)
                string[] driverLicenseColumns = { "√", "순서", "종류", "이름", "주민등록번호", "주소", "면허종류" };
                SetupColumns(driverLicenseColumns);
            }
            else
            {
                // 아무것도 선택하지 않았을 때 기본 열 구성 (6개 열)
                string[] defaultColumns = { "√", "순서", "종류", "이름", "주민등록번호", "주소", "면허종류" };
                SetupColumns(defaultColumns);
            }
        }

        private void SetupColumns(string[] columnNames)
        {
            // 테이블 레이아웃 패널 초기화
            tableLayoutPanel.Controls.Clear(); // 기존 컨트롤 삭제
            tableLayoutPanel.ColumnStyles.Clear(); // 기존 열 스타일 삭제

            // 열 너비를 고정 배열로 설정
            int[] columnWidths;

            if (columnNames.Length == 6) // 주민등록증 선택 시
            {
                columnWidths = new int[] { 45, 50, 110, 80, 160, 300 }; // 픽셀 단위로 설정
            }
            else if (columnNames.Length == 7) // 운전면허증 선택 시
            {
                columnWidths = new int[] { 45, 50, 100, 80, 140, 260, 90 }; // 픽셀 단위로 설정
            }
            else
            {
                // 기본 열 너비 (6개 열)
                columnWidths = new int[] { 45, 50, 100, 80, 140, 260, 90 }; // 픽셀 단위로 설정
            }

            tableLayoutPanel.ColumnCount = columnNames.Length;
            for (int i = 0; i < columnNames.Length; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, columnWidths[i]));

                // Label 생성하여 각 열 제목 추가
                Label label = new Label();
                label.Text = columnNames[i];
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = SystemColors.ControlLight; // 제목 배경색 설정
                label.Font = new Font(label.Font, FontStyle.Bold); // 굵게 설정하여 제목 강조
                label.BorderStyle = BorderStyle.FixedSingle; // 테두리 추가
                label.Margin = new Padding(0);
                label.Size = new Size(columnWidths[i], 30); // 각 열 너비에 맞게 설정

                // 상단 행(0번째)에 제목 추가
                tableLayoutPanel.Controls.Add(label, i, 0);
            }
        }

        // 검색 버튼 클릭 시 실행
        private void bt_search_Click(object sender, EventArgs e)
        {
            // 선택 버튼 초기화
            selectedRowIndex = -1;

            // 테이블 초기화
            ResetTableData();

            // 선택된 항목에 따라 열 구성
            ConfigureTableLayoutPanel();

            // 입력된 이름
            string searchName = tb_search.Text;

            // 성별 조건 확인 (남성 또는 여성)
            string selectedGender = null;
            if (checkedListBox2.GetItemChecked(0) && checkedListBox2.GetItemChecked(1)) // 남성과 여성 둘 다 선택됨
            {
                selectedGender = null; // 성별 조건을 무시
            }
            else if (checkedListBox2.GetItemChecked(0)) // 남성 선택됨
            {
                selectedGender = "남성";
            }
            else if (checkedListBox2.GetItemChecked(1)) // 여성 선택됨
            {
                selectedGender = "여성";
            }

            // 입력된 주소
            string searchAddress = tb_address.Text;

            // 데이터 베이스 연결 확인
            //_dbManager.TestDatabaseConnection();



            // 데이터 가져오기
            LoadDataFromDatabase();
        }

        // 데이터 초기화 (추가)
        private void ResetTableData()
        {
            tableLayoutPanel.Controls.Clear(); // 모든 컨트롤 삭제
            tableLayoutPanel.ColumnStyles.Clear(); // 열 스타일 초기화
            tableLayoutPanel.RowStyles.Clear(); // 행 스타일 초기화
        }

        // 데이터 가져오는 함수 (추가)
        private void LoadDataFromDatabase()
        {
            DataTable idCardData = new DataTable();

            // 조건에 맞는 데이터 로드
            if (cb_select.SelectedIndex == 1) // 이름으로 검색
            {
                if (!string.IsNullOrEmpty(tb_search.Text))
                {
                    idCardData = _dbManager.GetDataByConditions(name: tb_search.Text);
                }
            }
            else if (cb_select.SelectedIndex == 2) // 주민등록번호 첫 번째 6자리로 검색
            {
                if (tb_search.Text.Length >= 6)
                {
                    string searchPNumber = tb_search.Text.Substring(0, 6);
                    idCardData = _dbManager.GetDataByConditions(birth: searchPNumber);
                }
            }
            else
            {
                idCardData = _dbManager.GetDataByConditions(); // 모든 데이터
            }

            // 성별 조건 추가
            List<string> selectedGenders = new List<string>(); // 선택된 성별을 담을 리스트

            // checkedListBox2에서 선택된 항목을 selectedGenders 리스트에 추가
            if (checkedListBox2.GetItemChecked(0)) // 남성 선택됨
            {
                selectedGenders.Add("남성");
            }
            if (checkedListBox2.GetItemChecked(1)) // 여성 선택됨
            {
                selectedGenders.Add("여성");
            }
            // 성별 필터링이 있을 경우
            if (selectedGenders.Count > 0)
            {
                DataTable filteredData = idCardData.Clone(); // 원본 구조를 복제

                foreach (DataRow row in idCardData.Rows)
                {
                    string gender = row["pnumber"].ToString().Substring(7, 1);

                    if ((selectedGenders.Contains("남성") && (gender == "1" || gender == "3")) ||
                        (selectedGenders.Contains("여성") && (gender == "2" || gender == "4")))
                    {
                        filteredData.ImportRow(row);
                    }
                }

                idCardData = filteredData; // 성별 조건이 적용된 데이터로 덮어쓰기
            }
            // 주소 필터 추가 (tb_address에 입력된 값)
            string addressFilter = tb_address.Text;
            if (!string.IsNullOrEmpty(addressFilter))
            {
                DataTable filteredData = idCardData.Clone(); // 원본 구조를 복제

                foreach (DataRow row in idCardData.Rows)
                {
                    // 주소에 필터값이 포함된 경우만 추가
                    if (row["address"].ToString().Contains(addressFilter))
                    {
                        filteredData.ImportRow(row);
                    }
                }

                idCardData = filteredData; // 주소 필터가 적용된 데이터로 덮어쓰기
            }


            // selectedCardTypes에 맞는 데이터만 필터링
            if (selectedCardTypes.Count > 0)
            {
                DataTable filteredData = idCardData.Clone(); // 원본 구조를 복제

                foreach (DataRow row in idCardData.Rows)
                {
                    // 선택된 카드 타입에 맞는 데이터만 필터링
                    if (selectedCardTypes.Contains(row["idtype"].ToString()))
                    {
                        filteredData.ImportRow(row); // 조건에 맞는 행 추가
                    }
                }

                idCardData = filteredData; // 필터링된 데이터로 덮어쓰기
            }

            // 데이터 리스트 초기화
            names.Clear();
            pnumber.Clear();
            dltype.Clear();
            idtype.Clear();
            address.Clear();
            id.Clear();
            selectedCardTypes.Clear();
            selectedGenders.Clear();
            selectedRowIndex = -1;

            // 데이터를 리스트에 저장
            for (int i = 0; i < idCardData.Rows.Count; i++)
            {
                names.Add(idCardData.Rows[i]["name"].ToString());
                pnumber.Add(idCardData.Rows[i]["pnumber"].ToString());
                idtype.Add(idCardData.Rows[i]["idtype"].ToString());
                address.Add(idCardData.Rows[i]["address"].ToString());
                // 'dltype' 열이 존재하는지 체크하고, 존재하면 값을 추가, 없으면 빈 문자열 추가
                if (idCardData.Columns.Contains("dltype"))
                {
                    dltype.Add(idCardData.Rows[i]["dltype"] != DBNull.Value ? idCardData.Rows[i]["dltype"].ToString() : string.Empty);
                }
                else
                {
                    dltype.Add(string.Empty); // 열이 없으면 빈 문자열 추가
                }
                id.Add(idCardData.Rows[i]["id"].ToString());
            }

            // 각 데이터 행의 높이를 고정하기 위한 설정
            int rowHeight = 25; // 고정하고 싶은 높이 (예: 30px)

            // 데이터 행 수 설정
            int dataCount = names.Count;
            int totalRows = Math.Max(10, dataCount); // 10보다 적으면 빈 데이터 행 추가
            tableLayoutPanel.RowCount = totalRows + 1; // 1행은 제목을 위해 남김

            //tableLayoutPanel.Controls.Clear();
            //tableLayoutPanel.ColumnStyles.Clear();
            //tableLayoutPanel.RowStyles.Clear(); // 기존 RowStyle 초기화

            // 고정된 높이 설정
            for (int i = 0; i < totalRows + 1; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight)); // RowStyle 추가
            }

            // 고정된 높이 설정
            for (int i = 0; i < totalRows + 1; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight)); // RowStyle 추가
            }

            // TableLayoutPanel에 데이터 채우기
            for (int i = 0; i < totalRows; i++)
            {
                // 첫 번째 열에 라디오 버튼 추가
                // 라디오 버튼을 패널로 감싸 중앙 정렬 설정
                var panel = new Panel
                {
                    //Dock = DockStyle.Fill,
                    Margin = new Padding(0),
                    AutoSize = false,
                    Size = new Size(tableLayoutPanel.GetColumnWidths()[0], rowHeight), // 열 너비에 맞추고 높이 고정
                    Anchor = AnchorStyles.Top, // 부모 셀 크기에 영향을 받지 않도록 설정
                                               //BorderStyle = BorderStyle.FixedSingle,
                };

                var radioButton = new RadioButton
                {
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    Anchor = AnchorStyles.Top, // 패널 중앙에 위치하도록 설정
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(0, 5, 0, 0),
                    Size = new Size(tableLayoutPanel.GetColumnWidths()[0], rowHeight), // 열 너비에 맞추고 높이 고정
                    Visible = (i < dataCount ? true : false),
                };

                panel.Controls.Add(radioButton); // 라디오 버튼을 패널에 추가

                // 라디오 버튼 선택 시 실행될 이벤트 핸들러 추가
                radioButton.CheckedChanged += (sender, e) =>
                {
                    if (radioButton.Checked)
                    {
                        selectedRowIndex = tableLayoutPanel.GetRow(radioButton); // Tag에 저장된 인덱스를 가져와서 저장
                    }
                };

                // 라디오 버튼을 현재 데이터 행에 추가
                tableLayoutPanel.Controls.Add(radioButton, 0, i + 1); // i + 1로 데이터 행에 추가

                // 두 번째 열에 순서 추가
                var orderLabel = new Label
                {
                    Text = (i < dataCount ? (i + 1).ToString() : string.Empty), // 순서
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    //BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0),
                    Size = new Size(tableLayoutPanel.GetColumnWidths()[1], rowHeight), // 열 너비에 맞추고 높이 고정
                    AutoEllipsis = true,
                };
                tableLayoutPanel.Controls.Add(orderLabel, 1, i + 1); // 1열에 순서 추가

                // 네 번째 열에 신분증 종류 추가
                var idTypeLabel = new Label
                {
                    Text = (i < dataCount ? idtype[i] : string.Empty), // 데이터가 없으면 빈 값
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    //BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0),
                    Size = new Size(tableLayoutPanel.GetColumnWidths()[2], rowHeight), // 열 너비에 맞추고 높이 고정
                };
                tableLayoutPanel.Controls.Add(idTypeLabel, 2, i + 1); // 3열에 신분증 종류 추가

                // 세 번째 열에 이름 추가
                var nameLabel = new Label
                {
                    Text = (i < dataCount ? names[i] : string.Empty),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    //BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0),
                    Size = new Size(tableLayoutPanel.GetColumnWidths()[3], rowHeight), // 열 너비에 맞추고 높이 고정
                };
                tableLayoutPanel.Controls.Add(nameLabel, 3, i + 1); // 2열에 이름 추가

                // 다섯 번째 열에 주민등록번호 추가
                var idLabel = new Label
                {
                    Text = (i < dataCount ? pnumber[i] : string.Empty),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    //BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0),
                    Size = new Size(tableLayoutPanel.GetColumnWidths()[4], rowHeight), // 열 너비에 맞추고 높이 고정
                };
                tableLayoutPanel.Controls.Add(idLabel, 4, i + 1); // 5열에 주민등록번호 추가

                // 여섯 번째 열에 주소 추가
                var addressLabel = new Label
                {
                    Text = (i < dataCount ? address[i] : string.Empty),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    //BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0),
                    Size = new Size(tableLayoutPanel.GetColumnWidths()[5], rowHeight), // 열 너비에 맞추고 높이 고정
                    AutoEllipsis = true,
                };
                tableLayoutPanel.Controls.Add(addressLabel, 5, i + 1); // 4열에 주소 추가

                // 추가
                if (selectedIDType != "주민등록증")
                {
                    // 일곱 번째 열에 면허 종류 추가
                    var licenseTypeLabel = new Label
                    {
                        Text = (i < dataCount ? dltype[i] : string.Empty),
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        //BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(0),
                        Size = new Size(tableLayoutPanel.GetColumnWidths()[6], rowHeight), // 열 너비에 맞추고 높이 고정
                    };
                    tableLayoutPanel.Controls.Add(licenseTypeLabel, 6, i + 1); // 7열에 면허 종류 추가
                }



                // Row 추가 및 높이 고정
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight)); // RowStyle 추가
            }
            // 마지막 행 높이 고정 추가
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight)); // 마지막 행 높이 고정

            // 첫 번째 열의 너비을 30픽셀로 고정
            tableLayoutPanel.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 30);
            //tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            selectedIDType = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //cb_select.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        // 선택 버튼 눌렀을 때
        private void bt_choice_Click(object sender, EventArgs e)
        {
            // -1로 초기화한 후 아무것도 선택하지 않으면 index 에러 뜸
            // index 에러뜨면 메시지 박스
            try
            {
                if (string.Equals(idtype[selectedRowIndex - 1],"운전면허증", StringComparison.OrdinalIgnoreCase))
                {
                    DrCardDetail drCardDetail = new DrCardDetail(int.Parse((id[selectedRowIndex -1 ])));
                    drCardDetail.Show(); // 새 창으로 열기
                }
                else if (string.Equals(idtype[selectedRowIndex - 1], "주민등록증", StringComparison.OrdinalIgnoreCase))
                {
                    IdCardDetail idCardDetail = new IdCardDetail(int.Parse((id[selectedRowIndex -1 ])));
                    idCardDetail.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("선택해주세요.");
            }

        }
    }
}

