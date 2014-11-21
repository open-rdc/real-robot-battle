namespace motionControl
{
    partial class Form1
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
            this.buttonServoOn = new System.Windows.Forms.Button();
            this.buttonServoOff = new System.Windows.Forms.Button();
            this.buttonWriteOffsetAngle = new System.Windows.Forms.Button();
            this.numericUpDownOffsetWaist = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetLeftShoulderPitch = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetLeftShoulderRoll = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetLeftElbowPitch = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownOffsetRightElbowPitch = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetRightShoulderRoll = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetRightShoulderPitch = new System.Windows.Forms.NumericUpDown();
            this.buttonFileOpen = new System.Windows.Forms.Button();
            this.buttonFileSave = new System.Windows.Forms.Button();
            this.dataGridViewMotion = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parametric = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.left_shoulder_pitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.left_shoulder_roll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.left_elbow_pitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.right_shoulder_pitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.right_shoulder_roll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.right_elbow_pitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownRightElbowPitch = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRightShoulderRoll = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRightShoulderPitch = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownLeftElbowPitch = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLeftShoulderRoll = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLeftShoulderPitch = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWaist = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDownPeriod = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonErase = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.checkBoxTestMode = new System.Windows.Forms.CheckBox();
            this.checkBoxWaist = new System.Windows.Forms.CheckBox();
            this.checkBoxRightShoulderPitch = new System.Windows.Forms.CheckBox();
            this.checkBoxRightShoulderRoll = new System.Windows.Forms.CheckBox();
            this.checkBoxRightElbowPitch = new System.Windows.Forms.CheckBox();
            this.checkBoxLeftShoulderPitch = new System.Windows.Forms.CheckBox();
            this.checkBoxLeftShoulderRoll = new System.Windows.Forms.CheckBox();
            this.checkBoxLeftElbowPitch = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDownLift = new System.Windows.Forms.NumericUpDown();
            this.buttonLiftUp = new System.Windows.Forms.Button();
            this.buttonLiftDown = new System.Windows.Forms.Button();
            this.checkBoxLiftBrake = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetWaist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetLeftShoulderPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetLeftShoulderRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetLeftElbowPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetRightElbowPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetRightShoulderRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetRightShoulderPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightElbowPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightShoulderRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightShoulderPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftElbowPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftShoulderRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftShoulderPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWaist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLift)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonServoOn
            // 
            this.buttonServoOn.Location = new System.Drawing.Point(16, 16);
            this.buttonServoOn.Name = "buttonServoOn";
            this.buttonServoOn.Size = new System.Drawing.Size(88, 23);
            this.buttonServoOn.TabIndex = 0;
            this.buttonServoOn.Text = "SERVO ON";
            this.buttonServoOn.UseVisualStyleBackColor = true;
            this.buttonServoOn.Click += new System.EventHandler(this.buttonServoOn_Click);
            // 
            // buttonServoOff
            // 
            this.buttonServoOff.Location = new System.Drawing.Point(120, 16);
            this.buttonServoOff.Name = "buttonServoOff";
            this.buttonServoOff.Size = new System.Drawing.Size(88, 23);
            this.buttonServoOff.TabIndex = 1;
            this.buttonServoOff.Text = "SERVO OFF";
            this.buttonServoOff.UseVisualStyleBackColor = true;
            this.buttonServoOff.Click += new System.EventHandler(this.buttonServoOff_Click);
            // 
            // buttonWriteOffsetAngle
            // 
            this.buttonWriteOffsetAngle.Location = new System.Drawing.Point(440, 16);
            this.buttonWriteOffsetAngle.Name = "buttonWriteOffsetAngle";
            this.buttonWriteOffsetAngle.Size = new System.Drawing.Size(120, 23);
            this.buttonWriteOffsetAngle.TabIndex = 2;
            this.buttonWriteOffsetAngle.Text = "WRITE OFFSEST";
            this.buttonWriteOffsetAngle.UseVisualStyleBackColor = true;
            this.buttonWriteOffsetAngle.Click += new System.EventHandler(this.buttonWriteOffsetAngle_Click);
            // 
            // numericUpDownOffsetWaist
            // 
            this.numericUpDownOffsetWaist.Location = new System.Drawing.Point(488, 200);
            this.numericUpDownOffsetWaist.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetWaist.Name = "numericUpDownOffsetWaist";
            this.numericUpDownOffsetWaist.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownOffsetWaist.TabIndex = 3;
            this.numericUpDownOffsetWaist.ValueChanged += new System.EventHandler(this.numericUpDownOffsetWaist_ValueChanged);
            // 
            // numericUpDownOffsetLeftShoulderPitch
            // 
            this.numericUpDownOffsetLeftShoulderPitch.Location = new System.Drawing.Point(536, 80);
            this.numericUpDownOffsetLeftShoulderPitch.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetLeftShoulderPitch.Name = "numericUpDownOffsetLeftShoulderPitch";
            this.numericUpDownOffsetLeftShoulderPitch.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownOffsetLeftShoulderPitch.TabIndex = 4;
            this.numericUpDownOffsetLeftShoulderPitch.ValueChanged += new System.EventHandler(this.numericUpDownOffsetLeftShoulderPitch_ValueChanged);
            // 
            // numericUpDownOffsetLeftShoulderRoll
            // 
            this.numericUpDownOffsetLeftShoulderRoll.Location = new System.Drawing.Point(536, 120);
            this.numericUpDownOffsetLeftShoulderRoll.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetLeftShoulderRoll.Name = "numericUpDownOffsetLeftShoulderRoll";
            this.numericUpDownOffsetLeftShoulderRoll.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownOffsetLeftShoulderRoll.TabIndex = 5;
            this.numericUpDownOffsetLeftShoulderRoll.ValueChanged += new System.EventHandler(this.numericUpDownOffsetLeftShoulderRoll_ValueChanged);
            // 
            // numericUpDownOffsetLeftElbowPitch
            // 
            this.numericUpDownOffsetLeftElbowPitch.Location = new System.Drawing.Point(536, 160);
            this.numericUpDownOffsetLeftElbowPitch.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetLeftElbowPitch.Name = "numericUpDownOffsetLeftElbowPitch";
            this.numericUpDownOffsetLeftElbowPitch.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownOffsetLeftElbowPitch.TabIndex = 6;
            this.numericUpDownOffsetLeftElbowPitch.ValueChanged += new System.EventHandler(this.numericUpDownOffsetLeftElbowPitch_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "WAIST";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "LEFT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(536, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "PITCH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(536, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "ROLL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "PITCH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "PITCH";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "ROLL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "PITCH";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "RIGHT";
            // 
            // numericUpDownOffsetRightElbowPitch
            // 
            this.numericUpDownOffsetRightElbowPitch.Location = new System.Drawing.Point(440, 160);
            this.numericUpDownOffsetRightElbowPitch.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetRightElbowPitch.Name = "numericUpDownOffsetRightElbowPitch";
            this.numericUpDownOffsetRightElbowPitch.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownOffsetRightElbowPitch.TabIndex = 14;
            this.numericUpDownOffsetRightElbowPitch.ValueChanged += new System.EventHandler(this.numericUpDownOffsetRightElbowPitch_ValueChanged);
            // 
            // numericUpDownOffsetRightShoulderRoll
            // 
            this.numericUpDownOffsetRightShoulderRoll.Location = new System.Drawing.Point(440, 120);
            this.numericUpDownOffsetRightShoulderRoll.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetRightShoulderRoll.Name = "numericUpDownOffsetRightShoulderRoll";
            this.numericUpDownOffsetRightShoulderRoll.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownOffsetRightShoulderRoll.TabIndex = 13;
            this.numericUpDownOffsetRightShoulderRoll.ValueChanged += new System.EventHandler(this.numericUpDownOffsetRightShoulderRoll_ValueChanged);
            // 
            // numericUpDownOffsetRightShoulderPitch
            // 
            this.numericUpDownOffsetRightShoulderPitch.Location = new System.Drawing.Point(440, 80);
            this.numericUpDownOffsetRightShoulderPitch.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetRightShoulderPitch.Name = "numericUpDownOffsetRightShoulderPitch";
            this.numericUpDownOffsetRightShoulderPitch.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownOffsetRightShoulderPitch.TabIndex = 12;
            this.numericUpDownOffsetRightShoulderPitch.ValueChanged += new System.EventHandler(this.numericUpDownOffsetRightShoulderPitch_ValueChanged);
            // 
            // buttonFileOpen
            // 
            this.buttonFileOpen.Location = new System.Drawing.Point(224, 16);
            this.buttonFileOpen.Name = "buttonFileOpen";
            this.buttonFileOpen.Size = new System.Drawing.Size(88, 23);
            this.buttonFileOpen.TabIndex = 19;
            this.buttonFileOpen.Text = "FILE OPEN";
            this.buttonFileOpen.UseVisualStyleBackColor = true;
            this.buttonFileOpen.Click += new System.EventHandler(this.buttonFileOpen_Click);
            // 
            // buttonFileSave
            // 
            this.buttonFileSave.Location = new System.Drawing.Point(328, 16);
            this.buttonFileSave.Name = "buttonFileSave";
            this.buttonFileSave.Size = new System.Drawing.Size(88, 23);
            this.buttonFileSave.TabIndex = 20;
            this.buttonFileSave.Text = "FILE SAVE";
            this.buttonFileSave.UseVisualStyleBackColor = true;
            this.buttonFileSave.Click += new System.EventHandler(this.buttonFileSave_Click);
            // 
            // dataGridViewMotion
            // 
            this.dataGridViewMotion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMotion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMotion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.parametric,
            this.time,
            this.waist,
            this.left_shoulder_pitch,
            this.left_shoulder_roll,
            this.left_elbow_pitch,
            this.right_shoulder_pitch,
            this.right_shoulder_roll,
            this.right_elbow_pitch});
            this.dataGridViewMotion.Location = new System.Drawing.Point(0, 304);
            this.dataGridViewMotion.Name = "dataGridViewMotion";
            this.dataGridViewMotion.RowTemplate.Height = 21;
            this.dataGridViewMotion.Size = new System.Drawing.Size(640, 296);
            this.dataGridViewMotion.TabIndex = 26;
            this.dataGridViewMotion.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMotion_CellValueChanged);
            // 
            // no
            // 
            this.no.HeaderText = "no";
            this.no.Name = "no";
            // 
            // parametric
            // 
            this.parametric.HeaderText = "parametric";
            this.parametric.Name = "parametric";
            // 
            // time
            // 
            this.time.HeaderText = "time";
            this.time.Name = "time";
            // 
            // waist
            // 
            this.waist.HeaderText = "waist";
            this.waist.Name = "waist";
            // 
            // left_shoulder_pitch
            // 
            this.left_shoulder_pitch.HeaderText = "ls_pitch";
            this.left_shoulder_pitch.Name = "left_shoulder_pitch";
            // 
            // left_shoulder_roll
            // 
            this.left_shoulder_roll.HeaderText = "ls_roll";
            this.left_shoulder_roll.Name = "left_shoulder_roll";
            // 
            // left_elbow_pitch
            // 
            this.left_elbow_pitch.HeaderText = "le_pitch";
            this.left_elbow_pitch.Name = "left_elbow_pitch";
            // 
            // right_shoulder_pitch
            // 
            this.right_shoulder_pitch.HeaderText = "rs_pitch";
            this.right_shoulder_pitch.Name = "right_shoulder_pitch";
            // 
            // right_shoulder_roll
            // 
            this.right_shoulder_roll.HeaderText = "rs_roll";
            this.right_shoulder_roll.Name = "right_shoulder_roll";
            // 
            // right_elbow_pitch
            // 
            this.right_elbow_pitch.HeaderText = "re_pitch";
            this.right_elbow_pitch.Name = "right_elbow_pitch";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 12);
            this.label10.TabIndex = 42;
            this.label10.Text = "PITCH";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 12);
            this.label11.TabIndex = 41;
            this.label11.Text = "ROLL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 12);
            this.label12.TabIndex = 40;
            this.label12.Text = "PITCH";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 12);
            this.label13.TabIndex = 39;
            this.label13.Text = "RIGHT";
            // 
            // numericUpDownRightElbowPitch
            // 
            this.numericUpDownRightElbowPitch.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRightElbowPitch.Location = new System.Drawing.Point(24, 168);
            this.numericUpDownRightElbowPitch.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRightElbowPitch.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownRightElbowPitch.Name = "numericUpDownRightElbowPitch";
            this.numericUpDownRightElbowPitch.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownRightElbowPitch.TabIndex = 38;
            this.numericUpDownRightElbowPitch.ValueChanged += new System.EventHandler(this.numericUpDownRightElbowPitch_ValueChanged);
            // 
            // numericUpDownRightShoulderRoll
            // 
            this.numericUpDownRightShoulderRoll.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRightShoulderRoll.Location = new System.Drawing.Point(24, 128);
            this.numericUpDownRightShoulderRoll.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRightShoulderRoll.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownRightShoulderRoll.Name = "numericUpDownRightShoulderRoll";
            this.numericUpDownRightShoulderRoll.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownRightShoulderRoll.TabIndex = 37;
            this.numericUpDownRightShoulderRoll.ValueChanged += new System.EventHandler(this.numericUpDownRightShoulderRoll_ValueChanged);
            // 
            // numericUpDownRightShoulderPitch
            // 
            this.numericUpDownRightShoulderPitch.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRightShoulderPitch.Location = new System.Drawing.Point(24, 88);
            this.numericUpDownRightShoulderPitch.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRightShoulderPitch.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownRightShoulderPitch.Name = "numericUpDownRightShoulderPitch";
            this.numericUpDownRightShoulderPitch.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownRightShoulderPitch.TabIndex = 36;
            this.numericUpDownRightShoulderPitch.ValueChanged += new System.EventHandler(this.numericUpDownRightShoulderPitch_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(128, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 12);
            this.label14.TabIndex = 35;
            this.label14.Text = "PITCH";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(128, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 12);
            this.label15.TabIndex = 34;
            this.label15.Text = "ROLL";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(128, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 12);
            this.label16.TabIndex = 33;
            this.label16.Text = "PITCH";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(128, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 12);
            this.label17.TabIndex = 32;
            this.label17.Text = "LEFT";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(72, 192);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "WAIST";
            // 
            // numericUpDownLeftElbowPitch
            // 
            this.numericUpDownLeftElbowPitch.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLeftElbowPitch.Location = new System.Drawing.Point(128, 168);
            this.numericUpDownLeftElbowPitch.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownLeftElbowPitch.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownLeftElbowPitch.Name = "numericUpDownLeftElbowPitch";
            this.numericUpDownLeftElbowPitch.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownLeftElbowPitch.TabIndex = 30;
            this.numericUpDownLeftElbowPitch.ValueChanged += new System.EventHandler(this.numericUpDownLeftElbowPitch_ValueChanged);
            // 
            // numericUpDownLeftShoulderRoll
            // 
            this.numericUpDownLeftShoulderRoll.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLeftShoulderRoll.Location = new System.Drawing.Point(128, 128);
            this.numericUpDownLeftShoulderRoll.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownLeftShoulderRoll.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownLeftShoulderRoll.Name = "numericUpDownLeftShoulderRoll";
            this.numericUpDownLeftShoulderRoll.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownLeftShoulderRoll.TabIndex = 29;
            this.numericUpDownLeftShoulderRoll.ValueChanged += new System.EventHandler(this.numericUpDownLeftShoulderRoll_ValueChanged);
            // 
            // numericUpDownLeftShoulderPitch
            // 
            this.numericUpDownLeftShoulderPitch.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLeftShoulderPitch.Location = new System.Drawing.Point(128, 88);
            this.numericUpDownLeftShoulderPitch.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownLeftShoulderPitch.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownLeftShoulderPitch.Name = "numericUpDownLeftShoulderPitch";
            this.numericUpDownLeftShoulderPitch.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownLeftShoulderPitch.TabIndex = 28;
            this.numericUpDownLeftShoulderPitch.ValueChanged += new System.EventHandler(this.numericUpDownLeftShoulderPitch_ValueChanged);
            // 
            // numericUpDownWaist
            // 
            this.numericUpDownWaist.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWaist.Location = new System.Drawing.Point(72, 208);
            this.numericUpDownWaist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownWaist.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownWaist.Name = "numericUpDownWaist";
            this.numericUpDownWaist.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownWaist.TabIndex = 27;
            this.numericUpDownWaist.ValueChanged += new System.EventHandler(this.numericUpDownWaist_ValueChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(8, 272);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 23);
            this.buttonAdd.TabIndex = 43;
            this.buttonAdd.Text = "ADD";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 240);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 12);
            this.label19.TabIndex = 44;
            this.label19.Text = "PERIOD";
            // 
            // numericUpDownPeriod
            // 
            this.numericUpDownPeriod.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownPeriod.Location = new System.Drawing.Point(72, 240);
            this.numericUpDownPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPeriod.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownPeriod.Name = "numericUpDownPeriod";
            this.numericUpDownPeriod.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownPeriod.TabIndex = 45;
            this.numericUpDownPeriod.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(160, 248);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 12);
            this.label20.TabIndex = 46;
            this.label20.Text = "ms";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(112, 272);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(88, 23);
            this.buttonInsert.TabIndex = 47;
            this.buttonInsert.Text = "INSERT";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonErase
            // 
            this.buttonErase.Location = new System.Drawing.Point(216, 272);
            this.buttonErase.Name = "buttonErase";
            this.buttonErase.Size = new System.Drawing.Size(88, 23);
            this.buttonErase.TabIndex = 48;
            this.buttonErase.Text = "ERASE";
            this.buttonErase.UseVisualStyleBackColor = true;
            this.buttonErase.Click += new System.EventHandler(this.buttonErase_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(440, 272);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(88, 23);
            this.buttonMove.TabIndex = 49;
            this.buttonMove.Text = "MOVE";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(544, 272);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(88, 23);
            this.buttonPlay.TabIndex = 50;
            this.buttonPlay.Text = "PLAY";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // checkBoxTestMode
            // 
            this.checkBoxTestMode.AutoSize = true;
            this.checkBoxTestMode.Location = new System.Drawing.Point(544, 248);
            this.checkBoxTestMode.Name = "checkBoxTestMode";
            this.checkBoxTestMode.Size = new System.Drawing.Size(88, 16);
            this.checkBoxTestMode.TabIndex = 51;
            this.checkBoxTestMode.Text = "TEST MODE";
            this.checkBoxTestMode.UseVisualStyleBackColor = true;
            this.checkBoxTestMode.CheckedChanged += new System.EventHandler(this.checkBoxTestMode_CheckedChanged);
            // 
            // checkBoxWaist
            // 
            this.checkBoxWaist.AutoSize = true;
            this.checkBoxWaist.Location = new System.Drawing.Point(56, 208);
            this.checkBoxWaist.Name = "checkBoxWaist";
            this.checkBoxWaist.Size = new System.Drawing.Size(15, 14);
            this.checkBoxWaist.TabIndex = 52;
            this.checkBoxWaist.UseVisualStyleBackColor = true;
            this.checkBoxWaist.CheckedChanged += new System.EventHandler(this.checkBoxWaist_CheckedChanged);
            // 
            // checkBoxRightShoulderPitch
            // 
            this.checkBoxRightShoulderPitch.AutoSize = true;
            this.checkBoxRightShoulderPitch.Location = new System.Drawing.Point(8, 88);
            this.checkBoxRightShoulderPitch.Name = "checkBoxRightShoulderPitch";
            this.checkBoxRightShoulderPitch.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRightShoulderPitch.TabIndex = 53;
            this.checkBoxRightShoulderPitch.UseVisualStyleBackColor = true;
            this.checkBoxRightShoulderPitch.CheckedChanged += new System.EventHandler(this.checkBoxRightShoulderPitch_CheckedChanged);
            // 
            // checkBoxRightShoulderRoll
            // 
            this.checkBoxRightShoulderRoll.AutoSize = true;
            this.checkBoxRightShoulderRoll.Location = new System.Drawing.Point(8, 128);
            this.checkBoxRightShoulderRoll.Name = "checkBoxRightShoulderRoll";
            this.checkBoxRightShoulderRoll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRightShoulderRoll.TabIndex = 54;
            this.checkBoxRightShoulderRoll.UseVisualStyleBackColor = true;
            this.checkBoxRightShoulderRoll.CheckedChanged += new System.EventHandler(this.checkBoxRightShoulderRoll_CheckedChanged);
            // 
            // checkBoxRightElbowPitch
            // 
            this.checkBoxRightElbowPitch.AutoSize = true;
            this.checkBoxRightElbowPitch.Location = new System.Drawing.Point(8, 168);
            this.checkBoxRightElbowPitch.Name = "checkBoxRightElbowPitch";
            this.checkBoxRightElbowPitch.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRightElbowPitch.TabIndex = 55;
            this.checkBoxRightElbowPitch.UseVisualStyleBackColor = true;
            this.checkBoxRightElbowPitch.CheckedChanged += new System.EventHandler(this.checkBoxRightElbowPitch_CheckedChanged);
            // 
            // checkBoxLeftShoulderPitch
            // 
            this.checkBoxLeftShoulderPitch.AutoSize = true;
            this.checkBoxLeftShoulderPitch.Location = new System.Drawing.Point(112, 88);
            this.checkBoxLeftShoulderPitch.Name = "checkBoxLeftShoulderPitch";
            this.checkBoxLeftShoulderPitch.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLeftShoulderPitch.TabIndex = 56;
            this.checkBoxLeftShoulderPitch.UseVisualStyleBackColor = true;
            this.checkBoxLeftShoulderPitch.CheckedChanged += new System.EventHandler(this.checkBoxLeftShoulderPitch_CheckedChanged);
            // 
            // checkBoxLeftShoulderRoll
            // 
            this.checkBoxLeftShoulderRoll.AutoSize = true;
            this.checkBoxLeftShoulderRoll.Location = new System.Drawing.Point(112, 128);
            this.checkBoxLeftShoulderRoll.Name = "checkBoxLeftShoulderRoll";
            this.checkBoxLeftShoulderRoll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLeftShoulderRoll.TabIndex = 57;
            this.checkBoxLeftShoulderRoll.UseVisualStyleBackColor = true;
            this.checkBoxLeftShoulderRoll.CheckedChanged += new System.EventHandler(this.checkBoxLeftShoulderRoll_CheckedChanged);
            // 
            // checkBoxLeftElbowPitch
            // 
            this.checkBoxLeftElbowPitch.AutoSize = true;
            this.checkBoxLeftElbowPitch.Location = new System.Drawing.Point(112, 168);
            this.checkBoxLeftElbowPitch.Name = "checkBoxLeftElbowPitch";
            this.checkBoxLeftElbowPitch.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLeftElbowPitch.TabIndex = 58;
            this.checkBoxLeftElbowPitch.UseVisualStyleBackColor = true;
            this.checkBoxLeftElbowPitch.CheckedChanged += new System.EventHandler(this.checkBoxLeftElbowPitch_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(344, 272);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 59;
            this.buttonDown.Text = "DOWN";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(344, 240);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 60;
            this.buttonUp.Text = "UP";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(232, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 12);
            this.label21.TabIndex = 61;
            this.label21.Text = "LEFT";
            // 
            // numericUpDownLift
            // 
            this.numericUpDownLift.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownLift.Location = new System.Drawing.Point(232, 88);
            this.numericUpDownLift.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownLift.Name = "numericUpDownLift";
            this.numericUpDownLift.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownLift.TabIndex = 62;
            this.numericUpDownLift.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonLiftUp
            // 
            this.buttonLiftUp.Location = new System.Drawing.Point(232, 120);
            this.buttonLiftUp.Name = "buttonLiftUp";
            this.buttonLiftUp.Size = new System.Drawing.Size(75, 23);
            this.buttonLiftUp.TabIndex = 63;
            this.buttonLiftUp.Text = "UP";
            this.buttonLiftUp.UseVisualStyleBackColor = true;
            this.buttonLiftUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLiftUp_MouseDown);
            this.buttonLiftUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonLiftUp_MouseUp);
            // 
            // buttonLiftDown
            // 
            this.buttonLiftDown.Location = new System.Drawing.Point(328, 120);
            this.buttonLiftDown.Name = "buttonLiftDown";
            this.buttonLiftDown.Size = new System.Drawing.Size(75, 23);
            this.buttonLiftDown.TabIndex = 64;
            this.buttonLiftDown.Text = "DOWN";
            this.buttonLiftDown.UseVisualStyleBackColor = true;
            this.buttonLiftDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLiftDown_MouseDown);
            this.buttonLiftDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonLiftDown_MouseUp);
            // 
            // checkBoxLiftBrake
            // 
            this.checkBoxLiftBrake.AutoSize = true;
            this.checkBoxLiftBrake.Checked = true;
            this.checkBoxLiftBrake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLiftBrake.Location = new System.Drawing.Point(328, 88);
            this.checkBoxLiftBrake.Name = "checkBoxLiftBrake";
            this.checkBoxLiftBrake.Size = new System.Drawing.Size(62, 16);
            this.checkBoxLiftBrake.TabIndex = 65;
            this.checkBoxLiftBrake.Text = "BRAKE";
            this.checkBoxLiftBrake.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 603);
            this.Controls.Add(this.checkBoxLiftBrake);
            this.Controls.Add(this.buttonLiftDown);
            this.Controls.Add(this.buttonLiftUp);
            this.Controls.Add(this.numericUpDownLift);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.checkBoxLeftElbowPitch);
            this.Controls.Add(this.checkBoxLeftShoulderRoll);
            this.Controls.Add(this.checkBoxLeftShoulderPitch);
            this.Controls.Add(this.checkBoxRightElbowPitch);
            this.Controls.Add(this.checkBoxRightShoulderRoll);
            this.Controls.Add(this.checkBoxRightShoulderPitch);
            this.Controls.Add(this.checkBoxWaist);
            this.Controls.Add(this.checkBoxTestMode);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonErase);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.numericUpDownPeriod);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpDownRightElbowPitch);
            this.Controls.Add(this.numericUpDownRightShoulderRoll);
            this.Controls.Add(this.numericUpDownRightShoulderPitch);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.numericUpDownLeftElbowPitch);
            this.Controls.Add(this.numericUpDownLeftShoulderRoll);
            this.Controls.Add(this.numericUpDownLeftShoulderPitch);
            this.Controls.Add(this.numericUpDownWaist);
            this.Controls.Add(this.dataGridViewMotion);
            this.Controls.Add(this.buttonFileSave);
            this.Controls.Add(this.buttonFileOpen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDownOffsetRightElbowPitch);
            this.Controls.Add(this.numericUpDownOffsetRightShoulderRoll);
            this.Controls.Add(this.numericUpDownOffsetRightShoulderPitch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownOffsetLeftElbowPitch);
            this.Controls.Add(this.numericUpDownOffsetLeftShoulderRoll);
            this.Controls.Add(this.numericUpDownOffsetLeftShoulderPitch);
            this.Controls.Add(this.numericUpDownOffsetWaist);
            this.Controls.Add(this.buttonWriteOffsetAngle);
            this.Controls.Add(this.buttonServoOff);
            this.Controls.Add(this.buttonServoOn);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "MotionControl";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetWaist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetLeftShoulderPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetLeftShoulderRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetLeftElbowPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetRightElbowPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetRightShoulderRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetRightShoulderPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightElbowPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightShoulderRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightShoulderPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftElbowPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftShoulderRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftShoulderPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWaist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLift)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonServoOn;
        private System.Windows.Forms.Button buttonServoOff;
        private System.Windows.Forms.Button buttonWriteOffsetAngle;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetWaist;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetLeftShoulderPitch;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetLeftShoulderRoll;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetLeftElbowPitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetRightElbowPitch;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetRightShoulderRoll;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetRightShoulderPitch;
        private System.Windows.Forms.Button buttonFileOpen;
        private System.Windows.Forms.Button buttonFileSave;
        private System.Windows.Forms.DataGridView dataGridViewMotion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDownRightElbowPitch;
        private System.Windows.Forms.NumericUpDown numericUpDownRightShoulderRoll;
        private System.Windows.Forms.NumericUpDown numericUpDownRightShoulderPitch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDownLeftElbowPitch;
        private System.Windows.Forms.NumericUpDown numericUpDownLeftShoulderRoll;
        private System.Windows.Forms.NumericUpDown numericUpDownLeftShoulderPitch;
        private System.Windows.Forms.NumericUpDown numericUpDownWaist;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numericUpDownPeriod;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn parametric;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn waist;
        private System.Windows.Forms.DataGridViewTextBoxColumn left_shoulder_pitch;
        private System.Windows.Forms.DataGridViewTextBoxColumn left_shoulder_roll;
        private System.Windows.Forms.DataGridViewTextBoxColumn left_elbow_pitch;
        private System.Windows.Forms.DataGridViewTextBoxColumn right_shoulder_pitch;
        private System.Windows.Forms.DataGridViewTextBoxColumn right_shoulder_roll;
        private System.Windows.Forms.DataGridViewTextBoxColumn right_elbow_pitch;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonErase;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.CheckBox checkBoxTestMode;
        private System.Windows.Forms.CheckBox checkBoxWaist;
        private System.Windows.Forms.CheckBox checkBoxRightShoulderPitch;
        private System.Windows.Forms.CheckBox checkBoxRightShoulderRoll;
        private System.Windows.Forms.CheckBox checkBoxRightElbowPitch;
        private System.Windows.Forms.CheckBox checkBoxLeftShoulderPitch;
        private System.Windows.Forms.CheckBox checkBoxLeftShoulderRoll;
        private System.Windows.Forms.CheckBox checkBoxLeftElbowPitch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numericUpDownLift;
        private System.Windows.Forms.Button buttonLiftUp;
        private System.Windows.Forms.Button buttonLiftDown;
        private System.Windows.Forms.CheckBox checkBoxLiftBrake;
    }
}

