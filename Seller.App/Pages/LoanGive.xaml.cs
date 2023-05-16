using BLL.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Seller.App.Pages
{
    /// <summary>
    /// Interaction logic for LoanGive.xaml
    /// </summary>
    public partial class LoanGive : Window
    {
        CustomerViewDto customer;

        public LoanGive(CustomerViewDto customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fullName.Text = customer.FullName;
            phoneNumber.Text = customer.PhoneNumber;
        }
    }
}
