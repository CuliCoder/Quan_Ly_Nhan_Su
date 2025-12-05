using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    public static class GUIValidator
    {
        public static bool NotEmpty(TextBox tb, String message, ErrorProvider error)
        {
            if(string.IsNullOrEmpty(tb.Text))
            {
                error.SetError(tb, message);
                tb.Focus();
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool InPutKey(TextBox tb, string message, string key ,ErrorProvider error)
        {
            if (!tb.Text.Contains(key) || tb.Text.Length != 5)
            {
                error.SetError(tb, message);
                tb.Focus();
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool IsSelected(ComboBox cb, string message)
        {
            if(cb.SelectedIndex == -1)
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb.Focus();
                return false;
            }
            
            return true;
        }

        public static bool IsChecked(RadioButton rb1, RadioButton rb2, string message, ErrorProvider error)
        {
            if(!rb1.Checked && !rb2.Checked)
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool IsNumber(TextBox tb, string message, ErrorProvider error)
        {
            int number;
            if (!int.TryParse(tb.Text, out number))
            {
                error.SetError(tb, message);
                tb.Focus();
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool NotContainNumber(TextBox tb, string message, ErrorProvider error)
        {
            if(tb.Text.Any(char.IsDigit))
            {
                error.SetError(tb, message);
                tb.Focus();
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool IsOnlyNumberWithString(TextBox tb, string message, ErrorProvider error)
        {
            if (tb.Text.Any(char.IsLetter))
            {
                error.SetError(tb, message);
                tb.Focus();
                return false;
            }
            error.SetError(tb, "");
            return true;
        }


        public static bool IsGreaterThanNumber(TextBox tb, int number, string message, ErrorProvider error)
        {
            if (tb.Text.Length < number)
            {
                error.SetError(tb, message);
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool EqualNumber(TextBox tb, int number, string message, ErrorProvider error)
        {
            if (tb.Text.Length != number)
            {
                error.SetError(tb, message);
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool IsDecimal(TextBox tb, String message, ErrorProvider error)
        {
            decimal number;
            if(!decimal.TryParse(tb.Text, out number))
            {
                error.SetError(tb, message);
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool IsDate( TextBox tb, string message, ErrorProvider error)
        {
            DateTime date;
            if(!DateTime.TryParse(tb.Text, out date))
            {
                error.SetError(tb, message);
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool IsGreaterThanZero(TextBox tb, string message, ErrorProvider error)
        {
            decimal number = Convert.ToDecimal(tb.Text);
            if (number <= 0)
            {
                error.SetError(tb, message);
                return false;
            }
            error.SetError(tb, "");
            return true;
        }

        public static bool IsMatchRegex(TextBox tb, string pattern, string message, ErrorProvider error)
        {
            if(!Regex.IsMatch(tb.Text, pattern))
            {
                error.SetError(tb, message);
                tb.Focus();
                return false;
            }
            error.SetError(tb, "");
            return true;
        }
    }
}
