namespace ChartDrawerTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.itemListCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.unSelectAll = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.redrawChartButton = new System.Windows.Forms.Button();
            this.changeChartTypeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemListCheckedListBox
            // 
            this.itemListCheckedListBox.FormattingEnabled = true;
            this.itemListCheckedListBox.Location = new System.Drawing.Point(12, 99);
            this.itemListCheckedListBox.Name = "itemListCheckedListBox";
            this.itemListCheckedListBox.Size = new System.Drawing.Size(239, 625);
            this.itemListCheckedListBox.TabIndex = 1;
            this.itemListCheckedListBox.Visible = false;
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(12, 12);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(110, 34);
            this.selectAllButton.TabIndex = 2;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Visible = false;
            // 
            // unSelectAll
            // 
            this.unSelectAll.Location = new System.Drawing.Point(141, 12);
            this.unSelectAll.Name = "unSelectAll";
            this.unSelectAll.Size = new System.Drawing.Size(110, 34);
            this.unSelectAll.TabIndex = 2;
            this.unSelectAll.Text = "Unselect all";
            this.unSelectAll.UseVisualStyleBackColor = true;
            this.unSelectAll.Visible = false;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(269, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1141, 755);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            this.chart1.MouseHover += new System.EventHandler(this.chart1_MouseHover);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseMove);
            // 
            // redrawChartButton
            // 
            this.redrawChartButton.Location = new System.Drawing.Point(12, 733);
            this.redrawChartButton.Name = "redrawChartButton";
            this.redrawChartButton.Size = new System.Drawing.Size(239, 34);
            this.redrawChartButton.TabIndex = 2;
            this.redrawChartButton.Text = "Redraw chart";
            this.redrawChartButton.UseVisualStyleBackColor = true;
            this.redrawChartButton.Visible = false;
            this.redrawChartButton.Click += new System.EventHandler(this.redrawChartButton_Click);
            // 
            // changeChartTypeButton
            // 
            this.changeChartTypeButton.Location = new System.Drawing.Point(12, 52);
            this.changeChartTypeButton.Name = "changeChartTypeButton";
            this.changeChartTypeButton.Size = new System.Drawing.Size(239, 41);
            this.changeChartTypeButton.TabIndex = 5;
            this.changeChartTypeButton.Text = "Change Chart Type";
            this.changeChartTypeButton.UseVisualStyleBackColor = true;
            this.changeChartTypeButton.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 779);
            this.Controls.Add(this.changeChartTypeButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.redrawChartButton);
            this.Controls.Add(this.unSelectAll);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.itemListCheckedListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox itemListCheckedListBox;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button unSelectAll;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button redrawChartButton;
        private System.Windows.Forms.Button changeChartTypeButton;
    }
}

