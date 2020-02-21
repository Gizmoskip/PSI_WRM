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
using System.IO;

namespace PP2WRM_PSI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        int row = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_6(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_7(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_8(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_9(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_10(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try { string[] oldFile = File.ReadAllLines("data.csv");
                row = oldFile.Length+1;
            } catch (FormatException)
            {
                MessageBox.Show("Created new data.csv");
            }
            

            int result = 0;
            bool success = false;
            if (nursingCheck.IsChecked.Value)
            {
                result += 10;
            }
            if (neoCheck.IsChecked.Value)
            {
                result += 30;
            }
            if (liverCheck.IsChecked.Value)
            {
                result += 20;
            }
            if (heartCheck.IsChecked.Value)
            {
                result += 10;
            }
            if (renalCheck.IsChecked.Value)
            {
                result += 10;
            }
            if (mentalCheck.IsChecked.Value)
            {
                result += 20;
            }
            if (xrayCheck.IsChecked.Value)
            {
                result += 10;
            }

            bool riskClassLow = false;

            try
            {
                int age = Int32.Parse(ageText.Text);
                double resp = double.Parse(breathText.Text);
                double blood = double.Parse(bloodText.Text);
                double pulse = double.Parse(pulseText.Text);
                double ph = double.Parse(phText.Text);
                double bun = double.Parse(bunText.Text);
                double glucose = double.Parse(glucoseText.Text);
                double temp = double.Parse(tempText.Text);
                double sodium = double.Parse(ageText.Text);
                double hemo = double.Parse(hematoText.Text);
                double oxygen = double.Parse(oxygenText.Text);

                result += age;

                double temp2 = temp;
                double glucose2 = glucose;
                double bun2 = bun;
                double oxygen2 = oxygen;

                if (resp >= 30)
                {
                    result += 20;
                }
                if (blood < 90)
                {
                    result += 20;
                }
                if (farenCheck.IsChecked.Value)
                {
                    temp2 = (temp - 32.0) * 5.0 / 9.0;
                    if (temp > 103.8)
                    {
                        result += 15;
                    }
                    if (temp < 95)
                    {
                        result += 15;
                    } 
                }else
                {
                    
                    if (temp > 39.9)
                    {
                        result += 15;
                    }
                    if (temp < 35)
                    {
                        result += 15;
                    }
                }

                if (pulse >= 125)
                {
                    result += 10;
                }
                if (ph < 7.35)
                {
                    result += 30;
                }
                if (mgBunCheck.IsChecked.Value)
                {
                    if (bun >= 30)
                    {
                        result += 20;
                    }
                }
                else
                {
                    bun2 = 18 * bun;
                    if (bun >= 11)
                    {
                        result += 20;
                    }
                }
                if (sodium < 130)
                {
                    result += 20;
                }
                if (mgGluCheck.IsChecked.Value)
                {
                    if (glucose >= 250)
                    {
                        result += 10;
                    }
                }else
                {
                    glucose2 = 18 * glucose;
                    if (glucose >= 14)
                    {
                        result += 10;
                    }
                }
                if (hemo < 30)
                {
                    result += 10;
                }
                if (mmhOxygenCheck.IsChecked.Value)
                {
                    if (oxygen < 60)
                    {
                        result += 10;
                    }
                }else
                {
                    oxygen2 = oxygen * 7.501;
                    if (oxygen < 8)
                    {
                        result += 10;
                    }
                }


                if (result == Int32.Parse(ageText.Text))
                {
                    riskClassLow = true;
                }
                if (femaleCheck.IsChecked.Value)
                {
                    result -= 10;
                }



                string[] file = {row + "," + age + "," + resp + "," + blood + "," + pulse + "," + ph + "," + bun2 + "," + glucose2 + "," + temp2 + "," + sodium + "," + hemo + "," + oxygen2
                    +","+Convert.ToInt32(femaleCheck.IsChecked.Value) + "," + Convert.ToInt32(nursingCheck.IsChecked.Value) + "," + Convert.ToInt32(neoCheck.IsChecked.Value)
                    + "," + Convert.ToInt32(heartCheck.IsChecked.Value) + "," + Convert.ToInt32(cerebroCheck.IsChecked.Value) + "," + Convert.ToInt32(renalCheck.IsChecked.Value)
                    + "," + Convert.ToInt32(mentalCheck.IsChecked.Value) + "," + Convert.ToInt32(xrayCheck.IsChecked.Value) };
                    



                File.AppendAllLines("data.csv",file);


                

                success = true;

            }
            catch(FormatException)
            {
                MessageBox.Show("One or more required input boxes are empty or incorrectly filled in. Please use only numbers in these boxes.");
            }
            int riskClass = 0;
            if (riskClassLow == true)
            {
                riskClass = 1;
            }
            else
            {
                if (result <= 70)
                {
                    riskClass = 2;
                }
                else
                {


                    if (result <= 90)
                    {
                        riskClass = 3;
                    }
                    else
                          if (result <= 130)
                    {
                        riskClass = 4;
                    }
                    else
                    {
                        riskClass = 5;
                    }

                }

                

            }

            if (success)
            {
                switch (riskClass)
                {
                    case 1:
                        textBlock2.Text = "Outpatient Care";
                        textBlock1.Text = "I";
                        break;
                    case 2:
                        textBlock2.Text = "Outpatient Care";
                        textBlock1.Text = "II";
                        break;
                    case 3:
                        textBlock2.Text = "Outpatient Care or Observation Admission";
                        textBlock1.Text = "III";
                        break;
                    case 4:
                        textBlock2.Text = "Inpatient admission";
                        textBlock1.Text = "IV";
                        break;
                    case 5:
                        textBlock2.Text = "Inpatient admission (check for sepsis)";
                        textBlock1.Text = "V";
                        break;
                }
            }


        }
    }
}
