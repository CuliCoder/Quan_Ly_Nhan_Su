using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.ChamCongUserControl
{
    public partial class ucRequestCard : UserControl
    {
        public ucRequestCard()
        {
            InitializeComponent();
        }

        public void LoadData(YeuCauDTO request)
        {
            if (request == null) return;

            lblFullName.Text = request.TenNguoiGui;
            lblEmail.Text = $"<{request.EmailNguoiGui}>";

            // Format the date range
            string startDate = request.NgayBatDau?.ToString("dd/MM/yyyy HH:mm") ?? "N/A";
            string endDate = request.NgayKetThuc?.ToString("dd/MM/yyyy HH:mm") ?? "N/A";
            lblDateRange.Text = $"{startDate} - {endDate}";

            // You can set the picStatus image based on the request type or other properties
            // For example:
            // if (request.ThongTinYeuCau.Contains("nghỉ"))
            // {
            //     picStatus.Image = Properties.Resources.leave_icon;
            // }
        }
    }
}