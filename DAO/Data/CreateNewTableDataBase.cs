using System;
using System.Data.Entity;
using System.Windows.Forms;
using Quan_Ly_Nhan_Su.DAO.Models;



namespace Quan_Ly_Nhan_Su.DAO.Data
{
    public class CreateNewTableDataBase : DbContext
    {
        public CreateNewTableDataBase() : base("name=TestDB")
        {

            Database.SetInitializer(new CreateDatabaseIfNotExists<CreateNewTableDataBase>());
        }
        public DbSet<PersonalProfileEntity> PersonalProfileEntities { get; set; }
        public DbSet<CandidateEntity> CandidateEntities { get; set; }
    }



    public static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var db = new CreateNewTableDataBase())
                {
                    db.Database.Initialize(force: true);
                    MessageBox.Show("Đã kết nối và tạo database thành công);");
                }
            }
            catch (Exception ex)
            {     
                MessageBox.Show("Lỗi tạo DB: " + ex.Message + "\n" + ex.InnerException?.Message);
            }
        }

    }
}
