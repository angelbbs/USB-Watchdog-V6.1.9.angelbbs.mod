using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IWshRuntimeLibrary
{
  [CompilerGenerated]
  [DefaultMember("FullName")]
  [TypeIdentifier]
  [Guid("F935DC23-1CF0-11D0-ADB9-00C04FD58A0B")]
  [ComImport]
  public interface IWshShortcut
  {
    [SpecialName]
    void _VtblGap1_3();

    string Description { [DispId(1001)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(1001)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    [SpecialName]
    void _VtblGap2_2();

    string IconLocation { [DispId(1003)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(1003)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    [SpecialName]
    void _VtblGap3_1();

    string TargetPath { [DispId(1005)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(1005)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    int WindowStyle { [DispId(1006)] get; [DispId(1006)] [param: In] set; }

    string WorkingDirectory { [DispId(1007)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(1007)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    [SpecialName]
    void _VtblGap4_1();

    [DispId(2001)]
    void Save();
  }
}
