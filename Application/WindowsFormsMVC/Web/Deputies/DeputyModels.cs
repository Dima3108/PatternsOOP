using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVC.Web.Deputies
{
    public class DeputyModels : AbstractTemplateDeputy
    {
        //Controller.MainController controller = new Controller.MainController();
        const string url_pattern = "/models";
        private Controller.ControllerOutleetModelGettrs controller=new Controller.ControllerOutleetModelGettrs();
        public override bool ComplianceCheck(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp)
        {
            return url.Contains(url_pattern);
        }
        /* public void AttemptToProcess(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp)
         {
             Console.WriteLine($"url:#{url}#");
             if (!url.Contains(url_pattern))
             {
                 if (RequestHandlerDeputy is null == false)
                 {
                     RequestHandlerDeputy.AttemptToProcess(url,ref req,ref resp);
                 }
                 else
                 {
                     resp.StatusCode = 404;
                     resp.Close();
                 }
             }
             else
             {

                 {
                     var id=req.Headers["id"];
                     var model=Data.SeedData.outleetStoregeIntrafce.GetModelById(int.Parse(id));
                     string content = $"<!DOCTYPE html>" +
                         $"              <html>" +
                         $"                   <body>" +
                         $"                        <div>{model.ID}</div>" +
                         $"                        <div>{model.NumberOfWindows}</div>" +
                         $"                        <div>{model.Area}</div>" +
                         $"                        <div>{model.AllocatedPowerKilowatts}</div>" +
                         $"                        <div>{model.InventoryNumber}</div>" +
                         $"                        <div>{model.PresenceOfAirConditioning}</div>" +
                         $"                        <div>{model.RentalCostPerDay}</div>" +
                         $"                        <div>{model.Storey}</div>" +
                         $"                    </body>" +
                         $"              </html>";
                     byte[] data = UnicodeEncoding.UTF8.GetBytes(content);
                     resp.ContentType = "text/html";
                     resp.ContentEncoding = Encoding.UTF8;
                     resp.ContentLength64 = data.LongLength;
                     resp.OutputStream.Write(data, 0, data.Length);
                 }

  resp.Close();
             }
         }*/
        public override string RenderBody(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp)
        {
            Console.WriteLine($"{nameof(DeputyModels)}:#{url}#");
            var collectkeys = req.QueryString.AllKeys;
            var coolectvalspair=new List<string>();
            foreach (var key in collectkeys)
            {
                foreach(var value in req.QueryString.GetValues(key))
                {
                    //coolectvalspair.Add(key+":"+value.ToString());
                    Console.WriteLine($"{key}:{value}");
                }
            }
            var id = req.QueryString.GetValues("inv")[0];
            var model =controller.GetModelByInventoryNumber(id);
            if (model == null) {
                return $"<strong>Отсутствует сущность с указанным инвертарным номером!({id})</strong>";
            }
            else
            {
                // Data.SeedData.outleetStoregeIntrafce.GetModelByInventoryNumber(int.Parse(id));
                string content = $"           <div>{model.ID}</div>" +
                    $"                        <div>{model.NumberOfWindows}</div>" +
                    $"                        <div>{model.Area}</div>" +
                    $"                        <div>{model.AllocatedPowerKilowatts}</div>" +
                    $"                        <div>{model.InventoryNumber}</div>" +
                    $"                        <div>{model.PresenceOfAirConditioning}</div>" +
                    $"                        <div>{model.RentalCostPerDay}</div>" +
                    $"                        <div>{model.Storey}</div>";
                return content;
            }
        }
    }
}
