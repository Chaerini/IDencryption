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
    public partial class DrCardDetail : Form
    {
        private int id;
        private DatabaseManager _dbManager;
        //public DrCardDetail()
        //{
        //    InitializeComponent();
        //}

        public DrCardDetail(int id)
        {
            InitializeComponent();
            this.id = id;
            _dbManager = new DatabaseManager("localhost", 3306, "idcard", "root", "0000");
        }

            // X 버튼 클릭했을 때
            private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 폼이 로드 됐을 때
        private void DrCardDetail_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
            }
            if (_dbManager == null)
            {
                MessageBox.Show("_dbManager is not initialized");
                return;
            }

            // id 에 해당하는 데이터 가져오기
            DataTable data = _dbManager.GetDataByConditions(table: "drcard", id: id);

            

            if (data != null && data.Rows.Count > 0)
            {
                lb_dnumber.Text = data.Rows[0]["dnumber"].ToString();
                lb_name.Text = data.Rows[0]["name"].ToString();
                lb_pnumber.Text = data.Rows[0]["pnumber"].ToString();
                lb_address.Text = data.Rows[0]["address"].ToString();
                lb_dissuer.Text = data.Rows[0]["dissuer"].ToString();
                lb_dltype.Text = data.Rows[0]["dltype"].ToString();
                lb_ddate.Text = data.Rows[0]["ddate"].ToString();
                pb_dimage.ImageLocation = data.Rows[0]["dimage"].ToString();
                pb_dimage2.ImageLocation = data.Rows[0]["dimage"].ToString();
            } 
            else
            {
                MessageBox.Show("데이터를 찾을 수 없습니다.");
                this.Close();
            }
        }
    }
}
