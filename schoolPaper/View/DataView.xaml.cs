using Database.Data;
using Database.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace schoolPaper.View
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : UserControl
    {
        private readonly AbContext _context;
        private People _selectedUser;

        public DataView()
        {
            InitializeComponent();
            _context = new AbContext();
            LoadData();
        }

        private void LoadData()
        {
            var users = _context.People.ToList();
            listBox.ItemsSource = users;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                _selectedUser = (People)listBox.SelectedItem;
                nameTextBox.Text = _selectedUser.Name;
                ageTextBox.Text = _selectedUser.Age;
                cityTextBox.Text = _selectedUser.City;
                positionTextBox.Text = _selectedUser.Position;
                hobbyTextBox.Text = _selectedUser.Hobby;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                _selectedUser.Name = nameTextBox.Text;
                _selectedUser.Age = ageTextBox.Text;
                _selectedUser.City = cityTextBox.Text;
                _selectedUser.Position = positionTextBox.Text;
                _selectedUser.Hobby = hobbyTextBox.Text;

                _context.People.Update(_selectedUser);
                await _context.SaveChangesAsync();
                LoadData();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                _context.People.Remove(_selectedUser);
                await _context.SaveChangesAsync();
                LoadData();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            cityTextBox.Text = "";
            positionTextBox.Text = "";
            hobbyTextBox.Text = "";
        }
    }
}
