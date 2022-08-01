using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using EcosystemInterfacesWPF;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Threading;

namespace WPfOceanFirstTry
{
    public class WPFOceanViewer : IOceanDisplayer
    {
        private const char predatorChar = '$';
        private const char preyChar = 'f';
        private const char obstacleChar = '#';
        private const char nullChar = '-';

        private int numPrey;
        private int numPredators;
        private int numObstacles;
        private int iterationsLeft;
        private int tickTime;
        private bool isWindowDisplayed = false;
        private OceanWindow displayerWindow;
        private IOceanContainer _owner;
        private char[,] buffer;
        private Rectangle[,] cellRectangles;
        private ImageBrush emptyCellBrush;
        private ImageBrush preyBrush;
        private ImageBrush obstacleBrush;
        private ImageBrush predatorBrush;

        #region InputElements
        private TextBox _preyBox;
        private TextBox _predatorBox;
        private TextBox _obstacleBox;
        private TextBox _rowBox;
        private TextBox _colBox;
        private Label _preyLabel;
        private Label _predatorLabel;
        private Label _obstacleLabel;
        private Label _rowLabel;
        private Label _colLabel;
        private DispatcherTimer OceanDispatcherTimer = new DispatcherTimer();
        #endregion


        public bool IsAlive
        {
            get
            {
                bool returnValue = true;
                if (numPredators == 0 || numPrey == 0)
                    returnValue = false;
                return returnValue;
            }
        }

        public void AnalyseOcean()
        {
            numPredators = 0;
            numPrey = 0;
            numObstacles = 0;

            for (int i = 0; i < _owner.NumRows; i++)
            {
                for (int j = 0; j < _owner.NumCols; j++)
                {
                    if (_owner.Cells[i, j] != null)
                    {
                        if (_owner.Cells[i, j].Image == predatorChar)
                        {
                            numPredators++;
                        }
                        else if (_owner.Cells[i, j].Image == preyChar)
                        {
                            numPrey++;
                        }
                        else if (_owner.Cells[i, j].Image == obstacleChar)
                        {
                            numObstacles++;
                        }
                    }
                }
            }
        }
        public void AbortOcean()
        {
            iterationsLeft = 0;
        }
        public void DisplayCells()
        {
            if(!isWindowDisplayed)
            {
                OceanWindow window = new OceanWindow(this);
                window.Show();
                isWindowDisplayed = true;
                displayerWindow = window;
                buffer = new char[_owner.NumRows, _owner.NumCols];
                UpdateBuffer();
                DisplayOceanAsRectangle();
            }
        }
        public void RunOcean()
        {
            iterationsLeft = Convert.ToInt32(displayerWindow.IterationsTextBox.Text);
            tickTime = Convert.ToInt32(displayerWindow.TimeTextBox.Text);
            OceanDispatcherTimer.Interval = TimeSpan.FromMilliseconds(tickTime);
            OceanDispatcherTimer.Start();
        }
        private void DTTicker(object sender, EventArgs e)
        {
            Iterate();
        }
        public void Iterate()
        {            
            _owner.DoOneIteration();
            DoDisplayRoutine(iterationsLeft, tickTime);
            iterationsLeft--;
            if(iterationsLeft <= 0)
            {
                OceanDispatcherTimer.Stop();
            }
        }
        private void UpdateBuffer()
        {
            for (int i = 0; i < _owner.NumRows; i++)
            {
                for (int j = 0; j < _owner.NumCols; j++)
                {
                    if (_owner.Cells[i, j] == null)
                    {
                        buffer[i, j] = nullChar;
                    }
                    else
                    {
                        buffer[i, j] = _owner.Cells[i, j].Image;
                    }
                }
            }
        }
        private void DisplayOceanAsRectangle()
        {
            cellRectangles = new Rectangle[_owner.NumRows, _owner.NumCols];
            displayerWindow.OceanCanvas.Height = _owner.NumRows * 16;
            displayerWindow.OceanCanvas.Width = _owner.NumCols * 16;
            for (int i = 0; i < _owner.NumRows; i++)
            {
                for (int j = 0; j < _owner.NumCols; j++)
                {
                    cellRectangles[i, j] = new Rectangle();
                    cellRectangles[i, j].Width = 16;
                    cellRectangles[i, j].Height = 16;
                    cellRectangles[i, j].Fill = GetCellBrush(i, j);
                    Canvas.SetTop(cellRectangles[i, j], 16 * i);
                    Canvas.SetLeft(cellRectangles[i, j], 16 * j);
                    displayerWindow.OceanCanvas.Children.Add(cellRectangles[i, j]);
                }
            }
        }

        private ImageBrush GetCellBrush(int i, int j)
        {
            ImageBrush returnValue;
            if (_owner.Cells[i, j] == null)
            {
                returnValue = emptyCellBrush;
            }
            else
            {
                if(_owner.Cells[i, j].Image == predatorChar)
                {
                    returnValue = predatorBrush;
                }
                else if(_owner.Cells[i, j].Image == preyChar)
                {
                    returnValue = preyBrush;
                }
                else
                {
                    returnValue = obstacleBrush;
                }
            }
            return returnValue;
        }
        private string AssempleOceanString()
        {
            string oceanStr = "";

            for(int i = 0; i < _owner.NumRows; i++)
            {
                for(int j = 0; j < _owner.NumCols; j++)
                {
                    if (_owner.Cells[i, j] == null)
                    {
                        oceanStr += nullChar;
                    }
                    else
                    {
                        oceanStr += _owner.Cells[i, j].Image;
                    }
                }
                oceanStr += '\n';
            }

            return oceanStr;
        }

        public void DoDisplayRoutine(int x, int y)
        {
            for (int i = 0; i < _owner.NumRows; i++)
            {
                for (int j = 0; j < _owner.NumCols; j++)
                {
                    if ((_owner.Cells[i, j] == null && buffer[i, j] != nullChar))
                    {
                        cellRectangles[i, j].Fill = GetCellBrush(i, j);
                    }
                    else if (_owner.Cells[i, j] != null)
                    {
                        if (_owner.Cells[i, j].Image != buffer[i, j])
                        {
                            cellRectangles[i, j].Fill = GetCellBrush(i, j);
                        }
                    }
                }
            }
            UpdateBuffer();
        }

        public int GetAmountOfIterations()
        {
            int returnValue;

            returnValue = Convert.ToInt32(displayerWindow.IterationsTextBox.Text);

            return returnValue;
        }

        public int GetColAmountInput()
        {
            int returnValue;

            returnValue = Convert.ToInt32(_colBox.Text) ;

            return returnValue;
        }


        public int GetIterationTime()
        {
            int returnValue;

            returnValue = Convert.ToInt32(displayerWindow.TimeTextBox.Text);

            return returnValue;
        }

        public char GetNullCharInput()
        {
            return nullChar;
        }

        public char GetObstacleCharInput()
        {
            return obstacleChar;
        }

        public char GetOtherCharInput(string message)
        {
            throw new NotImplementedException();
        }

        public char GetPredatorCharInput()
        {
            return predatorChar;
        }

        public char GetPreyCharInput()
        {
            return preyChar;
        }

        public int GetRowAmountInput()
        {
            int returnValue;

            returnValue = Convert.ToInt32(_rowBox.Text);

            return returnValue;
        }

        int IOceanDisplayer.GetObstacleAmount()
        {
            int returnValue;

            returnValue = Convert.ToInt32(_obstacleBox.Text);

            return returnValue;
        }

        int IOceanDisplayer.GetPredatorAmount()
        {
            int returnValue;

            returnValue = Convert.ToInt32(_predatorBox.Text);

            return returnValue;
        }

        int IOceanDisplayer.GetPreyAmount()
        {
            int returnValue;

            returnValue = Convert.ToInt32(_preyBox.Text);

            return returnValue;
        }
        public WPFOceanViewer(IOceanContainer owner,
                              TextBox preyBox,
                              TextBox predatorBox,
                              TextBox obstacleBox,
                              TextBox rowBox,
                              TextBox colBox,
                              Label preyLabel,
                              Label predatorLabel,
                              Label obstacleLabel,
                              Label rowLabel,
                              Label colLabel)
        {
            _owner = owner;
            _colBox = colBox;
            _rowBox = rowBox;
            _colLabel = colLabel;
            _rowLabel = rowLabel;
            _preyLabel = preyLabel;
            _predatorLabel = predatorLabel;
            _obstacleLabel = obstacleLabel;
            _obstacleBox = obstacleBox;
            _predatorBox = predatorBox; 
            _preyBox = preyBox;
            predatorBrush = new ImageBrush(new BitmapImage(new Uri("C:/Users/nicvampire/source/repos/WPfOceanFirstTry/images/FishPredator.png", UriKind.Absolute)));
            
            preyBrush = new ImageBrush(new BitmapImage(new Uri("C:/Users/nicvampire/source/repos/WPfOceanFirstTry/images/Plancton.png", UriKind.Absolute)));
            obstacleBrush = new ImageBrush(new BitmapImage(new Uri("C:/Users/nicvampire/source/repos/WPfOceanFirstTry/images/KelpObstacle.png", UriKind.Absolute)));
            emptyCellBrush = new ImageBrush(new BitmapImage(new Uri("C:/Users/nicvampire/source/repos/WPfOceanFirstTry/images/OceanCell.png", UriKind.Absolute)));
            OceanDispatcherTimer = new DispatcherTimer();
            OceanDispatcherTimer.Tick += DTTicker;
        }
        public WPFOceanViewer(IOceanContainer owner, MainWindow mainWindow)
        {
            _owner = owner;
            OceanDispatcherTimer = new DispatcherTimer();
            OceanDispatcherTimer.Tick += DTTicker;
        }
    }
}
