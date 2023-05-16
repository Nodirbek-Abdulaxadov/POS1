using BLL.Dtos.CustomerDtos;
using Seller.App.Services;
using Seller.App.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Seller.App.Pages
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        public CustomerViewModel viewModel;
        private List<CustomerViewDto> customerViewDtos = new List<CustomerViewDto>();

        public Customers()
        {
            InitializeComponent();

            viewModel = new CustomerViewModel();
            customers_table.ItemsSource = viewModel.Customers;
            GetCustomerViews();
        }

        private void search_input_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(search_input.Text))
            {
                viewModel.Customers.Clear();
                foreach (var item in customerViewDtos)
                {
                    viewModel.Customers.Add(item);
                }
            }

            var filteredList = customerViewDtos.Where(c => c.FullName.ToLower()
                .Contains(search_input.Text.ToLower())).ToList();
            FillViewModel(filteredList);
        }

        private void GetCustomerViews()
        {
            using var customerService = new CustomerAPIService();
            var result = customerService.GetCustomers();
            result.Wait();
            var r = result.Result;
            customerViewDtos.Clear();
            customerViewDtos.AddRange(r ?? new List<CustomerViewDto>());
            FillViewModel(customerViewDtos);
        }

        private void new_customer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer customer = new AddCustomer();
            customer.ShowDialog();
            GetCustomerViews();
        }

        private void FillViewModel(List<CustomerViewDto> list)
        {
            viewModel.Customers.Clear();
            foreach (var item in list)
            {
                viewModel.Customers.Add(item);
            }
        }
    }
}