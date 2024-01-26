using FSLib.App.SimpleUpdater;
using FSLib.App.SimpleUpdater.UpdateControl;
using System.Diagnostics;

namespace AppLauncher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length == 0 || args[0] != "from:steam")
            {
                string update_url = "http://xian.abug.cc/app/pc/update.xml";
                var updater = Updater.CreateUpdaterInstance(update_url);
                updater.EnsureNoUpdate();
            }
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists("game.exe"))
            {
                MessageBox.Show("�����ļ�������");
                return;
            }
            ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.FileName = Path.Combine(Application.StartupPath, "game.exe");
            if (args.Length > 0)
            {
                proc.Arguments = String.Join(" ", args);
            }
            proc.CreateNoWindow = false;
            //��������
            Process.Start(proc);

        }
    }
}