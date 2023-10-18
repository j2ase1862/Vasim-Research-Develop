using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Implementation.Internal;

namespace VisionProCaliperToolDemo
{
    public partial class Form1 : Form
    {
        private CogImage24PlanarColor cogImg24Color;
        private CogImage8Grey cogImg8Grey;
        private CogCaliperScorerPositionNeg FirstEdge = new CogCaliperScorerPositionNeg();

        RegionInfo rInfo = new RegionInfo();
        CaliperTool caliperTool = new CaliperTool();

        string path = @"C:\Users\Vasim\Desktop\Region_Infro.ini";

        StringBuilder sb_cx = new StringBuilder(255);
        StringBuilder sb_cy = new StringBuilder(255);
        StringBuilder sb_sideXLength = new StringBuilder(255);
        StringBuilder sb_sideYLength = new StringBuilder(255);
        StringBuilder sb_rotation = new StringBuilder(255);
        StringBuilder sb_skew = new StringBuilder(255);

        StringBuilder sb_Polarity = new StringBuilder(255);
        StringBuilder sb_Thresold = new StringBuilder(255);
        StringBuilder sb_HalfSizePixels = new StringBuilder(255);

        #region CaliperTool
        private CogCaliperTool _tool;
        private CogRectangleAffine _region;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void imageLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFileName;

            CogImageFileTool ImageFile = new CogImageFileTool();
            OpenFileDialog OpenFile = new OpenFileDialog();

            OpenFile.DefaultExt = "bmp";
            OpenFile.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";

            OpenFile.ShowDialog();

            if (OpenFile.FileName.Length > 0)
            {
                strFileName = OpenFile.FileName;
                
                try
                {
                    ImageFile.Operator.Open(strFileName, CogImageFileModeConstants.Read);
                    ImageFile.Run();

                    Type type = ImageFile.OutputImage.GetType();

                    if (type.Name.Contains("24"))
                    {
                        cogImg24Color = ImageFile.OutputImage as CogImage24PlanarColor;
                    }
                    else if (type.Name.Contains("8"))
                    {
                        cogImg8Grey = ImageFile.OutputImage as CogImage8Grey;
                    }

                    cogDisplay1.Image = ImageFile.OutputImage;
                }
                catch { }
            }
        }

        /// <summary>
        /// tool 과 관심영역(roi)를 초기화, roi는 rectangleaffine 형태로 초기화 한다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _tool = caliperTool._tool;
            _region = caliperTool._region;

            FileManager.GetValue(path, "Region", "cx", "", sb_cx);
            string getCX = sb_cx.ToString();

            if (File.Exists(path) == true)
            {
                rInfo.Cx = double.Parse(getCX);
                FileManager.GetValue(path, "Region", "cy", "", sb_cy);
                rInfo.Cy = double.Parse(sb_cy.ToString());
                FileManager.GetValue(path, "Region", "sideXLength", "", sb_sideXLength);
                rInfo.SideXLength = double.Parse(sb_sideXLength.ToString());
                FileManager.GetValue(path, "Region", "sideYLength", "", sb_sideYLength);
                rInfo.SideYLength = double.Parse(sb_sideYLength.ToString());
                FileManager.GetValue(path, "Region", "rotation", "", sb_rotation);
                rInfo.Rotation = double.Parse(sb_rotation.ToString());
                FileManager.GetValue(path, "Region", "skew", "", sb_skew);
                rInfo.Skew = double.Parse(sb_skew.ToString());
            }

            caliperTool.Init(rInfo.Cx, rInfo.Cy, rInfo.SideXLength, rInfo.SideYLength, rInfo.Rotation, rInfo.Skew);

            tb_cx.Text = rInfo.Cx.ToString();
            tb_cy.Text = rInfo.Cy.ToString();
            tb_xLength.Text = rInfo.SideXLength.ToString();
            tb_yLength.Text = rInfo.SideYLength.ToString();
            tb_rotation.Text = rInfo.Rotation.ToString();
            tb_skew.Text = rInfo.Skew.ToString();

            _region.GraphicDOFEnable = CogRectangleAffineDOFConstants.All; // 영역 조작 가능
            _region.Interactive = true; // 이동 가능 
            _tool.Region = _region;

            cogDisplay1.StaticGraphics.Clear();
            cogDisplay1.InteractiveGraphics.Clear();
        }

        /// <summary>
        /// cogdisplay에 roi를 보여준다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogDisplay1.InteractiveGraphics.Add(_region, "", false);

            bt_save.Enabled = true;
            bt_get.Enabled = true;

            if(rInfo.Cx != 0)
            {
                tb_cx.Text = rInfo.Cx.ToString();
                tb_cy.Text = rInfo.Cy.ToString();
                tb_xLength.Text = rInfo.SideXLength.ToString();
                tb_yLength.Text = rInfo.SideYLength.ToString();
                tb_rotation.Text = rInfo.Rotation.ToString();
                tb_skew.Text = rInfo.Skew.ToString();
            } else
            {
                tb_cx.Text = "320";
                tb_cy.Text = "240";
                tb_xLength.Text = "200";
                tb_yLength.Text = "200";
                tb_rotation.Text = "0";
                tb_skew.Text = "0";
            }

            caliperTool.SetRegion(_region.CenterX, _region.CenterY, _region.SideXLength, _region.SideYLength, _region.Rotation, _region.Skew);
        }

        /// <summary>
        /// 24bit color Image를 8bit grey image로 변환
        /// </summary>
        /// <param name="image"></param>
        /// <param name="converType"></param>
        /// <returns></returns>
        public CogImage8Grey Run(CogImage24PlanarColor image, int converType)
        {
            CogImage8Grey cogImage = new CogImage8Grey();

            if (image == null) return null;

            try
            {
                switch (converType)
                {
                    case 0:        //Red
                        cogImage = image.GetPlane(CogImagePlaneConstants.Red); // red channel에 해당하는 cogImage8Grey image를 반환
                        break;
                    case 1:        //Green
                        cogImage = image.GetPlane(CogImagePlaneConstants.Green); // green channel에 해당하는 cogImage8Grey image를 반환
                        break;
                    case 2:        //Blue
                        cogImage = image.GetPlane(CogImagePlaneConstants.Blue); // blue channel에 해당하는 cogImage8Grey image를 반환
                        break;
                    default:
                        cogImage = image.GetPlane(CogImagePlaneConstants.Green);
                        break;
                }
                return cogImage;

            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Print("[ERROR] " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// red channel에서 image 분리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorToRedChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogImg8Grey = Run(cogImg24Color, 0);

            cogDisplay1.Image = cogImg8Grey;
        }

        /// <summary>
        /// green channel에서 image 분리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorToGreenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogImg8Grey = Run(cogImg24Color, 1);

            cogDisplay1.Image = cogImg8Grey;
        }

        /// <summary>
        /// blue channel에서 image 분리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorToBlueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogImg8Grey = Run(cogImg24Color, 2);

            cogDisplay1.Image = cogImg8Grey;
        }

        /// <summary>
        /// caliper tool을 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caliperTool.SetRegion(_region.CenterX, _region.CenterY, _region.SideXLength, _region.SideYLength, _region.Rotation, _region.Skew);

            if (cogImg8Grey != null) { caliperTool.Run(cogImg8Grey); }

            DrawResult(caliperTool.CogShapeGraphics, caliperTool.drawresult_cx, caliperTool.drawresult_cy); // shape 객체와 Edge Find Result의 cx, cy를 매개변수로 전달
        }


        /// <summary>
        /// 결과를 cogdisplay에 그려준다.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        public void DrawResult(CogCompositeShape shape, double cx, double cy)
        {
            CogGraphicLabel CogTLabel_X = new CogGraphicLabel();
            CogGraphicLabel CogTLabel_Y = new CogGraphicLabel();

            CogTLabel_X.Text = "Result X : " + cx;
            CogTLabel_X.X = 200;
            CogTLabel_X.Y = 100;
            CogTLabel_X.Font = new Font("굴림", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            CogTLabel_X.Color = CogColorConstants.Green;
            CogTLabel_X.BackgroundColor = CogColorConstants.None;
            CogTLabel_X.LineStyle = CogGraphicLineStyleConstants.DashDotDot;
            CogTLabel_X.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;

            CogTLabel_Y.Text = "Result Y : " + cy;
            CogTLabel_Y.X = 200;
            CogTLabel_Y.Y = 200;
            CogTLabel_Y.Font = new Font("굴림", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            CogTLabel_Y.Color = CogColorConstants.Green;
            CogTLabel_Y.BackgroundColor = CogColorConstants.None;
            CogTLabel_Y.LineStyle = CogGraphicLineStyleConstants.DashDotDot;
            CogTLabel_Y.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;

            cogDisplay1.StaticGraphics.Add(CogTLabel_X, "");
            cogDisplay1.StaticGraphics.Add(CogTLabel_Y, "");

            CogTLabel_X = null;
            CogTLabel_Y = null;

            cogDisplay1.StaticGraphics.Add(shape, "");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_get_Click(object sender, EventArgs e)
        {
            rInfo.Cx = Math.Round(_region.CenterX, 3); rInfo.Cy = Math.Round(_region.CenterY, 3);
            rInfo.SideXLength = Math.Round(_region.SideXLength, 3); rInfo.SideYLength = Math.Round(_region.SideYLength, 3);
            rInfo.Rotation = Math.Round(_region.Rotation, 3); rInfo.Skew = Math.Round(_region.Skew, 3);

            tb_cx.Text = rInfo.Cx.ToString();
            tb_cy.Text = rInfo.Cy.ToString();
            tb_xLength.Text = rInfo.SideXLength.ToString();
            tb_yLength.Text = rInfo.SideYLength.ToString();
            tb_rotation.Text = rInfo.Rotation.ToString();
            tb_skew.Text = rInfo.Skew.ToString();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            rInfo.Cx = Math.Round(_region.CenterX, 3); rInfo.Cy = Math.Round(_region.CenterY, 3);
            rInfo.SideXLength = Math.Round(_region.SideXLength, 3); rInfo.SideYLength = Math.Round(_region.SideYLength, 3);
            rInfo.Rotation = Math.Round(_region.Rotation, 3); rInfo.Skew = Math.Round(_region.Skew, 3);

            tb_cx.Text = rInfo.Cx.ToString();
            tb_cy.Text = rInfo.Cy.ToString();
            tb_xLength.Text = rInfo.SideXLength.ToString();
            tb_yLength.Text = rInfo.SideYLength.ToString();
            tb_rotation.Text = rInfo.Rotation.ToString();
            tb_skew.Text = rInfo.Skew.ToString();

            using (StreamWriter writer = new StreamWriter(path))
            {
                // 빈 내용으로 덮어쓰기
            }

            // Region의 정보를 파일로 전달 및 저장
            FileManager.SetValue(path, "Region", "cx", rInfo.Cx.ToString());
            FileManager.SetValue(path, "Region", "cy", rInfo.Cy.ToString());
            FileManager.SetValue(path, "Region", "sideXLength", rInfo.SideXLength.ToString());
            FileManager.SetValue(path, "Region", "sideYLength", rInfo.SideYLength.ToString());
            FileManager.SetValue(path, "Region", "rotation", rInfo.Rotation.ToString());
            FileManager.SetValue(path, "Region", "skew", rInfo.Skew.ToString());

            MessageBox.Show("Save Complete","Save Region Info");
        }


        private void setParamToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Parameter의 정보를 전달 및 파일로 저장

            caliperTool.SetParams();

            if (cb_edge0Polarity.SelectedIndex != -1)
            {
                int index = cb_edge0Polarity.SelectedIndex;
                caliperTool.SetPolarity(index);

                rInfo.Edge0Polarity = index;
            }

            double value = Convert.ToDouble(tb_Thresold.Text);
            caliperTool.SetThreshold(value);

            rInfo.Threshold = value;

            int pixels = int.Parse(tb_HalfsizePixels.Text);
            caliperTool.SetHalfSizePixels(pixels);

            rInfo.HalfsizePixels = pixels;

            FileManager.SetValue(path, "Parameter", "Polarity", rInfo.Edge0Polarity.ToString());
            FileManager.SetValue(path, "Parameter", "Thresold", rInfo.Threshold.ToString());
            FileManager.SetValue(path, "Parameter", "HalfSizePixels", rInfo.HalfsizePixels.ToString());


            MessageBox.Show("Setting Complete", "Set Params");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 파일 존재 유무 판단하여 프로그램 실행 시, 정보 ini file 불러와서 display

            FileManager.GetValue(path, "Region", "cx", "i", sb_cx);
            string getCX = sb_cx.ToString();

            FileManager.GetValue(path, "Parameter", "Polarity", "", sb_Polarity);
            string getPol = sb_Polarity.ToString();

            if (File.Exists(path) == true)
            {
                if (getCX.Equals("") == false)
                {
                    rInfo.Cx = double.Parse(getCX);
                    FileManager.GetValue(path, "Region", "cy", "", sb_cy);
                    rInfo.Cy = double.Parse(sb_cy.ToString());
                    FileManager.GetValue(path, "Region", "sideXLength", "", sb_sideXLength);
                    rInfo.SideXLength = double.Parse(sb_sideXLength.ToString());
                    FileManager.GetValue(path, "Region", "sideYLength", "", sb_sideYLength);
                    rInfo.SideYLength = double.Parse(sb_sideYLength.ToString());
                    FileManager.GetValue(path, "Region", "rotation", "", sb_rotation);
                    rInfo.Rotation = double.Parse(sb_rotation.ToString());
                    FileManager.GetValue(path, "Region", "skew", "", sb_skew);
                    rInfo.Skew = double.Parse(sb_skew.ToString());

                    tb_cx.Text = rInfo.Cx.ToString();
                    tb_cy.Text = rInfo.Cy.ToString();
                    tb_xLength.Text = rInfo.SideXLength.ToString();
                    tb_yLength.Text = rInfo.SideYLength.ToString();
                    tb_rotation.Text = rInfo.Rotation.ToString();
                    tb_skew.Text = rInfo.Skew.ToString();
                }
                else
                    return;

                if (getPol.Equals("") == false)
                {

                    FileManager.GetValue(path, "Parameter", "Polarity", "", sb_Polarity);
                    rInfo.Edge0Polarity = int.Parse(sb_Polarity.ToString());
                    FileManager.GetValue(path, "Parameter", "Thresold", "", sb_Thresold);
                    rInfo.Threshold = double.Parse(sb_Thresold.ToString());
                    FileManager.GetValue(path, "Parameter", "HalfSizePixels", "", sb_HalfSizePixels);
                    rInfo.HalfsizePixels = int.Parse(sb_HalfSizePixels.ToString());

                    caliperTool.SetPolarity(rInfo.Edge0Polarity);
                    cb_edge0Polarity.SelectedIndex = rInfo.Edge0Polarity;
                    caliperTool.SetThreshold(rInfo.Threshold);
                    tb_Thresold.Text = rInfo.Threshold.ToString();
                    caliperTool.SetHalfSizePixels(rInfo.HalfsizePixels);
                    tb_HalfsizePixels.Text = rInfo.HalfsizePixels.ToString();
                } else
                {
                    // 저장된 파일 없을 경우 기본값 부여

                    rInfo.Edge0Polarity = 0;
                    rInfo.Threshold = 10;
                    rInfo.HalfsizePixels = 4;

                    caliperTool.SetPolarity(rInfo.Edge0Polarity);
                    cb_edge0Polarity.SelectedIndex = rInfo.Edge0Polarity;
                    caliperTool.SetThreshold(rInfo.Threshold);
                    tb_Thresold.Text = rInfo.Threshold.ToString();
                    caliperTool.SetHalfSizePixels(rInfo.HalfsizePixels);
                    tb_HalfsizePixels.Text = rInfo.HalfsizePixels.ToString();
                }
            }
            else
                return;


        }
    }
}
