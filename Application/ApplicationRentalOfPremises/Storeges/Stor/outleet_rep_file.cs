using ApplicationRentalOfPremises.Storeges.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges.Stor
{
    public class outleet_rep_file : outleet_storege_strategy
    {
        public outleet_rep_file(FileStorege fileStorege) : base(new outleetmodel_cesh_adapter(fileStorege))
        {
        }
    }
}
