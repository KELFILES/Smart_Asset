namespace Smart_Asset
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // These must be called before creating the first form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run your main form
            //Application.Run(new FrontPage_Final());
            Application.Run(new Startup());
        }
    }
}