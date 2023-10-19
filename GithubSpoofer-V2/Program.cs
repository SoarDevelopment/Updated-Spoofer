using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSpoofer_V2
{
    public class ConsoleSpinnerPaste
    {
        static string[,] sequence = null;

        public int Delay { get; set; } = 200;

        int totalSequences = 0;
        int counter;

        public ConsoleSpinnerPaste()
        {
            counter = 0;
            sequence = new string[,] {
                { "/", "-", @"\", "|" },
            };

            totalSequences = sequence.GetLength(0);
        }
        static void Write(string lol)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] : " + lol);
        }

        public void Turn(string displayMsg = "", int sequenceCode = 0)
        {
            counter++;
            Thread.Sleep(Delay);
            sequenceCode = sequenceCode > totalSequences - 1 ? 0 : sequenceCode;
            int counterValue = counter % 4;
            string fullMessage = displayMsg + sequence[sequenceCode, counterValue];
            int msglength = fullMessage.Length + 8;
            Write(fullMessage);
            Console.SetCursorPosition(Console.CursorLeft - msglength, Console.CursorTop);
        }
    }
    class Program
    {

        static string Driver = "https://github.com/SoarDevelopment/Spoof-Driver/raw/main/soardrv.sys";
        static string Mapper = "https://github.com/SoarDevelopment/Spoof-Driver/raw/main/kdmapper.exe";
        static string serial1;
        static bool starttitle = false;
        static string serial2;
        static void Write(string lol)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("] : " + lol);
        }


        static void Write2(string lol)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] : " + lol);
        }

        [DllImport("msvcrt.dll")]
        public static extern int system(string format);

        class HardDrive
        {
            private string serialNo = null;
            public string SerialNo
            {
                get { return serialNo; }
                set { serialNo = value; }
            }
        }

        static void BackgroundTitle()
        {
            while (true)
            {
                Console.Title = "";
                string title1 = "Github Spoofer | SoarDevelopment";
                for (int i = 0; i < title1.Length; i++)
                {
                    Console.Title = Console.Title.ToString() + title1[i].ToString();
                    Thread.Sleep(50);
                }
                Thread.Sleep(1500);

                Console.Title = "VERSION 2!";
                Thread.Sleep(300);
                Console.Title = " ";
                Thread.Sleep(300);

                Console.Title = "VERSION 2!";
                Thread.Sleep(300);
                Console.Title = " ";
                Thread.Sleep(300);

                Console.Title = "VERSION 2!";
                Thread.Sleep(300);
                Console.Title = " ";
                Thread.Sleep(300);

                Console.Title = "VERSION 2!";
                Thread.Sleep(300);
                Console.Title = " ";
                
                string title2 = "github.com/soarcheats | feds.lol/soarcheats";
                for (int i = 0; i < title2.Length; i++)
                {
                    Console.Title = Console.Title.ToString() + title2[i].ToString();
                    Thread.Sleep(50);
                }
                Thread.Sleep(1500);
            }
        }
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;
            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        static void Spinner(int times, string msg)
        {
            ConsoleSpinnerPaste spinner = new ConsoleSpinnerPaste();
            spinner.Delay = 100;
            for (int i = 0; i < times; i++)
            {
                spinner.Turn(displayMsg: msg + " ", sequenceCode: 1);
            }
        }

        static void EasySpinner(int times, string msg1, bool success)
        {
            Spinner(times, msg1);
            if (success)
            {
                Write(msg1 + " . Success");
            }
            else if (!success)
            {
                Write(msg1 + " . Failure");
            }
        }

        private static string GetHddSerialNumber(string drive)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hard drive from collection
                // using index
                HardDrive hd = new HardDrive();

                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] == null)
                    hd.SerialNo = "None";
                else
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString();
                return hd.SerialNo;
            }
            return "";
        }


        static void Main(string[] args)
        {
            serial1 = GetHddSerialNumber("C");
            if (!starttitle)
            {
                Thread nig = new Thread(BackgroundTitle); nig.Start();
                starttitle = true;
            }
            Console.Clear();
            Console.WriteLine();
            Write("github.com/soarcheats");
            Write("Select an option.");
            Console.WriteLine();
            Write("1. Spoof EAC / BE (randomize)");
            Write("2. Check Serials");
            Console.WriteLine();
            Write2("");
            var kys = Console.ReadLine();
            if (kys == "1")
            {
                Console.WriteLine();
                Spinner(15,"Checking Internet Connection");
                bool internet = PingHost("https://google.com");
                if (internet)
                {

                    Write("Checking Internet Connection . Invalid Connection Type, Spoofer Will Not able To Load");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                else
                {
                    Write("Checking Internet Connection . Success");
                    Thread.Sleep(1000);
                }
                WebClient wb = new WebClient();
                wb.DownloadFile(Driver, @"C:\Windows\driver.sys");
                wb.DownloadFile(Mapper, @"C:\Windows\mapper.exe");
                system(@"C:\Windows\mapper.exe C:\Windows\driver.sys >nul");
                EasySpinner(5, "Randomizing Diskdrives", true);
                EasySpinner(5, "Nulling Tables", true);
                system(@"taskkill /f /im WmiPrvSE.exe >nul");
                serial2 = GetHddSerialNumber("C");
                if (serial2 != serial1)
                {
                    EasySpinner(16, "Verifying Required Task", true);
                }
                else if (serial2 == serial1)
                {
                    EasySpinner(20, "Verifying Required Task", false);
                }

                Console.WriteLine();
                Thread.Sleep(2000);
                Main(args);
            }
            if (kys == "2")
            {
                Console.WriteLine();
                int pid = 0;
                foreach (Process p in Process.GetProcessesByName("WmiPrvSE"))
                {
                    pid = p.Id;
                }
                if (pid > 1)
                {
                    EasySpinner(20, "Checking WMI Serivces", true);
                }
                else if (pid < 1)
                {
                    EasySpinner(20, "Checking WMI Serivces", false);
                    Write("Could not verify wmi serivce, operation has been cancled.");
                    Thread.Sleep(2000);
                    Main(args);
                }
                EasySpinner(5, "Getting Logical Disk Serials", true);
                Write("Diskdrive -> " + serial1);
                Thread.Sleep(2000);
                Write("Press any key to return.");
                system("pause >nul");
                EasySpinner(10, "Cleaning Up", true);
                Thread.Sleep(1000);
                serial1 = null;
                pid = 0;
                Main(args);
            }
            Thread.Sleep(-1);
        }
    }
}
