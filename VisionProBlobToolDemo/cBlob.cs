using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Display;

namespace VisionProBlobToolDemo
{
    public class cBlob : IInspectionTool
    {

        private CogBlobTool _tool;
        private CogRectangle _region;
        private CogCompositeShape CogShapeGraphics;

        public cBlob() { }

        /// <summary>
        /// Blob Tool Init
        /// </summary>
        public void Init()
        {
            _tool = new CogBlobTool();            
            _region = new CogRectangle();
            _region.GraphicDOFEnable = CogRectangleDOFConstants.All;
            _region.Interactive = true;
            _region.SetCenterWidthHeight(100,100,200,200);
            _tool.Region = _region;

            _tool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold; // 고정 Threshold
            _tool.RunParams.ConnectivityMinPixels = 10; // Blob을 찾을 최소영역의 크기로 이해(Pixel 단위)
            //_tool.RunParams.ConnectivityMode = CogBlobConnectivityModeConstants.GreyScale;
        }
        
        /// <summary>
        /// Rectangle 객체를 Blob Tool Region에 대입시킨다.
        /// </summary>
        public void SetRegion() 
        {
            _tool.Region = _region;
        }
        
        /// <summary>
        /// blob 찾을 속성을 정의해준다. 
        /// </summary>
        /// <param name="property"></param>
        public void SetPolarity(int property)
        {
            switch (property) 
            {
                case 0:
                    _tool.RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.DarkBlobs; // 밝은 배경에서 어두운 덩어리를 찾는다.                    
                    break;
                case 1:
                    _tool.RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.LightBlobs; // 어두운 배경에서 밝은 덩어리를 찾는다.
                    break;
            }
        }

        /// <summary>
        /// 경계값을 설정한다.
        /// </summary>
        /// <param name="value"></param>
        public void SetThreshold(int value)
        {
            _tool.RunParams.SegmentationParams.HardFixedThreshold = value;
        }
        /// <summary>
        /// 최소 영역의 크기를 설정한다. 만약 100의 값으로 설정하면 100이하의 크기를 가진 Blob은 결과에서 제외된다.
        /// </summary>
        /// <param name="value"></param>
        public void SetMinPixel(int value)
        {
            _tool.RunParams.ConnectivityMinPixels = value;
        }
        /// <summary>
        /// Rectangle의 정보를 Display에 보여준다.
        /// </summary>
        /// <param name="display"></param>
        public void ShowRegion(CogDisplay display)
        {
            display.InteractiveGraphics.Add(_region, "", false);
        }
        /// <summary>
        /// Blob Tool을 실행한다.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="display"></param>
        public void Run(CogImage8Grey img, CogDisplay display) 
        {
            double sumArea = 0;
            _tool.InputImage = img; // blob tool에 입력 이미지를 설정한다.

            if(_tool.InputImage != null)
            {
                _tool.Run(); // blob tool을 실행한다.

                if(_tool.Results != null)
                {                    
                    if (_tool.Results.GetBlobs().Count > 0) // blob Tool의 결과에서 찾은 blob count가 0보다 크다면 아래 반복문을 수행하면서 면적의 합을 구하고, 결과 그래픽을 생성한다.
                    {
                        for (int blobCount = 0; blobCount < _tool.Results.GetBlobs().Count; blobCount++)
                        {          
                            CogShapeGraphics = new CogCompositeShape();
                            CogShapeGraphics = _tool.Results.GetBlobs()[blobCount].CreateResultGraphics(CogBlobResultGraphicConstants.Boundary); // blob find result 그래픽을 생성한다.
                            display.StaticGraphics.Add(CogShapeGraphics, ""); // cogdisplay에 결과를 그려준다.

                            sumArea = sumArea + _tool.Results.GetBlobs()[blobCount].Area; // blob find 결과값에서 면적을 추출하여 면적의 합을 구한다.                              
                        }

                        double blobFindCount = _tool.Results.GetBlobs().Count; // blob find 결과값에서 찾은 blob의 count를 추출한다.

                        string msg = "Blob Find Count : " + blobFindCount.ToString();
                        DrawResult(display, 100, 100, msg);

                        msg = "Blob Find Sum of Area : " + sumArea.ToString();
                        DrawResult(display, 100, 200, msg);
                    }
                }
            }
        }
        /// <summary>
        /// cogdisplay에 문자열을 그려준다.
        /// </summary>
        /// <param name="display"></param>
        /// <param name="textXCoordinate"></param>
        /// <param name="textYCoordinate"></param>
        /// <param name="msg"></param>
        public void DrawResult(CogDisplay display, double textXCoordinate, double textYCoordinate, string msg)
        {
            CogGraphicLabel CogTLabel = new CogGraphicLabel(); // cogLabel 객체 생성            

            CogTLabel.Text = msg; 
            CogTLabel.X = textXCoordinate;
            CogTLabel.Y = textYCoordinate;
            CogTLabel.Font = new Font("굴림", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129))); // coglabel의 font 및 size 설정
            CogTLabel.Color = CogColorConstants.Orange;
            CogTLabel.BackgroundColor = CogColorConstants.None;
            CogTLabel.LineStyle = CogGraphicLineStyleConstants.DashDotDot;
            CogTLabel.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;

            display.StaticGraphics.Add(CogTLabel, ""); // display에 cogLabel 그리기

            CogTLabel = null;          
            
        }
    }
}
