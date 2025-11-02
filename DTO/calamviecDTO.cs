using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DTO
{
    public class calamviecDTO
    {
        string name;
        TimeSpan startTime;
        TimeSpan endTime;
        public calamviecDTO( string name, TimeSpan startTime, TimeSpan endTime)
        {
            this.name = name;
            this.startTime = startTime;
            this.endTime = endTime;
        }
        public string Name { get => name; set => name = value; }
        public TimeSpan StartTime { get => startTime; set => startTime = value; }
        public TimeSpan EndTime { get => endTime; set => endTime = value; }

    }
}
