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
        /// <summary>
        /// Площадь помещения
        /// </summary>
        [Required]
        [Range(0,int.MaxValue)]
        public int Area {  get; set; }
        /// <summary>
        /// Наличие кондиционера
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public short PresenceOfAirConditioning {  get; set; }
        /// <summary>
        /// Стоимость аренды в день
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int RentalCostPerDay {  get; set; }  
    }
}
