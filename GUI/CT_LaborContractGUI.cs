using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.BLL;
using YourNamespace.DTO;

namespace Quan_Ly_Nhan_Su.GUI
{
    public partial class CT_LaborContractGUI : UserControl
    {
        private readonly LaborContractBLL _bll;
        private string _contractId;

        public CT_LaborContractGUI()
        {
            InitializeComponent();
            _bll = new LaborContractBLL();
            LoadContractDetails();
        }

        private void LoadContractDetails()
        {
            try
            {
                // Assuming _contractId is set from a selected contract (e.g., from ContractGUI)
                if (string.IsNullOrEmpty(_contractId)) return;

                LaborContractDTO contract = _bll.GetContractById(_contractId);
                if (contract != null)
                {
                    labelMaNhanVienValue.Text = contract.MaNhanVien;
                    labelHoTenValue.Text = contract.TenNhanVien;
                    labelPhongBanValue.Text = contract.PhongBan;
                    labelMaHopDongValue.Text = contract.MaHopDong;
                    labelNgayHetHanValue.Text = contract.DenNgay?.ToString("dd/MM/yyyy") ?? "";
                    labelLoaiHopDongValue.Text = contract.LoaiHopDong;
                    labelLuongValue.Text = contract.LuongCoBan.ToString("N0") + " VND";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hợp đồng: {ex.Message}");
            }
        }

        public void SetContractId(string contractId)
        {
            _contractId = contractId;
            LoadContractDetails();
        }

        private void buttonGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                string giaHanThem = textBoxGiaHanThem.Text.Trim();
                if (string.IsNullOrEmpty(giaHanThem))
                {
                    MessageBox.Show("Vui lòng nhập thời gian gia hạn!");
                    return;
                }

                if (_bll.ExtendContract(_contractId, giaHanThem))
                {
                    MessageBox.Show("Gia hạn hợp đồng thành công!");
                    LoadContractDetails();
                }
                else
                {
                    MessageBox.Show("Gia hạn hợp đồng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gia hạn hợp đồng: {ex.Message}");
            }
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            textBoxGiaHanThem.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxAvatar_Click(object sender, EventArgs e)
        {

        }
    }
}