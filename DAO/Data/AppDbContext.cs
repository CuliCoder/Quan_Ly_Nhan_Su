using Quan_Ly_Nhan_Su.DAO.Models;
using System.Data.Entity;

namespace Quan_Ly_Nhan_Su.DAO.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=MyDB") { }

        public DbSet<PersonalProfileEntity> PersonalProfileEntities { get; set; }
        public DbSet<RecruitmentBatchEntity> RecruitmentBatchEntities { get; set; }
        public DbSet<CandidateEntity> CandidateEntities { get; set; }
    }
}
