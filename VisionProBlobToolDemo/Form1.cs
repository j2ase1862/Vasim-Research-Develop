using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageFile;
using Autofac;

namespace VisionProBlobToolDemo
{
    public partial class Form1 : Form
    {
        private CogImage24PlanarColor cogImg24Color;
        private CogImage8Grey cogImg8Grey;
            
        public Form1()
        {
            InitializeComponent();

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
            if(textBox_Threshold.Text != null)
            {
                int value = int.Parse(textBox_Threshold.Text);
                GlobalInstance.Instance.Tool.SetThreshold(value);
            }

            if (textBox_MinPixel.Text != null)
            {
                int value = int.Parse(textBox_MinPixel.Text);
                GlobalInstance.Instance.Tool.SetMinPixel(value);
            }

            if(radioButton_DarkBlob.Checked)
            {
                int value = 0;

                GlobalInstance.Instance.Tool.SetPolarity(value);
            }
            else if(radioButton_WhiteBlob.Checked)
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
    }
}
