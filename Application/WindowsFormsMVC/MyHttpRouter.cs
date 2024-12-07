using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVC
{
    public class MyHttpRouter
    {
        /// <summary>
        /// Роутер запросов
        /// </summary>
        /// <param name="ctx"></param>
        public static void Route(HttpListenerContext ctx)
        {
            // Peel out the requests and response objects
            HttpListenerRequest req = ctx.Request;
            HttpListenerResponse resp = ctx.Response;
            Web.GuardianOfDeputies.RequestHandlerDeputy.AttemptToProcess(req.RawUrl,ref req,ref  resp);
            return;
            // Write out to the response stream (asynchronously), then close it
            string cont_ = $"Hellow world!query=#{ req.RawUrl } #";
            Console.WriteLine(req.RawUrl);
            Console.WriteLine(cont_);
            byte[]data = UnicodeEncoding.UTF8.GetBytes(cont_);
            resp.ContentType = "text/html";
            resp.ContentEncoding = Encoding.UTF8;
            resp.ContentLength64 = data.LongLength;
            resp.OutputStream.Write(data, 0, data.Length);
            resp.Close();
        }
    }
}
