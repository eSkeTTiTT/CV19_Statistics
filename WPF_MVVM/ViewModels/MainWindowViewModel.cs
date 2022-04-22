using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPF_MVVM.Infrastructure.Commands;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public sealed class MainWindowViewModel : ViewModel
    {
        #region Constructors

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }

        #endregion

        #region Properties

        private string _title;
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region Commands

        #region Close Application Command

        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion

        #endregion
    }
}
