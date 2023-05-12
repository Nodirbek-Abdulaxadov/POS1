using BLL.Dtos.CustomerDtos;
using Seller.App.Components;
using Seller.App.Services;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace Seller.App.Pages
{
    public partial class AddCustomer : Window
    {
        Notifier notifier;
        public AddCustomer()
        {
            InitializeComponent(); 

            notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.Windows[Application.Current.Windows.Count-1],
                    corner: Corner.TopLeft,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(3));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name_input.Text) || name_input.Text.Length < 3)
            {
                notifier.ShowError("Ism familiya kamida 3 ta belgidan iborat bo'lishi kerak!");
                return;
            }
            if (string.IsNullOrEmpty(phone_input.Text) || phone_input.Text.Length < 9)
            {
                notifier.ShowError("Telefon raqam kamida 9 ta belgidan iborat bo'lishi kerak!");
                return;
            }

            Thread t = new Thread(Add);
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
        }

        private async void Add()
        {
            await Application.Current.Dispatcher.BeginInvoke(
                  DispatcherPriority.Background,
                  new Action(async () => {
                      try
                      {
                          using var customerService = new CustomerAPIService();
                          var result = await customerService.AddAsync(new AddCustomerDto()
                          {
                              PhoneNumber = phone_input.Text,
                              FullName = name_input.Text
                          });

                          if (result)
                          {
                              new MaterialMessageBox("Ma'lumotlar saqlandi!", MessageType.Success, MessageButtons.Ok)
                                    .ShowDialog();
                              this.Close();
                          }
                          else
                          {
                              notifier.ShowError("Qandaydir xatolik yuz berdi!");
                          }
                      }
                      catch (Exception ex)
                      {
                          notifier.ShowError(ex.Message);
                      }
                  }));
        }
    }
}
