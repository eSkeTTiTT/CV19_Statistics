﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WPF_MVVM_Web;

namespace WPF_MVVM_Console
{
    public static class WebServerTest
    {
        public static void Run()
        {
            var server = new WebServer(8080);

            server.RequestReceived += OnRequestReceived;
            server.Start();

            Console.WriteLine("Сервер запущен");
            Console.ReadLine();
        }

        public static void OnRequestReceived(object sender, RequestReceivedEventArgs e)
        {
            var context = e.Context;

            Console.WriteLine("Connection {0}", context.Request.UserHostAddress);

            using var writer = new StreamWriter(context.Response.OutputStream);
            writer.WriteLine("Soniya I Love You!!!");
        }
    }
}
