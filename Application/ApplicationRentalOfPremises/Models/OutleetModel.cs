using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Models
{
    public class OutletModelErrorStatus
    {
        public bool StoreyStatus { get; set; }
        public bool AreaStatus { get; set; }
        public bool PresenceOfAirConditioningStatus { get; set; }
        public bool RentalCostPerDayStatus { get; set; }
        public bool AllocatedPowerKilowattsStatus { get; set; }
        public bool NumberOfWindowsStatus { get; set; }
        public void RunExceptionIFNotSUCCESS()
        {
            /*if (!StoreyStatus || !AreaStatus || !PresenceOfAirConditioningStatus || !RentalCostPerDayStatus
                ||!AllocatedPowerKilowattsStatus||!NumberOfWindowsStatus)
                throw new Exception();*/
            bool stats = true;
            string[] names = {(string)nameof(StoreyStatus),nameof(AreaStatus),nameof(PresenceOfAirConditioningStatus),
            nameof(RentalCostPerDayStatus),nameof(AllocatedPowerKilowattsStatus),nameof(NumberOfWindowsStatus)};
            bool[] s =
            {
                StoreyStatus,AreaStatus,PresenceOfAirConditioningStatus,
                RentalCostPerDayStatus,AllocatedPowerKilowattsStatus,NumberOfWindowsStatus
            };
            for (int i = 0; i < s.Length; i++)
                if (!s[i])
                {
                    stats = false;
                    Console.WriteLine($"valid error:{names[i]}");
                }
            if (!stats)
                throw new Exception();
        }
    }
    /// <summary>
    /// Торговая точка
    /// </summary>
    public class OutleetModel:OutleetSmallModel
    {
        //[Required]
        
       /*
        public int Storey { get; private set; }
        public void SetStorey(int St)
        {
            if (!ValidStorey(St))
                throw new ArgumentException(nameof(Storey));
            this.Storey = St;
            //return 0;
        }
        public bool ValidStorey(int st)
        {
            if (st < -1)
                return false;
            // SetStorey(st);  
            return true;
        }*/
        /// <summary>
        /// Площадь помещения
        /// </summary>
        //[Required]
        //[Range(0,int.MaxValue)]
        public int Area { get; set; }
        public void SetArea(int area)
        {
            /*if (Area < 0)
                return -1;*/
            this.Area = area;
            if (!ValidArea(area))
                throw new ArgumentException(nameof(Area));
            //return 0;
        }
        public static bool ValidArea(int area)
        {
            if (area <= 0)
                return false;
            // SetArea(area);
            return true;
        }
        /// <summary>
        /// Наличие кондиционера
        /// </summary>
        //[Required]
        //[Range(0, 1)]
        public short PresenceOfAirConditioning { get; set; }
        public void SetPresenceOfAirConditioning(short POAC)
        {
            /*if (POAC > 1 || POAC < 0)
                return -1;*/
            if (!ValidPresenceOfAirConditioning(POAC))
                throw new ArgumentException(nameof(POAC));
            this.PresenceOfAirConditioning = POAC;
            //return 0;
        }
        public static bool ValidPresenceOfAirConditioning(short POAC)
        {
            if (POAC > 1 || POAC < 0)
                return false;
            // SetPresenceOfAirConditioning(POAC);
            return true;
        }
        /// <summary>
        /// Стоимость аренды в день
        /// </summary>
        //[Required]
        //[Range(0, int.MaxValue)]
        /*public decimal RentalCostPerDay { get; private set; }
        public void SetRentalCostPerDay(decimal RCPD)
        {
            
            if (!ValidRentalCostPerDay(RCPD))
                throw new ArgumentException(nameof(RentalCostPerDay));
            this.RentalCostPerDay = RCPD;
          
        }
        public bool ValidRentalCostPerDay(decimal RCPD)
        {
            if (RCPD < 0)
                return false;
            // SetRentalCostPerDay(RCPD);
            return true;
        }*/
        /// <summary>
        /// Число выделенных киловат
        /// </summary>
        public double AllocatedPowerKilowatts { get; set; }
        public void SetAllocatedPowerKilowatts(double AllocatedPowerKilowatts)
        {
            if (!ValidAllocatedPowerKilowatts(AllocatedPowerKilowatts))
                throw new ArgumentException(nameof(AllocatedPowerKilowatts));
            this.AllocatedPowerKilowatts = AllocatedPowerKilowatts;
        }
        public static bool ValidAllocatedPowerKilowatts(double AllocatedPowerKilowatts)
        {
            if (AllocatedPowerKilowatts <= 0)
                return false;
            //this.AllocatedPowerKilowatts = AllocatedPowerKilowatts;
            return true;
        }

        /// <summary>
        /// Число окон
        /// </summary>
        public int NumberOfWindows { get;  set; }
        public void SetNumberOfWindows(int NOW)
        {
            if (!ValidNumberOfWindows(NOW))
                throw new ArgumentException(nameof(NumberOfWindows));
            this.NumberOfWindows = NOW;
        }
        public static bool ValidNumberOfWindows(int NumberOfWindows)
        {
            if (NumberOfWindows < 0)
                return false;
            //this.NumberOfWindows = NumberOfWindows;
            return true;
        }
        public OutleetModel() { }
        public OutleetModel( int Storey, int Area, short PresenceOfAirConditining, decimal RentalCostPerDay,
            double AllocatedPowerKilowatts_, int NumberOfWindows_
            ,int InventoryNumber,
            //out OutletModelErrorStatus errors, 
            int? ID = null):base(Storey,InventoryNumber,RentalCostPerDay,ID)
        {
           
            
            //SetID(ID);
            //SetStorey(Storey);
            SetArea(Area);
            SetPresenceOfAirConditioning(PresenceOfAirConditining);
            //SetRentalCostPerDay(RentalCostPerDay);
            SetAllocatedPowerKilowatts(AllocatedPowerKilowatts_);

        }
        
        
       
        public override string ToString()
        {
            return $"{nameof(ID)}:{ID},{nameof(Storey)}:{Storey},{nameof(Area)}:{Area}," +
                $"{nameof(PresenceOfAirConditioning)}:{PresenceOfAirConditioning}," +
                $"{nameof(RentalCostPerDay)}:{RentalCostPerDay},"+
                $"{nameof(InventoryNumber)}:{InventoryNumber}," +
                $"{nameof(AllocatedPowerKilowatts)}:{AllocatedPowerKilowatts}," +
                $"{nameof(NumberOfWindows)}:{NumberOfWindows}"
                ;
        }
        public static bool operator ==(OutleetModel lhs, OutleetModel rhs) =>  lhs.Storey == lhs.Storey
            && lhs.Area == rhs.Area && lhs.RentalCostPerDay == rhs.RentalCostPerDay && lhs.PresenceOfAirConditioning == rhs.PresenceOfAirConditioning
            && lhs.AllocatedPowerKilowatts == rhs.AllocatedPowerKilowatts && lhs.NumberOfWindows == rhs.NumberOfWindows&&rhs.InventoryNumber == rhs.InventoryNumber
            ;
        public static bool operator !=(OutleetModel lhs, OutleetModel rhs) => !(lhs == rhs);
        public static bool ValidOutleetModel(OutleetModel outleetModel)
        {
            if(!ValidSmallOutleetModel(outleetModel)) return false;     
            if(!ValidPresenceOfAirConditioning(outleetModel.PresenceOfAirConditioning)) return false;
            if(!ValidNumberOfWindows(outleetModel.NumberOfWindows)) return false;
            if(!ValidAllocatedPowerKilowatts(outleetModel.AllocatedPowerKilowatts))return false;
            if(!ValidArea(outleetModel.Area)) return false;

            return true;
        }
    }
}
