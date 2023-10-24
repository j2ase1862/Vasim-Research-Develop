using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProBlobToolDemo
{
    public class RegionInfo
    {
        public RegionInfo() { }

        private int _index;

        public void RegionIndex(int index)
        {
            _index = index;
        }

        private double[] _cx = new double[2];
        private double[] _cy = new double[2];
        private double[] _width = new double[2];
        private double[] _height = new double[2];

        private string[] _blob = new string[2];
        private double[] _threshold = new double[2];
        private double[] _minpixel = new double[2];

        private int[] _minscope = new int[2];
        private int[] _maxscope = new int[2];

        public double Cx { get { return _cx[_index]; } set { _cx[_index] = value; } }
        public double Cy { get { return _cy[_index]; } set { _cy[_index] = value; } }
        public double Width { get { return _width[_index]; } set { _width[_index] = value; } }
        public double Height { get { return _height[_index]; } set { _height[_index] = value; } }

        public string Blob { get { return _blob[_index]; } set { _blob[_index] = value; } }
        public double Threshold { get { return _threshold[_index]; } set { _threshold[_index] = value; } }
        public double Minpixel { get { return _minpixel[_index]; } set { _minpixel[_index] = value; } }

        public int MinScope { get { return _minscope[_index]; } set { _minscope[_index] = value; } }
        public int MaxScope { get { return _maxscope[_index]; } set { _maxscope[_index] = value; } }
    }
}
