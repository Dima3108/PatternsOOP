using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVC.Web
{
    public interface RequestHandlerDeputyInterface
    {
       // RequestHandlerDeputyInterface RequestHandlerDeputy { get; }
        /// <summary>
        /// Попытатся обработать запрос , иначе передать заместителю , либо вернуть ошибку
        /// </summary>
        /// <param name="req"></param>
        /// <param name="resp"></param>
        void AttemptToProcess(string url,ref HttpListenerRequest req,ref HttpListenerResponse resp);
        /// <summary>
        /// Назначение заместителя , если заместитель уже есть , то назначить заместителя зама.
        /// </summary>
        /// <param name="deputy"></param>
        void AppointADeputy(RequestHandlerDeputyInterface deputy);
    }
}
