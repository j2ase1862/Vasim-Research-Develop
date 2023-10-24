using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Display;
using VisionProCaliperToolDemo;

namespace VisionProBlobToolDemo
{
    public class cBlob : IInspectionTool
    {
        private CogBlobTool[] _tool = new CogBlobTool[2];
        private CogRectangle[] _region = new CogRectangle[2];
        private CogCompositeShape CogShapeGraphics;

        string path = @"C:\Users\Vasim\Desktop\Bolb_Param.ini";
        string region_path = @"C:\Users\Vasim\Desktop\Bolb_Region.ini";

        StringBuilder sb_min = new StringBuilder(255);
        StringBuilder sb_max = new StringBuilder(255);

        StringBuilder sb_blob = new StringBuilder(255);
        StringBuilder sb_threshold = new StringBuilder(255);
        StringBuilder sb_minpixel = new StringBuilder(255);

        StringBuilder sb_index = new StringBuilder(10);
        StringBuilder sb_X = new StringBuilder(255);
        StringBuilder sb_Y = new StringBuilder(255);
        StringBuilder sb_Width = new StringBuilder(255);
        StringBuilder sb_Height = new StringBuilder(255);

        RegionInfo regionInfo = new RegionInfo();

        private int _index;
        private int offset;

        public cBlob() { }

        public void GetIndex(int index)
        {
            _index = index;
        }

        /// <summary>
        /// Blob Tool Init
        /// </summary>
        public void Init()
        {
            for (int si = 0; si < _tool.Length; si++)
            {
                regionInfo.RegionIndex(si);

                _tool[si] = new CogBlobTool();
                _region[si] = new CogRectangle();
                _region[si].GraphicDOFEnable = CogRectangleDOFConstants.All;
                _region[si].Interactive = true;
                _region[si].SetCenterWidthHeight(regionInfo.Cx, regionInfo.Cy, regionInfo.Width, regionInfo.Height);
                _tool[si].Region = _region[si];

                _tool[si].RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold; // 고정 Threshold
                _tool[si].RunParams.ConnectivityMinPixels = 10; // Blob을 찾을 최소영역의 크기로 이해(Pixel 단위)
                                                                //_tool.RunParams.ConnectivityMode = CogBlobConnectivityModeConstants.GreyScale;
            }
        }

        /// <summary>
        /// Rectangle 객체를 Blob Tool Region에 대입시킨다.
        /// </summary>
        public void SetRegion()
        {
            _tool[_index].Region = _region[_index];
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
                    _tool[_index].RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.DarkBlobs; // 밝은 배경에서 어두운 덩어리를 찾는다.
                    regionInfo.Blob = "Dark Blobs";
                    break;
                case 1:
                    _tool[_index].RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.LightBlobs; // 어두운 배경에서 밝은 덩어리를 찾는다.
                    regionInfo.Blob = "White Blobs";
                    break;
            }
        }

        /// <summary>
        /// 경계값을 설정한다.
        /// </summary>
        /// <param name="value"></param>
        public void SetThreshold(int value)
        {
            _tool[_index].RunParams.SegmentationParams.HardFixedThreshold = value;
            regionInfo.Threshold = value;
        }
        /// <summary>
        /// 최소 영역의 크기를 설정한다. 만약 100의 값으로 설정하면 100이하의 크기를 가진 Blob은 결과에서 제외된다.
        /// </summary>
        /// <param name="value"></param>
        public void SetMinPixel(int value)
        {
            _tool[_index].RunParams.ConnectivityMinPixels = value;
            regionInfo.Minpixel = value;
        }
        /// <summary>
        /// Rectangle의 정보를 Display에 보여준다.
        /// </summary>
        /// <param name="display"></param>
        public void ShowRegion(CogDisplay display)
        {
            display.InteractiveGraphics.Add(_region[_index], "", false);
        }
        /// <summary>
        /// Blob Tool을 실행한다.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="display"></param>
        public void Run(CogImage8Grey img, CogDisplay display, int index)
        {
            double sumArea = 0;

            _tool[index].InputImage = img; // blob tool에 입력 이미지를 설정한다.

            if (_tool[index].InputImage != null)
            {
                _tool[index].Run(); // blob tool을 실행한다.

                if (_tool[index].Results != null)
                {
                    if (_tool[index].Results.GetBlobs().Count > 0) // blob Tool의 결과에서 찾은 blob count가 0보다 크다면 아래 반복문을 수행하면서 면적의 합을 구하고, 결과 그래픽을 생성한다.
                    {
                        for (int blobCount = 0; blobCount < _tool[index].Results.GetBlobs().Count; blobCount++)
                        {
                            CogShapeGraphics = new CogCompositeShape();
                            CogShapeGraphics = _tool[index].Results.GetBlobs()[blobCount].CreateResultGraphics(CogBlobResultGraphicConstants.Boundary); // blob find result 그래픽을 생성한다.
                            display.StaticGraphics.Add(CogShapeGraphics, ""); // cogdisplay에 결과를 그려준다.

                            sumArea = sumArea + _tool[index].Results.GetBlobs()[blobCount].Area; // blob find 결과값에서 면적을 추출하여 면적의 합을 구한다.                              
                        }

                        double blobFindCount = _tool[index].Results.GetBlobs().Count; // blob find 결과값에서 찾은 blob의 count를 추출한다.

                        string resultArea;

                        if (sumArea > regionInfo.MinScope && sumArea < regionInfo.MaxScope)
                        {
                            resultArea = "OK";
                        }
                        else
                        {
                            resultArea = "NG";
                        }

                        if (offset != 0)
                        {
                            string msg = index + " Blob Find Count : " + blobFindCount.ToString();
                            DrawResult(display, 100, 400, msg);

                            msg = index + " Blob Find Sum of Area : " + sumArea.ToString();
                            DrawResult(display, 100, 500, msg);

                            msg = index + " Area Result : " + resultArea;
                            DrawResult(display, 100, 600, msg);

                            offset = 0;
                        }
                        else
                        {
                            string msg = index + " Blob Find Count : " + blobFindCount.ToString();
                            DrawResult(display, 100, 100, msg);

                            msg = index + " Blob Find Sum of Area : " + sumArea.ToString();
                            DrawResult(display, 100, 200, msg);

                            msg = index + " Area Result : " + resultArea;
                            DrawResult(display, 100, 300, msg);

                            offset += 1;
                        }
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
        public void GetRegion(Boolean file_exists, int index)
        {
            _region[index] = new CogRectangle();
            regionInfo.RegionIndex(index);

            if (file_exists == true)
            {
                FileManager.GetValue(region_path, "Region" + index, "X", "", sb_X);
                double x = double.Parse(sb_X.ToString());
                FileManager.GetValue(region_path, "Region" + index, "Y", "", sb_Y);
                double y = double.Parse(sb_Y.ToString());
                FileManager.GetValue(region_path, "Region" + index, "Width", "", sb_Width);
                double width = double.Parse(sb_Width.ToString());
                FileManager.GetValue(region_path, "Region" + index, "Height", "", sb_Height);
                double height = double.Parse(sb_Height.ToString());

                _region[index].SetCenterWidthHeight(x, y, width, height);

                regionInfo.Cx = x; regionInfo.Cy = y;
                regionInfo.Height = height; regionInfo.Width = width;
            }
            else
            {
                regionInfo.Cx = 100; regionInfo.Cy = 100;
                regionInfo.Height = 200; regionInfo.Width = 200;

                _region[index].SetCenterWidthHeight(100, 100, 200, 200);
            }
        }
        public void SaveRegion()
        {
            // 현재 Region 정보를 Save 및 Info에 Update
            regionInfo.Cx = _region[_index].CenterX; regionInfo.Cy = _region[_index].CenterY;
            regionInfo.Height = _region[_index].Height; regionInfo.Width = _region[_index].Width;

            FileManager.SetValue(region_path, "Region" + _index, "X", _region[_index].CenterX.ToString());
            FileManager.SetValue(region_path, "Region" + _index, "Y", _region[_index].CenterY.ToString());
            FileManager.SetValue(region_path, "Region" + _index, "Width", _region[_index].Width.ToString());
            FileManager.SetValue(region_path, "Region" + _index, "Height", _region[_index].Height.ToString());
        }

        public void GetParam(Boolean file_exists, int index)
        {
            regionInfo.RegionIndex(index);

            if (file_exists == true)
            {
                FileManager.GetValue(path, "Parameter" + index, "Blob", "", sb_blob);
                FileManager.GetValue(path, "Scope" + index, "Min", "", sb_min);

                string get_b = sb_blob.ToString();
                string get_m = sb_min.ToString();

                if (get_m.Equals("") == false)
                {
                    FileManager.GetValue(path, "Scope" + index, "Max", "", sb_max);

                    regionInfo.MinScope = int.Parse(get_m);
                    regionInfo.MaxScope = int.Parse(sb_max.ToString());
                }
                else
                {
                    regionInfo.MinScope = 1000000;
                    regionInfo.MaxScope = 3000000;
                }
                if (get_b.Equals("") == false)
                {
                    FileManager.GetValue(path, "Parameter" + index, "Threshold", "", sb_threshold);
                    FileManager.GetValue(path, "Parameter" + index, "Minpixel", "", sb_minpixel);

                    regionInfo.Blob = get_b;
                    regionInfo.Threshold = int.Parse(sb_threshold.ToString());
                    regionInfo.Minpixel = int.Parse(sb_minpixel.ToString());
                }
                else
                {
                    regionInfo.Blob = "White Blob";
                    regionInfo.Threshold = 40;
                    regionInfo.Minpixel = 100;
                }
            }
            else
            {
                regionInfo.Blob = "White Blob";
                regionInfo.Threshold = 40;
                regionInfo.Minpixel = 100;

                regionInfo.MinScope = 1000000;
                regionInfo.MaxScope = 3000000;
            }

            // 문제사항
            // info 배열에 값이 들어가지않음 > 현재 for index가 info에는 적용되지 않음
            // info에 직접 index 설정시, Form1에서 초기화되어 region값이 배열에 들어가지 않음
        }

        public void SetParam()
        {
            if (Form1.form1.radioButton_DarkBlob.Checked == true)
            {
                FileManager.SetValue(path, "Parameter" + _index, "Blob", Form1.form1.radioButton_DarkBlob.Text);
                regionInfo.Blob = Form1.form1.radioButton_DarkBlob.Text;
            }
            if (Form1.form1.radioButton_WhiteBlob.Checked == true)
            {
                FileManager.SetValue(path, "Parameter" + _index, "Blob", Form1.form1.radioButton_WhiteBlob.Text);
                regionInfo.Blob = Form1.form1.radioButton_WhiteBlob.Text;
            }

            FileManager.SetValue(path, "Parameter" + _index, "Threshold", Form1.form1.textBox_Threshold.Text);
            FileManager.SetValue(path, "Parameter" + _index, "MinPixel", Form1.form1.textBox_MinPixel.Text);

            regionInfo.Threshold = int.Parse(Form1.form1.textBox_Threshold.Text);
            regionInfo.Minpixel = int.Parse(Form1.form1.textBox_MinPixel.Text);

            MessageBox.Show("Save Complete", "Save Params");
        }

        public void SetScope()
        {
            FileManager.SetValue(path, "Scope" + _index, "Min", Form1.form1.textBox_MinSet.Text);
            FileManager.SetValue(path, "Scope" + _index, "Max", Form1.form1.textBox_MaxSet.Text);

            regionInfo.MinScope = int.Parse(Form1.form1.textBox_MinSet.Text);
            regionInfo.MaxScope = int.Parse(Form1.form1.textBox_MaxSet.Text);

            MessageBox.Show("Save Complete", "Save Scope");
        }

        public void DisplayParam()
        {
            regionInfo.RegionIndex(_index);

            if (regionInfo.Blob.Equals(Form1.form1.radioButton_WhiteBlob.Text) == true)
            {
                Form1.form1.radioButton_WhiteBlob.Checked = true;
            }
            else if (regionInfo.Blob.Equals(Form1.form1.radioButton_DarkBlob.Text) == true)
            {
                Form1.form1.radioButton_DarkBlob.Checked = true;
            }

            Form1.form1.textBox_Threshold.Text = regionInfo.Threshold.ToString();
            Form1.form1.textBox_MinPixel.Text = regionInfo.Minpixel.ToString();

            Form1.form1.textBox_MinSet.Text = regionInfo.MinScope.ToString();
            Form1.form1.textBox_MaxSet.Text = regionInfo.MaxScope.ToString();
        }
    }
}
