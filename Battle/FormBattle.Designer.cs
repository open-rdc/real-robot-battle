namespace Battle
{
    partial class FormBattle
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBattle));
            this.previewPanel = new System.Windows.Forms.Panel();
            this.labelNoVideo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBarLength = new System.Windows.Forms.TrackBar();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.timer100ms = new System.Windows.Forms.Timer(this.components);
            this.checkBoxBrake = new System.Windows.Forms.CheckBox();
            this.checkBoxTracking = new System.Windows.Forms.CheckBox();
            this.textBoxXValue = new System.Windows.Forms.TextBox();
            this.textBoxYValue = new System.Windows.Forms.TextBox();
            this.textBoxZValue = new System.Windows.Forms.TextBox();
            this.textBoxAccel = new System.Windows.Forms.TextBox();
            this.checkBoxManual = new System.Windows.Forms.CheckBox();
            this.comboBoxButtonB = new System.Windows.Forms.ComboBox();
            this.comboBoxButtonX = new System.Windows.Forms.ComboBox();
            this.comboBoxButtonY = new System.Windows.Forms.ComboBox();
            this.comboBoxButtonA = new System.Windows.Forms.ComboBox();
            this.comboBoxBoost = new System.Windows.Forms.ComboBox();
            this.checkBoxSpecial = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxVideo = new System.Windows.Forms.CheckBox();
            this.labelLive = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonLeft = new System.Windows.Forms.RadioButton();
            this.radioButtonRight = new System.Windows.Forms.RadioButton();
            this.checkBoxAttack = new System.Windows.Forms.CheckBox();
            this.buttonSteam = new System.Windows.Forms.Button();
            this.buttonVoice = new System.Windows.Forms.Button();
            this.comboBoxVoice = new System.Windows.Forms.ComboBox();
            this.buttonPreset = new System.Windows.Forms.Button();
            this.checkBoxHead = new System.Windows.Forms.CheckBox();
            this.checkBoxServo = new System.Windows.Forms.CheckBox();
            this.pictureBoxAttackPoint = new Battle.PictureBoxAttackPoint();
            this.panelDistance = new Battle.PanelDistance();
            this.panelURG = new Battle.PanelURG();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAttackPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // previewPanel
            // 
            this.previewPanel.Font = new System.Drawing.Font("Optimus", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewPanel.Location = new System.Drawing.Point(0, 0);
            this.previewPanel.Margin = new System.Windows.Forms.Padding(12);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(320, 240);
            this.previewPanel.TabIndex = 0;
            // 
            // labelNoVideo
            // 
            this.labelNoVideo.AutoSize = true;
            this.labelNoVideo.BackColor = System.Drawing.Color.Transparent;
            this.labelNoVideo.Location = new System.Drawing.Point(64, 88);
            this.labelNoVideo.Name = "labelNoVideo";
            this.labelNoVideo.Size = new System.Drawing.Size(189, 51);
            this.labelNoVideo.TabIndex = 121;
            this.labelNoVideo.Text = "No Video";
            this.labelNoVideo.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2392, 68);
            this.button1.Margin = new System.Windows.Forms.Padding(12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 98);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // trackBarLength
            // 
            this.trackBarLength.LargeChange = 100;
            this.trackBarLength.Location = new System.Drawing.Point(704, 184);
            this.trackBarLength.Maximum = 5000;
            this.trackBarLength.Minimum = 100;
            this.trackBarLength.Name = "trackBarLength";
            this.trackBarLength.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarLength.Size = new System.Drawing.Size(45, 320);
            this.trackBarLength.SmallChange = 10;
            this.trackBarLength.TabIndex = 100;
            this.trackBarLength.TickFrequency = 100;
            this.trackBarLength.Value = 1000;
            this.trackBarLength.Scroll += new System.EventHandler(this.trackBarLength_Scroll);
            // 
            // textBoxLength
            // 
            this.textBoxLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLength.Location = new System.Drawing.Point(576, 192);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(104, 53);
            this.textBoxLength.TabIndex = 5;
            this.textBoxLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timer100ms
            // 
            this.timer100ms.Tick += new System.EventHandler(this.timer100ms_Tick);
            // 
            // checkBoxBrake
            // 
            this.checkBoxBrake.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBrake.AutoSize = true;
            this.checkBoxBrake.BackColor = System.Drawing.Color.Blue;
            this.checkBoxBrake.Checked = true;
            this.checkBoxBrake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBrake.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxBrake.ForeColor = System.Drawing.Color.White;
            this.checkBoxBrake.Location = new System.Drawing.Point(16, 448);
            this.checkBoxBrake.Name = "checkBoxBrake";
            this.checkBoxBrake.Size = new System.Drawing.Size(145, 61);
            this.checkBoxBrake.TabIndex = 103;
            this.checkBoxBrake.Text = "Brake";
            this.checkBoxBrake.UseVisualStyleBackColor = false;
            this.checkBoxBrake.CheckedChanged += new System.EventHandler(this.checkBoxBrake_CheckedChanged);
            // 
            // checkBoxTracking
            // 
            this.checkBoxTracking.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxTracking.AutoSize = true;
            this.checkBoxTracking.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxTracking.Location = new System.Drawing.Point(576, 56);
            this.checkBoxTracking.Name = "checkBoxTracking";
            this.checkBoxTracking.Size = new System.Drawing.Size(199, 61);
            this.checkBoxTracking.TabIndex = 104;
            this.checkBoxTracking.Text = "Tracking";
            this.checkBoxTracking.UseVisualStyleBackColor = true;
            this.checkBoxTracking.CheckedChanged += new System.EventHandler(this.checkBoxTracking_CheckedChanged);
            // 
            // textBoxXValue
            // 
            this.textBoxXValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxXValue.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxXValue.Location = new System.Drawing.Point(168, 416);
            this.textBoxXValue.Name = "textBoxXValue";
            this.textBoxXValue.Size = new System.Drawing.Size(80, 30);
            this.textBoxXValue.TabIndex = 105;
            this.textBoxXValue.Text = "x value";
            this.textBoxXValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxYValue
            // 
            this.textBoxYValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxYValue.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYValue.Location = new System.Drawing.Point(168, 448);
            this.textBoxYValue.Name = "textBoxYValue";
            this.textBoxYValue.Size = new System.Drawing.Size(80, 30);
            this.textBoxYValue.TabIndex = 106;
            this.textBoxYValue.Text = "y value";
            this.textBoxYValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxZValue
            // 
            this.textBoxZValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxZValue.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZValue.Location = new System.Drawing.Point(168, 480);
            this.textBoxZValue.Name = "textBoxZValue";
            this.textBoxZValue.Size = new System.Drawing.Size(80, 30);
            this.textBoxZValue.TabIndex = 107;
            this.textBoxZValue.Text = "z value";
            this.textBoxZValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxAccel
            // 
            this.textBoxAccel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAccel.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAccel.ForeColor = System.Drawing.Color.Red;
            this.textBoxAccel.Location = new System.Drawing.Point(8, 416);
            this.textBoxAccel.Name = "textBoxAccel";
            this.textBoxAccel.Size = new System.Drawing.Size(144, 30);
            this.textBoxAccel.TabIndex = 108;
            this.textBoxAccel.Text = "Normal";
            // 
            // checkBoxManual
            // 
            this.checkBoxManual.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxManual.AutoSize = true;
            this.checkBoxManual.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxManual.Location = new System.Drawing.Point(16, 240);
            this.checkBoxManual.Name = "checkBoxManual";
            this.checkBoxManual.Size = new System.Drawing.Size(167, 61);
            this.checkBoxManual.TabIndex = 109;
            this.checkBoxManual.Text = "Manual";
            this.checkBoxManual.UseVisualStyleBackColor = true;
            this.checkBoxManual.CheckedChanged += new System.EventHandler(this.checkBoxManual_CheckedChanged);
            // 
            // comboBoxButtonB
            // 
            this.comboBoxButtonB.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxButtonB.FormattingEnabled = true;
            this.comboBoxButtonB.Location = new System.Drawing.Point(160, 336);
            this.comboBoxButtonB.Name = "comboBoxButtonB";
            this.comboBoxButtonB.Size = new System.Drawing.Size(144, 30);
            this.comboBoxButtonB.TabIndex = 110;
            this.comboBoxButtonB.Text = "RightPunch";
            // 
            // comboBoxButtonX
            // 
            this.comboBoxButtonX.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxButtonX.FormattingEnabled = true;
            this.comboBoxButtonX.Location = new System.Drawing.Point(8, 336);
            this.comboBoxButtonX.Name = "comboBoxButtonX";
            this.comboBoxButtonX.Size = new System.Drawing.Size(144, 30);
            this.comboBoxButtonX.TabIndex = 111;
            this.comboBoxButtonX.Text = "LeftPunch";
            // 
            // comboBoxButtonY
            // 
            this.comboBoxButtonY.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxButtonY.FormattingEnabled = true;
            this.comboBoxButtonY.Location = new System.Drawing.Point(32, 304);
            this.comboBoxButtonY.Name = "comboBoxButtonY";
            this.comboBoxButtonY.Size = new System.Drawing.Size(240, 30);
            this.comboBoxButtonY.TabIndex = 112;
            this.comboBoxButtonY.Text = "Pose";
            // 
            // comboBoxButtonA
            // 
            this.comboBoxButtonA.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxButtonA.FormattingEnabled = true;
            this.comboBoxButtonA.Location = new System.Drawing.Point(32, 368);
            this.comboBoxButtonA.Name = "comboBoxButtonA";
            this.comboBoxButtonA.Size = new System.Drawing.Size(240, 30);
            this.comboBoxButtonA.TabIndex = 113;
            this.comboBoxButtonA.Text = "CenterPunch";
            // 
            // comboBoxBoost
            // 
            this.comboBoxBoost.FormattingEnabled = true;
            this.comboBoxBoost.Items.AddRange(new object[] {
            "No Select",
            "Grenade",
            "Exhaust",
            "Axe"});
            this.comboBoxBoost.Location = new System.Drawing.Point(272, 448);
            this.comboBoxBoost.Name = "comboBoxBoost";
            this.comboBoxBoost.Size = new System.Drawing.Size(216, 59);
            this.comboBoxBoost.TabIndex = 115;
            this.comboBoxBoost.Text = "Boost";
            // 
            // checkBoxSpecial
            // 
            this.checkBoxSpecial.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSpecial.AutoSize = true;
            this.checkBoxSpecial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxSpecial.Location = new System.Drawing.Point(496, 448);
            this.checkBoxSpecial.Name = "checkBoxSpecial";
            this.checkBoxSpecial.Size = new System.Drawing.Size(78, 61);
            this.checkBoxSpecial.TabIndex = 116;
            this.checkBoxSpecial.Text = "Go";
            this.checkBoxSpecial.UseVisualStyleBackColor = true;
            this.checkBoxSpecial.CheckedChanged += new System.EventHandler(this.checkBoxSpecial_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(416, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 22);
            this.label3.TabIndex = 118;
            this.label3.Text = " 800";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(416, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 22);
            this.label4.TabIndex = 119;
            this.label4.Text = "2200";
            // 
            // checkBoxVideo
            // 
            this.checkBoxVideo.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxVideo.AutoSize = true;
            this.checkBoxVideo.BackColor = System.Drawing.Color.Blue;
            this.checkBoxVideo.Checked = true;
            this.checkBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVideo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxVideo.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVideo.ForeColor = System.Drawing.Color.White;
            this.checkBoxVideo.Location = new System.Drawing.Point(216, 240);
            this.checkBoxVideo.Name = "checkBoxVideo";
            this.checkBoxVideo.Size = new System.Drawing.Size(66, 32);
            this.checkBoxVideo.TabIndex = 120;
            this.checkBoxVideo.Text = "Video";
            this.checkBoxVideo.UseVisualStyleBackColor = false;
            this.checkBoxVideo.CheckedChanged += new System.EventHandler(this.checkBoxVideo_CheckedChanged);
            // 
            // labelLive
            // 
            this.labelLive.AutoSize = true;
            this.labelLive.BackColor = System.Drawing.Color.Transparent;
            this.labelLive.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLive.Location = new System.Drawing.Point(272, 208);
            this.labelLive.Name = "labelLive";
            this.labelLive.Size = new System.Drawing.Size(43, 22);
            this.labelLive.TabIndex = 122;
            this.labelLive.Text = "Live";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "Optimus";
            // 
            // radioButtonLeft
            // 
            this.radioButtonLeft.AutoSize = true;
            this.radioButtonLeft.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLeft.Location = new System.Drawing.Point(584, 448);
            this.radioButtonLeft.Name = "radioButtonLeft";
            this.radioButtonLeft.Size = new System.Drawing.Size(64, 26);
            this.radioButtonLeft.TabIndex = 123;
            this.radioButtonLeft.Text = "Left";
            this.radioButtonLeft.UseVisualStyleBackColor = true;
            this.radioButtonLeft.CheckedChanged += new System.EventHandler(this.radioButtonLeft_CheckedChanged);
            // 
            // radioButtonRight
            // 
            this.radioButtonRight.AutoSize = true;
            this.radioButtonRight.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRight.Location = new System.Drawing.Point(584, 480);
            this.radioButtonRight.Name = "radioButtonRight";
            this.radioButtonRight.Size = new System.Drawing.Size(71, 26);
            this.radioButtonRight.TabIndex = 124;
            this.radioButtonRight.Text = "Right";
            this.radioButtonRight.UseVisualStyleBackColor = true;
            this.radioButtonRight.CheckedChanged += new System.EventHandler(this.radioButtonRight_CheckedChanged);
            // 
            // checkBoxAttack
            // 
            this.checkBoxAttack.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxAttack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxAttack.Location = new System.Drawing.Point(576, 120);
            this.checkBoxAttack.Name = "checkBoxAttack";
            this.checkBoxAttack.Size = new System.Drawing.Size(199, 61);
            this.checkBoxAttack.TabIndex = 125;
            this.checkBoxAttack.Text = "Attack";
            this.checkBoxAttack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxAttack.UseVisualStyleBackColor = true;
            this.checkBoxAttack.CheckedChanged += new System.EventHandler(this.checkBoxAttack_CheckedChanged);
            // 
            // buttonSteam
            // 
            this.buttonSteam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSteam.Font = new System.Drawing.Font("Optimus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSteam.Location = new System.Drawing.Point(312, 288);
            this.buttonSteam.Name = "buttonSteam";
            this.buttonSteam.Size = new System.Drawing.Size(96, 32);
            this.buttonSteam.TabIndex = 126;
            this.buttonSteam.Text = "Steam";
            this.buttonSteam.UseVisualStyleBackColor = true;
            this.buttonSteam.Click += new System.EventHandler(this.buttonSteam_Click);
            // 
            // buttonVoice
            // 
            this.buttonVoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVoice.Font = new System.Drawing.Font("Optimus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVoice.Location = new System.Drawing.Point(312, 368);
            this.buttonVoice.Name = "buttonVoice";
            this.buttonVoice.Size = new System.Drawing.Size(96, 32);
            this.buttonVoice.TabIndex = 128;
            this.buttonVoice.Text = "Voice";
            this.buttonVoice.UseVisualStyleBackColor = true;
            this.buttonVoice.Click += new System.EventHandler(this.buttonVoice_Click);
            // 
            // comboBoxVoice
            // 
            this.comboBoxVoice.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVoice.FormattingEnabled = true;
            this.comboBoxVoice.Items.AddRange(new object[] {
            "01",
            "05a",
            "05b",
            "06",
            "08",
            "09",
            "11",
            "12"});
            this.comboBoxVoice.Location = new System.Drawing.Point(312, 328);
            this.comboBoxVoice.Name = "comboBoxVoice";
            this.comboBoxVoice.Size = new System.Drawing.Size(112, 30);
            this.comboBoxVoice.TabIndex = 129;
            this.comboBoxVoice.Text = "No Select";
            // 
            // buttonPreset
            // 
            this.buttonPreset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPreset.Font = new System.Drawing.Font("Optimus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreset.Location = new System.Drawing.Point(312, 408);
            this.buttonPreset.Name = "buttonPreset";
            this.buttonPreset.Size = new System.Drawing.Size(96, 32);
            this.buttonPreset.TabIndex = 130;
            this.buttonPreset.Text = "Preset";
            this.buttonPreset.UseVisualStyleBackColor = true;
            this.buttonPreset.Click += new System.EventHandler(this.buttonPreset_Click);
            // 
            // checkBoxHead
            // 
            this.checkBoxHead.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxHead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxHead.Font = new System.Drawing.Font("Optimus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHead.Location = new System.Drawing.Point(312, 248);
            this.checkBoxHead.Name = "checkBoxHead";
            this.checkBoxHead.Size = new System.Drawing.Size(96, 32);
            this.checkBoxHead.TabIndex = 131;
            this.checkBoxHead.Text = "Head";
            this.checkBoxHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxHead.UseVisualStyleBackColor = true;
            this.checkBoxHead.CheckedChanged += new System.EventHandler(this.checkBoxHead_CheckedChanged);
            // 
            // checkBoxServo
            // 
            this.checkBoxServo.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxServo.BackColor = System.Drawing.Color.White;
            this.checkBoxServo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxServo.Font = new System.Drawing.Font("Optimus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxServo.ForeColor = System.Drawing.Color.Black;
            this.checkBoxServo.Location = new System.Drawing.Point(88, 408);
            this.checkBoxServo.Name = "checkBoxServo";
            this.checkBoxServo.Size = new System.Drawing.Size(72, 32);
            this.checkBoxServo.TabIndex = 132;
            this.checkBoxServo.Text = "Servo";
            this.checkBoxServo.UseVisualStyleBackColor = false;
            this.checkBoxServo.CheckedChanged += new System.EventHandler(this.checkBoxServo_CheckedChanged);
            // 
            // pictureBoxAttackPoint
            // 
            this.pictureBoxAttackPoint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxAttackPoint.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAttackPoint.Image")));
            this.pictureBoxAttackPoint.Location = new System.Drawing.Point(432, 256);
            this.pictureBoxAttackPoint.Name = "pictureBoxAttackPoint";
            this.pictureBoxAttackPoint.Size = new System.Drawing.Size(248, 192);
            this.pictureBoxAttackPoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAttackPoint.TabIndex = 117;
            this.pictureBoxAttackPoint.TabStop = false;
            // 
            // panelDistance
            // 
            this.panelDistance.Location = new System.Drawing.Point(752, 184);
            this.panelDistance.Name = "panelDistance";
            this.panelDistance.Size = new System.Drawing.Size(32, 320);
            this.panelDistance.TabIndex = 114;
            // 
            // panelURG
            // 
            this.panelURG.Font = new System.Drawing.Font("Optimus", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelURG.Location = new System.Drawing.Point(328, 0);
            this.panelURG.Margin = new System.Windows.Forms.Padding(12);
            this.panelURG.Name = "panelURG";
            this.panelURG.Size = new System.Drawing.Size(248, 240);
            this.panelURG.TabIndex = 1;
            // 
            // FormBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(23F, 51F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.checkBoxServo);
            this.Controls.Add(this.checkBoxHead);
            this.Controls.Add(this.buttonPreset);
            this.Controls.Add(this.comboBoxVoice);
            this.Controls.Add(this.buttonVoice);
            this.Controls.Add(this.buttonSteam);
            this.Controls.Add(this.checkBoxAttack);
            this.Controls.Add(this.radioButtonRight);
            this.Controls.Add(this.radioButtonLeft);
            this.Controls.Add(this.checkBoxVideo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBoxAttackPoint);
            this.Controls.Add(this.checkBoxSpecial);
            this.Controls.Add(this.comboBoxBoost);
            this.Controls.Add(this.panelDistance);
            this.Controls.Add(this.panelURG);
            this.Controls.Add(this.comboBoxButtonA);
            this.Controls.Add(this.comboBoxButtonY);
            this.Controls.Add(this.comboBoxButtonX);
            this.Controls.Add(this.comboBoxButtonB);
            this.Controls.Add(this.checkBoxManual);
            this.Controls.Add(this.textBoxAccel);
            this.Controls.Add(this.textBoxZValue);
            this.Controls.Add(this.textBoxYValue);
            this.Controls.Add(this.textBoxXValue);
            this.Controls.Add(this.checkBoxTracking);
            this.Controls.Add(this.checkBoxBrake);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.trackBarLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLive);
            this.Controls.Add(this.labelNoVideo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.previewPanel);
            this.Font = new System.Drawing.Font("Optimus", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(12);
            this.Name = "FormBattle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CIT Takara Tomy Team";
            this.Load += new System.EventHandler(this.FormBattle_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBattle_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBattle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAttackPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBarLength;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.Timer timer100ms;
        private System.Windows.Forms.CheckBox checkBoxBrake;
        private System.Windows.Forms.CheckBox checkBoxTracking;
        private System.Windows.Forms.TextBox textBoxXValue;
        private System.Windows.Forms.TextBox textBoxYValue;
        private System.Windows.Forms.TextBox textBoxZValue;
        private System.Windows.Forms.TextBox textBoxAccel;
        private System.Windows.Forms.CheckBox checkBoxManual;
        private System.Windows.Forms.ComboBox comboBoxButtonB;
        private System.Windows.Forms.ComboBox comboBoxButtonX;
        private System.Windows.Forms.ComboBox comboBoxButtonY;
        private System.Windows.Forms.ComboBox comboBoxButtonA;
        private PanelURG panelURG;
        private PanelDistance panelDistance;
        private System.Windows.Forms.ComboBox comboBoxBoost;
        private System.Windows.Forms.CheckBox checkBoxSpecial;
        private PictureBoxAttackPoint pictureBoxAttackPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxVideo;
        private System.Windows.Forms.Label labelNoVideo;
        private System.Windows.Forms.Label labelLive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonLeft;
        private System.Windows.Forms.RadioButton radioButtonRight;
        private System.Windows.Forms.CheckBox checkBoxAttack;
        private System.Windows.Forms.Button buttonSteam;
        private System.Windows.Forms.Button buttonVoice;
        private System.Windows.Forms.ComboBox comboBoxVoice;
        private System.Windows.Forms.Button buttonPreset;
        private System.Windows.Forms.CheckBox checkBoxHead;
        private System.Windows.Forms.CheckBox checkBoxServo;
    }
}

