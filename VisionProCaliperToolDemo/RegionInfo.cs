using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProCaliperToolDemo
{
    internal class RegionInfo
    {
        public RegionInfo() { }

        private double _cx;
        private double _cy;
        private double _sideXLength;
        private double _sideYLength;
        private double _rotation;
        private double _skew;

        private int _edge0Polarity;
        private double _threshold;
        private int _halfsizePixels;

        public double Cx { get { return _cx; } set { _cx = value; } }
        public double Cy { get { return _cy; } set { _cy = value; } }
        public double SideXLength {  get { return _sideXLength; } set { _sideXLength = value; } }
        public double SideYLength { get { return _sideYLength; } set { _sideYLength = value; } }
        public double Rotation { get { return _rotation; } set { _rotation = value; } } 
        public double Skew { get { return _skew; } set { _skew = value; } } 

        public int Edge0Polarity {  get { return _edge0Polarity; } set { _edge0Polarity = value; } }
        public double Threshold {  get { return _threshold; } set { _threshold = value; } }
        public int HalfsizePixels {  get { return _halfsizePixels; } set { _halfsizePixels = value; } }
    }
}
