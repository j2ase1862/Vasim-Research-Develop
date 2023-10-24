using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageFile;
using Autofac;
using VisionProCaliperToolDemo;

namespace VisionProBlobToolDemo
{
    public partial class Form1 : Form
    {
        private CogImage24PlanarColor cogImg24Color;
        private CogImage8Grey cogImg8Grey;

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

        public static Form1 form1;

        public Form1()
        {
            InitializeComponent();
            form1 = this;

            #region 이 부분은 이해 필요
            // Autofac를 이용한 의존성 주입 설정
            var builder = new ContainerBuilder();
            builder.RegisterType<cBlob>().As<IInspectionTool>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                IInspectionTool tool = scope.Resolve<IInspectionTool>();
                GlobalInstance.Instance.Tool = BlobToolFactory.CreateTools(tool);
            }
            #endregion
            //GlobalInstance.Instance.Tool = BlobToolFactory.CreateTools();
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

        private void colorToRedChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogImg8Grey = Run(cogImg24Color, 0);

            cogDisplay1.Image = cogImg8Grey;
        }

        private void colorToGreenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogImg8Grey = Run(cogImg24Color, 1);

            cogDisplay1.Image = cogImg8Grey;
        }

        private void colorToBlueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogImg8Grey = Run(cogImg24Color, 2);

            cogDisplay1.Image = cogImg8Grey;
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

        private void initToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogDisplay1.StaticGraphics.Clear();
            cogDisplay1.InteractiveGraphics.Clear();

            GlobalInstance.Instance.Tool.Init();
        }

        private void showRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalInstance.Instance.Tool.ShowRegion(cogDisplay1);
        }

        private void setParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalInstance.Instance.Tool.GetIndex(comboBox_Blob.SelectedIndex);

            if (textBox_Threshold.Text != null)
            {
                int value = int.Parse(textBox_Threshold.Text);
                GlobalInstance.Instance.Tool.SetThreshold(value);
            }

            if (textBox_MinPixel.Text != null)
            {
                int value = int.Parse(textBox_MinPixel.Text);
                GlobalInstance.Instance.Tool.SetMinPixel(value);
            }

            if (radioButton_DarkBlob.Checked)
            {
                int value = 0;

                GlobalInstance.Instance.Tool.SetPolarity(value);
            }
            else if (radioButton_WhiteBlob.Checked)
            {
                int value = 1;

                GlobalInstance.Instance.Tool.SetPolarity(value);
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cogDisplay1.InteractiveGraphics.Clear();
            cogDisplay1.StaticGraphics.Clear();

            GlobalInstance.Instance.Tool.Run(cogImg8Grey, cogDisplay1, comboBox_Blob.SelectedIndex);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Pamramsave_Click(object sender, EventArgs e)
        {
            GlobalInstance.Instance.Tool.SetParam();
        }

        private void bt_Scopesave_Click(object sender, EventArgs e)
        {
            GlobalInstance.Instance.Tool.SetScope();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 프로그램 로드될 때 파일 유무 확인하여 display
            for (int cb = 0; cb < comboBox_Blob.Items.Count; cb++)
            {
                // 파일로 저장된 Region 정보 호출
                FileManager.GetValue(region_path, "Region" + cb, "Width", "", sb_Width);
                string get_w = sb_Width.ToString();

                if (File.Exists(region_path) == true && get_w.Equals("") == false)
                {
                    GlobalInstance.Instance.Tool.GetRegion(true, cb);
                }
                else
                {
                    GlobalInstance.Instance.Tool.GetRegion(false, cb);
                }

                // 파일로 저장된 Param 정보 호출
                if (File.Exists(path) == true)
                {
                    GlobalInstance.Instance.Tool.GetParam(true, cb);
                }
                else
                {
                    GlobalInstance.Instance.Tool.GetParam(false, cb);
                }
            }
        }

        private void bt_SaveRegion_Click(object sender, EventArgs e)
        {
            GlobalInstance.Instance.Tool.SaveRegion();
        }

        private void comboBox_Blob_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalInstance.Instance.Tool.GetIndex(comboBox_Blob.SelectedIndex);
            GlobalInstance.Instance.Tool.DisplayParam();
        }

        private void button_Inspection_Click(object sender, EventArgs e)
        {
            cogDisplay1.InteractiveGraphics.Clear();
            cogDisplay1.StaticGraphics.Clear();

            for (int si=0; si<comboBox_Blob.Items.Count; si++)
            {
                GlobalInstance.Instance.Tool.Run(cogImg8Grey, cogDisplay1, si);
            }
        }
    }
}
