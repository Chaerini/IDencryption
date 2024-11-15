using System;
using System.Windows.Forms;

namespace project2
{
    public partial class login : Form
    {
        // 로그인에 필요한 고정된(하드코딩) 아이디와 비밀번호
        private string validUsername = "pj2"; // 유효한 아이디
        private string validPassword = "241115"; // 유효한 비밀번호

        public login()
        {
            // 폼의 초기화
            InitializeComponent();
        }

        // 로그인 버튼 클릭 시 호출되는 메서드
        private void btn_login_Click(object sender, EventArgs e)
        {
            // 사용자가 입력한 아이디와 비밀번호 가져오기
            string username = txt_username.Text;
            string password = txt_password.Text;

            // 입력값과 유효한 아이디 & 비밀번호 비교
            if (username == validUsername && password == validPassword)
            {
                // 아이디와 비밀번호가 일치할 때
                MessageBox.Show("접속하셨습니다."); // 로그인 성공 후 메시지
                menu menu = new menu(); // Form2 인스턴스 생성
                menu.Show(); // Form2 화면 보여주기
                this.Hide(); // 현재 로그인 화면 (Form1) 숨기기 [Close 시 프로그램 종료 되므로 금지]
            }
            else
            {
                // 아이디 또는 비밀번호가 틀렸을 때
                MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다."); // 오류 메시지
            }
        }

        private void btn_faceid_Click(object sender, EventArgs e)
        {
            faceid faceid = new faceid();
            this.Hide();
            faceid.Show();
        }

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e); // 엔터 키가 눌리면 버튼 클릭 이벤트 호출
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e); // 엔터 키가 눌리면 버튼 클릭 이벤트 호출
            }
        }
    }
}