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
            mainGUI mainGUI = new mainGUI();
            Application.Run(mainGUI);
        }
    }
}
