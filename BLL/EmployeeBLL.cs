using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAO _dao;
        private readonly PersonalProfileBLL personalProfileBLL;
        public EmployeeBLL()
        {
            _dao = new EmployeeDAO();
            personalProfileBLL = new PersonalProfileBLL();
        }

        public List<EmployeeDTO> GetAll() => _dao.getAll();

        public bool Insert(EmployeeDTO employeeDTO, string maTuyenDung, PositionDTO positionDTO)
        {
            return _dao.createEmployee(employeeDTO, maTuyenDung, positionDTO); ;
        }

        public bool InsertNoCandiDate(EmployeeDTO employeeDTO, PersonalProfileDTO personalProfileDTO, PositionDTO positionDTO)
        {
            return _dao.createEmployeeNoCandiDate(employeeDTO, personalProfileDTO, positionDTO);
        }

        public bool ImportExcelEmployees(List<EmployeeFullDTO> employees)
        {
            List<string> listcccd = new List<string>();
            foreach (EmployeeFullDTO employee in employees)
            {
                if(!personalProfileBLL.checkID(employee.SoCmnd))
                {        
                    MessageBox.Show("Căn cước công dân " + employee.SoCmnd + " đã tồn tại trong hồ sơ cá nhân. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return _dao.ImportEmployees(employees);
        }

        public bool Update(EmployeeDTO employeeDTO)
        {
            return _dao.updateEmployee(employeeDTO);
        }

        public bool UpdateChucVu(string maNV, string maChucvu)
        {
            return _dao.updateChucVu(maNV, maChucvu);
        }

        public bool Delete(string maNhanVien)
        {

            return _dao.deleteEmployee(maNhanVien);
        }

        public List<EmployeeDTO> SearchEmployee(string keyword)
        {

            return _dao.searchEmployee(keyword);
        }

        // Thêm method này để hỗ trợ form frmAccountCU (tìm nhân viên bằng mã tài khoản)
        public EmployeeDTO GetByAccountId(string maTaiKhoan)
        {
            if (string.IsNullOrWhiteSpace(maTaiKhoan))
            {
                throw new ArgumentException("Mã tài khoản không được để trống!");
            }

            // Phương thức này gọi xuống EmployeeDAO.GetByAccountId()
            // mà chúng ta đã thảo luận ở bước trước.
            // Nó không dùng cache 'list' vì đây là một truy vấn cụ thể, 
            // tương tự như SearchEmployee()
            return _dao.GetByAccountId(maTaiKhoan);
        }

        public EmployeeDTO GetEmp(string MaNhanVien)
        {
            return _dao.GetEmp(MaNhanVien);
        }
    }
}
