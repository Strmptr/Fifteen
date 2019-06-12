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

namespace Fifteen
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int time = 0;
        SQlite sq = new SQlite();
        public Window1(int timer)
        {
            InitializeComponent();
            scoregrid.ItemsSource = sq.output();
            scoregrid.Items.Refresh();
            time = timer;
            scoregrid.IsReadOnly = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            add.IsEnabled = false;
            sq.input(time, name.Text);
            scoregrid.ItemsSource = sq.output();
            scoregrid.Items.Refresh();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
