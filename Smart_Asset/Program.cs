namespace Smart_Asset
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            SetProcessDPIAware(); // Disable automatic DPI scaling

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Apply manual scaling adjustment
            AdjustScaling();

            Application.Run(new Login());
            //Application.Run(new FrontPage_Final());
        }

        private static void AdjustScaling()
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                // Get the current DPI (dots per inch)
                float currentDpi = g.DpiX;

                // Standard DPI (100% scaling)
                const float standardDpi = 96f;

                // Calculate the scaling factor
                float scalingFactor = currentDpi / standardDpi;

                // Apply scaling factor to all forms
                foreach (Form form in Application.OpenForms)
                {
                    form.Scale(new SizeF(1 / scalingFactor, 1 / scalingFactor));
                }
            }
        }
    }
}