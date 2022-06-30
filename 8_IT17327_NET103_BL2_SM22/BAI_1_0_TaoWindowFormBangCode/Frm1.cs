using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//Thư viện

namespace BAI_1_0_TaoWindowFormBangCode
{
    internal class Frm1:Form
    {
        //Khai báo lớp đối tượng Control
        private Label lblName;
        private Button btnOk;
        public Frm1()
        {
            //Phần 1: Cáu hình form
            this.Text = "Tên form";
            this.Size = new Size(800, 600);

            //Phần 2: Add các control vào trong form
            lblName = new Label();
            lblName.Text = "Giá trị của Label";
            lblName.Location = new Point(100, 200);
            this.Controls.Add(lblName);

            btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Width = 200;
            btnOk.Height = 100;
            btnOk.Location = new Point(150, 250);
            this.Controls.Add(btnOk);
        }

        public static void Main(string[] arg)
        {
            Application.Run(new Frm1());
        }
    }
}
