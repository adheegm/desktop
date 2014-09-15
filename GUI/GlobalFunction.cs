using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace GUI
{
    public static class GlobalFunction
    {
        public static Telerik.WinControls.UI.RadGridView gvSuratMasuk;
        public static void ExportExcelProcess(RadGridView _gv)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strFileName = saveFileDialog1.FileName;

                ExportToExcelML exporter = new ExportToExcelML(_gv);//RadGridView1)
                string fileName = strFileName;
                exporter.RunExport(fileName);
            }
        }

        public static string SqlCharChecker(string _string)
        {
            return check_Str(_string);
        }

        private static string check_Str(string _string)
        {
            return _string.Replace("'","''");
        }

        public static string NumberToRomawi(int _number)
        {
            int bil = _number;
            string str_bil = ""; ;
            while (bil >= 1000)
            {
                bil = bil - 1000;
                str_bil = str_bil + "M";
            }
            while (bil >= 500)
            {
                if (bil >= 900)
                {
                    bil = bil - 900;
                    str_bil = str_bil + "CM";
                }
                else
                {
                    bil = bil - 500;

                    str_bil = str_bil + "D";
                }

            }
            while (bil >= 100)
            {
                if (bil >= 400)
                {
                    bil = bil - 400;
                    str_bil =  str_bil + "CD";
                }
                else
                {

                    bil = bil - 100;
                    str_bil = str_bil + "C";
                }

            }
            while (bil >= 50)
            {
                if (bil >= 90)
                {
                    bil = bil - 90;
                    str_bil = str_bil + "CX";
                }
                else
                {
                    bil = bil - 50;
                    str_bil =  str_bil + "CL";
                }
            }
            while (bil >= 10)
            {
                if (bil >= 40)
                {
                    bil = bil - 40;
                    str_bil =  str_bil + "XL";
                }
                else
                {
                    bil = bil - 10;
                    str_bil = str_bil + "X";
                }
            }
            while (bil >= 5)
            {
                if (bil == 9)
                {
                    bil = bil - 9;
                    str_bil =  str_bil + "IX";
                }
                else
                {
                    bil = bil - 5;
                    str_bil =  str_bil + "V";
                }

            }
            while (bil >= 1)
            {
                if (bil == 4)
                {
                    bil = bil - 4;
                    str_bil =  str_bil + "IV";
                }
                else
                {
                    bil = bil - 1;
                    str_bil = str_bil +  "I";
                }
            }
            return str_bil;
        }
    }
}
