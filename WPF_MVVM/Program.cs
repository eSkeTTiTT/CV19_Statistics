using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_MVVM
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
