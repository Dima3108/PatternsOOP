using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Models
{
    /// <summary>
    /// Торговая точка
    /// </summary>
    public class OutletModel
    {
        [Required]
        public int ID {  get; set; }
        /// <summary>
        /// Этаж
        /// </summary>
        [Required]
        public int Storey {  get; set; }
        public int SetStorey(int St)
        {
            this.Storey = St;
            return 0;
        }
        /// <summary>
        /// Площадь помещения
        /// </summary>
        [Required]
        //[Range(0,int.MaxValue)]
        public int Area {  get; set; }
        public int SetArea(int area)
        {
            if (Area < 0)
                return -1;
            this.Area = area;
            return 0;
        }
        /// <summary>
        /// Наличие кондиционера
        /// </summary>
        [Required]
        [Range(0, 1)]
        public short PresenceOfAirConditioning {  get; set; }
        public int SetPresenceOfAirConditioning(short POAC)
        {
            if (POAC > 1 || POAC < 0)
                return -1;
            this.PresenceOfAirConditioning = POAC;
            return 0;
        }
        /// <summary>
        /// Стоимость аренды в день
        /// </summary>
        [Required]
        //[Range(0, int.MaxValue)]
        public int RentalCostPerDay {  get; set; }  
        public int SetRentalCostPerDay(int RCPD)
        {
            if (RCPD < 0)
                return -1;
            this.RentalCostPerDay = RCPD;
            return 0;
        }
        public OutletModel(int ID,int Storege,int Area,short PresenceOfAirConditining,int RentalCostPerDay)
        {
            int p = 1;
          int  error=  SetStorey(Storege);
           error+=-1*((int)(Math.Pow(2,p++)))* SetArea(Area);
            error += -1 * ((int)(Math.Pow(2, p++))) * SetPresenceOfAirConditioning(PresenceOfAirConditining);
            error += -1 * ((int)(Math.Pow(2, p++))) * SetRentalCostPerDay(RentalCostPerDay);

        }
       
    }
}
