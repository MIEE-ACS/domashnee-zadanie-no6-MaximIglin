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

namespace dz6_V11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public abstract class Weapon{
            public string name;
            public double splash;
            public double dpm;
            public double cd;
            public Weapon(string nam, double spl, double dp, double cd) {
                name = nam;
                splash = spl;
                dpm = dp;
                cd = cd;
            }
            public override string ToString()
            {
                return "Оружие " + name;
            }

        }
        public class Firearms : Weapon {

            public Firearms(string nam, double spl, double dp, double cd) :
                base(nam, spl, dp, cd){
            }
        }
        public class SteelArms : Weapon
        {
            public SteelArms(string nam, double spl, double dp, double cd) :
                base(nam, spl, dp, cd)
            {
            }
        }
        public class Thermonuclear : Weapon
        {
            public Thermonuclear(string nam, double spl, double dp, double cd) :
                base(nam, spl, dp, cd)
            {
            }
        }
        public class Arbalet : SteelArms
        {
            public Arbalet(string nam, double spl, double dp, double cd) :
                base(nam, spl, dp, cd)
            {
            }
        }
        public class Gun : SteelArms
        {
            public Gun(string nam, double spl, double dp, double cd) :
                base(nam, spl, dp, cd)
            {
            }
        }
        public class MBR : SteelArms
        {
            public MBR(string nam, double spl, double dp, double cd) :
                base(nam, spl, dp, cd)
            {
            }
        }
        List<Weapon> Guns = new List<Weapon>();
        public MainWindow()
        {
            Guns.Add(new MBR("МБР-11", 11.0, 12.0, 13.0));
            Guns.Add(new Arbalet("Арбалет-1", 9.0, 14.0, 10.0));
            Guns.Add(new Gun("ПМ-1", 9.0, 14.0, 10.0));
            string first_text = "";
            foreach (var obj in Guns) {
                first_text += obj.ToString() + "\n";
            }
            InitializeComponent();
            tb_output.Text = first_text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            string all_guns = tb_output.Text;
            string name = tb_name.Text;
            double splash = double.Parse(tb_splash.Text);
            double dpm = double.Parse(tb_dpm.Text);
            double cd = double.Parse(tb_cd.Text);
            if (rb_1.IsChecked == true) {
                Arbalet new_arbalet = new Arbalet(name, splash, dpm, cd);
                tb_output.Text += new_arbalet.ToString() + "\n";
                Guns.Add(new_arbalet);
            }
            if (rb_2.IsChecked == true)
            {
                Gun new_gun = new Gun(name, splash, dpm, cd);
                tb_output.Text += new_gun.ToString() + "\n";
                Guns.Add(new_gun);
            }
            if (rb_3.IsChecked == true) {
                MBR new_mbr = new MBR(name, splash, dpm, cd);
                tb_output.Text += new_mbr.ToString() + "\n";
                Guns.Add(new_mbr);
            }

        }
    }
}
