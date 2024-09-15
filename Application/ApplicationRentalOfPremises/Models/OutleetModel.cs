using System;
using System.Collections.Generic;
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
        public int ID {  get; set; }
        /// <summary>
        /// Этаж
        /// </summary>
        public int Storey {  get; set; }  
        /// <summary>
        /// Площадь помещения
        /// </summary>
        public int Area {  get; set; }
        /// <summary>
        /// Наличие кондиционера
        /// </summary>
        public short PresenceOfAirConditioning {  get; set; }  
        /// <summary>
        /// Стоимость аренды в день
        /// </summary>
        public int RentalCostPerDay {  get; set; }  
    }
}
