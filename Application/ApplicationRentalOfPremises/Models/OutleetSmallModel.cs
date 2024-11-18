using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Models
{
    public class OutleetSmallModel:Infrastructure.OutleetModelInterface
    {
        public int? ID { get; set; }
        public void SetID(int? id) => this.ID = id;
        public OutleetSmallModel(int Storey,int InventoryNumber,decimal RentalCostPerDay,int? id=null)
        {
            SetID(id);
            SetStorey(Storey);
            SetInventoryNumber(InventoryNumber);
            SetRentalCostPerDay(RentalCostPerDay);
        }
        public OutleetSmallModel() { }
        /// <summary>
        /// Этаж
        /// </summary>
        public int Storey { get; set; }
        public int GetStorey() => Storey;
        public static bool ValidStorey(int st)
        {
            if(st<-1)
                return false;
            return true;
        }
        public void SetStorey(int st)
        {
            if (!ValidStorey(st))
                throw new ArgumentException(nameof(Storey));
            this.Storey = st;
        }
        public int InventoryNumber {  get; set; }    
        public int GetInventoryNumber() => InventoryNumber;
        public static bool ValidInventoryNumber(int numb)
        {
           
            return numb >= 0;
        } 
        public  void SetInventoryNumber(int numb)
        {
            if(!ValidInventoryNumber(numb))
                throw new ArgumentException(nameof(InventoryNumber));
            InventoryNumber = numb;
        }
        /// <summary>
        /// Стоимость аренды в день
        /// </summary>
        public decimal RentalCostPerDay {  get; set; }
        public decimal GetRentalCostPerDay() => RentalCostPerDay;
        public static bool ValidRentalCostPerDay(decimal rcpd) => rcpd > 0;
        public static bool ValidSmallOutleetModel(OutleetSmallModel model)
        {
            if(!ValidInventoryNumber(model.InventoryNumber)) return false;
            if(!ValidRentalCostPerDay(model.RentalCostPerDay)) return false;
            if(!ValidStorey(model.Storey)) return false;
            return true;
        }
        public void SetRentalCostPerDay(Decimal rcpd)
        {
            if(!ValidRentalCostPerDay(rcpd))
                throw new ArgumentException(nameof(RentalCostPerDay));
            RentalCostPerDay = rcpd;
        }
        public override string ToString()
        {
            return $"{nameof(RentalCostPerDay)}:{RentalCostPerDay}\n" +
                $"{nameof(InventoryNumber)}:{InventoryNumber}\n" +
                $"{nameof(Storey)}:{Storey}\n";
        }
    }
}
