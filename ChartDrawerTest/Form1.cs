using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartDrawerTest
{
    public partial class Form1 : Form
    {
        ChartDrawer.ChartDrawer chart=null;

        Dictionary<string, Dictionary<object, float>> data = new Dictionary<string, Dictionary<object, float>>()
        {
            { "test1", new Dictionary<object, float>(){{"t1", 1 },{"t3", 2}, {"q4", 5}, {"s", 8 } } },
            { "test2", new Dictionary<object, float>(){{"t1", 5 },{"t3", 8}, {"q4", 2}, {"s", 1 } } },
            { "chuchu", new Dictionary<object, float>(){{"t1", 10 },{"t3", 1}, {"q4", 7}, {"s", 3 } } }
        };

        List<object> axis = new List<object>() { "t1", "t3", "q4", "s" };

        public Form1()
        {
            InitializeComponent();
        }

        public Dictionary<string, Color> GetColorScheme(List<string> objects)
        {
            Dictionary<string, Color> result = new Dictionary<string, Color>();
            if (objects.Count <= 1)
            {
                result.Add(objects[0], Color.Black);
            }
            if (objects.Count == 2)
            {
                result.Add(objects[0], Color.Red);
                result.Add(objects[0], Color.Blue);
            }
            if (objects.Count >= 3)
            {
                int parts = (int)Math.Truncate(Math.Log(objects.Count) / Math.Log(3) + 1);
                int partssq = parts * parts;
                int countOfColors = (int)Math.Pow(parts, 3);
                if (parts + objects.Count > countOfColors)
                    ++parts;
                double numberBase = parts - 1;
                if (numberBase == 0)
                    numberBase = 1;
                int red, green, blue, skipped = 0;
                for( int i =0; i< objects.Count; ++i)
                {
                    red = (int)(255 * (1-(((i + skipped) / partssq) % parts) / numberBase));
                    green = (int)(255 * (1-(((i + skipped) / parts) % parts) / numberBase));
                    blue = (int)(255 * (1-((i + skipped)% parts) / numberBase));
                    if (red == green && green == blue)
                    {
                        ++skipped;
                        --i;
                    }
                    else
                        result.Add(objects[i], Color.FromArgb(red, green, blue));
                }
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            Random rand = new Random();
            for (int i =0; i<10+rand.Next(10); ++i)
            {
                data.Add("chuchu" + i.ToString(), new Dictionary<object, float>() { { "t1", (float)rand.NextDouble() * 10 }, { "t3", (float)rand.NextDouble() * 10 }, { "q4", (float)rand.NextDouble() * 10 }, { "s", (float)rand.NextDouble() * 10 } });
            }
            int j = 0;
            SeriesChartType[] charttypes = new SeriesChartType[] { SeriesChartType.Line, SeriesChartType.Line };
            Dictionary<string, Color> colorschema = GetColorScheme(data.Keys.ToList<string>());
            foreach (KeyValuePair<string, Dictionary<object, float>> obj in data)
            {
                Series series = new Series(obj.Key);
                for (int i = 0; i < axis.Count; ++i)
                {
                    DataPoint point = series.Points[series.Points.AddXY(i, obj.Value[axis[i]])];
                    point.AxisLabel = axis[i].ToString();
                    point.ToolTip = string.Format("value for {0} at {1} is {2}", obj.Key.ToString(), axis[i], obj.Value[axis[i]]);
                }
                series.BorderWidth = 2;
                series.BorderColor = Color.Black;
                series.LabelBorderColor = Color.Red;
                series.LabelBorderWidth = 3;
                series.LabelBorderDashStyle = ChartDashStyle.Solid;
                series.MarkerStyle = MarkerStyle.Diamond;
                series.MarkerSize = 10;
                series.ChartType = charttypes[j++ % charttypes.Length];
                series.Color = colorschema[obj.Key];
                chart1.Series.Add(series);
            }
            ser = chart1.Series[chart1.Series.Count - 1];
            chart = new ChartDrawer.ChartDrawer(data, axis);
            chart.SetTitle("Test data");
            chart.Left = 0;
            chart.Top = 0;
            chart.Size = new Size(ClientSize.Width - 10, ClientSize.Height-10);
            Controls.Add(chart);
        }

        ToolTip tooltip = new ToolTip();
        Point? clickPosition = null;
        Series ser;

        void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clickPosition.HasValue && e.Location != clickPosition)
            {
                tooltip.RemoveAll();
                clickPosition = null;
            }
        }

        void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var pos = e.Location;
                clickPosition = pos;
                Debug.WriteLine(pos);
                var results = chart1.HitTest(pos.X, pos.Y, false,
                                             ChartElementType.PlottingArea);
                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.PlottingArea)
                    {
                        var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                        var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

                        tooltip.Show("X=" + xVal + ", Y=" + yVal,
                                     this.chart1, e.Location.X, e.Location.Y - 15);
                    }
                }
                if (chart1.Series.Contains(ser))
                    chart1.Series.Remove(ser);
                else
                    chart1.Series.Add(ser);
            }
        }

        private void chart1_MouseHover(object sender, EventArgs e)
        {
            /*Point pos = chart1.PointToClient(System.Windows.Forms.Cursor.Position);
            clickPosition = pos;
            Debug.WriteLine(pos);
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                         ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

                    tooltip.Show("X=" + xVal + ", Y=" + yVal,
                                 this.chart1, pos);
                }
            }*/
        }

        private void redrawChartButton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (chart != null)
            {
                chart.Height = ClientSize.Height - chart.Top;
                chart.Width = ClientSize.Width - chart.Left;
            }

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (chart != null)
            {
                chart.Height = ClientSize.Height - chart.Top;
                chart.Width = ClientSize.Width - chart.Left;
            }
        }
    }
}
