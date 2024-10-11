using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges.Reps
{
    public class outleetmodel_fasade_rep_yaml:FileStorege
    {
        public outleetmodel_fasade_rep_yaml(string f_name):base(f_name,new Parsers.YamlOutleetModelParser())
        {

        }
    }
}
