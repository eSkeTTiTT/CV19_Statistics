﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WPF_MVVM_Web
{
    public class WebServer
    {
        private event EventHandler<RequestReceivedEventArgs> RequestReceived;

        //private TcpListener _listener = new TcpListener(new IPEndPoint(IPAddress.Any, 8080));
        private HttpListener _listener;
        private readonly int _port;
        private bool _enabled;
        private readonly object _syncRoot = new object();

        public int Port => _port;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (value)
                    Start();
                else
                    Stop();
            }
        }

        public WebServer(int port) => _port = port;

        public void Start()
        {
            if (_enabled) return;
            lock(_syncRoot)
            {
                if (_enabled) return; // чтобы след поток не начал делать тоже самое
                _listener = new HttpListener();
                _listener.Prefixes.Add($"http://*:{_port}");
                _listener.Prefixes.Add($"http://+:{_port}");
                _enabled = true;
                ListenAsync();
            }
        }

        public void Stop()
        {
            if (!_enabled) return;
            lock(_syncRoot)
            {
                if (!_enabled) return;
                _listener = null;
                _enabled = false;
            }
        }

        private async void ListenAsync()
        {
            var listener = _listener; // чтобы если ссылка изменена - продожить работу

            listener.Start();

            while (_enabled)
            {
                var context = await listener.GetContextAsync().ConfigureAwait(false);
                ProcessRequest(context);
            }

            listener.Stop();
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            RequestReceived?.Invoke(this, new RequestReceivedEventArgs(context));
        }
    }

    public class RequestReceivedEventArgs : EventArgs
    {
        public HttpListenerContext Context { get; }

        public RequestReceivedEventArgs(HttpListenerContext context) => Context = context;
    }
}
