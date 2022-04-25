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
using WPF_MVVM.Models.Decanat;

namespace WPF_MVVM.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Group group)) return;
            if (group.Name is null) return;

            string filterText = GroupNameFilterText.Text;

            if (filterText.Length == 0) return;

            if (group.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (group.Description != null && group.Description.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }

        private void GroupNameFilterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var collection = textBox.FindResource("GroupsCollection") as CollectionViewSource;

            collection.View.Refresh();
        }
    }
}
