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
using System.Runtime.InteropServices;
using System.Windows.Controls.Primitives;

namespace WPF4fromBookbon4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Random randomnumber = new Random();

        private int max = 100;
        private int number = 0;
        private int count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetTitle()
        {
            string Title = string.Format("Guess a number,  Max value ={0}", max);
        }

        public void Newmaxvalue(object sender, MaxEventArgs e)
        {

            max = e.Max;            
            SetTitle();
            NewGame();

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            NewGame();
            SetTitle();
        }

        private void NewGame()
        {
            count = 0;
            number = randomnumber.Next(1, max+1);
            lstResult.Items.Clear();
            BtnOk.IsEnabled = true;
            Clear();
        }

        private void Clear()
        {
            txtName.Clear();
            txtName.Focus();

        }

        private void NewGame_click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

      

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Guess a number that Computer provides",
                " About the Magic Number",MessageBoxButton.OK, MessageBoxImage.Information);
        }

       

        private void MaxValue_Click(object sender, RoutedEventArgs e)
        {
            MaxWindow dialg = new MaxWindow();
            dialg.MaxChanged += Newmaxvalue;
            dialg.ShowDialog();

            
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try { 
            
            int usernum = int.Parse(txtName.Text.Trim());
            if(usernum>0 && usernum<=max)
            {
                if(usernum < number)
                {
                    lstResult.Items.Add( string.Format(" the Number {0} is too small ",usernum));
                    ++count;
                }

                else if (usernum>number)
                {
                    lstResult.Items.Add(string.Format(" the Number {0} is too large",usernum));
                    ++count;
                }

                else  {
                 lstResult.Items.Add(string.Format("the number {0} if after {1} attempts", usernum, count));                        
                   
                   }                  
                    Clear();
                    return;
                }

            else {
                    MessageBox.Show(string.Format(" Dont pur negative :enter 1-100"), "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);        
                
                
                
                }

            }
            catch  {
                MessageBox.Show(string.Format("Enter betn 0 and {0}",max),"Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                Clear();
            }




        }
    }
}
