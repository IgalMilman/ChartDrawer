using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text;
using System.Threading.Tasks;

namespace ChartDrawer
{
    public partial class ChartDrawer : Panel
    {
        const int MARGIN = 5;

        protected static List<SeriesChartType> _chartTypes = new List<SeriesChartType>
        {
            SeriesChartType.Line,
            SeriesChartType.Spline,
            SeriesChartType.Bar,
            SeriesChartType.Column
        };
        protected Dictionary<string, Dictionary<object, float>> chartData = new Dictionary<string, Dictionary<object, float>>();
        protected Dictionary<string, Series> chartSeries = new Dictionary<string, Series>();
        protected List<object> chartAxis = new List<object>();
        protected Title chartTitle;
        protected SeriesChartType currentChartType = SeriesChartType.Line;

        private const int DEFAULT_MARKER_WIDTH = 10;

        public ChartDrawer()
        {
            InitializeComponent();
        }

        public ChartDrawer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ChartDrawer(Dictionary<string, Dictionary<object, double>> data, List<object> axis, IContainer container = null)
        {
            if (container != null)
                container.Add(this);

            InitializeComponent();
            foreach (KeyValuePair<string, Dictionary<object, double>> obj in data)
            {
                Dictionary<object, float> chartDataChunk = new Dictionary<object, float>();
                foreach (KeyValuePair<object, double> value in obj.Value)
                {
                    chartDataChunk.Add(value.Key, (float)value.Value);
                }
                chartData.Add(obj.Key, chartDataChunk);
            }
            chartAxis = axis.ToList<object>();
            PopulateData();
        }

        public ChartDrawer(Dictionary<string, Dictionary<object, float>> data, List<object> axis, IContainer container = null)
        {
            if (container != null)
                container.Add(this);

            InitializeComponent();
            foreach (KeyValuePair<string, Dictionary<object, float>> obj in data)
            {
                Dictionary<object, float> chartDataChunk = new Dictionary<object, float>();
                foreach (KeyValuePair<object, float> value in obj.Value)
                {
                    chartDataChunk.Add(value.Key, (float)value.Value);
                }
                chartData.Add(obj.Key, chartDataChunk);
            }
            chartAxis = axis.ToList<object>();
            PopulateData();
        }

        public ChartDrawer(Dictionary<string, Dictionary<object, int>> data, List<object> axis, IContainer container = null)
        {
            if (container != null)
                container.Add(this);

            InitializeComponent();
            foreach (KeyValuePair<string, Dictionary<object, int>> obj in data)
            {
                Dictionary<object, float> chartDataChunk = new Dictionary<object, float>();
                foreach (KeyValuePair<object, int> value in obj.Value)
                {
                    chartDataChunk.Add(value.Key, (float)value.Value);
                }
                chartData.Add(obj.Key, chartDataChunk);
            }
            chartAxis = axis.ToList<object>();
            PopulateData();
        }

        protected void PopulateData()
        {
            chartSeries.Clear();
            foreach (KeyValuePair<string, Dictionary<object, float>> obj in chartData)
            {
                Series series = new Series(obj.Key);
                for (int i = 0; i < chartAxis.Count; ++i)
                {
                    DataPoint point = series.Points[series.Points.AddXY(i, obj.Value[chartAxis[i]])];
                    point.AxisLabel = chartAxis[i].ToString();
                    point.ToolTip = string.Format("Value for {0} at {1} is {2}", obj.Key.ToString(), chartAxis[i], obj.Value[chartAxis[i]]);
                }
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerBorderColor = Color.Black;
                series.MarkerBorderWidth = 0;
                series.MarkerSize = DEFAULT_MARKER_WIDTH;
                series.ChartType = currentChartType;
                //series.Color = colorschema[obj.Key];
                chartSeries.Add(obj.Key, series);
                itemListCheckedListBox.Items.Add(obj.Key, false);
            }
            saveChartContextMenuItem.Click += SaveChartContextMenuItem_Click;
        }

        public void SetTitle(string title)
        {
            if (title == null || !mainChart.Titles.Contains(chartTitle))
            {
                chartTitle = new Title(title);
                chartTitle.Font = new System.Drawing.Font(Font, FontStyle.Bold | FontStyle.Underline);
                mainChart.Titles.Add(chartTitle);
            }
        }

        private void SaveChartContextMenuItem_Click(object sender, EventArgs e)
        {
            if (saveChartDialog.ShowDialog() == DialogResult.OK)
            {
                mainChart.SaveImage(saveChartDialog.FileName, ChartImageFormat.Png);
            }
        }

        private ToolTip tooltip = new ToolTip();

        public Dictionary<string, Color> GetColorScheme(List<string> objects)
        {
            Dictionary<string, Color> result = new Dictionary<string, Color>();
            if (objects.Count == 1)
            {
                result.Add(objects[0], Color.Black);
            }
            if (objects.Count == 2)
            {
                result.Add(objects[0], Color.Red);
                result.Add(objects[1], Color.Blue);
            }
            if (objects.Count >= 3)
            {
                List<Color> allColors = new List<Color>();
                int parts = (int)Math.Truncate(Math.Log(objects.Count) / Math.Log(3) + 1);
                int partssq = parts * parts;
                int countOfColors = (int)Math.Pow(parts, 3);
                if (parts + objects.Count > countOfColors)
                    ++parts;
                double numberBase = parts - 1;
                if (numberBase == 0)
                    numberBase = 1;
                int red, green, blue;
                for (int i = 0; i < countOfColors; ++i)
                {
                    red = (int)(255 * (1 - ((i / partssq) % parts) / numberBase));
                    green = (int)(255 * (1 - ((i / parts) % parts) / numberBase));
                    blue = (int)(255 * (1 - (i % parts) / numberBase));
                    if (red != green || green != blue)
                        allColors.Add(Color.FromArgb(red, green, blue));
                }
                double step = ((double)allColors.Count) / ((double)objects.Count);
                double now = 0;
                green = 0;
                while (result.Count < objects.Count)
                {
                    red = (int)Math.Floor(now);
                    result.Add(objects[green++], allColors[red]);
                    now += step;
                }
            }
            return result;
        }

        private void MainChartMouseClick(object sender, MouseEventArgs e)
        {
            tooltip.RemoveAll();
            Point pos = e.Location;
            HitTestResult[] results = mainChart.HitTest(pos.X, pos.Y, false,
                                         ChartElementType.DataPoint);
            string tooltipText = "";
            foreach (HitTestResult result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    tooltipText = (tooltipText == "") ? (result.Object as DataPoint).ToolTip : (tooltipText + "\n" + (result.Object as DataPoint).ToolTip);
                }
            }
            if (tooltipText != "")
                tooltip.Show(tooltipText, mainChart, pos);
            results = mainChart.HitTest(pos.X, pos.Y, false,
                                         ChartElementType.DataPoint | ChartElementType.LegendItem);
            foreach (HitTestResult result in results)
            {
                if (result.ChartElementType == ChartElementType.LegendItem)
                {
                    if (result.Series.MarkerBorderWidth > 0)
                        result.Series.MarkerBorderWidth = 0;
                    else
                        result.Series.MarkerBorderWidth = 2;
                }
            }
        }

        private void DrawChartButton_Click(object sender, EventArgs e)
        {
            mainChart.Series.Clear();
            List<string> objectsOnChart = new List<string>();
            foreach (object item in itemListCheckedListBox.CheckedItems)
            {
                if (chartSeries.ContainsKey(item.ToString()))
                {
                    objectsOnChart.Add(item.ToString());
                }
            }
            Dictionary<string, Color> colorschema = GetColorScheme(objectsOnChart);
            foreach (string obj in objectsOnChart)
            {
                chartSeries[obj].Color = colorschema[obj];
                mainChart.Series.Add(chartSeries[obj]);
            }
            chartContextMenu.Enabled = objectsOnChart.Count > 0;
            saveChartContextMenuItem.Enabled = chartContextMenu.Enabled;
            mainChart.Visible = objectsOnChart.Count > 0;
        }

        private void ChartDrawer_Resize(object sender, EventArgs e)
        {
            int workwidth = ClientSize.Width - MARGIN;
            int workheight = ClientSize.Height - MARGIN;
            drawChartButton.Top = workheight - drawChartButton.Height;
            itemListCheckedListBox.Height = drawChartButton.Top - MARGIN - itemListCheckedListBox.Top;
            mainChart.Width = workwidth - mainChart.Left;
            mainChart.Height = workheight - mainChart.Top;
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < itemListCheckedListBox.Items.Count; i++)
            {
                itemListCheckedListBox.SetItemChecked(i, true);
            }
        }

        private void UnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < itemListCheckedListBox.Items.Count; i++)
            {
                itemListCheckedListBox.SetItemChecked(i, true);
            }
        }

        private void changeChartTypeButton_Click(object sender, EventArgs e)
        {
            currentChartType = _chartTypes[(_chartTypes.IndexOf(currentChartType) + 1) % _chartTypes.Count];
            foreach (KeyValuePair<string, Series> obj in chartSeries)
            {
                obj.Value.ChartType = currentChartType;
                if (currentChartType == SeriesChartType.Bar || currentChartType == SeriesChartType.Column)
                {
                    obj.Value.MarkerSize = 0;
                }
                else
                {
                    obj.Value.MarkerSize = DEFAULT_MARKER_WIDTH;
                }
            }
        }
    }
}
