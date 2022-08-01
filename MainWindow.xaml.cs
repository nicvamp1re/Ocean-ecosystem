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
using OceanBusinessLogic;
using EcosystemInterfacesWPF;

namespace WPfOceanFirstTry
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MaxCols = 80;
        private const int MaxRows = 40;
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool CheckInputValids()
        {
            bool valid = true;
            ResetLabels();
            try
            {
                if(Convert.ToUInt32(RowTextBox.Text) > MaxRows)
                {
                    valid = false;
                    RowLabel.Content = "Too many rows! " + MaxRows + "Maximum!";
                }
            }
            catch (FormatException)
            {
                valid = false;
                RowLabel.Content = "Invalid column input!";
            }
            catch(OverflowException)
            {
                valid = false;
                RowLabel.Content = "Invalid column input!";
            }
            try
            {
                if (Convert.ToUInt32(ColumnTextBox.Text) > MaxCols)
                {
                    valid = false;
                  ColumnLabel.Content = "Too many cols! " + MaxRows + "Maximum!";
                }
            }
            catch (FormatException)
            {
                valid = false;
                ColumnLabel.Content = "Invalid column input!";
            }
            catch(OverflowException)
            {
                valid = false;
                ColumnLabel.Content = "Invalid column input!";
            }

            try
            {
                Convert.ToUInt32(PredatorTextBox.Text);
            }
            catch (FormatException)
            {
                valid = false;
                PredatorLabel.Content = "Invalid predator input!";
            }
            catch(OverflowException)
            {
                valid = false;
                PredatorLabel.Content = "Invalid predator input!";
            }

            try
            {
                Convert.ToUInt32(PreyTextBox.Text);
            }
            catch (FormatException)
            {
                valid = false;
                PreyLabel.Content = "Invalid prey input!";
            }
            catch (OverflowException)
            {
                valid = false;
                PreyLabel.Content = "Invalid prey input!";
            }

            try
            {
                Convert.ToUInt32(ObstacleTextBox.Text);
            }
            catch (FormatException)
            {
                ObstacleLabel.Content = "Invalid obstacle input!";
                valid = false;
            }
            catch(OverflowException)
            {
                ObstacleLabel.Content = "Invalid obstacle input!";
                valid = false;
            }

            if(valid)
            {
                if((Convert.ToUInt32(RowTextBox.Text) * Convert.ToUInt32(ColumnTextBox.Text)) 
                    < (Convert.ToUInt32(ObstacleTextBox.Text) + Convert.ToUInt32(PreyTextBox.Text) + Convert.ToUInt32(PredatorTextBox.Text)))
                {
                    MessageBox.Show("The summary amount of cells is too big to fit in the field! Please, decrease the amount of cells");
                    valid = false;
                }
            }

            return valid;
        }
        private void ResetLabels()
        {
            ColumnLabel.Content = "Enter the amount of columns of here";
            RowLabel.Content = "Enter the amount of rows of here";
            PredatorLabel.Content = "Enter the amount of predators of here";
            PreyLabel.Content = "Enter the amount of prey of here";
            ObstacleLabel.Content = "Enter the amount of obstacles of here";
        }

        private void GenerateOceanbutton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputValids())
            {
                Ocean ocean = new Ocean();
                WPFOceanViewer viewer =
                    new WPFOceanViewer
                    (ocean,
                    PreyTextBox,
                    PredatorTextBox,
                    ObstacleTextBox,
                    RowTextBox, ColumnTextBox,
                    PreyLabel,
                    PredatorLabel,
                    ObstacleLabel,
                    RowLabel,
                    ColumnLabel);
                ocean.Initialize(viewer);
                ResetLabels();
            }
        }
    }
}
