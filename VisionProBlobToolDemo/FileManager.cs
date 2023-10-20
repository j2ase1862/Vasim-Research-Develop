using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisionProBlobToolDemo
{
    internal class FileManager
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        public static void SetValue(string Path, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }
    }
}

