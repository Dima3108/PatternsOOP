using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMVC.Infrastructure;

namespace WindowsFormsMVC.Fabric
{
    public abstract class AbstarctFabricCreater
    {
        protected FabricType _type { get;}
        protected object _object { get; }
        public AbstarctFabricCreater(FabricType type, object Object)
        {
            _type = type;
            _object = Object;
        }
        public abstract System.Windows.Forms.Form CreateForm();
        
    }
}
