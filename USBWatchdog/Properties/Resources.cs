using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace USBWatchdog.Properties
{
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager a;
    private static CultureInfo b;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) USBWatchdog.Properties.Resources.a, (object) null))
          USBWatchdog.Properties.Resources.a = new ResourceManager("USBWatchdog.Properties.Resources", typeof (USBWatchdog.Properties.Resources).Assembly);
        return USBWatchdog.Properties.Resources.a;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => USBWatchdog.Properties.Resources.b;
      set => USBWatchdog.Properties.Resources.b = value;
    }
  }
}
