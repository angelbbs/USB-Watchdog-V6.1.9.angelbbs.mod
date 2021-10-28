using System;
using System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets.Assembly)]
[ComVisible(false)]
public sealed class DotfuscatorAttribute : Attribute
{
  private string a;
  private int c;

  public DotfuscatorAttribute(string a, int c)
  {
    DotfuscatorAttribute dotfuscatorAttribute = this;
    // ISSUE: explicit constructor call
    //dotfuscatorAttribute.\u002Ector();
   // dotfuscatorAttribute.a = a;
   // this.c = c;
  }

  public string A => this.a;

  //public string a() => this.a;

  public int C => this.c;

 // public int c() => this.c;
}
