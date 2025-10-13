using System;

namespace Quan_Ly_Nhan_Su.DTO
{
  /// <summary>
  /// DTO for Function table
  /// </summary>
  public class FunctionDTO
  {
    public int MaChucNang { get; set; }
    public string TenChucNang { get; set; }
    public string MoTa { get; set; }
    public bool TinhTrang { get; set; }
  }
}