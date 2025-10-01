using Quan_Ly_Nhan_Su.BUS;
using Quan_Ly_Nhan_Su.GUI.AuthControl;
using System;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.GUI;

namespace Quan_Ly_Nhan_Su
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // AUTOMATICALLY CREATE DEV ACCOUNT IF IT DOESN'T EXIST
            // ===========================================
            AccountBUS accountBUS = new AccountBUS();
            accountBUS.EnsureDevAccountExists();
            // ===========================================

            Login loginForm = new Login();
            DialogResult result = loginForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Application.Run(new mainGUI());
            }
        }
    }
}