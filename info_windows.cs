using System.Management;
using System;

namespace FallBuster
{
    internal class info_windows
    {
        public string get_info(string name)
        {
            string Q = "SELECT Name FROM " + name;
            string result = String.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Q);
            foreach (ManagementObject obj in searcher.Get())
            {
                result += obj["Name"].ToString().Trim() + "\n";
            }

            result = result.Remove(result.Length - 1);

            return result;
        }
    }
}
