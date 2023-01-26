using Microsoft.AspNetCore.Identity;
using PhoneBookEntitiesLib;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp.Views;
using Microsoft.AspNetCore.Mvc;
using static System.Console;
using WebApp.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WpfApp.ViewModels
{
    internal class MainWindowViewModel
    {

        /// <summary>
        /// Аутентификация и Авторизация.
        /// </summary>
        private RelayCommand login;
        public RelayCommand Login
        {
            get
            {
                return login ??
                  (login = new RelayCommand(obj =>
                  {
                      //DataApi context = new DataApi();
                      MainWindow? mainWindow = obj as MainWindow;
                      string login = mainWindow.LoginTB.Text;
                      string password = mainWindow.LoginPassB.Password;

                      try
                      {
                          User user = new User();

                          using (AppDbContext db = new AppDbContext())
                          {
                              user = (User)db.AspNetUsers.Where(b => b.Email == login).FirstOrDefault();

                              if (user != null)
                              {
                                  MessageBox.Show("Всё хорошо", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                              }
                              else
                              {
                                  MessageBox.Show("Всё плохо", "Не успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                              }
                          }
                      }
                      catch (Exception e28)
                      {
                          MessageBox.Show($"{e28.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                      }

                  }
                  ));
            }
        }

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
                          sPb.pbID = data.PhoneBookID;

                          try
                          {
                              sPb.SomePb.ItemsSource = context.GetContactsByIdPb(data.PhoneBookID);

                          }
                          catch (Exception e1)
                          {
                              MessageBox.Show($"{e1.Message}", "Ошибка открытия телефонной книжки!", MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                          sPb.ShowDialog();
                          
                      }

                  }
                  ));
            }
        }

        /// <summary>
        /// Добавить телефонную книгу
        /// </summary>
        private RelayCommand addPb;
        public RelayCommand AddPb
        {
            get
            {
                return addPb ??
                  (addPb = new RelayCommand(obj =>
                  {
                      DataApi context = new DataApi();
                      MainWindow mainWindow = obj as MainWindow;
                      var owner = mainWindow.Owner.Text;

                      if (owner != string.Empty)
                      {
                          try
                          {
                              context.AddPhoneBook(new PhoneBook()
                              {
                                  OwnerPhoneBook = owner
                              });

                          }
                          catch (Exception e2)
                          {
                              MessageBox.Show($"{e2.Message}", "Ошибка-e2! Что-то пошло не так", 
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                          mainWindow.Phbooks.ItemsSource = context.GetPhoneBooks();

                      }
                      else
                      {
                          MessageBox.Show($"Заполните поле ввода ФИО владельца книжки", 
                              "Ошибка-e2! Введите ФИО", MessageBoxButton.OK, MessageBoxImage.Information);
                      }

                  }
                  ));
            }
        }





    }
}
