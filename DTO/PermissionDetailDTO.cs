namespace Quan_Ly_Nhan_Su.DTO
{
    public class PermissionDetailDTO
    {
        public int PermissionGroupID { get; set; }
        public int FunctionID { get; set; }
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}