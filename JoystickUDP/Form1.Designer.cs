namespace JoystickUDP
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
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.textBoxButton0 = new System.Windows.Forms.TextBox();
            this.textBoxButton1 = new System.Windows.Forms.TextBox();
            this.textBoxButton2 = new System.Windows.Forms.TextBox();
            this.textBoxButton3 = new System.Windows.Forms.TextBox();
            this.textBoxButton4 = new System.Windows.Forms.TextBox();
            this.textBoxButton5 = new System.Windows.Forms.TextBox();
            this.textBoxButton6 = new System.Windows.Forms.TextBox();
            this.textBoxButton7 = new System.Windows.Forms.TextBox();
            this.checkBoxConnect = new System.Windows.Forms.CheckBox();
            this.timer100ms = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(8, 24);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(272, 19);
            this.textBoxAddress.TabIndex = 0;
            this.textBoxAddress.Text = "192.168.1.69";
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Z";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(24, 56);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(82, 19);
            this.textBoxX.TabIndex = 5;
            this.textBoxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(24, 80);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(82, 19);
            this.textBoxY.TabIndex = 6;
            this.textBoxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(24, 104);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(82, 19);
            this.textBoxZ.TabIndex = 7;
            this.textBoxZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxButton0
            // 
            this.textBoxButton0.Location = new System.Drawing.Point(112, 56);
            this.textBoxButton0.Name = "textBoxButton0";
            this.textBoxButton0.Size = new System.Drawing.Size(72, 19);
            this.textBoxButton0.TabIndex = 8;
            this.textBoxButton0.Text = "Button 0";
            this.textBoxButton0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxButton1
            // 
            this.textBoxButton1.Location = new System.Drawing.Point(112, 80);
            this.textBoxButton1.Name = "textBoxButton1";
            this.textBoxButton1.Size = new System.Drawing.Size(72, 19);
            this.textBoxButton1.TabIndex = 9;
            this.textBoxButton1.Text = "Button 1";
            this.textBoxButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxButton2
            // 
            this.textBoxButton2.Location = new System.Drawing.Point(112, 104);
            this.textBoxButton2.Name = "textBoxButton2";
            this.textBoxButton2.Size = new System.Drawing.Size(72, 19);
            this.textBoxButton2.TabIndex = 10;
            this.textBoxButton2.Text = "Button 2";
            this.textBoxButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxButton3
            // 
            this.textBoxButton3.Location = new System.Drawing.Point(112, 128);
            this.textBoxButton3.Name = "textBoxButton3";
            this.textBoxButton3.Size = new System.Drawing.Size(72, 19);
            this.textBoxButton3.TabIndex = 11;
            this.textBoxButton3.Text = "Button 3";
            this.textBoxButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxButton4
            // 
            this.textBoxButton4.Location = new System.Drawing.Point(192, 56);
            this.textBoxButton4.Name = "textBoxButton4";
            this.textBoxButton4.Size = new System.Drawing.Size(72, 19);
            this.textBoxButton4.TabIndex = 12;
            this.textBoxButton4.Text = "Button 4";
            this.textBoxButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxButton5
            // 
            this.textBoxButton5.Location = new System.Drawing.Point(192, 80);
            this.textBoxButton5.Name = "textBoxButton5";
            this.textBoxButton5.Size = new System.Drawing.Size(72, 19);
            this.textBoxButton5.TabIndex = 13;
            this.textBoxButton5.Text = "Button 5";
            this.textBoxButton5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxButton6
            // 
            this.textBoxButton6.Location = new System.Drawing.Point(192, 104);
            this.textBoxButton6.Name = "textBoxButton6";
            this.textBoxButton6.Size = new System.Drawing.Size(72, 19);
            this.textBoxButton6.TabIndex = 14;
            this.textBoxButton6.Text = "Button 6";
            this.textBoxButton6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxButton7
            // 
            this.textBoxButton7.Location = new System.Drawing.Point(192, 128);
            this.textBoxButton7.Name = "textBoxButton7";
            this.textBoxButton7.Size = new System.Drawing.Size(72, 19);
            this.textBoxButton7.TabIndex = 15;
            this.textBoxButton7.Text = "Button 7";
            this.textBoxButton7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxConnect
            // 
            this.checkBoxConnect.AutoSize = true;
            this.checkBoxConnect.Location = new System.Drawing.Point(24, 128);
            this.checkBoxConnect.Name = "checkBoxConnect";
            this.checkBoxConnect.Size = new System.Drawing.Size(66, 16);
            this.checkBoxConnect.TabIndex = 16;
            this.checkBoxConnect.Text = "Connect";
            this.checkBoxConnect.UseVisualStyleBackColor = true;
            this.checkBoxConnect.CheckedChanged += new System.EventHandler(this.checkBoxConnect_CheckedChanged);
            // 
            // timer100ms
            // 
            this.timer100ms.Enabled = true;
            this.timer100ms.Interval = 50;
            this.timer100ms.Tick += new System.EventHandler(this.timer100ms_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.checkBoxConnect);
            this.Controls.Add(this.textBoxButton7);
            this.Controls.Add(this.textBoxButton6);
            this.Controls.Add(this.textBoxButton5);
            this.Controls.Add(this.textBoxButton4);
            this.Controls.Add(this.textBoxButton3);
            this.Controls.Add(this.textBoxButton2);
            this.Controls.Add(this.textBoxButton1);
            this.Controls.Add(this.textBoxButton0);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAddress);
            this.Name = "Form1";
            this.Text = "joystick UDP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.TextBox textBoxButton0;
        private System.Windows.Forms.TextBox textBoxButton1;
        private System.Windows.Forms.TextBox textBoxButton2;
        private System.Windows.Forms.TextBox textBoxButton3;
        private System.Windows.Forms.TextBox textBoxButton4;
        private System.Windows.Forms.TextBox textBoxButton5;
        private System.Windows.Forms.TextBox textBoxButton6;
        private System.Windows.Forms.TextBox textBoxButton7;
        private System.Windows.Forms.CheckBox checkBoxConnect;
        private System.Windows.Forms.Timer timer100ms;
    }
}

