using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_MVVM.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);


            return true;
        }

        #region IDisposable

        //~ViewModel()
        //{
        //    Dispose(false);
        //}

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _isDisposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _isDisposed) return;

            _isDisposed = true;
            // освобождение управляемых ресурсов
        }

        #endregion
    }
}
