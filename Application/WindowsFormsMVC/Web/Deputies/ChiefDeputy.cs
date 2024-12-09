using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVC.Web.Deputies
{
    public class ChiefDeputy : AbstractTemplateDeputy
    {
        public HomePageScrollingSubstitute scrollingSubstitute { get; }
        public ChiefDeputy()
        {
            scrollingSubstitute = new HomePageScrollingSubstitute(controller);
        }
        Controller.MainController controller = new Controller.MainController();
        /*public  void AttemptToProcess(string url,ref HttpListenerRequest req,ref HttpListenerResponse resp)
        {
            var models = controller.GetModels();

            string content = "<!DOCTYPE html>" +
                "              <html>" +
                "                   <head>" +
                "                         <meta charset='utf-8'>" +
                "                   </head>" +
                "                   <body>" +
                "                          <div>" +
                "                              <table>";
            Console.WriteLine($"{nameof(ChiefDeputy)}-count_rows:{models.Count}");

            for (int i = 0; i < models.Count; i++)
            {

                content += "<tr>\n";
                foreach (var column in models[i])
                {
                    if (i != 0)
                    {
                        content += $"<td>{column.ToString()}</td>\n";
                    }
                    else
                    {
                        content += $"<th>{column.ToString()}</th>\n";
                    }
                }
                if (i > 0)
                {
                    content += $"<td>" +
                        $"           <a href={'"'}/models/openbyid?id='{models[i][0]}'{'"'}>Открыть</a>" +
                        $"       </td>";
                }
                content += "</tr>\n";
            }
            content += "                        </table>" +
                "                          </div>" +
                "                   </body>" +
                       "        </html>";
            byte[] data = UnicodeEncoding.UTF8.GetBytes(content);
            resp.ContentType = "text/html";
            resp.ContentEncoding = Encoding.UTF8;
            resp.ContentLength64 = data.LongLength;
            resp.OutputStream.Write(data, 0, data.Length);
            resp.Close();
        }*/
        public override bool ComplianceCheck(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp)
        {
            return true;
        }
        public override string RenderBody(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp)
        {
            var models = controller.GetModels();
            string content = ""+
            "                          <div>" +
                "                              <table>";
            Console.WriteLine($"{nameof(ChiefDeputy)}-count_rows:{models.Count}");

            for (int i = 0; i < models.Count; i++)
            {

                content += "<tr>\n";
                foreach (var column in models[i])
                {
                    if (i != 0)
                    {
                        content += $"<td>{column.ToString()}</td>\n";
                    }
                    else
                    {
                        content += $"<th>{column.ToString()}</th>\n";
                    }
                }
                if (i > 0)
                {
                    content += $"<td>" +
                        $"           <a href={'"'}/models/openbyid?inv={models[i][1]}{'"'}>Открыть</a>" +
                        $"       </td>";
                }
                content += "</tr>\n";
            }
            content += "                        </table>" +
                "                          </div>";
            return content;
        }
    }
}
