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

        string path = @"C:\Users\Vasim\Desktop\Param_Bolb.ini";

        StringBuilder sb_min = new StringBuilder(255);
        StringBuilder sb_max = new StringBuilder(255);

        StringBuilder sb_blob = new StringBuilder(255);
        StringBuilder sb_threshold = new StringBuilder(255);
        StringBuilder sb_minpixel = new StringBuilder(255);

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
            GlobalInstance.Instance.Tool.Init();
        }

        private void showRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalInstance.Instance.Tool.ShowRegion(cogDisplay1);
        }

        private void setParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

            GlobalInstance.Instance.Tool.Run(cogImg8Grey, cogDisplay1);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Pamramsave_Click(object sender, EventArgs e)
        {
            if (radioButton_DarkBlob.Checked == true)
            {
                FileManager.SetValue(path, "Parameter", "Blob", radioButton_DarkBlob.Text);
                FileManager.SetValue(path, "Parameter", "Threshold", textBox_Threshold.Text);
                FileManager.SetValue(path, "Parameter", "Min Pixel", textBox_MinPixel.Text);

                MessageBox.Show("Save Complete", "Save Params");
            }
            if (radioButton_WhiteBlob.Checked == true)
            {
                FileManager.SetValue(path, "Parameter", "Blob", radioButton_WhiteBlob.Text);
                FileManager.SetValue(path, "Parameter", "Threshold", textBox_Threshold.Text);
                FileManager.SetValue(path, "Parameter", "Min Pixel", textBox_MinPixel.Text);

                MessageBox.Show("Save Complete", "Save Params");
            }
        }

        private void bt_Scopesave_Click(object sender, EventArgs e)
        {
            FileManager.SetValue(path, "Scope", "Min", textBox_MinSet.Text);
            FileManager.SetValue(path, "Scope", "Max", textBox_MaxSet.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 프로그램 로드될 때 파일 유무 확인하여 display
            FileManager.GetValue(path, "Scope", "Min", "", sb_min);
            string get_min = sb_min.ToString();

            if (File.Exists(path) == true && get_min.Equals("") == false)
            {
                textBox_MinSet.Text = get_min;

                FileManager.GetValue(path, "Scope", "Max", "", sb_max);
                textBox_MaxSet.Text = sb_max.ToString();

                FileManager.GetValue(path, "Parameter", "Blob", "", sb_blob);
                FileManager.GetValue(path, "Parameter", "Threshold", "", sb_threshold);
                FileManager.GetValue(path, "Parameter", "Min Pixel", "", sb_minpixel);

                if (sb_blob.ToString().Equals(radioButton_WhiteBlob.Text) == true)
                {
                    radioButton_WhiteBlob.Checked = true;
                }
                else if (sb_blob.ToString().Equals(radioButton_DarkBlob.Text) == true)
                {
                    radioButton_DarkBlob.Checked = true;
                }
                textBox_Threshold.Text = sb_threshold.ToString();
                textBox_MinPixel.Text = sb_minpixel.ToString();
            }
            else
            {
                textBox_MinSet.Text = "100000";
                textBox_MaxSet.Text = "500000";
            }
        }
    }
}
