using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public sealed class MainWindowViewModel : ViewModel
    {
        #region Properties

        private string _title;
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion
    }
}
