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
    public class AddContactViewModel
    {
        /// <summary>
        /// Добавить новый контакт
        /// </summary>
        private RelayCommand addContactCommand;
        public RelayCommand AddContactCommand
        {
            get
            {
                return addContactCommand ??
                  (addContactCommand = new RelayCommand(obj =>
                  {
                      DataApi context = new DataApi();
                      AddContact addC = obj as AddContact;

                      if (addC.AddSurname.Text != string.Empty &
                      addC.AddName.Text != string.Empty &
                      addC.AddMiddleName.Text != string.Empty &
                      addC.AddPhoneNumber.Text != string.Empty)
                      {
                          try
                          {
                              context.AddContact(new Contact()
                              {
                                  PhoneBookID = addC.pbId,
                                  Surname = addC.AddSurname.Text,
                                  Name = addC.AddName.Text,
                                  MiddleName = addC.AddMiddleName.Text,
                                  PhoneNumber = addC.AddPhoneNumber.Text,
                                  Address = addC.AddAddress.Text,
                                  Description = addC.AddDescription.Text
                              });

                          }
                          catch (Exception e3)
                          {
                              MessageBox.Show($"{e3.Message}", "Ошибка-e3! Что-то пошло не так", 
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                          MessageBox.Show($"Контакт добавлен. После закрытия данного окна нажмите кнопку обновить", 
                              $"Успешное добавление",
                                  MessageBoxButton.OK, MessageBoxImage.Information);

                          addC.Close();
                      }
                      else
                      {
                          MessageBox.Show($"Поля ввода Фамилия, Имя, Отчество и Номер телефона должны быть заполнены", 
                              "Ошибка-e3! Ведите недостающие данные", MessageBoxButton.OK, MessageBoxImage.Information);
                      }

                  }
                  ));
            }
        }
    }
}
