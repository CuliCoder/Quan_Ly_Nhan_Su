using MySql.Data.MySqlClient;
using Quan_Ly_Nhan_Su.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.GUI;

namespace Quan_Ly_Nhan_Su
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("test");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tạo một Form chứa UserControl
            Form hostForm = new Form();
            hostForm.Text = "Chạy UserControl";
            hostForm.Size = new System.Drawing.Size(1200, 700);

            // Thay ContractGUI bằng UserControl bạn muốn chạy
            ContractGUI contractGUI = new ContractGUI();
            contractGUI.Dock = DockStyle.Fill;
            hostForm.Controls.Add(contractGUI);

            Application.Run(hostForm);
        }
    }
}
