using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Services.Interfaces;

namespace WPF_MVVM.Services
{
    public class HttpListenerWebServer : IWebServerService
    {
        public bool Enabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
