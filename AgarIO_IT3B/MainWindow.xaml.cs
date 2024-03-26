using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AgarIO_IT3B
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
        double y;
        double x;
        double speedX;
        double speedY;
        Ellipse eli = new Ellipse();
        private DispatcherTimer dispatcherTimer;
        private double MouseX;
        private double MouseY;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += canvasGame_Loaded;
        }

        private void Timer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(5);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            y = Canvas.GetTop(eli);
            x = Canvas.GetLeft(eli);
            if (x != MouseX)
            {
                speedX = x - MouseX /10; 
                x += -speedX;
            }
            if (x < MouseX)
            {
                x = MouseX;
            }
            if (y != MouseY)
            {
                speedY = y - MouseY /10;
                y += -speedY;
            }
            if (y < MouseY)
            {
                y = MouseY;
            }
            else
            {
                dispatcherTimer.Stop();
            }
            Lbl.Content = speedX.ToString() + "\n";
            Lbl.Content += speedY.ToString() + "\n";
            Canvas.SetLeft(eli, x);
            Canvas.SetTop(eli, y);
        }

        public void See()
        {
            canvasGame.Children.Clear();
            double y = canvasGame.ActualHeight / 2;
            double x = canvasGame.ActualWidth / 2;
            Player plar = new Player(Brushes.Red, "Arnold") 
            { 
                Location = new Point(x, y),
            };    
            eli = new Ellipse() 
            {
                Fill = plar.Color,
                Width = plar.Size,
                Height = plar.Size,
            };
            canvasGame.Children.Add(eli);
            Canvas.SetLeft(eli, plar.Location.X);
            Canvas.SetTop(eli, plar.Location.Y);

        }

        private void canvasGame_Loaded(object sender, RoutedEventArgs e)
        {
            See();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            /*x = Canvas.GetLeft(eli);
            y = Canvas.GetTop(eli);


            switch (e.Key)
            {
                case Key.Left:
                    x -= 10;
                    break;
                case Key.Right:
                    x += 10;
                    break;
                case Key.Up:
                    y -= 10;
                    break;
                case Key.Down:
                    y += 10;
                    break;
            }
            Canvas.SetLeft(eli, x);
            Canvas.SetTop(eli, y);

            Lbl.Content = x.ToString();
            Lbl.Content += "\n";
            Lbl.Content += y.ToString();*/

        }

        private void canvasGame_MouseMove_1(object sender, MouseEventArgs e)
        {
            Point Position = Mouse.GetPosition(this);
            MouseX = Position.X;
            MouseY = Position.Y;

           /* Lbl.Content = MouseX.ToString() + "\n";
            Lbl.Content += MouseY.ToString() + "\n";
            Lbl.Content += "Ahoj";*/

            if((MouseX != x) || (MouseY != y)) 
            {
                Timer();
            }
        }
    }
}