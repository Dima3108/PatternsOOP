using System.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace WebApplicationMVCRentalOfPremises.Models
{
    public class OutleetModel : OutleetSmallModel
    {
        [Display(Name ="ID")]
        public new int? ID { get; set; }
        [Required]
        [Range(-1, int.MaxValue, ErrorMessage = "Значение должно быть больше >=-1")]
        public new int Storey { get; set; }
        [Required]
        [Display(Name = "InventoryNumber")]
        [Remote(action: "VerifyInventoryNumber", controller: "Outleet", AdditionalFields = nameof(ID), ErrorMessage = "Нарушена уникальность")]
        [Range(0, int.MaxValue, ErrorMessage = "Значение должно быть больше >=0")]

        public new int InventoryNumber { get; set; }

        /// <summary>
        /// Площадь помещения
        /// </summary>
        [Required]
        [Range(0, int.MaxValue,ErrorMessage ="Значение должно быть больше >=0")]
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
        [Required]
        [Range(0,1)]
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
        /// Число выделенных киловат
        /// </summary>
        [Required]
        [Range(0.0000001, double.MaxValue, ErrorMessage = "Значение должно быть больше >0")]
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
        [Range(0, int.MaxValue, ErrorMessage = "Значение должно быть больше >=0")]
        [Required]
        public int NumberOfWindows { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Storey">Этаж</param>
        /// <param name="Area">Площадь помещения</param>
        /// <param name="PresenceOfAirConditining">Наличие кондиционера</param>
        /// <param name="RentalCostPerDay">Стоимость аренды в день</param>
        /// <param name="AllocatedPowerKilowatts_">Число выделенных киловат</param>
        /// <param name="NumberOfWindows_">Число окон</param>
        /// <param name="InventoryNumber">Инвертарный номер</param>
        /// <param name="ID"></param>
        public OutleetModel(int Storey, int Area, short PresenceOfAirConditining, decimal RentalCostPerDay,
            double AllocatedPowerKilowatts_, int NumberOfWindows_
            , int InventoryNumber,
            //out OutletModelErrorStatus errors, 
            int? ID = null) : base(Storey, InventoryNumber, RentalCostPerDay, ID)
        {


            //SetID(ID);
            //SetStorey(Storey);
            SetArea(Area);
            SetPresenceOfAirConditioning(PresenceOfAirConditining);
            //SetRentalCostPerDay(RentalCostPerDay);
            SetAllocatedPowerKilowatts(AllocatedPowerKilowatts_);
            SetNumberOfWindows(NumberOfWindows_);
        }



        public override string ToString()
        {
            return $"{nameof(ID)}:{ID},{nameof(Storey)}:{Storey},{nameof(Area)}:{Area}," +
                $"{nameof(PresenceOfAirConditioning)}:{PresenceOfAirConditioning}," +
                $"{nameof(RentalCostPerDay)}:{RentalCostPerDay}," +
                $"{nameof(InventoryNumber)}:{InventoryNumber}," +
                $"{nameof(AllocatedPowerKilowatts)}:{AllocatedPowerKilowatts}," +
                $"{nameof(NumberOfWindows)}:{NumberOfWindows}"
                ;
        }
        public static bool operator ==(OutleetModel lhs, OutleetModel rhs) => lhs.InventoryNumber == rhs.InventoryNumber;  /*lhs.Storey == lhs.Storey
            && lhs.Area == rhs.Area && lhs.RentalCostPerDay == rhs.RentalCostPerDay && lhs.PresenceOfAirConditioning == rhs.PresenceOfAirConditioning
            && lhs.AllocatedPowerKilowatts == rhs.AllocatedPowerKilowatts && lhs.NumberOfWindows == rhs.NumberOfWindows&&rhs.InventoryNumber == rhs.InventoryNumber
            ;*/
        public static bool operator !=(OutleetModel lhs, OutleetModel rhs) => !(lhs == rhs);
        public static bool ValidOutleetModel(OutleetModel outleetModel)
        {
            if (!ValidSmallOutleetModel(outleetModel)) return false;
            if (!ValidPresenceOfAirConditioning(outleetModel.PresenceOfAirConditioning)) return false;
            if (!ValidNumberOfWindows(outleetModel.NumberOfWindows)) return false;
            if (!ValidAllocatedPowerKilowatts(outleetModel.AllocatedPowerKilowatts)) return false;
            if (!ValidArea(outleetModel.Area)) return false;

            return true;
        }
    }

}
