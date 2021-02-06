using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiulioSmedile_Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Graphics g;

        int selectedMethod = 1;

        int n = 200;
        int m = 150;
        int k = 2;

        double sigma = 0.10;                  //Brownian Motion user variable
        double lambda = 10;                   //Bernoulli Process user variable
        double mu = 0.10;                     //Geometric brownian motion user variable
        double a = 1;                         //Values for Vasicek's process
        double b = 5;
        double startingValue = 1;             //Value for those processes that don't start at 0
        double sqrt;
        float step = 0;
        double b_iterator = 0, b_successes = 0;          //iteration values, used in the bernoulli trials

        Random R = new Random();
        Color[] Colors = new Color[] {
            Color.Black, Color.White, Color.Blue, Color.Red, Color.Magenta, Color.Orange, Color.Brown, Color.DarkGreen, Color.Green, Color.Teal, Color.Cyan, Color.Purple, Color.Pink
        };


        List<PointF[]> variables = new List<PointF[]>();
        List<double> valuesList = new List<double>();

        public double minX;
        public double maxX;
        public double minY;
        public double maxY;
        public double rangeX;
        public double rangeY;

        public Rectangle chart;

        private void Form1_Load(object sender, EventArgs e)
        {                                                  
            this.nInput.Text = n.ToString();               
            this.mInput.Text = m.ToString();               
            this.sigmaInput.Text = sigma.ToString();
            this.lambdaInput.Text = lambda.ToString();
            this.muInput.Text = mu.ToString();
            this.aInput.Text = a.ToString();
            this.bInput.Text = b.ToString();
            this.startInput.Text = startingValue.ToString();
            this.kInput.Text = k.ToString();
        }

        private void compute_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            debugLabel.Text = "";
            // Parse the input values from the Form, be careful those are actually numerical values...
            try
            {
                n = Convert.ToInt32(this.nInput.Text);
                m = Convert.ToInt32(this.mInput.Text);
                a = Convert.ToDouble(this.aInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                b = Convert.ToDouble(this.bInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                mu = Convert.ToDouble(this.muInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                sigma = Convert.ToDouble(this.sigmaInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                lambda = Convert.ToDouble(this.lambdaInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                startingValue = Convert.ToDouble(this.startInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                k = Convert.ToInt32(this.kInput.Text);
            } catch (Exception ex)
            {
                debugLabel.Text = "There is at least one illegal value. Using previous ones.";
            }

            //Watching for overflows/underflows so those don't cause crashes
            lambda = lambda == 100 ? 99 : lambda;
            sigma = sigma == 0 ? 0.1 : sigma;


            progressBar1.PerformStep();
            this.init();
        }

        void init()
        {
            sqrt = Math.Sqrt(1f / (float)n);

            variables.Clear();
            valuesList.Clear();

            randomVariables();
            minX = 0;
            maxX = (double)n;
            minY = valuesList.Min();
            maxY = valuesList.Max();
            rangeX = (double)n;
            rangeY = maxY - minY;
            progressBar1.PerformStep();

            initializeGraphics();
            progressBar1.PerformStep();
            draw();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            if (drawChart() == -1) return;
            progressBar1.PerformStep();
            calcHistograms();
            progressBar1.PerformStep();

        }

        void initializeGraphics()
        {
            bitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            chart = new Rectangle(0, 0, this.pictureBox1.Width - 60, this.pictureBox1.Height);
        }


        // ------------------------------------------------------------------------
        // ---------------------------Function Computers---------------------------
        // ------------------------------------------------------------------------

        double bernoulliStep(double k)
        {
            float prob = (float)lambda * 1f/(float)n;
            //float x = Convert.ToSingle(R.Next(-1000, +1000) * 0.001);
            float x = (float)R.NextDouble();
            if (x <= prob)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        double brownianStep(double k)
        {
            double plusOrMinus = R.NextDouble() < 0.5 ? -1 : 1;
            double zeta = R.NextDouble();
            double result = (double)sigma * sqrt * zeta * plusOrMinus;
            //Debug.WriteLine("Result: " + plusOrMinus);
            return result;
        }

        double geometricBrownianStep(double prevVal)
        {
            double step = 1d / n;
            double noise =  sigma * SampleGaussian(0, Math.Sqrt(step));
            double result = (prevVal + mu * step + sqrt * noise) * Math.Exp((mu - (sigma * sigma) / 2) * step + noise);
            return result;
        }

        double vasicekStep(double prevVal)
        {
            double step = 1d / n;
            double result = (1 - a * step) * prevVal + a * b * step + sigma * Math.Sqrt(step) * SampleGaussian(0, 1);
            return result;
        }

        double rademacherStep(double k)
        {
            return R.NextDouble() < 0.5 ? -1 : 1;
        }

        double LLNStep(double prevVal)
        {
            b_iterator++;
            double tmp = R.NextDouble();
            if (tmp < lambda/100) b_successes++;
            double result = b_successes / b_iterator;
            return result;
        }

        double mertonStep(double prevVal)
        {
            //// The process can be approximated as a GBM plus a jump term
            //return geometricBrownianStep(prevVal);

            double result;
            double dt = 1d / n;
            double z1 = SampleGaussian(0, 1);
            double z2 = SampleGaussian(0, 1);
            double mu_y = Math.Exp(a + 0.5 * b * b);
            double sigma2_y = Math.Exp(2 * a + b * b) * (Math.Exp(b * b) - 1);

            double n_deltat = randomPoisson(lambda * dt) * dt;
            double sigma_y = Math.Sqrt(sigma2_y);
            double j = mu_y * n_deltat + sigma_y * z2 * Math.Sqrt(n_deltat);

            result = prevVal * Math.Exp((mu - 0.5*(sigma * sigma)) * dt + sigma * Math.Sqrt(dt) * z1 + j);

            return result;
        }

        // ------------------------------------------------------------------------
        // ----------------------------Step Calculator-----------------------------
        // ------------------------------------------------------------------------

        void randomVariables()
        {
            double value = 0;
            List<PointF> pointsList = new List<PointF>();
            Func<Double, Double> selectedFunction;

            switch (selectedMethod)
            {
                case 1:
                    selectedFunction = bernoulliStep;
                    break;
                case 2:
                    selectedFunction = geometricBrownianStep;
                    value = startingValue;
                    break;
                case 3:
                    selectedFunction = brownianStep;
                    break;
                case 4:
                    selectedFunction = vasicekStep;
                    value = startingValue;
                    break;
                case 5:
                    selectedFunction = rademacherStep;
                    break;
                case 6:
                    selectedFunction = LLNStep;
                    break;
                case 7:
                    selectedFunction = mertonStep;
                    value = startingValue;
                    break;
                default:
                    selectedFunction = bernoulliStep;
                    debugLabel.Text = "Error while choosing which function to compute steps with. Using Bernoulli one instead.";
                    break;
            }

            // For each path...
            for (int j = 0; j < m; j++)
            {
                PointF point = new PointF();
                point.X = 0;
                point.Y = (float)value;
                pointsList.Add(point);
                valuesList.Add(value);

                // For each point in the path...
                for (int i = 0; i < n; i++)
                {
                    PointF p = new PointF();
                    
                    switch (selectedMethod)
                    {
                        //step for geometric, bernoulli and rademacher
                        case 1: case 3: case 5:
                            step = (float)selectedFunction(i);
                            value = pointsList[i].Y + step;
                            break;
                        //step for geometric brownian, vasicek, bernoulli trials and merton
                        case 2: case 4: case 6: case 7:
                            value = (float)selectedFunction(pointsList[i].Y);
                            break;                       
                        default:
                            debugLabel.Text = "Error while computing. Using Bernoulli steps as a last resource.";
                            step = (float)bernoulliStep(i);
                            value = pointsList[i].Y + step;
                            break;
                    }

                    p.X = i+1;
                    p.Y = (float)value;
                    valuesList.Add(value);

                    pointsList.Add(p);                    
                }

                variables.Add(pointsList.ToArray());
                b_iterator = 0;
                b_successes = 0;
                pointsList.Clear();
                // If I'm dealing with GBM, Vasicek or Merton, I have to reset the starting value at the user input value
                value = (selectedMethod == 2 || selectedMethod == 4 || selectedMethod == 7) ? startingValue : 0;
                
            }
        }

        // ------------------------------------------------------------------------
        // ---------------------------Drawing Functions----------------------------
        // ------------------------------------------------------------------------


        void draw()
        {
            g.Clear(Color.Transparent);
            g.DrawRectangle(Pens.Black, chart);
            g.FillRectangle(new SolidBrush(Color.LightGray), chart);
            pictureBox1.Image = bitmap;
        }


        int drawChart()
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < m; i++)
            {
                int xDevice, yDevice;
                for (j = 0; j < n; j++)
                 {
                    try
                    {
                        xDevice = transformXViewport(variables[i][j].X, chart, minX, rangeX);
                        yDevice = transformYViewport(variables[i][j].Y, chart, minY, rangeY);

                        int xNext = transformXViewport(variables[i][j + 1].X, chart, minX, rangeX);
                        int yNext = transformYViewport(variables[i][j + 1].Y, chart, minY, rangeY);
                    
                        g.DrawLine(new Pen(Color.FromArgb(100, Colors[i % Colors.Length])), new PointF(xDevice, yDevice), new PointF(xNext, yNext));
                    } catch (Exception ex)
                    {
                        debugLabel.Text = "Couldn't complete simulation because some results are out-of-range. Please change the simulation parameters.";
                        return -1;
                    }
                }

            }

            //Draw 0 line
            int xZero = 0;
            int yZero = transformYViewport(0, chart, minY, rangeY);
            //Debug.WriteLine("x: " + xZero + "; y: " + yZero);

            g.DrawLine(Pens.White, new Point(xZero, yZero), new Point(xZero + pictureBox1.Width, yZero));
            return 0;
        }

        void calcHistograms()
        {
            //for each i-th line of points, create the histogram
            for (int i = 1; i <= k; i++)
            {
                List<double> histList = new List<double>();
                histList = getValuesFromPoints(i * n / k, variables);
                Histogram hist = new Histogram(histList, 15);

                //calculate the rectangle on which the histogram is drawn
                int iViewportX = transformXViewport(i * n / k, chart, minX, rangeX);
                int maxViewport = transformYViewport(histList.Max(), chart, minY, rangeY);
                int minViewport = transformYViewport(histList.Min(), chart, minY, rangeY);
                int heightViewport = Math.Abs(maxViewport - minViewport);
                Rectangle histViewport = new Rectangle(iViewportX, maxViewport, 50, heightViewport);

                hist.drawYHistogram(g, histViewport);

                //draw vertical line
                int xDevice = transformXViewport((n / k) * (i), chart, minX, rangeX);
                int yDevice = transformYViewport(0, chart, minY, rangeY);
                g.DrawLine(new Pen(Color.White), new Point(xDevice, chart.Bottom), new Point(xDevice, 0));                
            }
        }

        private List<double> getValuesFromPoints(int v, List<PointF[]> variables)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (variables[i][j].X == v) result.Add((double)variables[i][j].Y);
                }
            }

            return result;
        }

        // ------------------------------------------------------------------------
        // ---------------------------Function Selectors---------------------------
        // ------------------------------------------------------------------------
        private void functionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMethod = functionSelector.SelectedIndex + 1;

            switch (selectedMethod)
            {
                case 1:
                    this.Bernoulli_Selected();
                    break;
                case 2:
                    this.GeometricBrownian_Selected();
                    break;
                case 3:
                    this.Brownian_Selected();
                    break;
                case 4:
                    this.Vasicek_Selected();
                    break;
                case 5:
                    this.Rademacher_Selected();
                    break;
                case 6:
                    this.LLN_Selected();
                    break;
                case 7:
                    this.Merton_Selected();
                    break;
                default:
                    this.Bernoulli_Selected();
                    break;
            }
        }

        private void Bernoulli_Selected()
        {
            selectedMethod = 1;
            lambdaInput.Enabled = true;
            sigmaInput.Enabled = false;
            muInput.Enabled = false;
            aInput.Enabled = false;
            bInput.Enabled = false;
            startInput.Enabled = false;
        }

        private void GeometricBrownian_Selected()
        {
            selectedMethod = 2;
            lambdaInput.Enabled = false;
            sigmaInput.Enabled = true;
            muInput.Enabled = true;
            aInput.Enabled = false;
            bInput.Enabled = false;
            startInput.Enabled = true;
        }

        private void Brownian_Selected()
        {
            selectedMethod = 3;
            lambdaInput.Enabled = false;
            sigmaInput.Enabled = true;
            muInput.Enabled = false;
            aInput.Enabled = false;
            bInput.Enabled = false;
            startInput.Enabled = false;
        }

        private void Vasicek_Selected()
        {
            selectedMethod = 4;
            lambdaInput.Enabled = false;
            sigmaInput.Enabled = true;
            muInput.Enabled = false;
            aInput.Enabled = true;
            bInput.Enabled = true;
            startInput.Enabled = true;
            labelA.Text = "Speed (a)";
            labelB.Text = "Target (b)";
        }

        private void Rademacher_Selected()
        {
            selectedMethod = 5;
            lambdaInput.Enabled = false;
            sigmaInput.Enabled = false;
            muInput.Enabled = false;
            aInput.Enabled = false;
            bInput.Enabled = false;
            startInput.Enabled = false;
        }

        private void LLN_Selected()
        {
            selectedMethod = 6;
            lambdaInput.Enabled = true;
            sigmaInput.Enabled = false;
            muInput.Enabled = false;
            aInput.Enabled = false;
            bInput.Enabled = false;
            startInput.Enabled = false;
        }

        private void Merton_Selected()
        {
            selectedMethod = 7;
            lambdaInput.Enabled = true;
            sigmaInput.Enabled = true;
            muInput.Enabled = true;
            aInput.Enabled = true;
            bInput.Enabled = true;
            startInput.Enabled = true;
            labelA.Text = "a";
            labelB.Text = "b";

            sigma = 0.1;
            lambda = 150;
            mu = 0;
            a = 1;
            b = 0.2;
            startingValue = 1;

            sigmaInput.Text = "0,1";
            lambdaInput.Text = "150";
            muInput.Text = "0";
            aInput.Text = "1";
            bInput.Text = "0.2";
            startInput.Text = "1";

        }

        // ------------------------------------------------------------------------
        // -----------------General Purpose Mathematical Functions-----------------
        // ------------------------------------------------------------------------

        int transformXViewport(double X_World, Rectangle viewport, double MinX, double RangeX)
        {
            return (int)(viewport.Left + viewport.Width * (X_World - MinX) / RangeX);
        }
        int transformYViewport(double Y_World, Rectangle viewport, double MinY, double RangeY)
        {
            return (int)(viewport.Top + viewport.Height - viewport.Height * (Y_World - MinY) / RangeY);
        }

        static double Interpolate(double Value, double OldMin, double OldMax, double NewMin, double NewMax)
        {
            //Linear interpolation
            return ((NewMax - NewMin) / (OldMax - OldMin)) * (Value - OldMin) + NewMin;
        }

        private double randomPoisson(double lambda)
        {
            double p = 1.0, L = Math.Exp(-lambda);
            int k = 0;
            do
            {
                k++;
                p *= R.NextDouble();
            }
            while (p > L);
            return k - 1;
        }

        public double SampleGaussian(double mean, double stddev)
        {
            // The method requires sampling from a uniform random of (0,1]
            // but Random.NextDouble() returns a sample of [0,1).
            double x1 = 1 - R.NextDouble();
            double x2 = 1 - R.NextDouble();

            double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
            return y1 * stddev + mean;
        }

        
    }
}
