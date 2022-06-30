using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_1_TongQuanWindowForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_HienThi.Text = "Chào các bạn đến với C#3";
            LoadNamSinh();
            LoadData();
        }

        private void LoadData()
        {
            Phim phim = new Phim();
            //Cách 1:
            //dgrid_Phim.DataSource = phim.GetLstPhim();

            //Cách 2: Dùng DataTable
            DataTable dt = new DataTable();
            //Tạo cột và kiểu dữ liệu của cột đó
            dt.Columns.Add("Stt", typeof(int));
            dt.Columns.Add("Tên Phim", typeof(string));
            dt.Columns.Add("Thể Loại Phim", typeof(string));
            dt.Columns.Add("Trạng Thái", typeof(string));

            //Fill data
            int stt = 1;
            foreach (var x in phim.GetLstPhim())
            {
                dt.Rows.Add(stt++, x.TenPhim, x.TheLoaiPhim, (x.TrangThai ==1?"Hoạt động":"Không hoạt động"));
            }
            //Gán lại cho Datagridview
            //dgrid_Phim.DataSource = dt;

            //Cách 3: Làm việc trực tiếp với DatagridView
            //Định nghĩa số lượng cột
            dgrid_Phim.ColumnCount = 4;
            dgrid_Phim.Columns[0].Name = "Stt";
            dgrid_Phim.Columns[1].Name = "Tên phim";
            dgrid_Phim.Columns[2].Name = "Tên thể loại";
            dgrid_Phim.Columns[3].Name = "Trạng thái";
            int stt1 = 1;
            foreach (var x in phim.GetLstPhim())
            {
                dgrid_Phim.Rows.Add(stt1++, x.TenPhim, x.TheLoaiPhim, (x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"));
            }

        }

        private void LoadNamSinh()
        {
            for (int i = 1600; i < 2023; i++)
            {
                cmb_NamSinh.Items.Add(i);
            }

            cmb_NamSinh.SelectedIndex = 0;//Gán giá trị mặc định khi hiển thị cho combobox
        }

        private void btn_ClickVaoDay_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_HienThi.Text = "MouseDown....";
        }

        private void btn_ClickVaoDay_MouseUp(object sender, MouseEventArgs e)
        {
            lbl_HienThi.Text = "MouseUp....";
        }

        private void btn_ClickVaoDay_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Chào bạn {txt_Name.Text} đến với FPOLY");
        }
    }
}
