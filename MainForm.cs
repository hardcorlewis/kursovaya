using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Management;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace PCMonitor
{
    public partial class MainForm : Form
    {
        private MonitorService monitorService;
        private Timer timer;
        private Timer processTimer;
        private const int MaxDataPoints = 60;

        private ImageList processImageList;
        private Dictionary<int, ProcessInfo> previousProcesses;

        private class ProcessInfo
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public long MemoryUsage { get; set; }
            public double CpuUsage { get; set; }
            public int ThreadCount { get; set; }
        }

        public MainForm()
        {
            InitializeComponent();

            monitorService = new MonitorService();
            previousProcesses = new Dictionary<int, ProcessInfo>();

            processImageList = new ImageList();
            processImageList.ImageSize = new Size(16, 16);
            processImageList.ColorDepth = ColorDepth.Depth32Bit;
            treeViewProcesses.ImageList = processImageList;

            InitializeChart();

            LoadSystemInfo();
            LoadDiskInfo();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            processTimer = new Timer();
            processTimer.Interval = 2000;
            processTimer.Tick += ProcessTimer_Tick;
            processTimer.Start();

            LoadProcesses();
        }

        private void InitializeChart()
        {
            var area = chart1.ChartAreas[0];

            area.AxisY2.Enabled = AxisEnabled.True;
            area.AxisY2.Title = "Температура (°C)";
            area.AxisY2.Minimum = 0;
            area.AxisY2.Maximum = 100;
            area.AxisY2.Interval = 20;

            area.AxisX.Title = "Час (сек)";
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = MaxDataPoints;
            area.AxisX.Interval = 10;

            area.AxisY.Title = "Навантаження (%)";
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 100;

            chart1.Series.Clear();

            var sCPU = new Series("CPU");
            sCPU.ChartType = SeriesChartType.Line;
            sCPU.BorderWidth = 2;
            sCPU.Color = Color.FromArgb(0, 120, 215);
            sCPU.YAxisType = AxisType.Primary;
            chart1.Series.Add(sCPU);

            var sGPU = new Series("GPU");
            sGPU.ChartType = SeriesChartType.Line;
            sGPU.BorderWidth = 2;
            sGPU.Color = Color.FromArgb(232, 17, 35);
            sGPU.YAxisType = AxisType.Primary;
            chart1.Series.Add(sGPU);

            var sCpuTemp = new Series("CPUTemp");
            sCpuTemp.ChartType = SeriesChartType.Line;
            sCpuTemp.Color = Color.Orange;
            sCpuTemp.BorderWidth = 2;
            sCpuTemp.BorderDashStyle = ChartDashStyle.Dash;
            sCpuTemp.YAxisType = AxisType.Secondary;
            chart1.Series.Add(sCpuTemp);

            var sGpuTemp = new Series("GPUTemp");
            sGpuTemp.ChartType = SeriesChartType.Line;
            sGpuTemp.Color = Color.Red;
            sGpuTemp.BorderWidth = 2;
            sGpuTemp.BorderDashStyle = ChartDashStyle.Dash;
            sGpuTemp.YAxisType = AxisType.Secondary;
            chart1.Series.Add(sGpuTemp);
        }

        private void LoadSystemInfo()
        {
            try
            {
                lblPCName.Text = $"💻 ПК: {Environment.MachineName}";

                lblUserName.Text = $"👤 Користувач: {Environment.UserName}";

                string osVersion = GetWindowsVersion();
                lblWindowsVersion.Text = $"🪟 Windows: {osVersion}";

                string cpuName = GetCPUName();
                int coreCount = Environment.ProcessorCount;
                lblCPUInfo.Text = $"🧠 CPU: {cpuName} ({coreCount} логічних ядер)";

                long totalRAM = GetTotalRAM();
                long availableRAM = GetAvailableRAM();
                lblRAMInfo.Text = $"📦 RAM: {availableRAM / 1024} / {totalRAM / 1024} MB вільно";

                string gpuName = GetGPUName();
                lblGPUInfo.Text = $"🎮 GPU: {gpuName}";

                TimeSpan uptime = TimeSpan.FromMilliseconds(Environment.TickCount64);
                lblUptime.Text = $"⏱️ Uptime: {uptime.Days:D2}.{uptime.Hours:D2}:{uptime.Minutes:D2}:{uptime.Seconds:D2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження системної інформації: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDiskInfo()
        {
            listViewDisks.Items.Clear();

            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady && drive.DriveType == DriveType.Fixed)
                    {
                        long totalGB = drive.TotalSize / (1024 * 1024 * 1024);
                        long freeGB = drive.AvailableFreeSpace / (1024 * 1024 * 1024);
                        long usedGB = totalGB - freeGB;
                        double usedPercent = (double)usedGB / totalGB * 100;

                        var item = new ListViewItem(drive.Name);
                        item.SubItems.Add($"{usedGB} ГБ");
                        item.SubItems.Add($"{freeGB} ГБ");
                        item.SubItems.Add($"{totalGB} ГБ");
                        item.SubItems.Add($"{usedPercent:F1}%");

                        listViewDisks.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження інформації про диски: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetWindowsVersion()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject os in searcher.Get())
                    {
                        return os["Caption"].ToString();
                    }
                }
            }
            catch { }
            return "Невідомо";
        }

        private string GetCPUName()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor"))
                {
                    foreach (ManagementObject cpu in searcher.Get())
                    {
                        return cpu["Name"].ToString().Trim();
                    }
                }
            }
            catch { }
            return "Невідомо";
        }

        private long GetTotalRAM()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject os in searcher.Get())
                    {
                        return Convert.ToInt64(os["TotalVisibleMemorySize"]);
                    }
                }
            }
            catch { }
            return 0;
        }

        private long GetAvailableRAM()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT FreePhysicalMemory FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject os in searcher.Get())
                    {
                        return Convert.ToInt64(os["FreePhysicalMemory"]);
                    }
                }
            }
            catch { }
            return 0;
        }

        private string GetGPUName()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_VideoController"))
                {
                    foreach (ManagementObject gpu in searcher.Get())
                    {
                        string name = gpu["Name"].ToString();
                        if (!name.Contains("Microsoft") && !name.Contains("Remote"))
                        {
                            return name;
                        }
                    }
                }
            }
            catch { }
            return "Невідомо";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            float cpu = monitorService.GetCpu();
            float gpu = monitorService.GetGpu();
            float cpuTemp = monitorService.GetCpuTemp();
            float gpuTemp = monitorService.GetGpuTemp();

            cpuLabel.Text = $"CPU: {cpu:F0}%";
            gpuLabel.Text = $"GPU: {gpu:F0}%";

            cpuTempLabel.Text = $"🌡️ CPU: {(cpuTemp > 0 ? cpuTemp.ToString("F1") : "N/A")} °C";
            gpuTempLabel.Text = $"🔥 GPU: {(gpuTemp > 0 ? gpuTemp.ToString("F1") : "N/A")} °C";

            UpdateChart(cpu, gpu, cpuTemp, gpuTemp);

            TimeSpan uptime = TimeSpan.FromMilliseconds(Environment.TickCount64);
            lblUptime.Text = $"⏱️ Uptime: {uptime.Days:D2}.{uptime.Hours:D2}:{uptime.Minutes:D2}:{uptime.Seconds:D2}";

            long availableRAM = GetAvailableRAM();
            long totalRAM = GetTotalRAM();
            lblRAMInfo.Text = $"📦 RAM: {availableRAM / 1024} / {totalRAM / 1024} MB вільно";
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            UpdateProcesses();
        }

        private void UpdateChart(float cpu, float gpu, float cpuTemp, float gpuTemp)
        {
            chart1.Series["CPU"].Points.AddY(cpu);
            chart1.Series["GPU"].Points.AddY(gpu);
            chart1.Series["CPUTemp"].Points.AddY(cpuTemp);
            chart1.Series["GPUTemp"].Points.AddY(gpuTemp);

            foreach (Series s in chart1.Series)
            {
                if (s.Points.Count > MaxDataPoints)
                    s.Points.RemoveAt(0);
            }

            int count = chart1.Series["CPU"].Points.Count;

            chart1.ChartAreas[0].AxisX.Maximum = count;
            chart1.ChartAreas[0].AxisX.Minimum = Math.Max(0, count - MaxDataPoints);
        }

        private void LoadProcesses()
        {
            var processes = monitorService.GetProcesses();
            treeViewProcesses.BeginUpdate();
            treeViewProcesses.Nodes.Clear();
            processImageList.Images.Clear();
            previousProcesses.Clear();

            foreach (var proc in processes)
            {
                try
                {
                    Icon icon;
                    try
                    {
                        icon = !string.IsNullOrEmpty(proc.MainModule?.FileName)
                            ? Icon.ExtractAssociatedIcon(proc.MainModule.FileName)
                            : SystemIcons.Application;
                    }
                    catch
                    {
                        icon = SystemIcons.Application;
                    }

                    processImageList.Images.Add(proc.ProcessName + proc.Id, icon);

                    long memoryMB = proc.WorkingSet64 / (1024 * 1024);

                    var node = new TreeNode($"{proc.ProcessName}  |  PID: {proc.Id}  |  RAM: {memoryMB} MB  |  Потоки: {proc.Threads.Count}")
                    {
                        ImageKey = proc.ProcessName + proc.Id,
                        SelectedImageKey = proc.ProcessName + proc.Id,
                        Tag = proc
                    };

                    treeViewProcesses.Nodes.Add(node);

                    previousProcesses[proc.Id] = new ProcessInfo
                    {
                        Name = proc.ProcessName,
                        Id = proc.Id,
                        MemoryUsage = proc.WorkingSet64,
                        ThreadCount = proc.Threads.Count
                    };
                }
                catch
                {
                }
            }

            treeViewProcesses.EndUpdate();
        }

        private void UpdateProcesses()
        {
            try
            {
                var currentProcesses = monitorService.GetProcesses();
                var currentProcessIds = new HashSet<int>(currentProcesses.Select(p => p.Id));
                var previousProcessIds = new HashSet<int>(previousProcesses.Keys);

                treeViewProcesses.BeginUpdate();

                TreeNode selectedNode = treeViewProcesses.SelectedNode;
                int? selectedPid = null;
                if (selectedNode?.Tag is Process selectedProc)
                {
                    selectedPid = selectedProc.Id;
                }

                var processesToRemove = previousProcessIds.Except(currentProcessIds).ToList();
                foreach (var pid in processesToRemove)
                {
                    var nodeToRemove = treeViewProcesses.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(n => n.Tag is Process p && p.Id == pid);
                    if (nodeToRemove != null)
                    {
                        treeViewProcesses.Nodes.Remove(nodeToRemove);
                        processImageList.Images.RemoveByKey(previousProcesses[pid].Name + pid);
                    }
                    previousProcesses.Remove(pid);
                }

                foreach (var proc in currentProcesses)
                {
                    try
                    {
                        long memoryMB = proc.WorkingSet64 / (1024 * 1024);
                        string nodeText = $"{proc.ProcessName}  |  PID: {proc.Id}  |  RAM: {memoryMB} MB  |  Потоки: {proc.Threads.Count}";

                        if (!previousProcesses.ContainsKey(proc.Id))
                        {
                            Icon icon;
                            try
                            {
                                icon = !string.IsNullOrEmpty(proc.MainModule?.FileName)
                                    ? Icon.ExtractAssociatedIcon(proc.MainModule.FileName)
                                    : SystemIcons.Application;
                            }
                            catch
                            {
                                icon = SystemIcons.Application;
                            }

                            processImageList.Images.Add(proc.ProcessName + proc.Id, icon);

                            var node = new TreeNode(nodeText)
                            {
                                ImageKey = proc.ProcessName + proc.Id,
                                SelectedImageKey = proc.ProcessName + proc.Id,
                                Tag = proc,
                                ForeColor = Color.LightGreen
                            };

                            treeViewProcesses.Nodes.Add(node);

                            previousProcesses[proc.Id] = new ProcessInfo
                            {
                                Name = proc.ProcessName,
                                Id = proc.Id,
                                MemoryUsage = proc.WorkingSet64,
                                ThreadCount = proc.Threads.Count
                            };
                        }
                        else
                        {
                            var existingNode = treeViewProcesses.Nodes.Cast<TreeNode>()
                                .FirstOrDefault(n => n.Tag is Process p && p.Id == proc.Id);

                            if (existingNode != null)
                            {
                                existingNode.Text = nodeText;
                                existingNode.Tag = proc;

                                var prevInfo = previousProcesses[proc.Id];
                                if (proc.WorkingSet64 > prevInfo.MemoryUsage * 1.1)
                                {
                                    existingNode.ForeColor = Color.Orange;
                                }
                                else if (proc.WorkingSet64 < prevInfo.MemoryUsage * 0.9)
                                {
                                    existingNode.ForeColor = Color.LightBlue;
                                }
                                else
                                {
                                    existingNode.ForeColor = Color.White;
                                }

                                previousProcesses[proc.Id] = new ProcessInfo
                                {
                                    Name = proc.ProcessName,
                                    Id = proc.Id,
                                    MemoryUsage = proc.WorkingSet64,
                                    ThreadCount = proc.Threads.Count
                                };
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                if (selectedPid.HasValue)
                {
                    var nodeToSelect = treeViewProcesses.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(n => n.Tag is Process p && p.Id == selectedPid.Value);
                    if (nodeToSelect != null)
                    {
                        treeViewProcesses.SelectedNode = nodeToSelect;
                    }
                }

                treeViewProcesses.EndUpdate();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Помилка оновлення процесів: {ex.Message}");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            if (treeViewProcesses.SelectedNode == null)
            {
                MessageBox.Show("Виберіть процес.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proc = (Process)treeViewProcesses.SelectedNode.Tag;

            var ask = MessageBox.Show(
                $"Завершити процес {proc.ProcessName}?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ask == DialogResult.Yes)
            {
                if (monitorService.KillProcess(proc, out string error))
                {
                    MessageBox.Show("Процес завершено.");
                    UpdateProcesses();
                }
                else
                {
                    MessageBox.Show(error, "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer?.Stop();
            timer?.Dispose();
            processTimer?.Stop();
            processTimer?.Dispose();
            processImageList?.Dispose();
            base.OnFormClosing(e);
        }

        private void listViewDisks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}