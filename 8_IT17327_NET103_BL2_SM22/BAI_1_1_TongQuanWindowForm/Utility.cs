using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_TongQuanWindowForm
{
    internal class Utility
    {
        //Các phương thức tiện ích
        public static string ZenMaTuDong(string value)//nguyen ANH Dũng => Dungna
        {
            string temp = value.Trim().ToLower();//nguyen anh dũng
            string[] arrValues = temp.Split(' ');//Cắt chuỗi thành mảng
            string final = GetVietHoaChuCaiDau(arrValues[arrValues.Length - 1]).Trim();//Dũng
            for (int i = 0; i < arrValues.Length - 1; i++)
            {
                final += GetChuCaiDau(arrValues[i]);
            }
            return LoaiBoDauTiengViet(final);//Dungna
        }

        public static string VietHoaCaTen(string value)//nguyen ANH Dũng => Nguyễn Anh Dũng
        {
            string temp = value.Trim().ToLower();//nguyen anh dũng
            string[] arrValues = temp.Split(' ');//Cắt chuỗi thành mảng
            string final = "";
            for (int i = 0; i < arrValues.Length; i++)
            {
                final += GetVietHoaChuCaiDau(arrValues[i]);
            }
            return final;//Dungna
        }

        private static string GetChuCaiDau(string value)//nguyen
        {
            return Convert.ToString(value[0]);//n
        }

        private static string GetVietHoaChuCaiDau(string value)//nguyen
        {
            if (string.IsNullOrEmpty(value)) return "";
            return Convert.ToString(value[0]).ToUpper() + value.Substring(1) + " ";//N + guyen
        }

        private static string LoaiBoDauTiengViet(string str)
        {
            string strFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc =
                    System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
    }
}