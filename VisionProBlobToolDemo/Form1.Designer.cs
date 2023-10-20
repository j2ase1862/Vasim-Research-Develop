namespace VisionProBlobToolDemo
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToRedChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToGreenChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToBlueChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setParamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cogDisplay1 = new Cognex.VisionPro.Display.CogDisplay();
            this.radioButton_WhiteBlob = new System.Windows.Forms.RadioButton();
            this.radioButton_DarkBlob = new System.Windows.Forms.RadioButton();
            this.textBox_MinPixel = new System.Windows.Forms.TextBox();
            this.textBox_Threshold = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_Save = new System.Windows.Forms.Button();
            this.textBox_Max = new System.Windows.Forms.TextBox();
            this.textBox_Min = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageProcessToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1281, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageLoadToolStripMenuItem,
            this.imageSaveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // imageLoadToolStripMenuItem
            // 
            this.imageLoadToolStripMenuItem.Name = "imageLoadToolStripMenuItem";
            this.imageLoadToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.imageLoadToolStripMenuItem.Text = "Image Load";
            this.imageLoadToolStripMenuItem.Click += new System.EventHandler(this.imageLoadToolStripMenuItem_Click);
            // 
            // imageSaveToolStripMenuItem
            // 
            this.imageSaveToolStripMenuItem.Name = "imageSaveToolStripMenuItem";
            this.imageSaveToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.imageSaveToolStripMenuItem.Text = "Image Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // imageProcessToolStripMenuItem
            // 
            this.imageProcessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToRedChannelToolStripMenuItem,
            this.colorToGreenChannelToolStripMenuItem,
            this.colorToBlueChannelToolStripMenuItem});
            this.imageProcessToolStripMenuItem.Name = "imageProcessToolStripMenuItem";
            this.imageProcessToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.imageProcessToolStripMenuItem.Text = "Image Process";
            // 
            // colorToRedChannelToolStripMenuItem
            // 
            this.colorToRedChannelToolStripMenuItem.Name = "colorToRedChannelToolStripMenuItem";
            this.colorToRedChannelToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.colorToRedChannelToolStripMenuItem.Text = "Color to Red Channel";
            this.colorToRedChannelToolStripMenuItem.Click += new System.EventHandler(this.colorToRedChannelToolStripMenuItem_Click);
            // 
            // colorToGreenChannelToolStripMenuItem
            // 
            this.colorToGreenChannelToolStripMenuItem.Name = "colorToGreenChannelToolStripMenuItem";
            this.colorToGreenChannelToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.colorToGreenChannelToolStripMenuItem.Text = "Color to Green Channel";
            this.colorToGreenChannelToolStripMenuItem.Click += new System.EventHandler(this.colorToGreenChannelToolStripMenuItem_Click);
            // 
            // colorToBlueChannelToolStripMenuItem
            // 
            this.colorToBlueChannelToolStripMenuItem.Name = "colorToBlueChannelToolStripMenuItem";
            this.colorToBlueChannelToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.colorToBlueChannelToolStripMenuItem.Text = "Color to Blue Channel";
            this.colorToBlueChannelToolStripMenuItem.Click += new System.EventHandler(this.colorToBlueChannelToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initToolStripMenuItem,
            this.setParamToolStripMenuItem,
            this.showRegionToolStripMenuItem,
            this.runToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // initToolStripMenuItem
            // 
            this.initToolStripMenuItem.Name = "initToolStripMenuItem";
            this.initToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.initToolStripMenuItem.Text = "Init";
            this.initToolStripMenuItem.Click += new System.EventHandler(this.initToolStripMenuItem_Click);
            // 
            // setParamToolStripMenuItem
            // 
            this.setParamToolStripMenuItem.Name = "setParamToolStripMenuItem";
            this.setParamToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.setParamToolStripMenuItem.Text = "Set Param";
            this.setParamToolStripMenuItem.Click += new System.EventHandler(this.setParamToolStripMenuItem_Click);
            // 
            // showRegionToolStripMenuItem
            // 
            this.showRegionToolStripMenuItem.Name = "showRegionToolStripMenuItem";
            this.showRegionToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.showRegionToolStripMenuItem.Text = "Show Region";
            this.showRegionToolStripMenuItem.Click += new System.EventHandler(this.showRegionToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // cogDisplay1
            // 
            this.cogDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay1.Location = new System.Drawing.Point(20, 38);
            this.cogDisplay1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cogDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay1.MouseWheelSensitivity = 1D;
            this.cogDisplay1.Name = "cogDisplay1";
            this.cogDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay1.OcxState")));
            this.cogDisplay1.Size = new System.Drawing.Size(1349, 772);
            this.cogDisplay1.TabIndex = 3;
            // 
            // radioButton_WhiteBlob
            // 
            this.radioButton_WhiteBlob.AutoSize = true;
            this.radioButton_WhiteBlob.Location = new System.Drawing.Point(26, 834);
            this.radioButton_WhiteBlob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton_WhiteBlob.Name = "radioButton_WhiteBlob";
            this.radioButton_WhiteBlob.Size = new System.Drawing.Size(100, 19);
            this.radioButton_WhiteBlob.TabIndex = 4;
            this.radioButton_WhiteBlob.TabStop = true;
            this.radioButton_WhiteBlob.Text = "White Blob";
            this.radioButton_WhiteBlob.UseVisualStyleBackColor = true;
            // 
            // radioButton_DarkBlob
            // 
            this.radioButton_DarkBlob.AutoSize = true;
            this.radioButton_DarkBlob.Location = new System.Drawing.Point(26, 861);
            this.radioButton_DarkBlob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton_DarkBlob.Name = "radioButton_DarkBlob";
            this.radioButton_DarkBlob.Size = new System.Drawing.Size(92, 19);
            this.radioButton_DarkBlob.TabIndex = 5;
            this.radioButton_DarkBlob.TabStop = true;
            this.radioButton_DarkBlob.Text = "Dark Blob";
            this.radioButton_DarkBlob.UseVisualStyleBackColor = true;
            // 
            // textBox_MinPixel
            // 
            this.textBox_MinPixel.Location = new System.Drawing.Point(101, 934);
            this.textBox_MinPixel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_MinPixel.Name = "textBox_MinPixel";
            this.textBox_MinPixel.Size = new System.Drawing.Size(89, 25);
            this.textBox_MinPixel.TabIndex = 26;
            // 
            // textBox_Threshold
            // 
            this.textBox_Threshold.Location = new System.Drawing.Point(101, 894);
            this.textBox_Threshold.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Threshold.Name = "textBox_Threshold";
            this.textBox_Threshold.Size = new System.Drawing.Size(89, 25);
            this.textBox_Threshold.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 939);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Min Pixel";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 899);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Threshold";
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(404, 936);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(216, 34);
            this.bt_Save.TabIndex = 37;
            this.bt_Save.Text = "Save";
            this.bt_Save.UseVisualStyleBackColor = true;
            // 
            // textBox_Max
            // 
            this.textBox_Max.Location = new System.Drawing.Point(454, 883);
            this.textBox_Max.Name = "textBox_Max";
            this.textBox_Max.Size = new System.Drawing.Size(100, 25);
            this.textBox_Max.TabIndex = 36;
            // 
            // textBox_Min
            // 
            this.textBox_Min.Location = new System.Drawing.Point(454, 834);
            this.textBox_Min.Name = "textBox_Min";
            this.textBox_Min.Size = new System.Drawing.Size(100, 25);
            this.textBox_Min.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 886);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 839);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Min";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 1020);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.textBox_Max);
            this.Controls.Add(this.textBox_Min);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_MinPixel);
            this.Controls.Add(this.textBox_Threshold);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.radioButton_DarkBlob);
            this.Controls.Add(this.radioButton_WhiteBlob);
            this.Controls.Add(this.cogDisplay1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToRedChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToGreenChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToBlueChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setParamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay1;
        private System.Windows.Forms.RadioButton radioButton_WhiteBlob;
        private System.Windows.Forms.RadioButton radioButton_DarkBlob;
        private System.Windows.Forms.TextBox textBox_MinPixel;
        private System.Windows.Forms.TextBox textBox_Threshold;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.TextBox textBox_Max;
        private System.Windows.Forms.TextBox textBox_Min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

