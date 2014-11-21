namespace SimpleBattle
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
            this.checkBoxBrake = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.checkBoxServoOn = new System.Windows.Forms.CheckBox();
            this.buttonFileOpen = new System.Windows.Forms.Button();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.checkBoxTestMode = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBoxBrake
            // 
            this.checkBoxBrake.AutoSize = true;
            this.checkBoxBrake.Checked = true;
            this.checkBoxBrake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBrake.Location = new System.Drawing.Point(8, 8);
            this.checkBoxBrake.Name = "checkBoxBrake";
            this.checkBoxBrake.Size = new System.Drawing.Size(62, 16);
            this.checkBoxBrake.TabIndex = 0;
            this.checkBoxBrake.Text = "BRAKE";
            this.checkBoxBrake.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(24, 32);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 19);
            this.textBoxX.TabIndex = 1;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(24, 56);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 19);
            this.textBoxY.TabIndex = 2;
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(24, 80);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(100, 19);
            this.textBoxZ.TabIndex = 3;
            // 
            // checkBoxServoOn
            // 
            this.checkBoxServoOn.AutoSize = true;
            this.checkBoxServoOn.Location = new System.Drawing.Point(8, 112);
            this.checkBoxServoOn.Name = "checkBoxServoOn";
            this.checkBoxServoOn.Size = new System.Drawing.Size(82, 16);
            this.checkBoxServoOn.TabIndex = 4;
            this.checkBoxServoOn.Text = "SERVO ON";
            this.checkBoxServoOn.UseVisualStyleBackColor = true;
            this.checkBoxServoOn.CheckedChanged += new System.EventHandler(this.checkBoxServoOn_CheckedChanged);
            // 
            // buttonFileOpen
            // 
            this.buttonFileOpen.Location = new System.Drawing.Point(8, 136);
            this.buttonFileOpen.Name = "buttonFileOpen";
            this.buttonFileOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonFileOpen.TabIndex = 5;
            this.buttonFileOpen.Text = "FILE OPEN";
            this.buttonFileOpen.UseVisualStyleBackColor = true;
            this.buttonFileOpen.Click += new System.EventHandler(this.buttonFileOpen_Click);
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(96, 136);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(176, 19);
            this.textBoxFilename.TabIndex = 6;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(192, 168);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.Text = "PLAY";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // checkBoxTestMode
            // 
            this.checkBoxTestMode.AutoSize = true;
            this.checkBoxTestMode.Location = new System.Drawing.Point(96, 176);
            this.checkBoxTestMode.Name = "checkBoxTestMode";
            this.checkBoxTestMode.Size = new System.Drawing.Size(88, 16);
            this.checkBoxTestMode.TabIndex = 8;
            this.checkBoxTestMode.Text = "TEST MODE";
            this.checkBoxTestMode.UseVisualStyleBackColor = true;
            this.checkBoxTestMode.CheckedChanged += new System.EventHandler(this.checkBoxTestMode_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(192, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 19);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Button 1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Z";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(192, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 19);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Button 2";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(192, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 19);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "Button 3";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(192, 80);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(80, 19);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "Button 4";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 207);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxTestMode);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.textBoxFilename);
            this.Controls.Add(this.buttonFileOpen);
            this.Controls.Add(this.checkBoxServoOn);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.checkBoxBrake);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "SimpleBattleForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxBrake;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.CheckBox checkBoxServoOn;
        private System.Windows.Forms.Button buttonFileOpen;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.CheckBox checkBoxTestMode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}

