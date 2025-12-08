using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.BLL
{
    public class SalaryIncreaseBLL
    {
        private readonly SalaryIncreaseDAO _dao;
        private readonly EvaluationBLL _evaluationBLL;
        private readonly EmployeeBLL _employeeBLL;
        private readonly SalaryBLL _salaryBLL;

        public SalaryIncreaseBLL()
        {
            _dao = new SalaryIncreaseDAO();
            _evaluationBLL = new EvaluationBLL();
            _employeeBLL = new EmployeeBLL();
            _salaryBLL = new SalaryBLL();
        }

        public List<SalaryIncreaseDTO> GetAll()
        {
            return _dao.GetAll();
        }

        public SalaryIncreaseDTO GetById(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        public bool Insert(SalaryIncreaseDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.MaNhanVien))
            {
                MessageBox.Show("Mã nhân viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var emp = _employeeBLL.GetEmp(dto.MaNhanVien);
            if (emp == null)
            {
                MessageBox.Show("Nhân viên không tồn tại: " + dto.MaNhanVien, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var salary = _salaryBLL.GetSalaryByEmployeeId(dto.MaNhanVien);
                if (salary != null)
                    dto.LuongHienTai = salary.LuongCoBan;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không lấy được lương hiện tại " + ex.Message);
            }

            int year = dto.NgayDuyet.HasValue ? dto.NgayDuyet.Value.Year : DateTime.Now.Year;

            try
            {
                double totalScore = _evaluationBLL.GetTotalEvaluationScore(dto.MaNhanVien, year);
                dto.DiemDanhGia = (float)totalScore;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không lấy được điểm đánh giá " + ex.Message);
                dto.DiemDanhGia = 0f;
            }

            if (!dto.LuongMoi.HasValue && dto.PhanTramTang.HasValue)
            {
                dto.LuongMoi = Math.Round(dto.LuongHienTai * (1 + dto.PhanTramTang.Value / 100m), 2);
            }

            return _dao.Insert(dto);
        }

        public bool Update(SalaryIncreaseDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.Id <= 0)
            {
                MessageBox.Show("Id không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(dto.MaNhanVien))
            {
                MessageBox.Show("Mã nhân viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var emp = _employeeBLL.GetEmp(dto.MaNhanVien);
            if (emp == null)
            {
                MessageBox.Show("Nhân viên không tồn tại: " + dto.MaNhanVien, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var salary = _salaryBLL.GetSalaryByEmployeeId(dto.MaNhanVien);
                if (salary != null)
                    dto.LuongHienTai = salary.LuongCoBan;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không lấy được lương hiện tại " + ex.Message);
            }

            int year = dto.NgayDuyet.HasValue ? dto.NgayDuyet.Value.Year : DateTime.Now.Year;

            try
            {
                double totalScore = _evaluationBLL.GetTotalEvaluationScore(dto.MaNhanVien, year);
                dto.DiemDanhGia = (float)totalScore;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không lấy được điểm đánh giá " + ex.Message);
                dto.DiemDanhGia = 0f;
            }

            if (dto.PhanTramTang.HasValue)
            {
                dto.LuongMoi = Math.Round(dto.LuongHienTai * (1 + dto.PhanTramTang.Value / 100m), 2);   
            }

            return _dao.Update(dto);
        }

        public bool Delete(int id)
        {
            if (id <= 0) throw new ArgumentException("Id phải lớn hơn 0.", nameof(id));
            return _dao.Delete(id);
        }

        public List<SalaryIncreaseDTO> Search(string keyword)
        {
            return _dao.Search(keyword ?? string.Empty);
        }
    }
}
