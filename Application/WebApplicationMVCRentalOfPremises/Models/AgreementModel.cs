namespace WebApplicationMVCRentalOfPremises.Models
{
    public class AgreementModel
    {
        public int ID { get; set; } 
        public int OUTLEET_ID {  get; set; }    
        public int CLIENT_ID {  get; set; } 
        public DateTime DateStart { get; set; }
        public DateTime DateStop { get; set; }  
    }
}
