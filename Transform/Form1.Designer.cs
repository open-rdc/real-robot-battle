namespace Transform
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
            this.checkBoxRRBservoON = new System.Windows.Forms.CheckBox();
            this.checkBoxFUTABAservoON = new System.Windows.Forms.CheckBox();
            this.Transform = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxBrake = new System.Windows.Forms.CheckBox();
            this.checkBoxLiftLock = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxSquence = new System.Windows.Forms.ComboBox();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonDo = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Frontlight = new System.Windows.Forms.Button();
            this.Matrix = new System.Windows.Forms.Button();
            this.Smoke = new System.Windows.Forms.Button();
            this.HeadLight = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxRRBservoON
            // 
            this.checkBoxRRBservoON.AutoSize = true;
            this.checkBoxRRBservoON.Location = new System.Drawing.Point(13, 13);
            this.checkBoxRRBservoON.Name = "checkBoxRRBservoON";
            this.checkBoxRRBservoON.Size = new System.Drawing.Size(92, 16);
            this.checkBoxRRBservoON.TabIndex = 0;
            this.checkBoxRRBservoON.Text = "RRBservoON";
            this.checkBoxRRBservoON.UseVisualStyleBackColor = true;
            this.checkBoxRRBservoON.CheckedChanged += new System.EventHandler(this.checkBoxRRBservoON_CheckedChanged);
            // 
            // checkBoxFUTABAservoON
            // 
            this.checkBoxFUTABAservoON.AutoSize = true;
            this.checkBoxFUTABAservoON.Location = new System.Drawing.Point(13, 36);
            this.checkBoxFUTABAservoON.Name = "checkBoxFUTABAservoON";
            this.checkBoxFUTABAservoON.Size = new System.Drawing.Size(114, 16);
            this.checkBoxFUTABAservoON.TabIndex = 1;
            this.checkBoxFUTABAservoON.Text = "FUTABAservoON";
            this.checkBoxFUTABAservoON.UseVisualStyleBackColor = true;
            this.checkBoxFUTABAservoON.CheckedChanged += new System.EventHandler(this.checkBoxFUTABAservoON_CheckedChanged);
            // 
            // Transform
            // 
            this.Transform.Location = new System.Drawing.Point(13, 59);
            this.Transform.Name = "Transform";
            this.Transform.Size = new System.Drawing.Size(75, 23);
            this.Transform.TabIndex = 2;
            this.Transform.Text = "Transform";
            this.Transform.UseVisualStyleBackColor = true;
            this.Transform.Visible = false;
            this.Transform.Click += new System.EventHandler(this.Transform_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxBrake
            // 
            this.checkBoxBrake.AutoSize = true;
            this.checkBoxBrake.Checked = true;
            this.checkBoxBrake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBrake.Location = new System.Drawing.Point(112, 12);
            this.checkBoxBrake.Name = "checkBoxBrake";
            this.checkBoxBrake.Size = new System.Drawing.Size(54, 16);
            this.checkBoxBrake.TabIndex = 3;
            this.checkBoxBrake.Text = "Brake";
            this.checkBoxBrake.UseVisualStyleBackColor = true;
            // 
            // checkBoxLiftLock
            // 
            this.checkBoxLiftLock.AutoSize = true;
            this.checkBoxLiftLock.Checked = true;
            this.checkBoxLiftLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLiftLock.Location = new System.Drawing.Point(173, 11);
            this.checkBoxLiftLock.Name = "checkBoxLiftLock";
            this.checkBoxLiftLock.Size = new System.Drawing.Size(65, 16);
            this.checkBoxLiftLock.TabIndex = 4;
            this.checkBoxLiftLock.Text = "LiftLock";
            this.checkBoxLiftLock.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(16, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 88);
            this.button1.TabIndex = 5;
            this.button1.Text = "トランスフォーム一連";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxSquence
            // 
            this.comboBoxSquence.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxSquence.FormattingEnabled = true;
            this.comboBoxSquence.Items.AddRange(new object[] {
            "ヘッドライトON",
            "前進",
            "スチーム",
            "リフト",
            "バンパー稼動",
            "肩が出る",
            "手が出る",
            "頭が出る",
            "眼が光る",
            "スチーム",
            "移動",
            "ポージング"});
            this.comboBoxSquence.Location = new System.Drawing.Point(16, 224);
            this.comboBoxSquence.Name = "comboBoxSquence";
            this.comboBoxSquence.Size = new System.Drawing.Size(256, 32);
            this.comboBoxSquence.TabIndex = 6;
            this.comboBoxSquence.Visible = false;
            // 
            // buttonUp
            // 
            this.buttonUp.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUp.Location = new System.Drawing.Point(160, 264);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(112, 32);
            this.buttonUp.TabIndex = 7;
            this.buttonUp.Text = "UP";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Visible = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonDown.Location = new System.Drawing.Point(160, 304);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(112, 32);
            this.buttonDown.TabIndex = 8;
            this.buttonDown.Text = "DOWN";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Visible = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonDo
            // 
            this.buttonDo.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonDo.Location = new System.Drawing.Point(16, 264);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(112, 32);
            this.buttonDo.TabIndex = 11;
            this.buttonDo.Text = "DO";
            this.buttonDo.UseVisualStyleBackColor = true;
            this.buttonDo.Visible = false;
            this.buttonDo.Click += new System.EventHandler(this.buttonDo_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Frontlight
            // 
            this.Frontlight.Location = new System.Drawing.Point(173, 58);
            this.Frontlight.Name = "Frontlight";
            this.Frontlight.Size = new System.Drawing.Size(75, 23);
            this.Frontlight.TabIndex = 6;
            this.Frontlight.Text = "フロントライト";
            this.Frontlight.UseVisualStyleBackColor = true;
            this.Frontlight.Click += new System.EventHandler(this.Frontlight_Click);
            // 
            // Matrix
            // 
            this.Matrix.Location = new System.Drawing.Point(173, 88);
            this.Matrix.Name = "Matrix";
            this.Matrix.Size = new System.Drawing.Size(75, 23);
            this.Matrix.TabIndex = 7;
            this.Matrix.Text = "マトリクス";
            this.Matrix.UseVisualStyleBackColor = true;
            this.Matrix.Click += new System.EventHandler(this.Matrix_Click);
            // 
            // Smoke
            // 
            this.Smoke.Location = new System.Drawing.Point(173, 118);
            this.Smoke.Name = "Smoke";
            this.Smoke.Size = new System.Drawing.Size(75, 23);
            this.Smoke.TabIndex = 8;
            this.Smoke.Text = "スモーク";
            this.Smoke.UseVisualStyleBackColor = true;
            this.Smoke.Click += new System.EventHandler(this.Smoke_Click);
            // 
            // HeadLight
            // 
            this.HeadLight.Location = new System.Drawing.Point(173, 147);
            this.HeadLight.Name = "HeadLight";
            this.HeadLight.Size = new System.Drawing.Size(75, 23);
            this.HeadLight.TabIndex = 9;
            this.HeadLight.Text = "ヘッドライト";
            this.HeadLight.UseVisualStyleBackColor = true;
            this.HeadLight.Click += new System.EventHandler(this.HeadLight_Click);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(24, 376);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(64, 19);
            this.textBoxX.TabIndex = 12;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(120, 376);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(64, 19);
            this.textBoxY.TabIndex = 13;
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(216, 376);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(64, 19);
            this.textBoxZ.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "z";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 398);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.buttonDo);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.comboBoxSquence);
            this.Controls.Add(this.HeadLight);
            this.Controls.Add(this.Smoke);
            this.Controls.Add(this.Matrix);
            this.Controls.Add(this.Frontlight);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxLiftLock);
            this.Controls.Add(this.checkBoxBrake);
            this.Controls.Add(this.Transform);
            this.Controls.Add(this.checkBoxFUTABAservoON);
            this.Controls.Add(this.checkBoxRRBservoON);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Transform";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxRRBservoON;
        private System.Windows.Forms.CheckBox checkBoxFUTABAservoON;
        private System.Windows.Forms.Button Transform;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxBrake;
        private System.Windows.Forms.CheckBox checkBoxLiftLock;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.ComboBox comboBoxSquence;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.Timer timer2;

        private System.Windows.Forms.Button Frontlight;
        private System.Windows.Forms.Button Matrix;
        private System.Windows.Forms.Button Smoke;
        private System.Windows.Forms.Button HeadLight;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

