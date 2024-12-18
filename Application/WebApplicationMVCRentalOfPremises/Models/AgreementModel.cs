using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVCRentalOfPremises.Models
{
    public class AgreementModel
    {
        public int ID { get; set; } 
        public int OUTLEET_ID {  get; set; }    
        public int CLIENT_ID {  get; set; }
        [Required(ErrorMessage ="Поле должно быть заполнено")]
        [Remote(controller:"Agreement",action: "VerifyStartDate",AdditionalFields =nameof(AgreementModel.OUTLEET_ID),ErrorMessage ="В выбранную дату помещение уже забраннировано")]
        public DateTime DateStart { get; set; }
		[Required(ErrorMessage = "Поле должно быть заполнено")]
		[Remote(controller: "Agreement", action: "VerifyStopDate", AdditionalFields = nameof(AgreementModel.OUTLEET_ID), ErrorMessage = "В выбранную дату помещение уже забраннировано")]
        public DateTime DateStop { get; set; }  
    }
}
