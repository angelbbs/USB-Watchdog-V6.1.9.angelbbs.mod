using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IWshRuntimeLibrary
{
  [Guid("41904400-BE18-11D3-A28B-00104BD35090")]
  [TypeIdentifier]
  [CompilerGenerated]
  [ComImport]
  public interface IWshShell3 : IWshShell2
  {
    [SpecialName]
    void _VtblGap1_4();

    [DispId(1002)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object CreateShortcut([MarshalAs(UnmanagedType.BStr), In] string PathLink);
  }
}
