using Microsoft.AspNetCore.Identity;
using PhoneBookEntitiesLib;
using System;
using System.Windows;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    internal class MainWindowViewModel
    {

        /// <summary>
        /// Открыть телефонную книгу
        /// </summary>
        private RelayCommand openSomePb;
        public RelayCommand OpenSomePb
        {
            get
            {
                return openSomePb ??
                  (openSomePb = new RelayCommand(obj =>
                  {
                      SomePhoneBookViewModel somePhoneBookViewModel = new SomePhoneBookViewModel();
                      SomePhoneBook sPb = new SomePhoneBook(somePhoneBookViewModel);
                      DataApi context = new DataApi();

                      if (obj is PhoneBook data)
                      {
                          sPb.Title = $"Владелец телефонной книжки - {data.OwnerPhoneBook}";


                          try
                          {
                              sPb.SomePb.ItemsSource = context.GetContactsByIdPb(data.PhoneBookID);

                          }
                          catch (Exception e1)
                          {
                              MessageBox.Show($"{e1.Message}", "Ошибка-e1!", MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                          sPb.ShowDialog();
                          
                      }

                  }
                  ));
            }
        }

        ///// <summary>
        ///// Добавить телефонную книгу
        ///// </summary>
        //private RelayCommand addPb;
        //public RelayCommand AddPb
        //{
        //    get
        //    {
        //        return addPb ??
        //          (addPb = new RelayCommand(obj =>
        //          {
        //              DataApi context = new DataApi();
        //              var owner = obj as string;

        //              if (owner != null)
        //              {
        //                  try
        //                  {
        //                      context.AddPhoneBook(new PhoneBook()
        //                      {
        //                          OwnerPhoneBook = owner
        //                      });

        //                  }
        //                  catch (Exception e2)
        //                  {
        //                      MessageBox.Show($"{e2.Message}", "Ошибка-e2! Введите ФИО", MessageBoxButton.OK, MessageBoxImage.Information);
        //                  }

        //                  App.Current.MainWindow.Show();
                          
        //              }

        //          }
        //          ));
        //    }
        //}





    }
}
