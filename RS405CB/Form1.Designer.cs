namespace RS405CB
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
            this.ServoOn = new System.Windows.Forms.Button();
            this.ServoOff = new System.Windows.Forms.Button();
            this.Front = new System.Windows.Forms.Button();
            this.Shoulder = new System.Windows.Forms.Button();
            this.Bumper = new System.Windows.Forms.Button();
            this.Sidewheel = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HeadButton1 = new System.Windows.Forms.Button();
            this.HeadButton2 = new System.Windows.Forms.Button();
            this.Allgo2 = new System.Windows.Forms.Button();
            this.Allback2 = new System.Windows.Forms.Button();
            this.Launcherbutton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.TiltangleLabel = new System.Windows.Forms.Label();
            this.Tiltfront = new System.Windows.Forms.Button();
            this.Handneck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // ServoOn
            // 
            this.ServoOn.Cursor = System.Windows.Forms.Cursors.Default;
            this.ServoOn.Location = new System.Drawing.Point(12, 12);
            this.ServoOn.Name = "ServoOn";
            this.ServoOn.Size = new System.Drawing.Size(131, 23);
            this.ServoOn.TabIndex = 1;
            this.ServoOn.Text = "SERVO ON";
            this.ServoOn.UseVisualStyleBackColor = true;
            this.ServoOn.Click += new System.EventHandler(this.ServoOn_Click);
            // 
            // ServoOff
            // 
            this.ServoOff.Location = new System.Drawing.Point(12, 56);
            this.ServoOff.Name = "ServoOff";
            this.ServoOff.Size = new System.Drawing.Size(131, 23);
            this.ServoOff.TabIndex = 2;
            this.ServoOff.Text = "SERVO OFF";
            this.ServoOff.UseVisualStyleBackColor = true;
            this.ServoOff.Click += new System.EventHandler(this.ServoOff_Click);
            // 
            // Front
            // 
            this.Front.Location = new System.Drawing.Point(74, 120);
            this.Front.Name = "Front";
            this.Front.Size = new System.Drawing.Size(131, 23);
            this.Front.TabIndex = 5;
            this.Front.Text = "FRONT OPEN";
            this.Front.UseVisualStyleBackColor = true;
            this.Front.Click += new System.EventHandler(this.Front_Click);
            // 
            // Shoulder
            // 
            this.Shoulder.Location = new System.Drawing.Point(74, 180);
            this.Shoulder.Name = "Shoulder";
            this.Shoulder.Size = new System.Drawing.Size(131, 23);
            this.Shoulder.TabIndex = 7;
            this.Shoulder.Text = "Shoulder Expand";
            this.Shoulder.UseVisualStyleBackColor = true;
            this.Shoulder.Click += new System.EventHandler(this.Shoulder_Click);
            // 
            // Bumper
            // 
            this.Bumper.Location = new System.Drawing.Point(74, 240);
            this.Bumper.Name = "Bumper";
            this.Bumper.Size = new System.Drawing.Size(131, 23);
            this.Bumper.TabIndex = 10;
            this.Bumper.Text = "Bumper Up";
            this.Bumper.UseVisualStyleBackColor = true;
            this.Bumper.Click += new System.EventHandler(this.Bumper_Click);
            // 
            // Sidewheel
            // 
            this.Sidewheel.Location = new System.Drawing.Point(74, 300);
            this.Sidewheel.Name = "Sidewheel";
            this.Sidewheel.Size = new System.Drawing.Size(131, 23);
            this.Sidewheel.TabIndex = 11;
            this.Sidewheel.Text = "SideWheel Up";
            this.Sidewheel.UseVisualStyleBackColor = true;
            this.Sidewheel.Click += new System.EventHandler(this.Sidewheel_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(824, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(296, 108);
            this.CloseButton.TabIndex = 12;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HeadButton1
            // 
            this.HeadButton1.Location = new System.Drawing.Point(74, 360);
            this.HeadButton1.Name = "HeadButton1";
            this.HeadButton1.Size = new System.Drawing.Size(131, 23);
            this.HeadButton1.TabIndex = 14;
            this.HeadButton1.Text = "HEAD UP";
            this.HeadButton1.UseVisualStyleBackColor = true;
            this.HeadButton1.Click += new System.EventHandler(this.HeadButton1_Click);
            // 
            // HeadButton2
            // 
            this.HeadButton2.Location = new System.Drawing.Point(74, 420);
            this.HeadButton2.Name = "HeadButton2";
            this.HeadButton2.Size = new System.Drawing.Size(131, 23);
            this.HeadButton2.TabIndex = 15;
            this.HeadButton2.Text = "HEAD DOWN";
            this.HeadButton2.UseVisualStyleBackColor = true;
            this.HeadButton2.Click += new System.EventHandler(this.HeadButton2_Click);
            // 
            // Allgo2
            // 
            this.Allgo2.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Allgo2.Location = new System.Drawing.Point(282, 35);
            this.Allgo2.Name = "Allgo2";
            this.Allgo2.Size = new System.Drawing.Size(442, 215);
            this.Allgo2.TabIndex = 16;
            this.Allgo2.Text = "ALL GO!";
            this.Allgo2.UseVisualStyleBackColor = true;
            this.Allgo2.Click += new System.EventHandler(this.Allgo2_Click);
            // 
            // Allback2
            // 
            this.Allback2.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Allback2.Location = new System.Drawing.Point(282, 287);
            this.Allback2.Name = "Allback2";
            this.Allback2.Size = new System.Drawing.Size(442, 215);
            this.Allback2.TabIndex = 17;
            this.Allback2.Text = "ALL BACK!";
            this.Allback2.UseVisualStyleBackColor = true;
            this.Allback2.Click += new System.EventHandler(this.Allback2_Click);
            // 
            // Launcherbutton
            // 
            this.Launcherbutton.Font = new System.Drawing.Font("MS UI Gothic", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Launcherbutton.Location = new System.Drawing.Point(758, 161);
            this.Launcherbutton.Name = "Launcherbutton";
            this.Launcherbutton.Size = new System.Drawing.Size(362, 212);
            this.Launcherbutton.TabIndex = 18;
            this.Launcherbutton.Text = "Launcher";
            this.Launcherbutton.UseVisualStyleBackColor = true;
            this.Launcherbutton.Click += new System.EventHandler(this.Launcherbutton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(758, 426);
            this.trackBar1.Maximum = 160;
            this.trackBar1.Minimum = -160;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(362, 45);
            this.trackBar1.TabIndex = 19;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // TiltangleLabel
            // 
            this.TiltangleLabel.AutoSize = true;
            this.TiltangleLabel.Location = new System.Drawing.Point(918, 398);
            this.TiltangleLabel.Name = "TiltangleLabel";
            this.TiltangleLabel.Size = new System.Drawing.Size(19, 12);
            this.TiltangleLabel.TabIndex = 20;
            this.TiltangleLabel.Text = "tilt";
            // 
            // Tiltfront
            // 
            this.Tiltfront.Location = new System.Drawing.Point(887, 470);
            this.Tiltfront.Name = "Tiltfront";
            this.Tiltfront.Size = new System.Drawing.Size(100, 35);
            this.Tiltfront.TabIndex = 21;
            this.Tiltfront.Text = "Front";
            this.Tiltfront.UseVisualStyleBackColor = true;
            this.Tiltfront.Click += new System.EventHandler(this.Tiltfront_Click);
            // 
            // Handneck
            // 
            this.Handneck.Location = new System.Drawing.Point(74, 480);
            this.Handneck.Name = "Handneck";
            this.Handneck.Size = new System.Drawing.Size(131, 23);
            this.Handneck.TabIndex = 22;
            this.Handneck.Text = "Handneck Open";
            this.Handneck.UseVisualStyleBackColor = true;
            this.Handneck.Click += new System.EventHandler(this.Handneck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(1163, 511);
            this.Controls.Add(this.Handneck);
            this.Controls.Add(this.Tiltfront);
            this.Controls.Add(this.TiltangleLabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Launcherbutton);
            this.Controls.Add(this.Allback2);
            this.Controls.Add(this.Allgo2);
            this.Controls.Add(this.HeadButton2);
            this.Controls.Add(this.HeadButton1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.Sidewheel);
            this.Controls.Add(this.Bumper);
            this.Controls.Add(this.Shoulder);
            this.Controls.Add(this.Front);
            this.Controls.Add(this.ServoOff);
            this.Controls.Add(this.ServoOn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ServoOn;
        private System.Windows.Forms.Button ServoOff;
        private System.Windows.Forms.Button Front;
        private System.Windows.Forms.Button Shoulder;
        private System.Windows.Forms.Button Bumper;
        private System.Windows.Forms.Button Sidewheel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button HeadButton1;
        private System.Windows.Forms.Button HeadButton2;
        private System.Windows.Forms.Button Allgo2;
        private System.Windows.Forms.Button Allback2;
        private System.Windows.Forms.Button Launcherbutton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label TiltangleLabel;
        private System.Windows.Forms.Button Tiltfront;
        private System.Windows.Forms.Button Handneck;
    }
}

