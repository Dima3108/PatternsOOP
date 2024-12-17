using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace WebApplicationMVCRentalOfPremises.Models
{
    public class ClientsModel
    {
        public int ID { get; set; }
        [Required]
        [NotNull]
        [Length(minimumLength:1, maximumLength:45,ErrorMessage ="Недопустимая длина")]
        public string Name { get; set; }
        [Required]
        [NotNull]
        [Length(minimumLength:1,maximumLength:30,ErrorMessage ="Недопустимая длина")]
        public string Phone {  get; set; }
        [Required]
        [NotNull]
        /// <summary>
        /// Контактное лицо
        /// </summary>
        public string ContactPerson {  get; set; }    
        public ClientsModel()
        {

        }
        public ClientsModel(string name, string phone, string contactPerson)
        {
            this.Name = name;
            this.Phone = phone;
            this.ContactPerson = contactPerson;
        }
    }
}
