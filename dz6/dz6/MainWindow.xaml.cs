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

namespace dz6
{
    public partial class MainWindow : Window
    {
        public abstract class Body
        {
            public int side = 0;
            public int radius = 0;
            public int high = 0;

            public Body(int pSide = 0, int pRadius = 0, int pHigh = 0)
            {
                if (pSide < 0 || pRadius < 0 || pHigh < 0)
                {
                    throw new Exception("Данные параметры не могут быть меньше нуля");
                }
                side = pSide;
                radius = pSide;
                high = pHigh;
            }
            public virtual double getSquare()
            {
                double square = 0;
                return square;
            }
            public virtual double getVolume()
            {
                double volume = 0;
                return volume;
            }
        }
        public class Coube : Body 
        {
            public Coube(int pSide, int pHigh = 0, int pRadius=0):
                base(pSide, pHigh, pRadius){ }

            public override double getSquare()
            {
                double square = side * side * 6;
                return square;
            }
            public override double getVolume()
            {
                double square = side * side * side;
                return square;
            }
            public override string ToString()
            {
                return $"Куб со стороной: {side}" +
                    $"\n\t Площадью: {getSquare().ToString()}" +
                    $"\n\t {getVolume().ToString()}";
            }
        }
        public class Conus : Body
        {
            public Conus(int pSide, int pHigh, int pRadius) :
                base(pSide, pHigh, pRadius)
            { }

            public override double getSquare()
            {
                double square = Math.Round(Math.PI * radius*radius + Math.PI * radius * side);
                return square;
            }
            public override double getVolume()
            {
                double square = Math.Round((double)1 /3 * Math.PI * radius * radius * high);
                return square;
            }
            public override string ToString()
            {
                return $"Конус со образующей: {side}, высотой: {high}" +
                    $"\n\t Площадью: {getSquare().ToString()}" +
                    $"\n\t Объемом: {getVolume().ToString()}";
            }
        }
        public class Sphere : Body
        {
            public Sphere(int pRadius, int pSide=0, int pHigh=0) :
                base(pRadius=pRadius)
            { }

            public override double getSquare()
            {
                double square = Math.Round(4 * Math.PI * radius * radius);
                return square;
            }
            public override double getVolume()
            {
                double square = Math.Round(4 * Math.PI * radius * radius * radius, 2);
                return square;
            }
            public override string ToString()
            {
                return $"Сфера с радиусом: {radius}" +
                    $"\n\tПлощадью: {getSquare().ToString()}" +
                    $"\n\tОбъемом: {getVolume().ToString()}";
            }
        }
        List<Body> figures = new List<Body>();
        public MainWindow()
        {
            InitializeComponent();
            figures.Add(new Coube(pSide: 5));
            figures.Add(new Sphere(pRadius: 7));
            figures.Add(new Conus(pRadius: 7, pSide: 8, pHigh: 9));
            string result = "";
            foreach (var figure in figures)
            {
                result += figure.ToString() + "\n";
            }
            tb_output.Text = result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int radius = int.Parse(tb_radius.Text);
                int side = int.Parse(tb_side.Text);
                int high = int.Parse(tb_high.Text);
                int selected_index = cb_figure.SelectedIndex;
                switch (selected_index)
                {
                    case 0:
                        figures.Add(new Coube(pSide: side));
                        tb_status.Text = "SUCCES";
                        window.Background = Brushes.Green;
                        break;
                    case 1:
                        figures.Add(new Conus(pSide: side, pHigh: high, pRadius: radius));
                        tb_status.Text = "SUCCES";
                        window.Background = Brushes.Green;
                        break;
                    case 2:
                        figures.Add(new Sphere(pRadius: radius));
                        tb_status.Text = "SUCCES";
                        window.Background = Brushes.Green;
                        break;
                    default:
                        tb_status.Text = "FAIL";
                        tb_output.Text = "Выберите фигуру";
                        window.Background = Brushes.Red;
                        break;
                }
                

            }
            catch (System.FormatException) {
                window.Background = Brushes.Red;
                tb_status.Text = "FAIL";
                tb_output.Text = "Введите корректные данные для выбранной фигуры";
            }

        }

        private void btn_restart_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            foreach (var figure in figures)
            {
                result += figure.ToString() + "\n";
            }
            tb_output.Text = result;
        }
    }

}
