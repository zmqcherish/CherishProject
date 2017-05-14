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

namespace MicrosoftCoreFans
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int num;
        Random r= new Random();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num = Convert.ToInt16(txtNum.Text.Trim());

                txtResult.Text = r.Next(1, num + 1).ToString();
            }
            catch (Exception)
            { 
            }
        }
    }
}
