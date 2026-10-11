using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CinemaVR.Api.Server
{
    public class HttpServer
    {
        private readonly HttpListener _listener;

        public HttpServer(string[] prefixes)
        {
            _listener = new HttpListener();

            foreach (var prefix in prefixes)
                _listener.Prefixes.Add(prefix);
        }

        public async Task StartAsync()
        {
            _listener.Start();

            // 🔥 Додаю вивід усіх URL, які слухає сервер
            Console.WriteLine("HTTP сервер запущено. Доступні адреси:");
            foreach (var prefix in _listener.Prefixes)
                Console.WriteLine($" → {prefix}");

            bool runServer = true;

            while (runServer)
            {
                HttpListenerContext ctx = await _listener.GetContextAsync();

                HttpListenerRequest req = ctx.Request!;
                HttpListenerResponse resp = ctx.Response!;

                Console.WriteLine($"Запит: {req.HttpMethod} {req.Url}");

                if (req.HttpMethod == "POST" && req.Url.AbsolutePath == "/shutdown")
                {
                    Console.WriteLine("Отримано команду на завершення.");
                    runServer = false;
                }

                string html =
                    "<!DOCTYPE html>" +
                    "<html>" +
                    "<head><title>HttpListener</title></head>" +
                    "<body>" +
                    $"<p>Server running: {runServer}</p>" +
                    "<form method=\"post\" action=\"shutdown\">" +
                    $"<input type=\"submit\" value=\"Shutdown\" {(runServer ? "" : "disabled")}>" +
                    "</form>" +
                    "</body>" +
                    "</html>";

                byte[] data = Encoding.UTF8.GetBytes(html);

                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.Length;

                if (resp.OutputStream != null)
                    await resp.OutputStream.WriteAsync(data, 0, data.Length);

                resp.Close();
            }

            Stop();
        }

        public void Stop()
        {
            if (_listener.IsListening)
            {
                _listener.Stop();
                _listener.Close();
                Console.WriteLine("HTTP сервер зупинено.");
            }
        }
    }
}
