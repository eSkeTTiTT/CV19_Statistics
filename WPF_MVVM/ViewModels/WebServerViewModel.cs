using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPF_MVVM.Infrastructure.Commands;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public class WebServerViewModel : ViewModel
    {
        public WebServerViewModel()
        {

        }

        #region Properties

        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set => Set(ref _enabled, value);
        }

        #endregion

        #region Commands

        private ICommand _startCommand;
        public ICommand StartCommand => _startCommand ??= new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        private ICommand _stopCommand;
        public ICommand StopCommand => _stopCommand ??= new LambdaCommand(OnStopCommandExecuted, CanStopCommandExecute);

        #region Commands Methods

        private bool CanStartCommandExecute(object o) => !Enabled;

        private void OnStartCommandExecuted(object o)
        {
            Enabled = true;
        }

        private bool CanStopCommandExecute(object o) => Enabled;

        private void OnStopCommandExecuted(object o)
        {
            Enabled = false;
        }

        #endregion

        #endregion
    }
}
