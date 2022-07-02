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
    public partial class FrmQLPhimAnh : Form
    {
        private QLPhimService _qlPhimService;
        Guid _idKhoaChinhCuaBanGhi;
        public FrmQLPhimAnh()
        {
            InitializeComponent();
            _qlPhimService = new QLPhimService();
            _qlPhimService.FakeData();//Đổ dữ liệu vào List
            LoadTheLoai();
            LoadPhim();
            rbtn_KoHoatDong.Checked = true;
        }

        private void LoadTheLoai()
        {
            foreach (var x in _qlPhimService.GetAllTheLoai())
            {
                cmb_TheLoai.Items.Add(x);
            }
            cmb_TheLoai.SelectedIndex = 0;
        }

        private void LoadPhim()
        {
            int stt = 1;
            //Đếm được số lượng thuộc tính trong  1 Class đối tượng
            Type type = typeof(PhimAnh);
            int SlThuocTinh = type.GetProperties().Length;//Đếm số lượng thuộc tính
            dgrid_Phim.ColumnCount = SlThuocTinh + 1;//Cộng 1 là vì muốn thêm 1 cột số thứ tự
            dgrid_Phim.Columns[0].Name = "STT";
            dgrid_Phim.Columns[1].Name = "Id";
            dgrid_Phim.Columns[2].Name = "Mã";
            dgrid_Phim.Columns[3].Name = "Tên";
            dgrid_Phim.Columns[4].Name = "Thể Loại";
            dgrid_Phim.Columns[5].Name = "Trạng Thái";
            dgrid_Phim.Rows.Clear();//Xóa trắng dataa mỗi lần load lại table

            foreach (var x in _qlPhimService.GetALL())
            {
                dgrid_Phim.Rows.Add(stt++, x.Id, x.MaPhim, x.TenPhim, x.TheLoaiPhim,
                    (x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"));
            }
            
        }

        private PhimAnh GetValueDataFromControl()
        {
            return new PhimAnh()
            {
                Id = Guid.Empty, MaPhim = txt_MaPhim.Text, TenPhim = txt_Ten.Text, TheLoaiPhim = cmb_TheLoai.Text,
                TrangThai = (rbtn_HoatDong.Checked == true ? 1 : 0)
            };
            //Trả về 1 đối tượng chứa dữ liệu được lấy từ trên các control ở giao diện
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_qlPhimService.Add(GetValueDataFromControl()));
            LoadPhim();
        }

        private void dgrid_Phim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1. Lấy được row index khi người dùng bấm
            int rowIndex = e.RowIndex;
            if (rowIndex == _qlPhimService.GetALL().Count) return;//Khi bấm vào dòng của grid nằm ngoài index của list hiện tại thì sẽ không làm chết chương trình
            //2. Lấy khóa chính trên Datagrid
            _idKhoaChinhCuaBanGhi = Guid.Parse(dgrid_Phim.Rows[rowIndex].Cells[1].Value.ToString());

            //3. tìm đối tượng theo id
            var DoiTuongTimThay = _qlPhimService.GetALL().FirstOrDefault(c => c.Id == _idKhoaChinhCuaBanGhi);
            //4. Fill data lên control
            txt_Ten.Text = DoiTuongTimThay.TenPhim;
            txt_MaPhim.Text = DoiTuongTimThay.MaPhim;
            cmb_TheLoai.SelectedItem = DoiTuongTimThay.TheLoaiPhim;
         
            if (DoiTuongTimThay.TrangThai == 1)
            {
                rbtn_HoatDong.Checked = true;
                return;
            }

            rbtn_KoHoatDong.Checked = true;

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            var temp = GetValueDataFromControl();
            temp.Id = _idKhoaChinhCuaBanGhi;
            MessageBox.Show(_qlPhimService.Update(temp));
            LoadPhim();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            var temp = new PhimAnh();
            temp.Id =_idKhoaChinhCuaBanGhi;
            MessageBox.Show(_qlPhimService.Delete(temp));
            LoadPhim();
        }
    }
}
