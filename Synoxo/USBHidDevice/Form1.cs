using IWshRuntimeLibrary;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Synoxo.USBHidDevice
{
    public class Form1 : Form
    {
        private const byte _a = 255;
        private const byte _b = 238;
        private const byte _c = 128;
        private const byte _d = 144;
        private DeviceManagement _e = new DeviceManagement();
        private byte[] _f = new byte[2]
        {
      byte.MaxValue,
      (byte) 85
        };
        private byte[] _g = new byte[2] { (byte)85, (byte)85 };
        private byte[] _h = new byte[2] { (byte)24, (byte)0 };
        private byte[] _i = new byte[2] { (byte)128, (byte)0 };
        private bool _j;
        private bool _k;
        private bool _l = true;
        private bool _m = true;
        private bool _n = true;
        private bool _o;
        private bool _p;
        private bool _q = true;
        private bool _r;
        private bool _s;
        private byte _t;
        private byte _u;
        private byte _v;
        private byte _w;
        private byte _x;
        private byte _y = 3;
        private byte _z;
        private byte aa;
        private byte ab;
        private byte ac;
        private int ad = 100;
        private int ae = 100;
        private int af = 100;
        private byte ag;
        private byte ah;
        private byte ai = 2;
        private SerialPort aj = new SerialPort();
        private StringBuilder ak = new StringBuilder();
        private long al;
        private string[] am;
        private IContainer an;
        private System.Windows.Forms.Timer _mainTimer;
        private CheckBox ap;
        private TextBox aq;
        private Label ar;
        private Label @as;
        private Label at;
        private TextBox au;
        private HScrollBar av;
        private Label aw;
        private TextBox ax;
        private HScrollBar ay;
        private GroupBox az;
        private Button a0;
        private Button a1;
        private Button a2;
        private Button a3;
        private TextBox a4;
        private Label a5;
        private Label a6;
        private Label a7;
        private Label a8;
        private Label a9;
        private Label ba;
        private GroupBox bb;
        private Label bc;
        private Label bd;
        private Button be;
        private TextBox bf;
        private Label bg;
        private ComboBox bh;
        private Label bi;
        private Label bj;
        private ComboBox bk;
        private CheckBox bl;
        private Label bm;

        public Form1() => this.a();

        private void n()
        {
            try
            {
                this._e.WhenUsbEvent += new DeviceManagement.usbEventsHandler(this.a);
            }
            catch (Exception ex)
            {
                this.a4.AppendText(ex.Message + "\r\n");
            }
            try
            {
                /*
                if (this.CheckUSBWatchdog())
                {
                    this._s = true;
                    this.ai = (byte)6;
                    this.a4.AppendText("Find Serial Device\r\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("Find Serial Device\r\n");
                    byte[] inputDatas = new byte[16];
                    //this.a4.AppendText("** 1\r\n");
                    this._e.WriteReportToDevice(0, this._i);
                    //this.a4.AppendText("** 2\r\n");
                    this._e.ReadReportFromDevice(0, ref inputDatas, 2000);
                    //this.a4.AppendText("** 3\r\n");
                    if (inputDatas[0] > (byte)128)
                    {
                        //this.a4.AppendText("** 4\r\n");
                        this.ai = Convert.ToByte((int)inputDatas[0] - (int)sbyte.MaxValue);
                    }
                    this._r = true;
                    if (this.ai != (byte)3)
                    {
                        //this.a4.AppendText("** 5\r\n");
                        this.bi.Visible = false;
                        this.bj.Visible = false;
                        this.bk.Visible = false;
                        this.bh.Visible = false;
                    }
                    this.f();
                    this.ao.Enabled = true;
                }
                */
                if (this.CheckUSBWatchdog())
                {
                    this._s = true;
                    this.bi.Visible = false;
                    this.bj.Visible = false;
                    this.bk.Visible = false;
                    this.bh.Visible = false;
                    this.ai = (byte)7;
                    this._r = true;
                    this.f();
                    this.a4.AppendText("Find USB Device\r\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("Find USB HID Device\r\n");
                    _mainTimer.Enabled = true;
                }
                else
                {
                    this._s = true;

                    this.ai = (byte)6;
                    this.a4.AppendText("Find Serial Device\r\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("Find Serial Device\r\n");
                    byte[] inputDatas = new byte[16];
                    //this.a4.AppendText("** 1\r\n");
                    this._e.WriteReportToDevice(0, this._i);
                    //this.a4.AppendText("** 2\r\n");
                    this._e.ReadReportFromDevice(0, ref inputDatas, 2000);
                    //this.a4.AppendText("** 3\r\n");
                    if (inputDatas[0] > (byte)128)
                    {
                        //this.a4.AppendText("** 4\r\n");
                        this.ai = Convert.ToByte((int)inputDatas[0] - (int)sbyte.MaxValue);
                    }
                    this._r = true;
                    if (this.ai != (byte)3)
                    {
                        //this.a4.AppendText("** 5\r\n");
                        this.bi.Visible = false;
                        this.bj.Visible = false;
                        this.bk.Visible = false;
                        this.bh.Visible = false;
                    }
                    this.f();
                    _mainTimer.Enabled = true;
                    Thread.Sleep(1000);
                    this.Open_Com();
                }
            }
            catch (Exception ex)
            {
                this.a4.AppendText(ex.Message + "\r\n");
                throw;
            }
        }

        public static bool Delay(int delayTime)
        {
            DateTime now = DateTime.Now;
            int seconds;
            do
            {
                seconds = (DateTime.Now - now).Seconds;
                Application.DoEvents();
            }
            while (seconds < delayTime);
            return true;
        }

        private void a(object A_0, USBEventArgs A_1)
        {
            switch (A_1.Status)
            {
                case USBDeviceStateEnum.Put_In:
                    this.a4.AppendText("--Insert\r\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("--Insert\r\n");
                    break;
                case USBDeviceStateEnum.Put_Out:
                    this.a4.AppendText("--Pull out\r\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("--Pull out\r\n");
                    break;
            }
            int deviceCount = this._e.DeviceCount;
        }

        private bool CheckUSBWatchdog()
        {
            int myVendorID = 0x5131;
            int myProductID = 0x2007;
            /*
            try
            {
                int num1 = 20785;
                int num2 = 8199;
                myVendorID = num1;
                myProductID = num2;
            }
            catch (SystemException ex)
            {
                this.a4.AppendText(ex.Message + "\r\n");
            }
            */
            a4.AppendText("Found USB WatchDog: " + _e.findHidDevices(ref myVendorID, ref myProductID) + "\r\n");
            return this._e.findHidDevices(ref myVendorID, ref myProductID);
        }

        private bool findHidDevices()
        {
            //int myVendorID = 1155;
            int myVendorID = 0x5131;
            //int myProductID = 22352;
            int myProductID = 0x2007;
            /*
            try
            {
                int num1 = 0x5131;
                int num2 = 0x2007;
                myVendorID = num1;
                myProductID = num2;
            }
            catch (SystemException ex)
            {
                this.a4.AppendText(ex.Message + "\r\n");
            }
            */
            return this._e.findHidDevices(ref myVendorID, ref myProductID);
        }

        public static bool Download(string uri, string savePath)
        {
            string str = uri.IndexOf("\\") <= -1 ? uri.Substring(uri.LastIndexOf("/") + 1) : uri.Substring(uri.LastIndexOf("\\") + 1);
            if (!savePath.EndsWith("/") && !savePath.EndsWith("\\"))
                savePath += "/";
            savePath += str;
            WebClient webClient = new WebClient();
            try
            {
                webClient.DownloadFile(uri, savePath);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void WriteByteToUSB(byte[] outdatas) => this._e.WriteReportToDevice(0, outdatas);

        public void ReadTextlog()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "RunLog.txt";
            try
            {
                System.IO.File.ReadAllLines(path);
            }
            catch
            {
                this.a4.AppendText("Unable to read the run log file, the watchdog continued to run！\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("Unable to read the run log file, the watchdog continued to run！\n");
                this.b("\n");
            }
        }

        public void Read()
        {
            byte num = 0;
            string path = AppDomain.CurrentDomain.BaseDirectory + "config.inf";
            try
            {
                string[] strArray = System.IO.File.ReadAllLines(path);
                if (strArray[0][7] == '=')
                {
                    if (strArray[0][10] == ';')
                        this.ay.Value = (int)Convert.ToByte(strArray[0][8]) - 48;
                    if (strArray[0][11] == ';')
                        this.ay.Value = ((int)Convert.ToByte(strArray[0][8]) - 48) * 10 + (int)Convert.ToByte(strArray[0][9]) - 48;
                    if (strArray[0][12] == ';')
                        this.ay.Value = ((int)Convert.ToByte(strArray[0][8]) - 48) * 100 + ((int)Convert.ToByte(strArray[0][9]) - 48) * 10 + (int)Convert.ToByte(strArray[0][10]) - 48;
                }
                this.ax.Text = (this.ay.Value * 10).ToString();
                if (strArray[1][16] == '=')
                {
                    if (strArray[1][17] == 'N')
                    {
                        this.av.Value = 0;
                        this.au.Text = "No";
                    }
                    else
                    {
                        if (strArray[1][18] == ';')
                            this.av.Value = (int)Convert.ToByte(strArray[1][17]) - 48;
                        if (strArray[1][19] == ';')
                            this.av.Value = ((int)Convert.ToByte(strArray[1][17]) - 48) * 10 + (int)Convert.ToByte(strArray[1][18]) - 48;
                        this.au.Text = this.av.Value.ToString();
                    }
                }
                if (strArray[2][11] == '=')
                {
                    if (strArray[2][12] == ';')
                    {
                        this.a2.Text = "Open";
                        this._j = false;
                    }
                    else
                    {
                        this.a2.Text = "Close";
                        this._j = true;
                    }
                }
                if (strArray[3][7] == '=')
                {
                    num = (byte)0;
                    while (num < (byte)30 && strArray[3][8 + (int)num] != ';')
                        ++num;
                }
                this.bf.Text = strArray[3].Substring(8, (int)num);
                if (strArray[4][16] == '=')
                {
                    if (strArray[4][17] == '1')
                        this.ap.Checked = true;
                    if (strArray[4][17] == '0')
                        this.ap.Checked = false;
                }
                if (strArray[5][10] == '=')
                {
                    if (strArray[5][12] == ';')
                        this.bh.Text = strArray[5][11].ToString();
                    if (strArray[5][13] == ';')
                        this.bh.Text = strArray[5][11].ToString() + strArray[5][12].ToString();
                }
                if (strArray[6][10] == '=')
                {
                    if (strArray[6][12] == ';')
                        this.bk.Text = strArray[6][11].ToString();
                    if (strArray[6][13] == ';')
                        this.bk.Text = strArray[6][11].ToString() + strArray[6][12].ToString();
                }
                if (strArray[7][8] == '=')
                {
                    num = (byte)0;
                    while (num < (byte)30 && strArray[7][9 + (int)num] != ';')
                        ++num;
                }
                this.aq.Text = strArray[7].Substring(9, (int)num);
                if (strArray[8][12] == '=')
                {
                    if (strArray[8][13] == ';')
                    {
                        this.be.Text = "Open";
                        this._k = false;
                    }
                    else
                    {
                        this.be.Text = "Close";
                        this._k = true;
                    }
                }
                if (strArray[9][11] != '=')
                    return;
                if (strArray[9][12] == '1')
                    this.bl.Checked = true;
                else
                    this.bl.Checked = false;
            }
            catch
            {
                //Form1.Download("http://sy.haicode123.com/USBwatchdog_update/config.inf", Environment.CurrentDirectory);
            }
        }

        public void Write()
        {
            string path = Environment.CurrentDirectory + "\\config.inf";
            string[] contents = new string[11]
            {
        "timeout=80;//超时复位时间，只能为10的整数，范围10-1270秒",
        "TimedRestartDays=3;//定时自动重启天数",
        "CheckOnline=;//1监控联网，没有不监控",
        "AppName=右键>属性>快捷方式>目标-把名称复制到这里;//被监控的程序名称",
        "VideoCardMonitor=0;//是否监控掉显卡，0不监控，1监控",
        "TimingBoot=;//定时开机时间范围0-23",
        "TimingShut=;//定时关机时间范围0-23",
        "HttpName=http://www.google.com;//被监控的链接域名，如http://www.google.com",
        "CheckProgram=;//1监控程序，没有不监控",
        "CheckUpdate=1;//1自动升级，没有不自动升级",
        "请不要手动修改数据！"
            };
            string str1 = contents[0].Substring(0, 8) + this.ax.Text + contents[0].Substring(10, 29);
            contents[0] = str1;
            string str2 = contents[1].Substring(0, 17) + this.au.Text + contents[1].Substring(18, 11);
            contents[1] = str2;
            string str3 = contents[2].Substring(0, 12);
            string str4 = !(this.a2.Text == "Open") ? str3 + (object)'1' + contents[2].Substring(12, 14) : str3 + contents[2].Substring(12, 14);
            contents[2] = str4;
            string str5 = contents[3].Substring(0, 8);
            byte num1 = 0;
            while (num1 < (byte)30 && contents[3][8 + (int)num1] != ';')
                ++num1;
            string str6 = str5 + this.bf.Text + contents[3].Substring(8 + (int)num1, 11);
            contents[3] = str6;
            string str7 = contents[4].Substring(0, 17);
            string str8 = !this.ap.Checked ? str7 + (object)'0' + contents[4].Substring(18, 19) : str7 + (object)'1' + contents[4].Substring(18, 19);
            contents[4] = str8;
            string str9 = contents[5].Substring(0, 11);
            string str10 = this.bh.Text != null ? str9 + this.bh.Text + contents[5].Substring(11, 15) : str9 + contents[5].Substring(11, 15);
            contents[5] = str10;
            string str11 = contents[6].Substring(0, 11);
            string str12 = this.bk.Text != null ? str11 + this.bk.Text + contents[6].Substring(11, 15) : str11 + contents[6].Substring(11, 15);
            contents[6] = str12;
            byte num2 = 0;
            while (num2 < (byte)30 && contents[7][9 + (int)num2] != ';')
                ++num2;
            string str13 = contents[7].Substring(0, 9) + this.aq.Text + contents[7].Substring(9 + (int)num2, 34);
            contents[7] = str13;
            string str14 = contents[8].Substring(0, 13);
            string str15 = !(this.be.Text == "Open") ? str14 + (object)'1' + contents[8].Substring(13, 14) : str14 + contents[8].Substring(13, 14);
            contents[8] = str15;
            string str16 = contents[9].Substring(0, 12);
            string str17 = this.bl.Checked ? str16 + (object)'1' + contents[9].Substring(13, 16) : str16 + (object)'0' + contents[9].Substring(13, 16);
            contents[9] = str17;
            System.IO.File.WriteAllLines(path, contents, Encoding.UTF8);
        }

        private string k()
        {
            try
            {
                string empty = string.Empty;
                foreach (ManagementObject instance in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    if ((bool)instance["IPEnabled"])
                    {
                        empty = instance["MacAddress"].ToString();
                        if (this.ad > 23)
                            this.ad = new Random(Convert.ToInt32(empty[9].ToString() + empty[10].ToString(), 16)).Next(1, 23);
                        if (this.ae > 59)
                            this.ae = new Random(Convert.ToInt32(empty[12].ToString() + empty[13].ToString(), 16)).Next(0, 59);
                        this.af = new Random(Convert.ToInt32(empty[15].ToString() + empty[16].ToString(), 16)).Next(0, 59);
                    }
                }
                return empty;
            }
            catch
            {
                return "unknown";
            }
        }

        private string j()
        {
            string str1;
            try
            {
                WebRequest webRequest = WebRequest.Create("");
                webRequest.Timeout = 0;
                Stream responseStream = webRequest.GetResponse().GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.Default);
                str1 = new Regex("((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|[1-9])", RegexOptions.None).Match(streamReader.ReadToEnd()).Groups[0].Value;
                responseStream.Close();
                streamReader.Close();
            }
            catch
            {
                return (string)null;
            }
            int startIndex = str1.IndexOf(".") + 1;
            int num = str1.IndexOf(".", startIndex) + 1;
            int index = str1.IndexOf(".", num) + 1;
            string str2 = "";
            if (index - num == 2)
                str2 = str1[num].ToString();
            else if (index - num == 3)
                str2 = str1[num].ToString() + str1[num + 1].ToString();
            else if (index - num == 4)
                str2 = str1[num].ToString() + str1[num + 1].ToString() + str1[num + 2].ToString();
            this.ad = new Random(Convert.ToInt32(str2, 16)).Next(1, 23);
            int length = str1.Length;
            if (length - index == 1)
                str2 = str1[index].ToString();
            else if (length - index == 2)
                str2 = str1[index].ToString() + str1[index + 1].ToString();
            else if (length - index == 3)
                str2 = str1[index].ToString() + str1[index + 1].ToString() + str1[index + 2].ToString();
            this.ae = new Random(Convert.ToInt32(str2, 16)).Next(1, 23);
            return str1;
        }

        public void WriteWorkState(char temp)
        {
            string path = Environment.CurrentDirectory + "\\WorkState.inf";
            string[] contents = new string[3]
            {
        "WorkState=0;//0正常,1本地，2服务器",
        "Countflag=0;//0没有发1已经发",
        "Please do not manually modify the data!！"
            };
            string str = contents[1].Substring(0, 10) + (object)temp + contents[1].Substring(11, 11);
            contents[1] = str;
            System.IO.File.WriteAllLines(path, contents, Encoding.UTF8);
        }

        public void ReadWorkState()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "WorkState.inf";
            if (System.IO.File.Exists(path))
            {
                string[] strArray = System.IO.File.ReadAllLines(path);
                try
                {
                    if (strArray[0][10] == '1')
                    {
                        this.a4.AppendText("Open the local XML error, the watchdog continues to run!\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("Open the local XML error, the watchdog continues to run!\n");
                    }
                    if (strArray[0][10] == '2')
                    {
                        this.a4.AppendText("Open the server XML error, the watchdog continues to run!\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("Open the server XML error, the watchdog continues to run!\n");
                    }
                }
                catch
                {
                    this.a4.AppendText("Unable to load workstate parameters, the watchdog continued to run！\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("Unable to load workstate parameters, the watchdog continued to run！\n");
                    this.b("\n");
                }
                try
                {
                    if (strArray[1][10] == '1' && DateTime.Now.Hour <= this.ad && (DateTime.Now.Minute <= this.ae && DateTime.Now.Second <= this.af))
                    {
                        this.WriteWorkState('0');
                    }
                    else
                    {
                        if (strArray[1][10] != '0' || DateTime.Now.Hour <= this.ad && (DateTime.Now.Hour != this.ad || DateTime.Now.Minute <= this.ae) && (DateTime.Now.Hour != this.ad || DateTime.Now.Minute != this.ae || DateTime.Now.Second <= this.af))
                            return;
                        this.f();
                        this.WriteWorkState('1');
                    }
                }
                catch
                {
                    // Form1.Download("http://sy.haicode123.com/USBwatchdog_update/WorkState.inf", Environment.CurrentDirectory);
                }
            }
            else
            {


                // Form1.Download("http://sy.haicode123.com/USBwatchdog_update/WorkState.inf", Environment.CurrentDirectory);
            }
        }

        private void b(string A_0)
        {
            using (StreamWriter streamWriter = new StreamWriter(Environment.CurrentDirectory + "\\RunLog.txt", true, Encoding.Default))
            {
                streamWriter.Flush();
                streamWriter.WriteLine(A_0);
                streamWriter.Close();
            }
        }

        private void i()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.StandardInput.WriteLine("shutdown -r -t 0");
        }

        public void Shutdown() => Process.Start("shutdown", "/s /t 0");

        public void Open_Com()
        {
            this.am = SerialPort.GetPortNames();
            Array.Sort<string>(this.am);
            this.aj.NewLine = "\r\n";
            this.aj.RtsEnable = true;
            this.aj.DataReceived += new SerialDataReceivedEventHandler(this.a);
            try
            {
                this.aj.PortName = !(this.am[0] != "COM1") ? this.am[1] : this.am[0];
                this.aj.BaudRate = 9600;
                this.aj.Parity = Parity.None;
                this.aj.StopBits = StopBits.One;
                this.aj.Open();
                if (this.aj.IsOpen)
                {
                    this.a((byte)128);
                    _mainTimer.Enabled = true;
                }
                else
                {
                    if (this.ah != (byte)0)
                        return;
                    this.a4.AppendText("Watchdog connection error, please ensure that the driver is installed.!\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("Watchdog connection error, please ensure that the driver is installed.!\n");
                    this.b("\n");
                }
            }
            catch
            {
            }
        }

        public static bool Create(
          string directory,
          string shortcutName,
          string targetPath,
          string description = null,
          string iconLocation = null)
        {
            /*
      try
      {

        if (!Directory.Exists(directory))
          Directory.CreateDirectory(directory);
        string PathLink = Path.Combine(directory, string.Format("{0}.lnk", (object) shortcutName));
        // ISSUE: variable of a compiler-generated type
        WshShell instance = (WshShell) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
        // ISSUE: reference to a compiler-generated field
        if (Form1.a.a == null)
        {
          // ISSUE: reference to a compiler-generated field
          Form1.a.a = CallSite<Func<CallSite, object, IWshShortcut>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (IWshShortcut), typeof (Form1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        IWshShortcut wshShortcut = Form1.a.a.Target((CallSite) Form1.a.a, instance.CreateShortcut(PathLink));
        wshShortcut.TargetPath = targetPath;
        wshShortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
        wshShortcut.WindowStyle = 1;
        wshShortcut.Description = description;
        wshShortcut.IconLocation = string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation;
        // ISSUE: reference to a compiler-generated method
        wshShortcut.Save();
        return true;
      }
      catch
      {
      }
            */
            return false;
        }

        private void a(object A_0, SerialDataReceivedEventArgs A_1)
        {
            if (!this.aj.IsOpen)
                return;
            int bytesToRead = this.aj.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            this.al += (long)bytesToRead;
            this.aj.Read(buffer, 0, bytesToRead);
            if (this.ah == (byte)1)
            {
                this.ah = (byte)0;
                this.a4.AppendText("Watchdog reconnect！\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("Watchdog reconnect！\n");
                this.b("\n");
            }
            switch (bytesToRead)
            {
                case 1:
                    if (buffer[0] == (byte)129)
                    {
                        this.bi.Visible = false;
                        this.bj.Visible = false;
                        this.bk.Visible = false;
                        this.bh.Visible = false;
                        this._s = true;
                        this.ag = (byte)0;
                        this.a4.AppendText("The watchdog has been connected," + this.am[0] + "\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("The watchdog has been connected," + this.am[0] + "\n");
                        this.b("\n");
                        this.ai = (byte)2;
                        this._r = false;
                        break;
                    }
                    if (buffer[0] == (byte)130 && !this._s)
                    {
                        this._q = true;
                        this._s = true;
                        this.ag = (byte)0;
                        this.a4.AppendText("The watchdog has been connected," + this.am[0] + "\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("The watchdog has been connected," + this.am[0] + "\n");
                        this.b("\n");
                        this._r = false;
                        this.ai = (byte)3;
                        break;
                    }
                    if (buffer[0] == (byte)240)
                    {
                        this._o = true;
                        break;
                    }
                    if ((int)buffer[0] == (int)this.ac && buffer[0] >= (byte)144 && buffer[0] < (byte)168)
                    {
                        if (!this._q)
                            break;
                        this.a4.AppendText("Received time：" + ((int)this.ac - 144).ToString() + "Time to shut down and turn off\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("Received time：" + ((int)this.ac - 144).ToString() + "H，Time to shut down and turn off\n");
                        this.b("\n");
                        this.Shutdown();
                        break;
                    }
                    this.ag = (byte)0;
                    break;
                case 2:
                    if (buffer[1] == (byte)129)
                    {
                        this.bi.Visible = false;
                        this.bj.Visible = false;
                        this.bk.Visible = false;
                        this.bh.Visible = false;
                        this._s = true;
                        this.ag = (byte)0;
                        this.a4.AppendText("The watchdog has been connected," + this.am[0] + "\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("The watchdog has been connected," + this.am[0] + "\n");
                        this.b("\n");
                        this.ai = (byte)2;
                        this._r = false;
                        break;
                    }
                    if (buffer[1] == (byte)130 && !this._s)
                    {
                        this._q = true;
                        this._s = true;
                        this.ag = (byte)0;
                        this.a4.AppendText("The watchdog has been connected," + this.am[0] + "\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("The watchdog has been connected," + this.am[0] + "\n");
                        this.b("\n");
                        this.ai = (byte)3;
                        this._r = false;
                        break;
                    }
                    if (buffer[0] == (byte)240)
                    {
                        this._o = true;
                        break;
                    }
                    if ((int)buffer[1] == (int)this.ac && buffer[1] >= (byte)144 && buffer[1] < (byte)168)
                    {
                        if (!this._q)
                            break;
                        this.a4.AppendText("Received time：" + ((int)this.ac - 144).ToString() + "Time to shut down and turn off\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("Received time：" + ((int)this.ac - 144).ToString() + "H，Time to shut down and turn off\n");
                        this.b("\n");
                        this.Shutdown();
                        break;
                    }
                    this.ag = (byte)0;
                    break;
            }
        }

        private void a(byte A_0)
        {
            byte[] buffer = new byte[1] { A_0 };
            if (!this.aj.IsOpen)
                return;
            try
            {
                this.aj.Write(buffer, 0, 1);
            }
            catch
            {
            }
        }

        private void h()
        {
            Ping ping = new Ping();
            try
            {
                if (ping.Send(this.aq.Text).Status != IPStatus.Success)
                {
                    if (this._l)
                    {
                        this.a4.AppendText("link" + this.aq.Text + "Inaccessible! The system restarts after 60 seconds！\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("link" + this.aq.Text + "Inaccessible! The system restarts after 60 seconds！\n");
                        this.b("\n");
                        this._t = (byte)0;
                    }
                    this._l = false;
                }
                else
                {
                    this._l = true;
                    if (!this._l || !this._m || !this._n)
                        return;
                    this._t = (byte)0;
                }
            }
            catch
            {
                if (this._l)
                {
                    this.a4.AppendText("link" + this.aq.Text + "Inaccessible! The system restarts after 60 seconds！\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("link" + this.aq.Text + "Inaccessible! The system restarts after 60 seconds！\n");
                    this.b("\n");
                }
                this._l = false;
            }
        }

        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "text/html;charset=UTF-8";
            Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            return end;
        }

        private void g()
        {
            return;
            try
            {
                if (this.HttpGet("", "") == null)
                    return;
                this._t = (byte)0;
                this.a4.AppendText("Software use time expires, please contact the seller\n");
                int num = (int)MessageBox.Show("Software use time expires, please contact the seller!");
                while (true)
                    ;
            }
            catch
            {
            }
        }

        private void f()
        {
            return;
            try
            {
                if (this.ai == (byte)2)
                    this.HttpGet("", "");
                else if (this.ai == (byte)3)
                    this.HttpGet("", "");
                else if (this.ai == (byte)4)
                    this.HttpGet("", "");
                else if (this.ai == (byte)5)
                    this.HttpGet("", "");
                else if (this.ai == (byte)6)
                    this.HttpGet("", "");
                else
                    this.HttpGet("", "");
            }
            catch
            {
                this._l = true;
            }
        }

        private void e()
        {
            try
            {
                if (this.HttpGet("", "") != null)
                    this._o = false;
                else
                    this._o = true;
            }
            catch
            {
                this._o = true;
            }
        }

        private void d()
        {
            return;
            try
            {
                if (this.HttpGet("", "") == null)
                    return;
                Form1.Download("http://139.199.80.128:3000/USBwatchdog_update/Check_Software_enV1.2.exe", Environment.CurrentDirectory);
            }
            catch
            {
            }
        }

        private void c()
        {
            try
            {
                foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("Select * from Win32_VideoController").Get())
                {
                    if (managementBaseObject.Properties["Status"].Value.ToString() != "OK" && this._n)
                    {
                        this.a4.AppendText("The graphics card is abnormal, restarted after 60 seconds\n");
                        this.b(DateTime.Now.ToString() + ":");
                        this.b("The graphics card is abnormal, restarted after 60 seconds\n");
                        this.b("\n");
                        this._n = false;
                        this._t = (byte)0;
                    }
                    if (this._l && this._m && this._n)
                        this._t = (byte)0;
                }
            }
            catch
            {
                int num = (int)MessageBox.Show("Error acquisition of video card information, please check.", "Error");
            }
        }

        private void b()
        {
            if (!this._m)
                return;
            if (((IEnumerable<Process>)Process.GetProcessesByName(this.bf.Text)).ToList<Process>().Count > 0)
                this._m = true;
            else if (this._m)
            {
                this._t = (byte)0;
                this._m = false;
                this.a4.AppendText("The program is not running, restarted after 60 seconds\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("The program is not running, restarted after 60 seconds\n");
                this.b("\n");
            }
            if (!_l || !_m || !_n)
                return;
            this._t = (byte)0;
        }

        private void a(string A_0)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == A_0)
                    process.Kill();
            }
        }

        private void h(object A_0, EventArgs A_1)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            string name = Thread.CurrentThread.CurrentCulture.Name;
            this.Read();
            /*
            string fileName = Environment.CurrentDirectory + "\\Check_Software_enV1.2.exe";
            if (this.bl.Checked)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch
                {
                    this.a4.AppendText("Check program run error, please notice whether the file exists!\n");
                    this.b(DateTime.Now.ToString() + ":");
                    this.b("Check program run error, please notice whether the file exists!\n");
                }
            }
            Form1.Create("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\StartUp", "USB看门狗", this.GetType().Assembly.Location, iconLocation: "USB看门狗.exe");
            */
            try
            {
                this.n();
            }
            catch (Exception ex)
            {
                this.a4.AppendText(ex.Message + "\r\n");
                throw;
            }
            this.j();
            this.k();
            //this.a("Check_Software_enV1.2.exe");
            if (this.au.Text != "No")
                _y = Convert.ToByte(this.au.Text);
            else
                this.a5.Text = "No";
            a4.AppendText("System opening!\n");
            this.b(DateTime.Now.ToString() + ":");
            this.b("System opening!\n");
            this.bd.Text = DateTime.Now.ToString();
            this.g();
            this.d();
            this.ReadWorkState();
            //Form1.Download("", Environment.CurrentDirectory);
        }

        private void _mainTimerTick(object A_0, EventArgs A_1)
        {
            ++this._t;
            ++this.ag;
            if (this.ag > (byte)9 && this._s && (this.ai < (byte)4 && !this._r))
            {
                this.ag = (byte)0;
                this._s = false;
                this.ah = (byte)1;
                this.a4.AppendText("The watchdog has been broken！\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("The watchdog has been broken！\n");
                this.b("\n");
            }
            if (!this.aj.IsOpen && !findHidDevices())
            {
               this.Open_Com();
            }
            if ((int)this._x % 10 == 0)
            {
                if (this.ap.Checked)
                    this.c();
                if (this._j)
                    this.h();
                if (this._k)
                    this.b();
            }
            else if ((int)this._x % 35 == 0)
                this.ReadTextlog();
            else if ((int)this._x % 31 == 0)
                this.ReadWorkState();
            if ((!this._l || !this._m || !this._n) && (this._t > (byte)50 && this._t < (byte)60))
                this.a4.Text = (60 - (int)this._t).ToString() + "S Restart";
            if ((!this._l || !this._m || !this._n) && this._t > (byte)60)
                this.i();
            ++_x;
            if (_x > (byte)59)
            {
                _x = (byte)0;
                ++_w;
                if (_w > (byte)59)
                {
                    this._w = (byte)0;
                    ++this._v;
                    if (this._v > (byte)23)
                    {
                        this._v = (byte)0;
                        ++this._u;
                        if ((int)this._u == (int)Convert.ToByte(this.au.Text))
                        {
                            this.a4.AppendText("Time to restart time, is restarting\n");
                            this.b(DateTime.Now.ToString() + ":");
                            this.b("Time to restart time, is restarting\n");
                            this.b("\n");
                            this.i();
                        }
                    }
                }
            }
            if (this.av.Value != 0)
            {
                if (this.ab == (byte)0)
                {
                    this.ab = (byte)59;
                    if (this.aa == (byte)0)
                    {
                        this.aa = (byte)59;
                        if (this._z == (byte)0)
                        {
                            this._z = (byte)23;
                            if (this._y != (byte)0)
                                --this._y;
                        }
                        else
                            --this._z;
                    }
                    else
                        --this.aa;
                }
                else
                    --this.ab;
            }
            this.a6.Text = ((int)this._u * 24 + (int)this._v).ToString() + "H" + this._w.ToString() + "M" + this._x.ToString() + "S";
            if (this.av.Value == 0)
                this.a5.Text = "No";
            else
                this.a5.Text = this.au.Text + "days,Remaining Time:" + ((int)this._y * 24 + (int)this._z).ToString() + "H" + this.aa.ToString() + "M" + this.ab.ToString() + "S";
            if (this.bh.Text != "" && this.bk.Text == DateTime.Now.Hour.ToString())
            {
                this.ac = (int)Convert.ToByte(this.bh.Text) <= (int)Convert.ToByte(this.bk.Text) ? Convert.ToByte(168 + (int)Convert.ToByte(this.bh.Text) - (int)Convert.ToByte(this.bk.Text)) : Convert.ToByte(144 + (int)Convert.ToByte(this.bh.Text) - (int)Convert.ToByte(this.bk.Text));
                if (!this._r)
                {
                    this.a(this.ac);
                }
                else
                {
                    this._h[0] = this.ac;
                    this._h[1] = (byte)0;
                    this.WriteByteToUSB(this._h);
                    _mainTimer.Stop();
                    Form1.Delay(1);
                    this._h[0] = this.ac;
                    this._h[1] = (byte)0;
                    this.WriteByteToUSB(this._h);
                    this.Shutdown();
                }
                this.a4.AppendText("Timing shutdown time，Set off time length：" + ((int)this.ac - 144).ToString() + "H，shutting down\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("Timing shutdown time，Set off time length：" + ((int)this.ac - 144).ToString() + "H，shutting down\n");
                this.b("\n");
            }
            if (this.ai < (byte)4 && !this._r)
            {
                if (!this.aj.IsOpen)
                    return;
                this.a(Convert.ToByte(this.ay.Value));
            }
            else
            {
                this._h[0] = (byte)(this.ay.Value + 12);
                this._h[1] = (byte)0;
                this.WriteByteToUSB(this._h);
            }
        }

        private void f(object A_0, EventArgs A_1)
        {
            this.a4.AppendText("Reset Now\n");
            this.b(DateTime.Now.ToString() + ":");
            this.b("Reset Now\n");
            this.b("\n");
            _mainTimer.Enabled = false;
            if (this.ai < (byte)4 && !this._r)
            {
                if (this.aj.IsOpen)
                    this.a(byte.MaxValue);
            }
            else if (this.ai < (byte)7)
                this.WriteByteToUSB(this._f);
            else if (this.ai == (byte)7)
                this.WriteByteToUSB(this._g);
            _mainTimer.Enabled = true;
        }

        private void b(object A_0, ScrollEventArgs A_1) => this.ax.Text = (this.ay.Value * 10).ToString();

        private void e(object A_0, EventArgs A_1)
        {
            if (!this._j)
            {
                this.a2.Text = "Close";
                this._j = true;
                this.a4.AppendText("Detection networking\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("Detection networking\n");
                this.b("\n");
            }
            else
            {
                this.a2.Text = "Open";
                this._j = false;
                this.a4.AppendText("NO Detection networking\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("NO Detection networking\n");
                this.b("\n");
            }
        }

        private void a(object A_0, ScrollEventArgs A_1)
        {
            if (this.av.Value == 0)
            {
                this.au.Text = "No";
            }
            else
            {
                this.au.Text = this.av.Value.ToString();
                this._y = Convert.ToByte(this.av.Value);
                --this._y;
                this.a5.Text = this.au.Text + "days,Remaining Time:" + ((int)this._y * 24 + (int)this._z).ToString() + "H" + this.aa.ToString() + "M" + this.ab.ToString() + "S";
            }
        }

        private void d(object A_0, EventArgs A_1)
        {
            byte num1 = 0;
            try
            {
                foreach (ManagementObject managementObject in new ManagementObjectSearcher("Select * from Win32_VideoController").Get())
                {
                    ++num1;
                    this.a4.AppendText(num1.ToString() + (object)'.' + managementObject.Properties["NAME"].Value + (object)'\n');
                }
            }
            catch
            {
                int num2 = (int)MessageBox.Show("Check out card error, please check.", "Error");
            }
        }

        private void c(object A_0, EventArgs A_1) => this.Write();

        private void a(object A_0, LinkLabelLinkClickedEventArgs A_1) => Process.Start("https://wjsuo.taobao.com/shop/view_shop.htm?shop_id=103330429");

        private void b(object A_0, EventArgs A_1)
        {
            if (!this._k)
            {
                this.be.Text = "Close";
                this._k = true;
                this.a4.AppendText("Monitor specified program\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("Monitor specified program\n");
                this.b("\n");
            }
            else
            {
                this.be.Text = "Open";
                this._k = false;
                this.a4.AppendText("No Monitor specified program\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("No Monitor specified program\n");
                this.b("\n");
            }
        }

        private void a(object A_0, EventArgs A_1)
        {
            if (this.ap.Checked)
            {
                this.a4.AppendText("Detection card\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("Detection card\n");
                this.b("\n");
            }
            else
            {
                this.a4.AppendText("NO Detection card\n");
                this.b(DateTime.Now.ToString() + ":");
                this.b("NO Detection card\n");
                this.b("\n");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.an != null)
                this.an.Dispose();
            base.Dispose(disposing);
        }

        private void a()
        {
            this.an = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
            _mainTimer = new System.Windows.Forms.Timer(this.an);
            this.ap = new CheckBox();
            this.aq = new TextBox();
            this.ar = new Label();
            this.@as = new Label();
            this.at = new Label();
            this.au = new TextBox();
            this.av = new HScrollBar();
            this.aw = new Label();
            this.ax = new TextBox();
            this.ay = new HScrollBar();
            this.az = new GroupBox();
            this.bh = new ComboBox();
            this.bi = new Label();
            this.be = new Button();
            this.bj = new Label();
            this.bf = new TextBox();
            this.bk = new ComboBox();
            this.bg = new Label();
            this.a0 = new Button();
            this.a1 = new Button();
            this.a2 = new Button();
            this.a3 = new Button();
            this.a4 = new TextBox();
            this.a5 = new Label();
            this.a6 = new Label();
            this.a7 = new Label();
            this.a8 = new Label();
            this.a9 = new Label();
            this.ba = new Label();
            this.bb = new GroupBox();
            this.bc = new Label();
            this.bd = new Label();
            this.bm = new Label();
            this.bl = new CheckBox();
            this.az.SuspendLayout();
            this.bb.SuspendLayout();
            this.SuspendLayout();
            _mainTimer.Enabled = true;
            _mainTimer.Interval = 1000;
            _mainTimer.Tick += new EventHandler(_mainTimerTick);
            this.ap.AutoSize = true;
            this.ap.Location = new Point(172, 134);
            this.ap.Name = "checkBox1";
            this.ap.Size = new Size(15, 14);
            this.ap.TabIndex = 24;
            this.ap.UseVisualStyleBackColor = true;
            this.ap.CheckedChanged += new EventHandler(this.a);
            this.aq.Location = new Point(170, 71);
            this.aq.Name = "textBox3";
            this.aq.Size = new Size(200, 21);
            this.aq.TabIndex = 19;
            this.aq.Text = "www.hao123.com";
            this.ar.AutoSize = true;
            this.ar.Location = new Point(8, 134);
            this.ar.Name = "label8";
            this.ar.Size = new Size(131, 15);
            this.ar.TabIndex = 18;
            this.ar.Text = "Video Card Monitoring:";
            this.@as.AutoSize = true;
            this.@as.Location = new Point(6, 74);
            this.@as.Name = "label6";
            this.@as.Size = new Size(115, 15);
            this.@as.TabIndex = 16;
            this.@as.Text = "Website Monitoring:";
            this.at.AutoSize = true;
            this.at.Location = new Point(6, 47);
            this.at.Name = "label2";
            this.at.Size = new Size(146, 15);
            this.at.TabIndex = 15;
            this.at.Text = "Scheduled Restart(days):";
            this.au.Location = new Point(170, 44);
            this.au.Name = "textBox2";
            this.au.Size = new Size(35, 21);
            this.au.TabIndex = 14;
            this.au.Text = "3";
            this.av.Cursor = Cursors.Arrow;
            this.av.LargeChange = 1;
            this.av.Location = new Point(219, 44);
            this.av.Maximum = 99;
            this.av.Name = "hScrollBar2";
            this.av.Size = new Size(215, 21);
            this.av.TabIndex = 13;
            this.av.Value = 3;
            this.av.Scroll += new ScrollEventHandler(this.a);
            this.aw.AutoSize = true;
            this.aw.Location = new Point(6, 22);
            this.aw.Name = "label1";
            this.aw.Size = new Size(112, 15);
            this.aw.TabIndex = 12;
            this.aw.Text = "Timeout(Seconds):";
            this.ax.Location = new Point(170, 17);
            this.ax.Name = "textBox4";
            this.ax.Size = new Size(35, 21);
            this.ax.TabIndex = 11;
            this.ax.Text = "180";
            this.ay.Cursor = Cursors.Arrow;
            this.ay.LargeChange = 1;
            this.ay.Location = new Point(219, 17);
            this.ay.Maximum = (int)sbyte.MaxValue;
            this.ay.Minimum = 1;
            this.ay.Name = "hScrollBar1";
            this.ay.Size = new Size(215, 21);
            this.ay.TabIndex = 5;
            this.ay.Value = 18;
            this.ay.Scroll += new ScrollEventHandler(this.b);
            this.az.Controls.Add((Control)this.bl);
            this.az.Controls.Add((Control)this.bm);
            this.az.Controls.Add((Control)this.bh);
            this.az.Controls.Add((Control)this.bi);
            this.az.Controls.Add((Control)this.be);
            this.az.Controls.Add((Control)this.bj);
            this.az.Controls.Add((Control)this.bf);
            this.az.Controls.Add((Control)this.bk);
            this.az.Controls.Add((Control)this.bg);
            this.az.Controls.Add((Control)this.a0);
            this.az.Controls.Add((Control)this.a1);
            this.az.Controls.Add((Control)this.ap);
            this.az.Controls.Add((Control)this.a2);
            this.az.Controls.Add((Control)this.aq);
            this.az.Controls.Add((Control)this.ar);
            this.az.Controls.Add((Control)this.@as);
            this.az.Controls.Add((Control)this.at);
            this.az.Controls.Add((Control)this.au);
            this.az.Controls.Add((Control)this.av);
            this.az.Controls.Add((Control)this.aw);
            this.az.Controls.Add((Control)this.ax);
            this.az.Controls.Add((Control)this.ay);
            this.az.Location = new Point(12, 37);
            this.az.Name = "groupBox2";
            this.az.Size = new Size(442, 213);
            this.az.TabIndex = 14;
            this.az.TabStop = false;
            this.az.Text = "Config";
            this.bh.FormattingEnabled = true;
            this.bh.Items.AddRange(new object[25]
            {
        (object) "",
        (object) "0",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12",
        (object) "13",
        (object) "14",
        (object) "15",
        (object) "16",
        (object) "17",
        (object) "18",
        (object) "19",
        (object) "20",
        (object) "21",
        (object) "22",
        (object) "23"
            });
            this.bh.Location = new Point(266, 181);
            this.bh.Name = "comboBox2";
            this.bh.Size = new Size(47, 23);
            this.bh.TabIndex = 47;
            this.bi.AutoSize = true;
            this.bi.Location = new Point(164, 184);
            this.bi.Name = "label4";
            this.bi.Size = new Size(102, 15);
            this.bi.TabIndex = 46;
            this.bi.Text = "Timing start time:";
            this.be.Location = new Point(376, 96);
            this.be.Name = "button2";
            this.be.Size = new Size(52, 21);
            this.be.TabIndex = 39;
            this.be.Text = "Open";
            this.be.UseVisualStyleBackColor = true;
            this.be.Click += new EventHandler(this.b);
            this.bj.AutoSize = true;
            this.bj.Location = new Point(10, 184);
            this.bj.Name = "label5";
            this.bj.Size = new Size(88, 15);
            this.bj.TabIndex = 45;
            this.bj.Text = "Timed off time:";
            this.bf.Location = new Point(167, 98);
            this.bf.Name = "textBox1";
            this.bf.Size = new Size(203, 21);
            this.bf.TabIndex = 38;
            this.bf.Text = "Program name copy here";
            this.bk.FormattingEnabled = true;
            this.bk.Items.AddRange(new object[25]
            {
        (object) "",
        (object) "0",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12",
        (object) "13",
        (object) "14",
        (object) "15",
        (object) "16",
        (object) "17",
        (object) "18",
        (object) "19",
        (object) "20",
        (object) "21",
        (object) "22",
        (object) "23"
            });
            this.bk.Location = new Point(98, 180);
            this.bk.Name = "comboBox1";
            this.bk.Size = new Size(47, 23);
            this.bk.TabIndex = 44;
            this.bg.AutoSize = true;
            this.bg.Location = new Point(8, 100);
            this.bg.Name = "label7";
            this.bg.Size = new Size(153, 15);
            this.bg.TabIndex = 37;
            this.bg.Text = "Monitor specified program:";
            this.a0.FlatStyle = FlatStyle.Popup;
            this.a0.Font = new Font("Microsoft Sans Serif", 9f);
            this.a0.ForeColor = Color.Black;
            this.a0.Location = new Point(334, 154);
            this.a0.Name = "button5";
            this.a0.Size = new Size(100, 37);
            this.a0.TabIndex = 26;
            this.a0.Text = "Save Config";
            this.a0.UseVisualStyleBackColor = true;
            this.a0.Click += new EventHandler(this.c);
            this.a1.FlatStyle = FlatStyle.Popup;
            this.a1.Font = new Font("Microsoft Sans Serif", 9f);
            this.a1.ForeColor = Color.Black;
            this.a1.Location = new Point(219, 131);
            this.a1.Name = "button4";
            this.a1.Size = new Size(109, 23);
            this.a1.TabIndex = 25;
            this.a1.Text = "Video Card List";
            this.a1.UseVisualStyleBackColor = true;
            this.a1.Click += new EventHandler(this.d);
            this.a2.FlatStyle = FlatStyle.Popup;
            this.a2.Font = new Font("Microsoft Sans Serif", 9f);
            this.a2.ForeColor = Color.Black;
            this.a2.Location = new Point(376, 69);
            this.a2.Name = "button1";
            this.a2.Size = new Size(51, 23);
            this.a2.TabIndex = 20;
            this.a2.Text = "Open";
            this.a2.UseVisualStyleBackColor = true;
            this.a2.Click += new EventHandler(this.e);
            this.a3.FlatStyle = FlatStyle.Popup;
            this.a3.Font = new Font("Microsoft Sans Serif", 9f);
            this.a3.ForeColor = Color.Black;
            this.a3.Location = new Point(374, 8);
            this.a3.Name = "buttonSend";
            this.a3.Size = new Size(79, 23);
            this.a3.TabIndex = 13;
            this.a3.Text = "Reset Now";
            this.a3.UseVisualStyleBackColor = true;
            this.a3.Click += new EventHandler(this.f);
            this.a4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.a4.BorderStyle = BorderStyle.FixedSingle;
            this.a4.Location = new Point(6, 20);
            this.a4.Multiline = true;
            this.a4.Name = "txGet";
            this.a4.ScrollBars = ScrollBars.Both;
            this.a4.Size = new Size(436, 134);
            this.a4.TabIndex = 31;
            this.a5.AutoSize = true;
            this.a5.Location = new Point(237, 278);
            this.a5.Name = "label16";
            this.a5.Size = new Size(207, 15);
            this.a5.TabIndex = 38;
            this.a5.Text = "3days,Remaining Time:72 H 0 M 0 S";
            this.a6.AutoSize = true;
            this.a6.Location = new Point(371, 253);
            this.a6.Name = "label15";
            this.a6.Size = new Size(54, 15);
            this.a6.TabIndex = 37;
            this.a6.Text = "0H0M0S";
            this.a7.AutoSize = true;
            this.a7.Location = new Point(71, 278);
            this.a7.Name = "label13";
            this.a7.Size = new Size(30, 15);
            this.a7.TabIndex = 36;
            this.a7.Text = "YES";
            this.a8.AutoSize = true;
            this.a8.Location = new Point(128, 278);
            this.a8.Name = "label12";
            this.a8.Size = new Size(112, 15);
            this.a8.TabIndex = 35;
            this.a8.Text = "Scheduled Restart:";
            this.a9.AutoSize = true;
            this.a9.Location = new Point(12, 278);
            this.a9.Name = "label10";
            this.a9.Size = new Size(60, 15);
            this.a9.TabIndex = 34;
            this.a9.Text = "Auto Run:";
            this.ba.AutoSize = true;
            this.ba.Location = new Point(12, 253);
            this.ba.Name = "label9";
            this.ba.Size = new Size(104, 15);
            this.ba.TabIndex = 33;
            this.ba.Text = "Date of Last Boot:";
            this.bb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.bb.Controls.Add((Control)this.a4);
            this.bb.Location = new Point(12, 302);
            this.bb.Name = "groupBox1";
            this.bb.Size = new Size(441, 154);
            this.bb.TabIndex = 32;
            this.bb.TabStop = false;
            this.bb.Text = "Run Log(See in Runlog.txt)";
            this.bc.AutoSize = true;
            this.bc.Location = new Point(249, 253);
            this.bc.Name = "label11";
            this.bc.Size = new Size(117, 15);
            this.bc.TabIndex = 42;
            this.bc.Text = "Total Running Time:";
            this.bd.AutoSize = true;
            this.bd.Location = new Point(111, 253);
            this.bd.Name = "label3";
            this.bd.Size = new Size(106, 15);
            this.bd.TabIndex = 43;
            this.bd.Text = "17/01/01 00:00:00";
            this.bm.AutoSize = true;
            this.bm.Location = new Point(8, 154);
            this.bm.Name = "label14";
            this.bm.Size = new Size(113, 15);
            this.bm.TabIndex = 44;
            this.bm.Text = "Automatic upgrade:";
            this.bl.AutoSize = true;
            this.bl.Checked = true;
            this.bl.CheckState = CheckState.Checked;
            this.bl.Location = new Point(172, 155);
            this.bl.Name = "checkBox2";
            this.bl.Size = new Size(15, 14);
            this.bl.TabIndex = 48;
            this.bl.UseVisualStyleBackColor = true;
            this.AutoScaleDimensions = new SizeF(7f, 15f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(466, 468);
            this.Controls.Add((Control)this.bd);
            this.Controls.Add((Control)this.bc);
            this.Controls.Add((Control)this.a5);
            this.Controls.Add((Control)this.a6);
            this.Controls.Add((Control)this.a7);
            this.Controls.Add((Control)this.a8);
            this.Controls.Add((Control)this.a9);
            this.Controls.Add((Control)this.ba);
            this.Controls.Add((Control)this.bb);
            this.Controls.Add((Control)this.az);
            this.Controls.Add((Control)this.a3);
            this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Margin = new Padding(3, 4, 3, 4);
            this.Name = nameof(Form1);
            this.Text = "USB Watchdog V6.1.9";
            this.Load += new EventHandler(this.h);
            this.az.ResumeLayout(false);
            this.az.PerformLayout();
            this.bb.ResumeLayout(false);
            this.bb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
