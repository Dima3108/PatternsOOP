using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVC.Web.Deputies
{
    /// <summary>
    /// Абстрактный заместитль , содержит шаблонные метода для рендеринга страниц
    /// </summary>
    public abstract  class AbstractTemplateDeputy:RequestHandlerDeputyInterface
    {
        protected RequestHandlerDeputyInterface RequestHandlerDeputy { get; private set; } = null;
        public void AppointADeputy(RequestHandlerDeputyInterface deputy)
        {
            if (RequestHandlerDeputy is null == false)
            {
                RequestHandlerDeputy.AppointADeputy(deputy);
            }
            else
            {
                RequestHandlerDeputy = deputy;
            }
        }
        public abstract bool ComplianceCheck(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp);
        public 
            void AttemptToProcess(string url,ref HttpListenerRequest req, ref HttpListenerResponse resp)
        {
            if(!ComplianceCheck(url,ref req,ref resp))
            {
                if (RequestHandlerDeputy != null)
                {
                    RequestHandlerDeputy.AttemptToProcess(url,ref req,ref resp);
                }
                else
                {
                    resp.StatusCode = 404;
                }
            }
            else
            {
                string content = "<!DOCTYPE html>\n" +
                    "             <html>" +
                    "             <head> " +
                    "                <meta charset='utf-8'>" +
                    "             </head>" +
                    "             <body>" +
                                       RenderBody(url,ref req,ref resp)+
                    "             </body>" +
                    "             </html>";
                byte[] data = UnicodeEncoding.UTF8.GetBytes(content);
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;
                resp.OutputStream.Write(data, 0, data.Length);
                resp.OutputStream.Flush();
                resp.OutputStream.Close();
            }
        }
        public abstract string RenderBody(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp);
    }
}
