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
    public class EditContactViewModel
    {
        /// <summary>
        /// Сохранить изменения в контакте
        /// </summary>
        private RelayCommand saveContactCommand;
        public RelayCommand SaveContactCommand
        {
            get
            {
                return saveContactCommand ??
                  (saveContactCommand = new RelayCommand(obj =>
                  {
                      DataApi context = new DataApi();
                      EditContact editWindow = obj as EditContact;

                      if (editWindow.EditSurname.Text != string.Empty &
                      editWindow.EditName.Text != string.Empty &
                      editWindow.EditMiddleName.Text != string.Empty & 
                      editWindow.EditPhoneNumber.Text != string.Empty)
                      {
                          try
                          {
                              context.UpdateContact(editWindow.contId, new Contact()
                              {
                                  ContactID = editWindow.contId,
                                  PhoneBookID = editWindow.pbId,
                                  Surname = editWindow.EditSurname.Text,
                                  Name = editWindow.EditName.Text,
                                  MiddleName = editWindow.EditMiddleName.Text,
                                  PhoneNumber = editWindow.EditPhoneNumber.Text,
                                  Address = editWindow.EditAddress.Text,
                                  Description=editWindow.EditDescription.Text
                              });

                          }
                          catch (Exception e4)
                          {
                              MessageBox.Show($"{e4.Message}", "Ошибка-e4! Что-то пошло не так", 
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                          MessageBox.Show($"Контакт изменён.",
                              $"Успешное изменение",
                                  MessageBoxButton.OK, MessageBoxImage.Information);

                          
                          editWindow.Close();
                          

                      }
                      else
                      {
                          MessageBox.Show($"Поля ввода Фамилия, Имя, Отчество и Номер телефона должны быть заполнены", 
                              "Ошибка-4! Ведите недостающие данные", MessageBoxButton.OK, MessageBoxImage.Information);
                      }

                  }
                  ));
            }
        }
    }
}
