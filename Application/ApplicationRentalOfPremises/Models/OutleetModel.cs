﻿using System;
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
        public bool StoreyStatus {  get; set; } 
        public bool AreaStatus {  get; set; }   
        public bool PresenceOfAirConditioningStatus {  get; set; }  
        public bool RentalCostPerDayStatus {  get; set; }   
        public void RunExceptionIFNotSUCCESS()
        {
            if (!StoreyStatus || !AreaStatus || !PresenceOfAirConditioningStatus || !RentalCostPerDayStatus)
                throw new Exception();
        }
    }
    /// <summary>
    /// Торговая точка
    /// </summary>
    public class OutletModel
    {
        [Required]
        public int ID {  get; set; }
        public void SetID(int id)=>this.ID = id;
        /// <summary>
        /// Этаж
        /// </summary>
        //[Required]
        public int Storey {  get; set; }
        private void SetStorey(int St)
        {
            this.Storey = St;
            //return 0;
        }
        public bool ValideAndSetStorey(int st)
        {
            SetStorey(st);  
            return true;
        }
        /// <summary>
        /// Площадь помещения
        /// </summary>
        //[Required]
        //[Range(0,int.MaxValue)]
        public int Area {  get; set; }
        private void SetArea(int area)
        {
            /*if (Area < 0)
                return -1;*/
            this.Area = area;
            //return 0;
        }
        public bool ValideAndSetArea(int area)
        {
            if (Area < 0)
                return false;
            SetArea(area);
            return true;
        }
        /// <summary>
        /// Наличие кондиционера
        /// </summary>
        //[Required]
        //[Range(0, 1)]
        public short PresenceOfAirConditioning {  get; set; }
        private void SetPresenceOfAirConditioning(short POAC)
        {
            /*if (POAC > 1 || POAC < 0)
                return -1;*/
            this.PresenceOfAirConditioning = POAC;
            //return 0;
        }
        public bool ValideAndSetPresenceOfAirConditioning(short POAC)
        {
            if (POAC > 1 || POAC < 0)
                return false;
            SetPresenceOfAirConditioning(POAC);
            return true;
        }
        /// <summary>
        /// Стоимость аренды в день
        /// </summary>
        //[Required]
        //[Range(0, int.MaxValue)]
        public int RentalCostPerDay {  get; set; }  
        private void SetRentalCostPerDay(int RCPD)
        {
            /*if (RCPD < 0)
                return -1;*/
            this.RentalCostPerDay = RCPD;
           // return 0;
        }
        public bool ValideAndSetRentalCostPerDay(int RCPD)
        {
            if(RCPD < 0)
                return false;
            SetRentalCostPerDay(RCPD);
            return true;
        }
        public OutletModel(int ID,int Storey,int Area,short PresenceOfAirConditining,int RentalCostPerDay,out OutletModelErrorStatus errors)
        {
            errors = new OutletModelErrorStatus();
            errors.StoreyStatus = ValideAndSetStorey(Storey);
            errors.AreaStatus=ValideAndSetArea(Area);
            errors.PresenceOfAirConditioningStatus=ValideAndSetPresenceOfAirConditioning(PresenceOfAirConditining);
            errors.RentalCostPerDayStatus = ValideAndSetRentalCostPerDay(RentalCostPerDay);
            SetID(ID);
        }
        /*public OutletModel(string json)
        {

        }*/
        public void PrintFullObject()
        {
            Console.WriteLine($"{nameof(ID)}:{ID},{nameof(Storey)}:{Storey},{nameof(Area)}:{Area}," +
                $"{nameof(PresenceOfAirConditioning)}:{PresenceOfAirConditioning}," +
                $"{nameof(RentalCostPerDay)}:{RentalCostPerDay}");
        }
        public void PrintSmallObject()
        {
            Console.WriteLine($"{ID},{Storey},{Area}," +
                $"{PresenceOfAirConditioning}," +
                $"{RentalCostPerDay}");
        }
        public static bool operator==(OutletModel lhs, OutletModel rhs)=>lhs.ID==rhs.ID&&lhs.Storey==lhs.Storey
            && lhs.Area==rhs.Area&&lhs.RentalCostPerDay==rhs.RentalCostPerDay&&lhs.PresenceOfAirConditioning==rhs.PresenceOfAirConditioning;
        public static bool operator !=(OutletModel lhs, OutletModel rhs) => !(lhs == rhs);
    }
}
