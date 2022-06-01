using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace VmsInformWeb
{
    public class Program
    {
        static Process _xvfb;
        const string _xvfbPid = "pid/pid.xvfb.fr";

        public static void Main(string[] args)
        {
            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            //    LinuxStart();

            CreateWebHostBuilder(args).Build().Run();

            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            //    LinuxStop();
        }

        private static void LinuxStop()
        {
            _xvfb.Kill();
            if (File.Exists(_xvfbPid))
                File.Delete(_xvfbPid);
        }

        private static void LinuxStart()
        {
            if (File.Exists(_xvfbPid))
            {
                var pid = File.ReadAllText(_xvfbPid);
                try
                {
                    _xvfb = Process.GetProcessById(int.Parse(pid));
                    _xvfb.Kill();
                    _xvfb = null;
                }
                catch { }
                File.Delete(_xvfbPid);
            }
            var display = Environment.GetEnvironmentVariable("DISPLAY");
            if (string.IsNullOrEmpty(display))
            {
                Environment.SetEnvironmentVariable("DISPLAY", ":99");
                display = ":99";
            }
            var info = new ProcessStartInfo();
            info.FileName = "/usr/bin/Xvfb";
            info.Arguments = display + " -ac -screen 0 1024x768x16 +extension RANDR -dpi 96";
            info.CreateNoWindow = true;
            _xvfb = new Process();
            _xvfb.StartInfo = info;
            _xvfb.Start();
            File.WriteAllText(_xvfbPid, _xvfb.Id.ToString());
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(opt => {
                opt.Listen(IPAddress.Loopback, 5080);
            })
            .UseStartup<Startup>()
            .ConfigureServices(service => service.AddAutofac());
    }
}
