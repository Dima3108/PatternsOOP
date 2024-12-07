using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVC.Web.Deputies
{
    public abstract class AbstractTemplateDeputy:RequestHandlerDeputyInterface
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
        public abstract void AttemptToProcess(string url,ref HttpListenerRequest req, ref HttpListenerResponse resp);
    }
}
