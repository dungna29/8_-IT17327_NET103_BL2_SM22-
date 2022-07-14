using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_2_ADO
{
    public partial class Form1 : Form
    {
        //1. Tạo 1 tài khoản SQL
        //Connection String: Data Source=DUNGNAPC\SQLEXPRESS;Initial Catalog=FINAL_ASSIGNMENT_JAVA3_DUNGNA29_V2;Persist Security Info=True;User ID=dungna33;Password=123456

        private string _strConnection = @"Data Source=DUNGNAPC\SQLEXPRESS;Initial Catalog=FINALASS_FPTShop_SP22_BL2_DUNGNA29;Persist Security Info=True;User ID=dungna33;Password=123456";
        private SqlConnection _conn;
        private SqlCommand _cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_KetNoi_Click(object sender, EventArgs e)
        {
            //1. Khởi tạo kết nối vào SQL
            _conn = new SqlConnection(_strConnection);
            //2. Mở kết nối
            _conn.Open();
            //3. Thực hiện 1 hành động nào đó
            //4. Triển khai 1 câu query
            _cmd = new SqlCommand("SELECT * FROM CHUCVU", _conn);
            //5. Thực thi câu lệnh và đổ dữ liệu về SqlDataAdapter
            SqlDataAdapter dataAdapter = new SqlDataAdapter(_cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);//Đổ dữ liệu vào DataTable
            dataGridView1.DataSource = dt;

            //6. Sau khi thực hiện xong hành động thì phải đóng kết nối
            _conn.Close();
        }
    }
}