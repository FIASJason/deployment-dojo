// WindowsService1

namespace WindowsService1
{
    #region Using Directives
    using System;
    using System.IO;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;
    using System.Timers;
    using Microsoft.Win32;
    using Timer = System.Timers.Timer;
    #endregion

    public partial class Service1 : ServiceBase
    {
        #region Fields
        readonly Timer _timer;
        int            _count;
        string         _path;
        #endregion

        #region Constructors
        public Service1()
        {
            InitializeComponent();
            _timer         =  new Timer(1000);
            _timer.Elapsed += OnTimer;
        }
        #endregion

        void InitializePath()
        {
            try
            {
                var path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFilePath", null) as string;

                _path = Path.GetFullPath(path);
            }
            catch (Exception)
            {
                // ignored
            }

            if (string.IsNullOrEmpty(_path))
            {
                _path = Path.Combine(AppContext.BaseDirectory, "WindowsService1.txt");
            }

            Directory.CreateDirectory(Path.GetDirectoryName(_path) ?? Path.GetTempPath());
        }

        void OnTimer(object sender, ElapsedEventArgs e) => UpdateFile($"Running count: {++_count:000}");

        void UpdateFile(string text)
        {
            var bytes = Encoding.UTF8.GetBytes($"[{DateTime.Now:u}] {text}");

            for (var attempt = 0; attempt < 5; attempt++)
            {
                try
                {
                    using (var file = File.Open(_path, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        file.Write(bytes, 0, bytes.Length);
                    }

                    break;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            InitializePath();
            UpdateFile($"Start count: {_count}");
            _timer.Start();
        }

        protected override void OnStop()
        {
            _timer.Stop();
            UpdateFile($"Stop count: {_count}");
        }
    }
}