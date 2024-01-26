namespace Game
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            FrmUI.FrmLogin frm = new FrmUI.FrmLogin();
            frm.ShowDialog();
            if (frm.getToken() != null && frm.getToken() != "")
            {
                Application.Run(new FrmUI.FrmMain(frm.getToken()));
            }
        }
    }
}