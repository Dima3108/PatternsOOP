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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CLIENT_ID">ID client</param>
        /// <param name="type">тип документа</param>
        /// <param name="meaningOfThePropsNAME">значение документа</param>
        public CustomerDetailsModel(int CLIENT_ID,string type,string meaningOfThePropsNAME)
        {
            this.client_id = CLIENT_ID;
            this.TYPE = type;
            this.MeaningOfThePropsNAME = meaningOfThePropsNAME;
        }
    }
}
