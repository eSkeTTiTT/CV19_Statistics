using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPF_MVVM.Infrastructure.Commands;
using WPF_MVVM.Services.Interfaces;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public class WebServerViewModel : ViewModel
    {
        public WebServerViewModel(IWebServerService webServer)
        {
            _webserver = webServer;
        }

        #region Properties

        private readonly IWebServerService _webserver;

        public bool Enabled
        {
            get => _webserver.Enabled;
            set
            {
                _webserver.Enabled = value;
                OnPropertyChanged();
            }
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
            _webserver.Start();
            OnPropertyChanged(nameof(Enabled));
        }

        private bool CanStopCommandExecute(object o) => Enabled;

        private void OnStopCommandExecuted(object o)
        {
            _webserver.Stop();
            OnPropertyChanged(nameof(Enabled));
        }

        #endregion

        #endregion
    }
}
