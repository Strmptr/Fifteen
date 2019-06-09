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

namespace Fifteen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();
            game.game(4);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            int button = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(button);
            Refresh();
            if (game.isEndGame())
            {
                MessageBox.Show("Вы победили!", "Победа");
                if ((MessageBox.Show("Начать игру заново?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                    StartGame();
                else
                {
                    BlockButtons();
                }
            }
        }

        private void BlockButtons()
        {
            for (int i = 0; i < 16; i++)
            {
                _Button(i).IsEnabled = false;
            }
        }

        private void UnblockButtons()
        {
            for (int i = 0; i < 16; i++)
            {
                _Button(i).IsEnabled = true;
            }
        }

        private Button _Button (int button)
        {
            switch (button)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void Refresh()
        {
            for (int i = 0; i < 16; i++)
            {
                _Button(i).Content = game.GetNumber(i).ToString();
                _Button(i).Visibility = (game.GetNumber(i) > 0) ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private void StartGame()
        {
            UnblockButtons();
            game.Start();
            for (int i = 0; i < 100; i++)
            {
                game.Shuffle();
            }
            Refresh();
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
