using System.Windows.Forms;

namespace PCMonitor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPerformance;
        private System.Windows.Forms.TabPage tabProcesses;
        private System.Windows.Forms.TabPage tabSystemInfo;

        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label gpuLabel;
        private System.Windows.Forms.Label cpuTempLabel;
        private System.Windows.Forms.Label gpuTempLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelTemp;
        private System.Windows.Forms.Panel panelChart;

        private System.Windows.Forms.TreeView treeViewProcesses;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.Panel panelProcessButtons;

        private System.Windows.Forms.Panel panelPCInfo;
        private System.Windows.Forms.Panel panelHardwareInfo;
        private System.Windows.Forms.Panel panelStorageInfo;
        private System.Windows.Forms.Label lblPCName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblWindowsVersion;
        private System.Windows.Forms.Label lblCPUInfo;
        private System.Windows.Forms.Label lblRAMInfo;
        private System.Windows.Forms.Label lblGPUInfo;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.ListView listViewDisks;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPerformance = new System.Windows.Forms.TabPage();
            this.tabProcesses = new System.Windows.Forms.TabPage();
            this.tabSystemInfo = new System.Windows.Forms.TabPage();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelTemp = new System.Windows.Forms.Panel();
            this.panelChart = new System.Windows.Forms.Panel();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.gpuLabel = new System.Windows.Forms.Label();
            this.cpuTempLabel = new System.Windows.Forms.Label();
            this.gpuTempLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.treeViewProcesses = new System.Windows.Forms.TreeView();
            this.panelProcessButtons = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonKill = new System.Windows.Forms.Button();

            this.panelPCInfo = new System.Windows.Forms.Panel();
            this.panelHardwareInfo = new System.Windows.Forms.Panel();
            this.panelStorageInfo = new System.Windows.Forms.Panel();
            this.lblPCName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblWindowsVersion = new System.Windows.Forms.Label();
            this.lblCPUInfo = new System.Windows.Forms.Label();
            this.lblRAMInfo = new System.Windows.Forms.Label();
            this.lblGPUInfo = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.listViewDisks = new System.Windows.Forms.ListView();

            this.tabControl.SuspendLayout();
            this.tabPerformance.SuspendLayout();
            this.tabProcesses.SuspendLayout();
            this.tabSystemInfo.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelTemp.SuspendLayout();
            this.panelChart.SuspendLayout();
            this.panelProcessButtons.SuspendLayout();
            this.panelPCInfo.SuspendLayout();
            this.panelHardwareInfo.SuspendLayout();
            this.panelStorageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PC Monitor - Мониторинг системи";
            this.MinimumSize = new System.Drawing.Size(1000, 600);


            this.tabControl.Controls.Add(this.tabPerformance);
            this.tabControl.Controls.Add(this.tabProcesses);
            this.tabControl.Controls.Add(this.tabSystemInfo);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 700);
            this.tabControl.TabIndex = 0;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl.ItemSize = new System.Drawing.Size(200, 40);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl_DrawItem);

 
            this.tabPerformance.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.tabPerformance.Controls.Add(this.panelChart);
            this.tabPerformance.Controls.Add(this.panelTemp);
            this.tabPerformance.Controls.Add(this.panelStats);
            this.tabPerformance.Location = new System.Drawing.Point(4, 44);
            this.tabPerformance.Name = "tabPerformance";
            this.tabPerformance.Padding = new System.Windows.Forms.Padding(15);
            this.tabPerformance.Size = new System.Drawing.Size(1192, 652);
            this.tabPerformance.TabIndex = 0;
            this.tabPerformance.Text = "Продуктивність";

            this.panelStats.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats.Controls.Add(this.cpuLabel);
            this.panelStats.Controls.Add(this.gpuLabel);
            this.panelStats.Location = new System.Drawing.Point(20, 20);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(560, 120);
            this.panelStats.TabIndex = 0;
            this.panelStats.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.cpuLabel.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.cpuLabel.Location = new System.Drawing.Point(20, 20);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(110, 30);
            this.cpuLabel.TabIndex = 0;
            this.cpuLabel.Text = "CPU: 0%";

            this.gpuLabel.AutoSize = true;
            this.gpuLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.gpuLabel.ForeColor = System.Drawing.Color.FromArgb(232, 17, 35);
            this.gpuLabel.Location = new System.Drawing.Point(20, 65);
            this.gpuLabel.Name = "gpuLabel";
            this.gpuLabel.Size = new System.Drawing.Size(110, 30);
            this.gpuLabel.TabIndex = 1;
            this.gpuLabel.Text = "GPU: 0%";

            this.panelTemp.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTemp.Controls.Add(this.cpuTempLabel);
            this.panelTemp.Controls.Add(this.gpuTempLabel);
            this.panelTemp.Location = new System.Drawing.Point(600, 20);
            this.panelTemp.Name = "panelTemp";
            this.panelTemp.Size = new System.Drawing.Size(560, 120);
            this.panelTemp.TabIndex = 1;
            this.panelTemp.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.cpuTempLabel.AutoSize = true;
            this.cpuTempLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.cpuTempLabel.ForeColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.cpuTempLabel.Location = new System.Drawing.Point(20, 20);
            this.cpuTempLabel.Name = "cpuTempLabel";
            this.cpuTempLabel.Size = new System.Drawing.Size(150, 30);
            this.cpuTempLabel.TabIndex = 0;
            this.cpuTempLabel.Text = "??? CPU: N/A";

            this.gpuTempLabel.AutoSize = true;
            this.gpuTempLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.gpuTempLabel.ForeColor = System.Drawing.Color.FromArgb(255, 69, 0);
            this.gpuTempLabel.Location = new System.Drawing.Point(20, 65);
            this.gpuTempLabel.Name = "gpuTempLabel";
            this.gpuTempLabel.Size = new System.Drawing.Size(150, 30);
            this.gpuTempLabel.TabIndex = 1;
            this.gpuTempLabel.Text = "?? GPU: N/A";

            this.panelChart.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChart.Controls.Add(this.chart1);
            this.panelChart.Location = new System.Drawing.Point(20, 160);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(1140, 460);
            this.panelChart.TabIndex = 2;
            this.panelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.chart1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            chartArea1.Name = "ChartArea1";
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(60, 60, 60);
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(60, 60, 60);
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            this.chart1.ChartAreas.Add(chartArea1);

            legend1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);

            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";

            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(0, 120, 215);
            series1.Legend = "Legend1";
            series1.Name = "CPU";

            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(232, 17, 35);
            series2.Legend = "Legend1";
            series2.Name = "GPU";

            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1138, 458);
            this.chart1.TabIndex = 0;

            this.tabProcesses.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.tabProcesses.Controls.Add(this.panelProcessButtons);
            this.tabProcesses.Controls.Add(this.treeViewProcesses);
            this.tabProcesses.Location = new System.Drawing.Point(4, 44);
            this.tabProcesses.Name = "tabProcesses";
            this.tabProcesses.Padding = new System.Windows.Forms.Padding(15);
            this.tabProcesses.Size = new System.Drawing.Size(1192, 652);
            this.tabProcesses.TabIndex = 1;
            this.tabProcesses.Text = "Процеси";
 
            this.treeViewProcesses.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.treeViewProcesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewProcesses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.treeViewProcesses.ForeColor = System.Drawing.Color.White;
            this.treeViewProcesses.FullRowSelect = true;
            this.treeViewProcesses.HideSelection = false;
            this.treeViewProcesses.Location = new System.Drawing.Point(20, 20);
            this.treeViewProcesses.Name = "treeViewProcesses";
            this.treeViewProcesses.ShowLines = true;
            this.treeViewProcesses.ShowPlusMinus = true;
            this.treeViewProcesses.ShowRootLines = true;
            this.treeViewProcesses.Size = new System.Drawing.Size(1140, 540);
            this.treeViewProcesses.TabIndex = 0;
            this.treeViewProcesses.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeViewProcesses.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TreeView_DrawNode);
 
            this.panelProcessButtons.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelProcessButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProcessButtons.Controls.Add(this.buttonRefresh);
            this.panelProcessButtons.Controls.Add(this.buttonKill);
            this.panelProcessButtons.Location = new System.Drawing.Point(20, 575);
            this.panelProcessButtons.Name = "panelProcessButtons";
            this.panelProcessButtons.Size = new System.Drawing.Size(1140, 60);
            this.panelProcessButtons.TabIndex = 1;

            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 140, 240);
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(10, 10);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(180, 40);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.Text = "Оновити";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);

            this.buttonKill.BackColor = System.Drawing.Color.FromArgb(232, 17, 35);
            this.buttonKill.FlatAppearance.BorderSize = 0;
            this.buttonKill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 50, 70);
            this.buttonKill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKill.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonKill.ForeColor = System.Drawing.Color.White;
            this.buttonKill.Location = new System.Drawing.Point(200, 10);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(180, 40);
            this.buttonKill.TabIndex = 1;
            this.buttonKill.Text = "Завершити";
            this.buttonKill.UseVisualStyleBackColor = false;
            this.buttonKill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);

            this.tabSystemInfo.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.tabSystemInfo.Controls.Add(this.panelStorageInfo);
            this.tabSystemInfo.Controls.Add(this.panelHardwareInfo);
            this.tabSystemInfo.Controls.Add(this.panelPCInfo);
            this.tabSystemInfo.Location = new System.Drawing.Point(4, 44);
            this.tabSystemInfo.Name = "tabSystemInfo";
            this.tabSystemInfo.Padding = new System.Windows.Forms.Padding(15);
            this.tabSystemInfo.Size = new System.Drawing.Size(1192, 652);
            this.tabSystemInfo.TabIndex = 2;
            this.tabSystemInfo.Text = "Система";

            this.panelPCInfo.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelPCInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPCInfo.Controls.Add(this.lblPCName);
            this.panelPCInfo.Controls.Add(this.lblUserName);
            this.panelPCInfo.Controls.Add(this.lblWindowsVersion);
            this.panelPCInfo.Location = new System.Drawing.Point(20, 20);
            this.panelPCInfo.Name = "panelPCInfo";
            this.panelPCInfo.Size = new System.Drawing.Size(1140, 140);
            this.panelPCInfo.TabIndex = 0;
            this.panelPCInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.lblPCName.AutoSize = true;
            this.lblPCName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPCName.ForeColor = System.Drawing.Color.FromArgb(0, 200, 255);
            this.lblPCName.Location = new System.Drawing.Point(20, 15);
            this.lblPCName.Name = "lblPCName";
            this.lblPCName.Size = new System.Drawing.Size(200, 25);
            this.lblPCName.TabIndex = 0;
            this.lblPCName.Text = "?? ПК: ";

            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(100, 220, 100);
            this.lblUserName.Location = new System.Drawing.Point(20, 55);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(200, 25);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "?? Користувач: ";

            this.lblWindowsVersion.AutoSize = true;
            this.lblWindowsVersion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblWindowsVersion.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblWindowsVersion.Location = new System.Drawing.Point(20, 95);
            this.lblWindowsVersion.Name = "lblWindowsVersion";
            this.lblWindowsVersion.Size = new System.Drawing.Size(200, 25);
            this.lblWindowsVersion.TabIndex = 2;
            this.lblWindowsVersion.Text = "?? Windows: ";

            this.panelHardwareInfo.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelHardwareInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHardwareInfo.Controls.Add(this.lblCPUInfo);
            this.panelHardwareInfo.Controls.Add(this.lblRAMInfo);
            this.panelHardwareInfo.Controls.Add(this.lblGPUInfo);
            this.panelHardwareInfo.Controls.Add(this.lblUptime);
            this.panelHardwareInfo.Location = new System.Drawing.Point(20, 180);
            this.panelHardwareInfo.Name = "panelHardwareInfo";
            this.panelHardwareInfo.Size = new System.Drawing.Size(1140, 180);
            this.panelHardwareInfo.TabIndex = 1;
            this.panelHardwareInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.lblCPUInfo.AutoSize = true;
            this.lblCPUInfo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCPUInfo.ForeColor = System.Drawing.Color.FromArgb(255, 200, 100);
            this.lblCPUInfo.Location = new System.Drawing.Point(20, 15);
            this.lblCPUInfo.Name = "lblCPUInfo";
            this.lblCPUInfo.Size = new System.Drawing.Size(200, 25);
            this.lblCPUInfo.TabIndex = 0;
            this.lblCPUInfo.Text = "?? CPU: ";

            this.lblRAMInfo.AutoSize = true;
            this.lblRAMInfo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRAMInfo.ForeColor = System.Drawing.Color.FromArgb(150, 150, 255);
            this.lblRAMInfo.Location = new System.Drawing.Point(20, 55);
            this.lblRAMInfo.Name = "lblRAMInfo";
            this.lblRAMInfo.Size = new System.Drawing.Size(200, 25);
            this.lblRAMInfo.TabIndex = 1;
            this.lblRAMInfo.Text = "?? RAM: ";

            this.lblGPUInfo.AutoSize = true;
            this.lblGPUInfo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGPUInfo.ForeColor = System.Drawing.Color.FromArgb(100, 255, 100);
            this.lblGPUInfo.Location = new System.Drawing.Point(20, 95);
            this.lblGPUInfo.Name = "lblGPUInfo";
            this.lblGPUInfo.Size = new System.Drawing.Size(200, 25);
            this.lblGPUInfo.TabIndex = 2;
            this.lblGPUInfo.Text = "?? GPU: ";
 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblUptime.ForeColor = System.Drawing.Color.FromArgb(255, 150, 200);
            this.lblUptime.Location = new System.Drawing.Point(20, 135);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(200, 25);
            this.lblUptime.TabIndex = 3;
            this.lblUptime.Text = "?? Uptime: ";

            this.panelStorageInfo.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelStorageInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStorageInfo.Controls.Add(this.listViewDisks);
            this.panelStorageInfo.Location = new System.Drawing.Point(20, 380);
            this.panelStorageInfo.Name = "panelStorageInfo";
            this.panelStorageInfo.Size = new System.Drawing.Size(1140, 240);
            this.panelStorageInfo.TabIndex = 2;
            this.panelStorageInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.listViewDisks.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.listViewDisks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewDisks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDisks.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.listViewDisks.ForeColor = System.Drawing.Color.White;
            this.listViewDisks.FullRowSelect = true;
            this.listViewDisks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDisks.Location = new System.Drawing.Point(0, 0);
            this.listViewDisks.Name = "listViewDisks";
            this.listViewDisks.Size = new System.Drawing.Size(1138, 238);
            this.listViewDisks.TabIndex = 0;
            this.listViewDisks.UseCompatibleStateImageBehavior = false;
            this.listViewDisks.View = System.Windows.Forms.View.Details;
            this.listViewDisks.Columns.Add("Диск", 150);
            this.listViewDisks.Columns.Add("Використано", 200);
            this.listViewDisks.Columns.Add("Вільно", 200);
            this.listViewDisks.Columns.Add("Загалом", 200);
            this.listViewDisks.Columns.Add("%", 150);
            this.listViewDisks.OwnerDraw = true;
            this.listViewDisks.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListView_DrawColumnHeader);
            this.listViewDisks.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView_DrawItem);
            this.listViewDisks.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListView_DrawSubItem);

            this.tabControl.ResumeLayout(false);
            this.tabPerformance.ResumeLayout(false);
            this.tabProcesses.ResumeLayout(false);
            this.tabSystemInfo.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelTemp.ResumeLayout(false);
            this.panelTemp.PerformLayout();
            this.panelChart.ResumeLayout(false);
            this.panelProcessButtons.ResumeLayout(false);
            this.panelPCInfo.ResumeLayout(false);
            this.panelPCInfo.PerformLayout();
            this.panelHardwareInfo.ResumeLayout(false);
            this.panelHardwareInfo.PerformLayout();
            this.panelStorageInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
        }

        private void TabControl_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            var tabControl = sender as TabControl;
            var tabPage = tabControl.TabPages[e.Index];
            var tabRect = tabControl.GetTabRect(e.Index);

            var bgColor = (e.State == DrawItemState.Selected)
                ? System.Drawing.Color.FromArgb(45, 45, 48)
                : System.Drawing.Color.FromArgb(30, 30, 30);

            using (var brush = new System.Drawing.SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            var textColor = (e.State == DrawItemState.Selected)
                ? System.Drawing.Color.FromArgb(0, 120, 215)
                : System.Drawing.Color.Gray;

            using (var textBrush = new System.Drawing.SolidBrush(textColor))
            {
                var stringFormat = new System.Drawing.StringFormat
                {
                    Alignment = System.Drawing.StringAlignment.Center,
                    LineAlignment = System.Drawing.StringAlignment.Center
                };
                e.Graphics.DrawString(tabPage.Text, e.Font, textBrush, tabRect, stringFormat);
            }
        }

        private void Panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var panel = sender as Panel;
            var rect = panel.ClientRectangle;

            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(60, 60, 60), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, rect.Width - 1, rect.Height - 1);
            }
        }

        private void TreeView_DrawNode(object sender, System.Windows.Forms.DrawTreeNodeEventArgs e)
        {
            var backColor = e.Node.IsSelected
                ? System.Drawing.Color.FromArgb(0, 120, 215)
                : System.Drawing.Color.FromArgb(45, 45, 48);

            var foreColor = System.Drawing.Color.White;

            using (var brush = new System.Drawing.SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            using (var textBrush = new System.Drawing.SolidBrush(foreColor))
            {
                e.Graphics.DrawString(e.Node.Text, e.Node.TreeView.Font, textBrush, e.Bounds.Left, e.Bounds.Top);
            }
        }

        private void ListView_DrawColumnHeader(object sender, System.Windows.Forms.DrawListViewColumnHeaderEventArgs e)
        {
            using (var brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(35, 35, 38)))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            using (var textBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 120, 215)))
            {
                var sf = new System.Drawing.StringFormat
                {
                    Alignment = System.Drawing.StringAlignment.Near,
                    LineAlignment = System.Drawing.StringAlignment.Center
                };
                e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, sf);
            }

            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(60, 60, 60)))
            {
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }
        }

        private void ListView_DrawItem(object sender, System.Windows.Forms.DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;
        }

        private void ListView_DrawSubItem(object sender, System.Windows.Forms.DrawListViewSubItemEventArgs e)
        {
            var backColor = e.Item.Selected
                ? System.Drawing.Color.FromArgb(0, 120, 215)
                : System.Drawing.Color.FromArgb(45, 45, 48);

            using (var brush = new System.Drawing.SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            using (var textBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White))
            {
                var sf = new System.Drawing.StringFormat
                {
                    Alignment = System.Drawing.StringAlignment.Near,
                    LineAlignment = System.Drawing.StringAlignment.Center,
                    Trimming = System.Drawing.StringTrimming.EllipsisCharacter
                };
                e.Graphics.DrawString(e.SubItem.Text, e.Item.ListView.Font, textBrush, e.Bounds, sf);
            }
        }
    }
}