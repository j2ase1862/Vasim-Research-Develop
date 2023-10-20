using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisionProCaliperToolDemo
{
    public class FileManager
    {
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(
            string section,
            string key,
            string def,
            StringBuilder reVal,
            int size,
            string filepath
            );

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string section,
            string key,
            string val,
            string filepath
            );

        public static void GetValue(string path, string Section, string Key, string Default, StringBuilder ReVal)
        {
            GetPrivateProfileString(Section, Key, Default, ReVal, ReVal.Capacity, path);
        }

        public static void SetValue(string path, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }
    }
}
