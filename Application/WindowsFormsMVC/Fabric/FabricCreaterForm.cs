using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMVC.Controller;
using WindowsFormsMVC.Infrastructure;

namespace WindowsFormsMVC.Fabric
{
public enum FabricType
        {
            Main=0,
            CreateOutleetModel=1,
            UpdateOutleetModel=2
        }
    public class FabricCreaterForm
    {
        
        
        public static System.Windows.Forms.Form CreateForm(FabricType fabricType,object Object=null)
        {
            /*switch (fabricType)
            {
                case FabricType.Main:
                    return new Form1(new MainController());

                default:
                    return null;
            }*/
            AbstarctFabricCreater creater = null;
            if(Object !=null)
            {
                creater=new FabricFormWithDataTransfer(fabricType,Object);  
            }
            else
            {
                creater =new FabricFormWithoutDataTransfer(fabricType);
            }
            return creater.CreateForm();

        }
    }
}
