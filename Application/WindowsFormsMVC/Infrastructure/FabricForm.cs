using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVC.Infrastructure
{
    public abstract class FabricForm:Form
    {
        //protected Infrastructure.SmallOutleetControllerInterface _controller;
       // protected Infrastructure.ModelCreaterInterface modelCreaterInterface;
        protected FabricForm(Infrastructure.SmallOutleetControllerInterface _controllerInterface)
        {
           // _controller = _controllerInterface;
            //modelCreaterInterface = _modelCreaterInterface;
        }
        //public abstract void Show();
    }
}
