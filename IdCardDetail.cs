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
    public partial class IdCardDetail : Form
    {
        private int id;
        private DatabaseManager _dbManager;

        public IdCardDetail()
        {
            InitializeComponent();
        }

        public IdCardDetail(int id)
        {
            InitializeComponent();
            this.id = id;
            _dbManager = new DatabaseManager("localhost", 3306, "idcard", "root", "0000");
        }

        // X 버튼 눌렀을 때
        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IdCardDetail_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
            } else
            {
                MessageBox.Show("아이디 없음");
                return;
            }

            // id 에 해당하는 데이터 가져오기
            DataTable data = _dbManager.GetDataByConditions(table: "idcard", id: id);



            if (data != null && data.Rows.Count > 0)
            {
                lb_name.Text = data.Rows[0]["name"].ToString();
                lb_pnumber.Text = data.Rows[0]["pnumber"].ToString();
                lb_address.Text = data.Rows[0]["address"].ToString();
                lb_issuer.Text = data.Rows[0]["issuer"].ToString();
                lb_pdate.Text = data.Rows[0]["pdate"].ToString();
                pb_pimage.ImageLocation = data.Rows[0]["pimage"].ToString();
            }
            else
            {
                MessageBox.Show("데이터를 찾을 수 없습니다.");
                this.Close();
            }
        }
    }
    }

