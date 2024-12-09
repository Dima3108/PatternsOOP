using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ApplicationRentalOfPremises;
namespace WindowsFormsMVC
{
    /*
     * https://gist.github.com/define-private-public/d05bc52dd0bed1c4699d49e2737e80e7
     */
    internal static class Program
    {
        public static HttpListener listener;
        public static async Task HandleIncomingConnections()
        {
            int pageViews = 0;
            int requestCount = 0;
            string pageData =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>HttpListener Example</title>" +
            "  </head>" +
            "  <body>" +
            "    <p>Page Views: {0}</p>" +
            "    <form method=\"post\" action=\"shutdown\">" +
            "      <input type=\"submit\" value=\"Shutdown\" {1}>" +
            "    </form>" +
            "  </body>" +
            "</html>";
            bool runServer = true;

            // While a user hasn't visited the `shutdown` url, keep on handling requests
            while (runServer)
            {
                // Will wait here until we hear from a connection
                //HttpListenerContext ctx = await listener.GetContextAsync();
                MyHttpRouter.Route(await listener.GetContextAsync());

                // Peel out the requests and response objects
                //HttpListenerRequest req = ctx.Request;
               // HttpListenerResponse resp = ctx.Response;

                // Print out some info about the request
                /*Console.WriteLine("Request #: {0}", ++requestCount);
                Console.WriteLine(req.Url.ToString());
                Console.WriteLine(req.HttpMethod);
                Console.WriteLine(req.UserHostName);
                Console.WriteLine(req.UserAgent);
                Console.WriteLine();*/

                // If `shutdown` url requested w/ POST, then shutdown the server after serving the page
                /*if ((req.HttpMethod == "POST") && (req.Url.AbsolutePath == "/shutdown"))
                {
                    Console.WriteLine("Shutdown requested");
                    runServer = false;
                }*/

                // Make sure we don't increment the page views counter if `favicon.ico` is requested
                /*if (req.Url.AbsolutePath != "/favicon.ico")
                    pageViews += 1;*/

                // Write the response info
                /*string disableSubmit = !runServer ? "disabled" : "";
                byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, pageViews, disableSubmit));
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;*/

                // Write out to the response stream (asynchronously), then close it
                //await resp.OutputStream.WriteAsync(data, 0, data.Length);
                //resp.Close();
            }
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //#if DEBUG
            Data.SeedData.SetOutleetStoregeIntrafce(ApplicationRentalOfPremises.Program.CreateStorege());
#if DEBUG
            Console.WriteLine(Data.SeedData.outleetStoregeIntrafce.get_count());
#endif
            //#endif
            Task t = Task.Run(delegate
            {
                #region НазначениеЗамов
                Web.GuardianOfDeputies.AddDeputy(new Web.Deputies.DeputyModels());
                var m = new Web.Deputies.ChiefDeputy();
                Web.GuardianOfDeputies.AddDeputy(m.scrollingSubstitute);
                Web.GuardianOfDeputies.AddDeputy(m);
                #endregion
                string url = "http://localhost:4444/";
                //System.Net.HttpListener 
                listener = new System.Net.HttpListener();
                listener.Prefixes.Add(url);
                listener.Start();

                Console.WriteLine("Listening for connections on {0}", url);
                // Handle requests
                Task listenTask = HandleIncomingConnections();
                listenTask.GetAwaiter().GetResult();

                // Close the listener
                listener.Close();
            });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            Application.Run(Fabric.FabricCreaterForm.CreateForm(Fabric.FabricType.Main));
            // IISHandler1 iISHandler1=new IISHandler1();
            t.Wait();
        }
    }
}
