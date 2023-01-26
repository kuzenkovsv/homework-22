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
    public class ContactDetailViewModel
    {
        /// <summary>
        /// Редактировать контакт
        /// </summary>
        private RelayCommand editContCommand;
        public RelayCommand EditContCommand
        {
            get
            {
                return editContCommand ??
                  (editContCommand = new RelayCommand(obj =>
                  {
                      EditContactViewModel editContactViewModel = new EditContactViewModel();
                      EditContact editCont = new EditContact(editContactViewModel);
                      DataApi context = new DataApi();

                      if (obj is ContactDetail data)
                      {
                          editCont.Title = $"Контакт с id-{data.DetailContactID.Text}";
                          editCont.contId = data.contId;
                          editCont.pbId = data.pbId;

                          try
                          {
                              editCont.EditContactID.Text = data.DetailContactID.Text;
                              editCont.EditSurname.Text = data.ContSurname.Text;
                              editCont.EditName.Text = data.ContName.Text;
                              editCont.EditMiddleName.Text = data.ContMiddleName.Text;
                              editCont.EditPhoneNumber.Text = data.ContPhoneNumber.Text;
                              editCont.EditAddress.Text = data.ContAddress.Text;
                              editCont.EditDescription.Text = data.ContDescription.Text;
                          }
                          catch (Exception e2)
                          {
                              MessageBox.Show($"{e2.Message}", "Какая-то ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                          }

                          editCont.ShowDialog();

                      }

                  }
                  ));
            }
        }

        /// <summary>
        /// Обновить данные контакта
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

                      ContactDetail data = obj as ContactDetail;

                      data.CoD.ItemsSource = context.GetContact(data.contId);

                  }

                  ));
            }
        }


    }
}
