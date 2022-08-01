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

namespace WPfOceanFirstTry
{
    /// <summary>
    /// Логика взаимодействия для OceanWindow.xaml
    /// </summary>
    public partial class OceanWindow : Window
    {
        private bool running = false;
        private WPFOceanViewer viewer;
        public OceanWindow(WPFOceanViewer viewer)
        {
            InitializeComponent();
            this.viewer = viewer;
        }
        public void ChangeButton()
        {
            if(running)
            {
                running = false;
                RunButton.Content = "Run Ocean!";
            }
            else
            {
                running = true;
                RunButton.Content = "Abort Iterating";
            }
        }
        public void UpdateText()
        {
            IterationLabel.Content = "Enter Amount of iterations here!";
            TimeLabel.Content = "Enter Time needed for one iteration!";
        }
        public bool CheckValidation()
        {
            bool valid = true;

            try
            {
                Convert.ToUInt32(IterationsTextBox.Text);
            }
            catch(FormatException)
            {
                valid = false;
                IterationLabel.Content = "Invalid iteration input!";
            }
            catch(OverflowException)
            {
                valid = false;
                IterationLabel.Content = "Invalid iteration input!";
            }

            try
            {
                Convert.ToUInt32(TimeTextBox.Text);
            }
            catch (FormatException)
            {
                valid = false;
                TimeLabel.Content = "Invalid time input!";
            }
            catch (OverflowException)
            {
                valid = false;
                TimeLabel.Content = "Invalid time input!";
            }

            return valid;
        }
        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if(CheckValidation() && !running)
            {
                ChangeButton();
                viewer.RunOcean();
            }
            else if (running)
            {
                viewer.AbortOcean();
                ChangeButton();
            }
        }
    }
}
