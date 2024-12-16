namespace WebApplicationMVCRentalOfPremises.Models
{
    public class CustomerDetailsModel
    {
        public int ID { get; set; } 
        /// <summary>
        /// Тип реквезита
        /// </summary>
        public string TYPE {  get; set; }
        /// <summary>
        /// ЗначениеИмениРеквизита
        /// </summary>
        public string MeaningOfThePropsNAME { get; set; }
        public int client_id {  get; set; } 
    }
}
