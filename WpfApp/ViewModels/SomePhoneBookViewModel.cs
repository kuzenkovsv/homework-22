using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using PhoneBookEntitiesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class SomePhoneBookViewModel
    {
        /// <summary>
        /// Удаление контакта
        /// </summary>
        private RelayCommand delCommandCont;
        public RelayCommand DelCommandCont
        {
            get
            {
                return delCommandCont ??
                  (delCommandCont = new RelayCommand(obj =>
                  {
                      DataApi context = new DataApi();

                      SomePhoneBook somePhoneBook = obj as SomePhoneBook;

                      //SignInManager<IdentityUser> SignInManager;
                      //UserManager<IdentityUser> UserManager;

                      //if (SignInManager<IdentityUser>.IsSignedIn(User))
                      //{
                          if (somePhoneBook.SomePb.SelectedItem is Contact data)
                          {

                              try
                              {
                                  context.DelContact(data.ContactID, data.PhoneBookID);
                              }
                              catch (Exception e3)
                              {
                                  MessageBox.Show($"{e3.Message}", "Ошибка удаления контакта !", MessageBoxButton.OK, MessageBoxImage.Information);
                              }

                              MessageBox.Show($"Контакт удалён. После закрытия данного окна нажмите кнопку обновить",
                                  $"Успешное удаление",
                                      MessageBoxButton.OK, MessageBoxImage.Information);

                              //somePhoneBook.SomePb.ItemsSource = context.GetContactsByIdPb(data.PhoneBookID);
                          }
                          else
                          {
                              MessageBox.Show("Нужно выбрать контакт для удаления!");
                          }
                      //}
                      //else
                      //{
                      //    MessageBox.Show($"Для выполнения данного действия необходимо войти в свой аккаунт",
                      //      $"Ошибка авторизации",
                      //          MessageBoxButton.OK, MessageBoxImage.Information);

                          
                      //}
                      
                  }
                  ));
            }
        }

        /// <summary>
        /// Посмотреть контакт
        /// </summary>
        private RelayCommand watchCommandCont;
        public RelayCommand WatchCommandCont
        {
            get
            {
                return watchCommandCont ??
                  (watchCommandCont = new RelayCommand(obj =>
                  {
                      ContactDetailViewModel contactDetailViewModel = new ContactDetailViewModel();
                      ContactDetail ContDet = new ContactDetail(contactDetailViewModel);
                      DataApi context = new DataApi();

                      if (obj is Contact data)
                      {
                          ContDet.Title = $"Контакт с id-{data.ContactID}";
                          ContDet.contId = data.ContactID;
                          ContDet.pbId = data.PhoneBookID;
                          ContDet.CoD.ItemsSource = context.GetContact(data.ContactID);
                          try
                          {
                              //ContDet.DataContext = context.GetContact(data.ContactID);
                              ContDet.DetailContactID.Text = data.ContactID.ToString();
                              ContDet.ContSurname.Text = data.Surname;
                              ContDet.ContName.Text = data.Name;
                              ContDet.ContMiddleName.Text = data.MiddleName;
                              ContDet.ContPhoneNumber.Text = data.PhoneNumber;
                              ContDet.ContAddress.Text = data.Address;
                              ContDet.ContDescription.Text = data.Description;


                          }
                          catch (Exception e2)
                          {
                              MessageBox.Show($"{e2.Message}", "Ошибка просмтра контакта!", MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                          ContDet.ShowDialog();

                      }

                  }
                  ));
            }
        }

        /// <summary>
        /// Добавить контакт
        /// </summary>
        private RelayCommand addCommandCont;
        public RelayCommand AddCommandCont
        {
            get
            {
                return addCommandCont ??
                  (addCommandCont = new RelayCommand(obj =>
                  {
                      AddContactViewModel addContactViewModel = new AddContactViewModel();
                      AddContact addCont = new AddContact(addContactViewModel);
                      DataApi context = new DataApi();

                      if (obj is Contact data)
                      {
                          addCont.Title = $"Создпние контакта телефонной книги с id-{data.PhoneBookID}";


                          try
                          {
                              addCont.pbId = data.PhoneBookID;
                          }
                          catch (Exception e2)
                          {
                              MessageBox.Show($"{e2.Message}", "Какая-то ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                          addCont.ShowDialog();

                      }

                  }
                  ));
            }
        }


        /// <summary>
        /// Обновить контакты
        /// </summary>
        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ??
                  (refresh = new RelayCommand(obj =>
                  {

                      DataApi context = new DataApi();

                      SomePhoneBook somePhoneBook = obj as SomePhoneBook;

                      somePhoneBook.SomePb.ItemsSource = context.GetContactsByIdPb(somePhoneBook.pbID);

                  }

                  ));
            }
        }



    }
}
