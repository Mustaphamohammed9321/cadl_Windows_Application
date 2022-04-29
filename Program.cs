using System.Configuration;

namespace cadl
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
            RepoDb.SqlServerBootstrap.Initialize();
            //Application.Run(new Form4());
            Application.Run(new Form1());
            //string apiUrl = ConfigurationManager.AppSettings["ServiceUrl"].ToString();
        }
    }
}