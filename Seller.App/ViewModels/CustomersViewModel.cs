using BLL.Dtos.CustomerDtos;
using System.Collections.ObjectModel;

namespace Seller.App.ViewModels
{
    public class CustomerViewModel
    {
        public ObservableCollection<CustomerViewDto> Customers = 
            new ObservableCollection<CustomerViewDto>();

        public CustomerViewModel()
        {

        }
    }
}
