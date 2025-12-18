using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PCMonitor
{
    public class MonitorService
    {
        Computer comp;
        PerformanceCounter cpuCounter;

        public MonitorService()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            comp = new Computer()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true
            };
            comp.Open();

            foreach (var hw in comp.Hardware)
            {
                hw.Update();
                foreach (var sub in hw.SubHardware)
                {
                    sub.Update();
                }
            }
        }

        public float GetCpu() => cpuCounter.NextValue();

        public float GetGpu()
        {
            float v = 0;
            foreach (var hw in comp.Hardware)
            {
                if (hw.HardwareType == HardwareType.GpuAmd ||
                    hw.HardwareType == HardwareType.GpuNvidia ||
                    hw.HardwareType == HardwareType.GpuIntel)
                {
                    hw.Update();
                    foreach (var s in hw.Sensors)
                        if (s.SensorType == SensorType.Load)
                            return s.Value ?? 0;
                }
            }
            return v;
        }

        public float GetCpuTemp()
        {
            foreach (var hw in comp.Hardware)
            {
                if (hw.HardwareType == HardwareType.Cpu)
                {
                    hw.Update();

                    foreach (var s in hw.Sensors)
                    {
                        if (s.SensorType == SensorType.Temperature)
                        {
                            if (s.Name.Contains("Package") ||
                                s.Name.Contains("Core Average") ||
                                s.Name.Contains("CPU Package") ||
                                s.Name.Contains("Core #1") ||
                                s.Name.Contains("Core 0"))
                            {
                                Debug.WriteLine($"CPU Temp найдена: {s.Name} = {s.Value}°C");
                                return s.Value ?? 0;
                            }
                        }
                    }

                    foreach (var sub in hw.SubHardware)
                    {
                        sub.Update();
                        foreach (var s in sub.Sensors)
                        {
                            if (s.SensorType == SensorType.Temperature)
                            {
                                if (s.Name.Contains("Tctl") ||
                                    s.Name.Contains("Tdie") ||
                                    s.Name.Contains("CPU") ||
                                    s.Name.Contains("Core"))
                                {
                                    Debug.WriteLine($"CPU Temp найдена в SubHardware: {s.Name} = {s.Value}°C");
                                    return s.Value ?? 0;
                                }
                            }
                        }
                    }

                    foreach (var s in hw.Sensors)
                    {
                        if (s.SensorType == SensorType.Temperature && s.Value.HasValue)
                        {
                            Debug.WriteLine($"CPU Temp (fallback): {s.Name} = {s.Value}°C");
                            return s.Value.Value;
                        }
                    }

                    Debug.WriteLine($"CPU Hardware: {hw.Name}");
                    Debug.WriteLine($"Найдено сенсоров CPU: {hw.Sensors.Length}");
                    foreach (var s in hw.Sensors)
                    {
                        Debug.WriteLine($"  - {s.Name} ({s.SensorType}): {s.Value}");
                    }
                }
            }
            return 0;
        }

        public float GetGpuTemp()
        {
            foreach (var hw in comp.Hardware)
            {
                if (hw.HardwareType == HardwareType.GpuAmd ||
                    hw.HardwareType == HardwareType.GpuNvidia ||
                    hw.HardwareType == HardwareType.GpuIntel)
                {
                    hw.Update();
                    foreach (var s in hw.Sensors)
                        if (s.SensorType == SensorType.Temperature)
                            return s.Value ?? 0;
                }
            }
            return 0;
        }

        public List<Process> GetProcesses()
        {
            return Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();
        }

        public bool KillProcess(int processId, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var process = Process.GetProcessById(processId);
                process.Kill();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool KillProcess(Process process, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                process.Kill();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}