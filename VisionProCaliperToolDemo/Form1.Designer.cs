namespace VisionProCaliperToolDemo
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
            this.cogDisplay1 = new Cognex.VisionPro.Display.CogDisplay();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_cx = new System.Windows.Forms.TextBox();
            this.tb_cy = new System.Windows.Forms.TextBox();
            this.tb_xLength = new System.Windows.Forms.TextBox();
            this.tb_yLength = new System.Windows.Forms.TextBox();
            this.tb_rotation = new System.Windows.Forms.TextBox();
            this.tb_skew = new System.Windows.Forms.TextBox();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_get = new System.Windows.Forms.Button();
            this.cb_edge0Polarity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_HalfsizePixels = new System.Windows.Forms.TextBox();
            this.tb_Thresold = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.cogDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay1.MouseWheelSensitivity = 1D;
            this.cogDisplay1.Name = "cogDisplay1";
            this.cogDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay1.OcxState")));
            this.cogDisplay1.Size = new System.Drawing.Size(1079, 618);
            this.cogDisplay1.TabIndex = 0;
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
            this.menuStrip1.Size = new System.Drawing.Size(1121, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageLoadToolStripMenuItem,
            this.imageSaveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // imageLoadToolStripMenuItem
            // 
            this.imageLoadToolStripMenuItem.Name = "imageLoadToolStripMenuItem";
            this.imageLoadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imageLoadToolStripMenuItem.Text = "Image Load";
            this.imageLoadToolStripMenuItem.Click += new System.EventHandler(this.imageLoadToolStripMenuItem_Click);
            // 
            // imageSaveToolStripMenuItem
            // 
            this.imageSaveToolStripMenuItem.Name = "imageSaveToolStripMenuItem";
            this.imageSaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imageSaveToolStripMenuItem.Text = "Image Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // imageProcessToolStripMenuItem
            // 
            this.imageProcessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToRedChannelToolStripMenuItem,
            this.colorToGreenChannelToolStripMenuItem,
            this.colorToBlueChannelToolStripMenuItem});
            this.imageProcessToolStripMenuItem.Name = "imageProcessToolStripMenuItem";
            this.imageProcessToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.imageProcessToolStripMenuItem.Text = "Image Process";
            // 
            // colorToRedChannelToolStripMenuItem
            // 
            this.colorToRedChannelToolStripMenuItem.Name = "colorToRedChannelToolStripMenuItem";
            this.colorToRedChannelToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.colorToRedChannelToolStripMenuItem.Text = "Color to Red Channel";
            this.colorToRedChannelToolStripMenuItem.Click += new System.EventHandler(this.colorToRedChannelToolStripMenuItem_Click);
            // 
            // colorToGreenChannelToolStripMenuItem
            // 
            this.colorToGreenChannelToolStripMenuItem.Name = "colorToGreenChannelToolStripMenuItem";
            this.colorToGreenChannelToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.colorToGreenChannelToolStripMenuItem.Text = "Color to Green Channel";
            this.colorToGreenChannelToolStripMenuItem.Click += new System.EventHandler(this.colorToGreenChannelToolStripMenuItem_Click);
            // 
            // colorToBlueChannelToolStripMenuItem
            // 
            this.colorToBlueChannelToolStripMenuItem.Name = "colorToBlueChannelToolStripMenuItem";
            this.colorToBlueChannelToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
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
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // initToolStripMenuItem
            // 
            this.initToolStripMenuItem.Name = "initToolStripMenuItem";
            this.initToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.initToolStripMenuItem.Text = "Init";
            this.initToolStripMenuItem.Click += new System.EventHandler(this.initToolStripMenuItem_Click);
            // 
            // setParamToolStripMenuItem
            // 
            this.setParamToolStripMenuItem.Name = "setParamToolStripMenuItem";
            this.setParamToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.setParamToolStripMenuItem.Text = "Set Param";
            this.setParamToolStripMenuItem.Click += new System.EventHandler(this.setParamToolStripMenuItem_Click);
            // 
            // showRegionToolStripMenuItem
            // 
            this.showRegionToolStripMenuItem.Name = "showRegionToolStripMenuItem";
            this.showRegionToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.showRegionToolStripMenuItem.Text = "Show Region";
            this.showRegionToolStripMenuItem.Click += new System.EventHandler(this.showRegionToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 692);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "center x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(429, 717);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "center y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(647, 692);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "sideXLength";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(647, 717);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "sideYLength";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(895, 690);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "rotation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(895, 715);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "skew";
            // 
            // tb_cx
            // 
            this.tb_cx.Location = new System.Drawing.Point(495, 687);
            this.tb_cx.Name = "tb_cx";
            this.tb_cx.Size = new System.Drawing.Size(125, 21);
            this.tb_cx.TabIndex = 9;
            // 
            // tb_cy
            // 
            this.tb_cy.Location = new System.Drawing.Point(495, 715);
            this.tb_cy.Name = "tb_cy";
            this.tb_cy.Size = new System.Drawing.Size(125, 21);
            this.tb_cy.TabIndex = 10;
            // 
            // tb_xLength
            // 
            this.tb_xLength.Location = new System.Drawing.Point(743, 687);
            this.tb_xLength.Name = "tb_xLength";
            this.tb_xLength.Size = new System.Drawing.Size(125, 21);
            this.tb_xLength.TabIndex = 11;
            // 
            // tb_yLength
            // 
            this.tb_yLength.Location = new System.Drawing.Point(743, 715);
            this.tb_yLength.Name = "tb_yLength";
            this.tb_yLength.Size = new System.Drawing.Size(125, 21);
            this.tb_yLength.TabIndex = 12;
            // 
            // tb_rotation
            // 
            this.tb_rotation.Location = new System.Drawing.Point(963, 687);
            this.tb_rotation.Name = "tb_rotation";
            this.tb_rotation.Size = new System.Drawing.Size(125, 21);
            this.tb_rotation.TabIndex = 13;
            // 
            // tb_skew
            // 
            this.tb_skew.Location = new System.Drawing.Point(963, 715);
            this.tb_skew.Name = "tb_skew";
            this.tb_skew.Size = new System.Drawing.Size(125, 21);
            this.tb_skew.TabIndex = 14;
            // 
            // bt_save
            // 
            this.bt_save.Enabled = false;
            this.bt_save.Location = new System.Drawing.Point(918, 751);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(169, 44);
            this.bt_save.TabIndex = 15;
            this.bt_save.Text = "Save Region Info";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_get
            // 
            this.bt_get.Enabled = false;
            this.bt_get.Location = new System.Drawing.Point(743, 751);
            this.bt_get.Name = "bt_get";
            this.bt_get.Size = new System.Drawing.Size(169, 44);
            this.bt_get.TabIndex = 16;
            this.bt_get.Text = "Get Region Info";
            this.bt_get.UseVisualStyleBackColor = true;
            this.bt_get.Click += new System.EventHandler(this.bt_get_Click);
            // 
            // cb_edge0Polarity
            // 
            this.cb_edge0Polarity.FormattingEnabled = true;
            this.cb_edge0Polarity.Items.AddRange(new object[] {
            "LightToDark",
            "DarkToLight"});
            this.cb_edge0Polarity.Location = new System.Drawing.Point(196, 693);
            this.cb_edge0Polarity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_edge0Polarity.Name = "cb_edge0Polarity";
            this.cb_edge0Polarity.Size = new System.Drawing.Size(186, 20);
            this.cb_edge0Polarity.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 695);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "Edge0Polarity";
            // 
            // tb_HalfsizePixels
            // 
            this.tb_HalfsizePixels.Location = new System.Drawing.Point(196, 757);
            this.tb_HalfsizePixels.Name = "tb_HalfsizePixels";
            this.tb_HalfsizePixels.Size = new System.Drawing.Size(186, 21);
            this.tb_HalfsizePixels.TabIndex = 22;
            // 
            // tb_Thresold
            // 
            this.tb_Thresold.Location = new System.Drawing.Point(196, 724);
            this.tb_Thresold.Name = "tb_Thresold";
            this.tb_Thresold.Size = new System.Drawing.Size(186, 21);
            this.tb_Thresold.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 759);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "FilterHalfSizeInPixels";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 727);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "ContrastThreshold";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 816);
            this.Controls.Add(this.tb_HalfsizePixels);
            this.Controls.Add(this.tb_Thresold);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_edge0Polarity);
            this.Controls.Add(this.bt_get);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.tb_skew);
            this.Controls.Add(this.tb_rotation);
            this.Controls.Add(this.tb_yLength);
            this.Controls.Add(this.tb_xLength);
            this.Controls.Add(this.tb_cy);
            this.Controls.Add(this.tb_cx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cogDisplay1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.Display.CogDisplay cogDisplay1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToRedChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToGreenChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToBlueChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_cx;
        private System.Windows.Forms.TextBox tb_cy;
        private System.Windows.Forms.TextBox tb_xLength;
        private System.Windows.Forms.TextBox tb_yLength;
        private System.Windows.Forms.TextBox tb_rotation;
        private System.Windows.Forms.TextBox tb_skew;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_get;
        private System.Windows.Forms.ComboBox cb_edge0Polarity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_HalfsizePixels;
        private System.Windows.Forms.TextBox tb_Thresold;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem setParamToolStripMenuItem;
    }
}

