using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WPF_MVVM.Services.Interfaces;
using WPF_MVVM_Web;

namespace WPF_MVVM.Services
{
    public class HttpListenerWebServer : IWebServerService
    {
        public HttpListenerWebServer()
        {
            _server.RequestReceived += OnRequestReceived;
        }

        private WebServer _server = new WebServer(8080);

        public bool Enabled
        {
            get => _server.Enabled;
            set => _server.Enabled = value;
        }

        public void Start() => _server.Start();

        public void Stop() => _server.Stop();

        private void OnRequestReceived(object sender, RequestReceivedEventArgs e)
        {
            using var writer = new StreamWriter(e.Context.Response.OutputStream);

            writer.WriteLine("CV-19 Application" + DateTime.Now);
        }
    }
}
