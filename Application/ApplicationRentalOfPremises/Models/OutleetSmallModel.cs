using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Models
{
    public class OutleetSmallModel:Infrastructure.OutleetModelInterface
    {
        
        public OutleetSmallModel(int Storey,int InventoryNumber,decimal RentalCostPerDay)
        {
            SetStorey(Storey);
            SetInventoryNumber(InventoryNumber);
            SetRentalCostPerDay(RentalCostPerDay);
        }
        /// <summary>
        /// Этаж
        /// </summary>
        protected int Storey { get; set; }
        public int GetStorey() => Storey;
        public bool ValidStorey(int st)
        {
            if(st<-1)
                return false;
            return true;
        }
        public void SetStorey(int st)
        {
            if (!ValidStorey(st))
                throw new ArgumentException(nameof(Storey));
        }
        protected int InventoryNumber {  get; set; }    
        public int GetInventoryNumber() => InventoryNumber;
        public bool ValidInventoryNumber(int numb)
        {
            return numb >= 0;
        } 
        public void SetInventoryNumber(int numb)
        {
            if(!ValidInventoryNumber(numb))
                throw new ArgumentException(nameof(InventoryNumber));
            InventoryNumber = numb;
        }
        /// <summary>
        /// Стоимость аренды в день
        /// </summary>
        protected decimal RentalCostPerDay {  get; set; }
        public decimal GetRentalCostPerDay() => RentalCostPerDay;
        public bool ValidRentalCostPerDay(decimal rcpd) => rcpd > 0;
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
                $"{nameof(Storey)}:{Storey}";
        }
    }
}
