using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionProCaliperToolDemo
{
    internal class CaliperTool
    {
        public CogCaliperTool _tool = new CogCaliperTool();
        public CogCaliperTool _tool2 = new CogCaliperTool();
        public CogRectangleAffine _region  = new CogRectangleAffine();
        CogCaliperScorerPositionNeg FirstEdge = new CogCaliperScorerPositionNeg();

        public void Init (double cx, double cy, double sideXLength, double sideYLenght, double rotation, double skew)
        {
            if (cx != 0)
            {
                _region.CenterX = cx;
                _region.CenterY = cy;
                _region.SideXLength = sideXLength;
                _region.SideYLength = sideYLenght;
                _region.Rotation = rotation;
                _region.Skew = skew;

                _region.SetCenterLengthsRotationSkew(cx, cy, sideXLength, sideYLenght, rotation, skew);
            } else
            {
                _region.SetCenterLengthsRotationSkew(320, 240, 200, 200, 0, 0);
            }

        }

        public void SetRegion (double cx, double cy, double sideXLength, double sideYLenght, double rotation, double skew)
        {
            _region = new CogRectangleAffine();

            _region.CenterX = cx;
            _region.CenterY = cy;
            _region.SideXLength = sideXLength;
            _region.SideYLength = sideYLenght;
            _region.Rotation = rotation;
            _region.Skew = skew;
        }

        public void SetParams ()
        {
            _tool = new CogCaliperTool ();

            _tool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge; // caliper tool의 find 방법 : 1개의 edge 찾음
            _tool.RunParams.SingleEdgeScorers.Add(FirstEdge);
        }

        public void SetPolarity(int Polarity)
        {
            switch (Polarity)
            {
                case 0:
                    _tool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark; // roi내에서 찾는 방향 : light => dark, 즉 밝은 쪽에서 어두운 쪽으로 변하는 edge를 찾는다.
                    break;
                case 1:
                    _tool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
                    break;

            }
        }

        public void SetThreshold(double threshold)
        {
            _tool.RunParams.ContrastThreshold = threshold;
        }

        public void SetHalfSizePixels (int pixelsize)
        {
            _tool.RunParams.FilterHalfSizeInPixels = pixelsize;
        }

        public CogCompositeShape CogShapeGraphics;

        public double drawresult_cx;
        public double drawresult_cy;

        public void Run(CogImage8Grey img)
        {
            CogShapeGraphics = new CogCompositeShape ();
            drawresult_cx = 0;
            drawresult_cy = 0;

            try
            {
                _tool.InputImage = img; // cogCaliperTool 입력이미지에 cogimage8grey Image를 선언합니다.

                _tool.Region = _region; // cogCaliperTool roi를 _region으로 선언합니다.                

                Stopwatch swRun = new Stopwatch();
                swRun.Start();
                _tool.Run();

                if (_tool.Results == null)
                {
                    return;
                }

                if (_tool.Results.Count > 0) // cogCaliperTool의 Edge Find Result가 0보다 크다면
                {
                    CogShapeGraphics = _tool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges); // cogCaliperTool의 Edge Find Result를 shape 객체로 만든다.

                    drawresult_cx = _tool.Results[0].PositionX;
                    drawresult_cy = _tool.Results[0].PositionY;

                }
                swRun.Stop();
            }
            catch (System.Exception ex)
            {
                //this.rtbInfoMessage.Text += "An error occurred while running the tool with ' " + ex.Message + " '\r\n";
            }
        }
    }
}
