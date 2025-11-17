using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class AttendanceTotalOfMonthDTO
    {
        private float totalHours;
        private int goLate;
        private int leaveEarly;
        public AttendanceTotalOfMonthDTO(float totalHours, int goLate, int leaveEarly)
        {
            this.totalHours = totalHours;
            this.goLate = goLate;
            this.leaveEarly = leaveEarly;
        }
        public float TotalHours { get => totalHours; set => totalHours = value; }
        public int GoLate { get => goLate; set => goLate = value; }
        public int LeaveEarly { get => leaveEarly; set => leaveEarly = value; }
    }
}
