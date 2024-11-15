using Mytrans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class menu : Form
    {
        public static bool pass = false;
        public menu()
        {
            InitializeComponent();
            InitializeUI();
        }

        // 그룹 박스 숨김 및 가시화 이벤트 발생 메서드
        private void InitializeUI()
        {
            // GroupBox 초기 상태를 숨김
            gb_dbloading.Visible = false;
            rbtn_encrypt.Checked = false;
            rbtn_decrypt.Checked = false;
        }

        // 신분증 추출 버튼 클릭 이벤트
        private void btn_idext_Click(object sender, EventArgs e)
        {
            captureForm captureForm = new captureForm();
            captureForm.Show();
            this.Close();
        }

        // 데이터 불러오기 버튼 클릭 이벤트
        private void btn_dataload_Click(object sender, EventArgs e)
        {
            // 데이터 불러오기 버튼 클릭 시 GroupBox 보이기
            gb_dbloading.Visible = true;
        }

        private void rbtn_encrypt_CheckedChanged(object sender, EventArgs e)
        {
            // 암호화 라디오 버튼이 선택되면 암호화 폼 표시
            if (rbtn_encrypt.Checked)
            {
                pass = false;
                Form3 form3 = new Form3();
                form3.Show();
            }
        }

        private void rbtn_decrypt_CheckedChanged(object sender, EventArgs e)
        {
            // 복호화 라디오 버튼이 선택되면 복호화 폼 표시
            if (rbtn_decrypt.Checked)
            {
                pass = true;
                Form3 form3 = new Form3();
                form3.Show();
            }
        }

        // 암호화 폼(채린)으로 수정할 것 2
        private void ShowEncryptForm()
        {
            //EncryptForm encryptForm = new EncryptForm();
            // this hide 추가
            //encryptForm.ShowDialog();
            // this close 추가
        }

        // 복호화 폼(예진)으로 수정할 것 2
        private void ShowDecryptForm()
        {
            //DecryptForm decryptForm = new DecryptForm();
            // this hide 추가
            //decryptForm.ShowDialog();
            // this close 추가
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }
    }
}