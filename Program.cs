using Quan_Ly_Nhan_Su.GUI.AuthControl;
using System;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.GUI;
using Quan_Ly_Nhan_Su.BLL;

namespace Quan_Ly_Nhan_Su
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                // 1. Hiện form login
                using (var login = new Login())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        // Người dùng nhấn Cancel → Thoát ứng dụng
                        return;
                    }
                }

                // 2. Nếu login thành công → chạy mainGUI
                using (var main = new mainGUI())
                {
                    var result = main.ShowDialog();

                    if (result != DialogResult.Retry)
                    {
                        // Không yêu cầu đăng nhập lại → Thoát app
                        return;
                    }
                }

                // 3. Nếu mainGUI trả về Retry → quay lại vòng lặp → mở login lần nữa
            }
        }
    }
}