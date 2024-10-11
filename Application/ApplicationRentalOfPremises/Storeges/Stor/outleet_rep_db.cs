using ApplicationRentalOfPremises.Storeges.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges.Stor
{
    public class outleet_rep_db:outleet_storege_strategy
    {
        public outleet_rep_db(outleetmodel_pattern_DB db) : base(db) { }
    }
}
