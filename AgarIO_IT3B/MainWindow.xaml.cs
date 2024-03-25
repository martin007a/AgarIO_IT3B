using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgarIO_IT3B
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
            
    }

    public void See()
    {
        double y = canvasGame.ActualHeight / 2;
        double x = canvasGame.ActualWidth / 2;

        Player plar = new Player(Brushes.Red, "Arnold") 
        { 
            Location = new Point(x, y),
        };    
        Ellipse eli = new Ellipse() 
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
    }
}