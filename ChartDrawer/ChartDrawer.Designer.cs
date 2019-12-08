namespace ChartDrawer
{
    partial class ChartDrawer
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.itemListCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.unSelectAll = new System.Windows.Forms.Button();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveChartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawChartButton = new System.Windows.Forms.Button();
            this.saveChartDialog = new System.Windows.Forms.SaveFileDialog();
            this.changeChartTypeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.chartContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemListCheckedListBox
            // 
            this.itemListCheckedListBox.CheckOnClick = true;
            this.itemListCheckedListBox.FormattingEnabled = true;
            this.itemListCheckedListBox.Location = new System.Drawing.Point(12, 99);
            this.itemListCheckedListBox.Name = "itemListCheckedListBox";
            this.itemListCheckedListBox.Size = new System.Drawing.Size(239, 625);
            this.itemListCheckedListBox.TabIndex = 1;
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(12, 12);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(110, 34);
            this.selectAllButton.TabIndex = 2;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // unSelectAll
            // 
            this.unSelectAll.Location = new System.Drawing.Point(141, 12);
            this.unSelectAll.Name = "unSelectAll";
            this.unSelectAll.Size = new System.Drawing.Size(110, 34);
            this.unSelectAll.TabIndex = 2;
            this.unSelectAll.Text = "Unselect all";
            this.unSelectAll.UseVisualStyleBackColor = true;
            this.unSelectAll.Click += new System.EventHandler(this.UnSelectAll_Click);
            // 
            // mainChart
            // 
            chartArea2.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea2);
            this.mainChart.ContextMenuStrip = this.chartContextMenu;
            legend2.Name = "Legend1";
            this.mainChart.Legends.Add(legend2);
            this.mainChart.Location = new System.Drawing.Point(269, 12);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(1141, 755);
            this.mainChart.TabIndex = 4;
            this.mainChart.Text = "mainChart";
            this.mainChart.Visible = false;
            this.mainChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainChartMouseClick);
            // 
            // chartContextMenu
            // 
            this.chartContextMenu.Enabled = false;
            this.chartContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.chartContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveChartContextMenuItem});
            this.chartContextMenu.Name = "chartContextMenu";
            this.chartContextMenu.Size = new System.Drawing.Size(227, 36);
            // 
            // saveChartContextMenuItem
            // 
            this.saveChartContextMenuItem.Enabled = false;
            this.saveChartContextMenuItem.Name = "saveChartContextMenuItem";
            this.saveChartContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveChartContextMenuItem.Size = new System.Drawing.Size(226, 32);
            this.saveChartContextMenuItem.Text = "Save chart";
            // 
            // drawChartButton
            // 
            this.drawChartButton.Location = new System.Drawing.Point(12, 733);
            this.drawChartButton.Name = "drawChartButton";
            this.drawChartButton.Size = new System.Drawing.Size(239, 34);
            this.drawChartButton.TabIndex = 2;
            this.drawChartButton.Text = "Draw chart";
            this.drawChartButton.UseVisualStyleBackColor = true;
            this.drawChartButton.Click += new System.EventHandler(this.DrawChartButton_Click);
            // 
            // saveChartDialog
            // 
            this.saveChartDialog.FileName = "Chart.png";
            this.saveChartDialog.Filter = "Pictures|*.png|All Files|*";
            // 
            // changeChartTypeButton
            // 
            this.changeChartTypeButton.Location = new System.Drawing.Point(12, 52);
            this.changeChartTypeButton.Name = "changeChartTypeButton";
            this.changeChartTypeButton.Size = new System.Drawing.Size(239, 41);
            this.changeChartTypeButton.TabIndex = 0;
            this.changeChartTypeButton.Text = "Change Chart Type";
            this.changeChartTypeButton.UseVisualStyleBackColor = true;
            this.changeChartTypeButton.Click += new System.EventHandler(this.changeChartTypeButton_Click);
            // 
            // ChartDrawer
            // 
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.drawChartButton);
            this.Controls.Add(this.unSelectAll);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.itemListCheckedListBox);
            this.Controls.Add(this.changeChartTypeButton);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Size = new System.Drawing.Size(1437, 779);
            this.Resize += new System.EventHandler(this.ChartDrawer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.chartContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.CheckedListBox itemListCheckedListBox;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button unSelectAll;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Button drawChartButton;

        #endregion

        private System.Windows.Forms.ContextMenuStrip chartContextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveChartContextMenuItem;
        private System.Windows.Forms.SaveFileDialog saveChartDialog;
        private System.Windows.Forms.Button changeChartTypeButton;
    }
}
