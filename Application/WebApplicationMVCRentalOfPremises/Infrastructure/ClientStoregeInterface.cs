namespace WebApplicationMVCRentalOfPremises.Infrastructure
{
    public interface ClientStoregeInterface
    {
        void AddClient(Models.ClientsModel client);
        void AddClientDetails(Models.CustomerDetailsModel customerDetails);
        Models.ClientsModel GetClientModelById(int id);
        int get_clients_count();
        List<Models.ClientsModel> get_k_n_list_client(int k, int n);
        List<(Models.CustomerDetailsModel,Models.ClientsModel)> get_k_n_list_client_details(int k, int n);
        (Models.ClientsModel, Models.CustomerDetailsModel) get_full_info_by_id_client(int id);
        List<Models.CustomerDetailsModel> get_details_by_client_id(int client_id);
    }
}
