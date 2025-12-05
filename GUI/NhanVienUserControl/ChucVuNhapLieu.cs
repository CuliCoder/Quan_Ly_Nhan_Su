using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI.NhanVienUserControl
{
    public partial class ChucVuNhapLieu : Form
    {
        private readonly PositionBLL positionBLL;
        public event EventHandler luuThongTinForm;
        private readonly ErrorProvider errorProvider;
        private PositionDTO positionDTO;
        private string HanhDong;
        public ChucVuNhapLieu(PositionDTO position, string hanhDong)
        {
            InitializeComponent();  
            positionBLL = new PositionBLL();
            HanhDong = hanhDong;

            if (position != null && HanhDong.Equals("Sua"))            
            {
                positionDTO = position;          
                btnXoa.Enabled = false;
                fillDataToTextBox(positionDTO);              
            }
                
            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
           
        }
        public Label LbHanhDong { get => lbHanhDong; set => lbHanhDong = value; }

        private void fillDataToTextBox(PositionDTO position)
        {
            if (position == null)
                return;
            maChucVuTb.Text = position.MaChucVu;
            maChucVuTb.Enabled = false;
            tenChucVuTb.Text = position.TenChucVu;
            phuCapChucVuTb.Text = position.PhuCapChucVu.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            maChucVuTb.Text = "";
            tenChucVuTb.Text = "";
            phuCapChucVuTb.Text = "";
        }

        private bool ValidateInputs()
        {
            //Ma chu vu
            if (!GUIValidator.NotEmpty(maChucVuTb, "Mã chức vụ không được để trống!", errorProvider))
                return false;
            if (!GUIValidator.InPutKey(maChucVuTb, "Mã chức vụ phải là CV0 và 5 chữ số", "CV0", errorProvider))
                return false;
            //Ten chu vu

            if(!GUIValidator.NotEmpty(tenChucVuTb, "Tên chức vụ không được để trống!", errorProvider))
                return false;
            if(!GUIValidator.NotContainNumber(tenChucVuTb, "Tên chức vụ không được chứa số!", errorProvider))
                return false;

            //Phu cap chu vu
            if(!GUIValidator.NotEmpty(phuCapChucVuTb, "Phụ cấp chức vụ không được để trống!", errorProvider))
                return false;
            if(!GUIValidator.IsDecimal(phuCapChucVuTb, "Phụ cấp chức vụ phải là số", errorProvider))
                return false;

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
               if(HanhDong.Equals("Them"))
               {
                    PositionDTO position = new PositionDTO
                    {
                        MaChucVu = maChucVuTb.Text.Trim(),
                        TenChucVu = tenChucVuTb.Text.Trim(),
                        PhuCapChucVu = decimal.TryParse(phuCapChucVuTb.Text.Trim(), out decimal phuCap) ? phuCap : 0
                    };
                    if (positionBLL.Insert(position))
                    {
                        luuThongTinForm?.Invoke(this, EventArgs.Empty);
                    this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thông tin chức vụ thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }            ;
               }else if (HanhDong.Equals("Sua")) 
               {
                    PositionDTO position = new PositionDTO
                    {
                        MaChucVu = maChucVuTb.Text.Trim(),
                        TenChucVu = tenChucVuTb.Text.Trim(),
                        PhuCapChucVu = decimal.TryParse(phuCapChucVuTb.Text.Trim(), out decimal phuCap) ? phuCap : 0
                    };
                    if (positionBLL.Update(position))
                    {
                        luuThongTinForm?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thông tin chức vụ thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
