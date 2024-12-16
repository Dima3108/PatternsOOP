using WebApplicationMVCRentalOfPremises.Models;
using WebApplicationMVCRentalOfPremises.Infrastructure;
namespace WebApplicationMVCRentalOfPremises.Storeges
{
    public class CsehClientStorege:ClientStoregeInterface
    {
        private List<ClientsModel> _clients = new List<ClientsModel>(); 
        private List<CustomerDetailsModel> _customerDetails = new List<CustomerDetailsModel>();
        public  void AddClient(Models.ClientsModel client)
        {
            _clients.Add(client);
        }
        public void AddClientDetails(Models.CustomerDetailsModel customerDetails)
        {
            _customerDetails.Add(customerDetails);
        }
        public Models.ClientsModel GetClientModelById(int id)
        {
            return _clients.Find(t => t.ID == id);
        }
        public List<Models.ClientsModel> get_k_n_list_client(int k, int n)
        {
            int end=Math.Min(k+n, _clients.Count); 
            var cl=new List<Models.ClientsModel>();
            for(int i = k; i < end; i++)
            {
                cl.Add(_clients[i]);    
            }
            return cl;
        }
        public (Models.ClientsModel, Models.CustomerDetailsModel) get_full_info_by_id_client(int id)
        {
            var client=_clients.Find(t => t.ID == id);
            var details=_customerDetails.Find(t=>t.client_id == id);    
            return (client, details);
        }
        public List<(Models.CustomerDetailsModel, Models.ClientsModel)> get_k_n_list_client_details(int k, int n)
        {
            var res = new List<(Models.CustomerDetailsModel, Models.ClientsModel)>();
            int end=Math.Min(k+n,_customerDetails.Count);
            for(int i=k;i< end; i++)
            {
                var det_ = _customerDetails[i];
                var cl_=_clients.Find(t=>t.ID==det_.ID);
                res.Add((det_, cl_));
            }
            return res;
        }
    }
}
