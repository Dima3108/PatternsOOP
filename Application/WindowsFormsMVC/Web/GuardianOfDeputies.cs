using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMVC.Web.Deputies;

namespace WindowsFormsMVC.Web
{
    public static class GuardianOfDeputies
    {
        public static AbstractTemplateDeputy RequestHandlerDeputy { get; private set; } = null;
        public static void AddDeputy(AbstractTemplateDeputy requestHandlerDeputy)
        {

            if (RequestHandlerDeputy is null)
            {
                RequestHandlerDeputy = requestHandlerDeputy;
            }
            else
            {
                RequestHandlerDeputy.AppointADeputy(requestHandlerDeputy);
            }
        }
    }
}
