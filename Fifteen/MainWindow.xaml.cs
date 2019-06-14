using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Data.SQLite;
using Microsoft.Win32;

namespace Fifteen
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        

        
        

        Game game = new Game();
        int sec = 0;

        bool flag = false;

        public MainWindow()
        {
            InitializeComponent();
            //button0.Background = Brushes.LightGray;
            //button1.Background = Brushes.LightGray;
            //button2.Background = Brushes.LightGray;
            game.game(4);
        }
        System.Windows.Threading.DispatcherTimer Timer;

        


            private void ButtonClick(object sender, RoutedEventArgs e)
        {
            int button = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(button);
            Refresh();
            if (flag == true)
            {
                //int W = imag.PixelWidth / 4;
                //int H = imag.PixelHeight / 4;
                //int button = Convert.ToInt32(((Button)sender).Tag);

                int W = imag.PixelWidth / 4;
                int H = imag.PixelHeight / 4;


                setbg(button0, W, H, 0);
                setbg(button1, W, H, 1);
                setbg(button2, W, H, 2);
                setbg(button3, W, H, 3);
                setbg(button4, W, H, 4);
                setbg(button5, W, H, 5);
                setbg(button6, W, H, 6);
                setbg(button7, W, H, 7);
                setbg(button8, W, H, 8);
                setbg(button9, W, H, 9);
                setbg(button10, W, H, 10);
                setbg(button11, W, H, 11);
                setbg(button12, W, H, 12);
                setbg(button13, W, H, 13);
                setbg(button14, W, H, 14);
                setbg(button15, W, H, 15);
                
            }
           

            if (game.isEndGame())
               
            {
               

                MessageBox.Show("Вы победили!", "Победа");
                
                if ((MessageBox.Show((sec.ToString() + " секунд. Записать время?"), "", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                {
                    Timer.Stop();
                    Window1 w1 = new Window1(sec);
                    w1.Owner = this;
                    if (w1.ShowDialog() == true)

                    {

                        if ((MessageBox.Show("Начать игру заново?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                        {
                            Timer.Start();
                            sec = 0;
                            StartGame();
                        }
                            
                        else
                        {
                            BlockButtons();
                        }
                    }
                }
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

        private Button _Button(int button)
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
           
            flag = false;

            button0.Background = Brushes.LightGray;
            button1.Background = Brushes.LightGray;
            button2.Background = Brushes.LightGray;
            button3.Background = Brushes.LightGray;
            button4.Background = Brushes.LightGray;
            button5.Background = Brushes.LightGray;
            button6.Background = Brushes.LightGray;
            button7.Background = Brushes.LightGray;
            button8.Background = Brushes.LightGray;
            button9.Background = Brushes.LightGray;
            button10.Background = Brushes.LightGray;
            button11.Background = Brushes.LightGray;
            button12.Background = Brushes.LightGray;
            button13.Background = Brushes.LightGray;
            button14.Background = Brushes.LightGray;
            button15.Background = Brushes.LightGray;
            


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
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            UnblockButtons();
            game.Start();
            for (int i = 0; i < 100; i++)
            {
                game.Shuffle();
            }
            Refresh();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            sec++;
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
      



        // тестовая часть потом удалить 
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.I) 
            {
                MessageBox.Show("Вы победили!", "Победа");
                if ((MessageBox.Show((sec.ToString() + " секунд. Записать время?"), "", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                {
                    Timer.Stop();
                    Window1 w1 = new Window1(sec);
                    w1.Owner = this;
                    if (w1.ShowDialog() == true)

                    {

                        if ((MessageBox.Show("Начать игру заново?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                        {
                            Timer.Start();
                            sec = 0;
                            StartGame();
                        }

                        else
                        {
                            BlockButtons();
                        }
                    }
                }
                else
                {
                    BlockButtons();
                }
            }
        }

        BitmapImage imag;



        private void setbg(Button btn, int W, int H, int n)
        {
            ImageBrush ib = new ImageBrush();
            
            //изображение будет выведено без растяжения/сжатия
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;

            //участок изображения который будет нарисован
            //в данном случае, второй кадр первой строки
            int num = int.Parse(btn.Content.ToString());

            double px = (num % 4) * W;
            double py = (num / 4) * H;

            ib.Viewbox = new Rect(px, py, px+W, py+H);
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            ib.ImageSource = imag;

            btn.Background = ib;

           
        }

        private void LoadingImage(object sender, RoutedEventArgs e)
        {

                OpenFileDialog dl = new OpenFileDialog();
                dl.ShowDialog();
                


                imag = new BitmapImage(new Uri(dl.FileName, UriKind.Absolute));

            flag = true;

            int W = imag.PixelWidth / 4;
            int H = imag.PixelHeight / 4;

            setbg(button0, W, H, 0);
            setbg(button1, W, H, 1);
            setbg(button2, W, H, 2);
            setbg(button3, W, H, 3);
            setbg(button4, W, H, 4);
            setbg(button5, W, H, 5);
            setbg(button6, W, H, 6);
            setbg(button7, W, H, 7);
            setbg(button8, W, H, 8);
            setbg(button9, W, H, 9);
            setbg(button10, W, H, 10);
            setbg(button11, W, H, 11);
            setbg(button12, W, H, 12);
            setbg(button13, W, H, 13);
            setbg(button14, W, H, 14);
            setbg(button15, W, H, 15);



        }

        private void LoadingTabl(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(sec);
            w1.Owner = this;
            if (w1.ShowDialog() == true) ;
        }
    }
}
