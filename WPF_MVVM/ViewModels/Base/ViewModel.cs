﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Windows.Threading;

namespace WPF_MVVM.ViewModels.Base
{
    public abstract class ViewModel : MarkupExtension, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region INotifyPropertyChanged

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            var handlers = PropertyChanged;
            if (handlers is null) return;

            var invoсation_list = handlers.GetInvocationList();

            foreach (var action in invoсation_list)
            {
                if (action.Target is DispatcherObject disp_object)
                {
                    disp_object.Dispatcher.Invoke(action, this, new PropertyChangedEventArgs(propertyName));
                }
                else
                {
                    action.DynamicInvoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
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

        #endregion

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

        #region Markup Extension

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion
    }
}
