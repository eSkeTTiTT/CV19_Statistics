using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WPF_MVVM.Infrastructure.Commands.Base;
using WPF_MVVM.Views.Windows;

namespace WPF_MVVM.Infrastructure.Commands
{
    public class ManageStudentsCommand : Command
    {
        private StudentsManagementWindow _window;

        public override bool CanExecute(object parameter) => _window is null;

        public override void Execute(object parameter)
        {
            var window = new StudentsManagementWindow
            {
                Owner = Application.Current.MainWindow
            };
            _window = window;
            window.Closed += OnWindowClosed;

            window.ShowDialog();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            _window = null;
        }
    }
}
