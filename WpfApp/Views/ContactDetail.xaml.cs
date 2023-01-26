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
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для OpenContact.xaml
    /// </summary>
    public partial class ContactDetail : Window
    {
        public int contId { get; set; }
        public int pbId { get; set; }

        public ContactDetail(ContactDetailViewModel contactDetailViewModel)
        {
            DataContext = contactDetailViewModel;
            InitializeComponent();
        }
    }
}
