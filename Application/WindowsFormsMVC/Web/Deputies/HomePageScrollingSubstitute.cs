using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVC.Web.Deputies
{
    public class HomePageScrollingSubstitute:AbstractTemplateDeputy
    {
        private string[] url_patterns = { "ReduceOffset", "IncreaseOffset" };
        private int status;
        private Controller.MainController controller;
        internal HomePageScrollingSubstitute(Controller.MainController controller)
        {
            this.controller = controller;
        }
        public override bool ComplianceCheck(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp)
        {
            if (req.HttpMethod == "POST")
            {
                for (int i = 0; i < url_patterns.Length; i++)
                {
                    if (url.Contains(url_patterns[i]))
                    {
                        switch (i)
                        {
                            case 0:
                                controller.ReduceOffset(null);
                                break;
                                case 1:
                                controller.IncreaseOffset(null);
                                break;
                        }
                        break;
                    }
                }
            }
            return false;
        }
        public override string RenderBody(string url, ref HttpListenerRequest req, ref HttpListenerResponse resp) => "";
    }
}
