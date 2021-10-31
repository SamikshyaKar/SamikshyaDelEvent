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

namespace WPF4fromBookbon4
{
    /// <summary>
    /// Interaction logic for MaxWindow.xaml
    /// </summary>


    public class MaxEventArgs : EventArgs
    {
        private int max;
        public MaxEventArgs(int max)
        {
            this.max = max;
        }

        public int Max { get; }
    }

    public delegate void MaxHandler(object sender, MaxEventArgs e);



    public partial class MaxWindow : Window
    {
        public event MaxHandler MaxChanged;
       
        public MaxWindow()
        {
            InitializeComponent();
        }

        private void btnMaxOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {  
                int max = int.Parse(txtMax.Text.Trim());
                if (max > 0) 
                
                { 
                if (MaxChanged != null)
                    {

                        MaxChanged(this, new MaxEventArgs(max));

                    }
                    Close();
                    return;
                }

            }

            catch
            {



            }

        }

        private void btnMaxCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }
    }
}
