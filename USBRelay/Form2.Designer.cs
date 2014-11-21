namespace usbrelay
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonWinkerRight = new System.Windows.Forms.Button();
            this.checkBoxFrontLight = new System.Windows.Forms.CheckBox();
            this.buttonWinkerLeft = new System.Windows.Forms.Button();
            this.checkBoxHeadLightBoost = new System.Windows.Forms.CheckBox();
            this.checkBoxExaustShoot = new System.Windows.Forms.CheckBox();
            this.checkBoxExaustCharge = new System.Windows.Forms.CheckBox();
            this.buttonSmoke = new System.Windows.Forms.Button();
            this.buttonHeadLight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonWinkerRight
            // 
            this.buttonWinkerRight.Location = new System.Drawing.Point(144, 152);
            this.buttonWinkerRight.Name = "buttonWinkerRight";
            this.buttonWinkerRight.Size = new System.Drawing.Size(123, 23);
            this.buttonWinkerRight.TabIndex = 0;
            this.buttonWinkerRight.Text = "WINKER RIGHT";
            this.buttonWinkerRight.UseVisualStyleBackColor = true;
            this.buttonWinkerRight.Click += new System.EventHandler(this.buttonWinkerRight_Click);
            // 
            // checkBoxFrontLight
            // 
            this.checkBoxFrontLight.AutoSize = true;
            this.checkBoxFrontLight.Location = new System.Drawing.Point(8, 8);
            this.checkBoxFrontLight.Name = "checkBoxFrontLight";
            this.checkBoxFrontLight.Size = new System.Drawing.Size(98, 16);
            this.checkBoxFrontLight.TabIndex = 1;
            this.checkBoxFrontLight.Text = "FRONT LIGHT";
            this.checkBoxFrontLight.UseVisualStyleBackColor = true;
            this.checkBoxFrontLight.CheckedChanged += new System.EventHandler(this.checkBoxFrontLight_CheckedChanged);
            // 
            // buttonWinkerLeft
            // 
            this.buttonWinkerLeft.Location = new System.Drawing.Point(8, 152);
            this.buttonWinkerLeft.Name = "buttonWinkerLeft";
            this.buttonWinkerLeft.Size = new System.Drawing.Size(123, 23);
            this.buttonWinkerLeft.TabIndex = 2;
            this.buttonWinkerLeft.Text = "WINKER LEFT";
            this.buttonWinkerLeft.UseVisualStyleBackColor = true;
            this.buttonWinkerLeft.Click += new System.EventHandler(this.buttonWinkerLeft_Click);
            // 
            // checkBoxHeadLightBoost
            // 
            this.checkBoxHeadLightBoost.AutoSize = true;
            this.checkBoxHeadLightBoost.Location = new System.Drawing.Point(8, 32);
            this.checkBoxHeadLightBoost.Name = "checkBoxHeadLightBoost";
            this.checkBoxHeadLightBoost.Size = new System.Drawing.Size(133, 16);
            this.checkBoxHeadLightBoost.TabIndex = 4;
            this.checkBoxHeadLightBoost.Text = "HEAD BOOST LIGHT";
            this.checkBoxHeadLightBoost.UseVisualStyleBackColor = true;
            this.checkBoxHeadLightBoost.CheckedChanged += new System.EventHandler(this.checkBoxHeadBoostLight_CheckedChanged);
            // 
            // checkBoxExaustShoot
            // 
            this.checkBoxExaustShoot.AutoSize = true;
            this.checkBoxExaustShoot.Location = new System.Drawing.Point(8, 56);
            this.checkBoxExaustShoot.Name = "checkBoxExaustShoot";
            this.checkBoxExaustShoot.Size = new System.Drawing.Size(110, 16);
            this.checkBoxExaustShoot.TabIndex = 5;
            this.checkBoxExaustShoot.Text = "EXAUST SHOOT";
            this.checkBoxExaustShoot.UseVisualStyleBackColor = true;
            this.checkBoxExaustShoot.CheckedChanged += new System.EventHandler(this.checkBoxExaustShoot_CheckedChanged);
            // 
            // checkBoxExaustCharge
            // 
            this.checkBoxExaustCharge.AutoSize = true;
            this.checkBoxExaustCharge.Location = new System.Drawing.Point(8, 80);
            this.checkBoxExaustCharge.Name = "checkBoxExaustCharge";
            this.checkBoxExaustCharge.Size = new System.Drawing.Size(119, 16);
            this.checkBoxExaustCharge.TabIndex = 6;
            this.checkBoxExaustCharge.Text = "EXAUST CHARGE";
            this.checkBoxExaustCharge.UseVisualStyleBackColor = true;
            this.checkBoxExaustCharge.CheckedChanged += new System.EventHandler(this.checkBoxExaustXCharge_CheckedChanged);
            // 
            // buttonSmoke
            // 
            this.buttonSmoke.Location = new System.Drawing.Point(144, 120);
            this.buttonSmoke.Name = "buttonSmoke";
            this.buttonSmoke.Size = new System.Drawing.Size(123, 23);
            this.buttonSmoke.TabIndex = 7;
            this.buttonSmoke.Text = "SMOKE";
            this.buttonSmoke.UseVisualStyleBackColor = true;
            this.buttonSmoke.Click += new System.EventHandler(this.buttonSmoke_Click);
            // 
            // buttonHeadLight
            // 
            this.buttonHeadLight.Location = new System.Drawing.Point(8, 120);
            this.buttonHeadLight.Name = "buttonHeadLight";
            this.buttonHeadLight.Size = new System.Drawing.Size(123, 23);
            this.buttonHeadLight.TabIndex = 8;
            this.buttonHeadLight.Text = "HEAD LIGHT";
            this.buttonHeadLight.UseVisualStyleBackColor = true;
            this.buttonHeadLight.Click += new System.EventHandler(this.buttonHeadLight_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 186);
            this.Controls.Add(this.buttonHeadLight);
            this.Controls.Add(this.buttonSmoke);
            this.Controls.Add(this.checkBoxExaustCharge);
            this.Controls.Add(this.checkBoxExaustShoot);
            this.Controls.Add(this.checkBoxHeadLightBoost);
            this.Controls.Add(this.buttonWinkerLeft);
            this.Controls.Add(this.checkBoxFrontLight);
            this.Controls.Add(this.buttonWinkerRight);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWinkerRight;
        private System.Windows.Forms.CheckBox checkBoxFrontLight;
        private System.Windows.Forms.Button buttonWinkerLeft;
        private System.Windows.Forms.CheckBox checkBoxHeadLightBoost;
        private System.Windows.Forms.CheckBox checkBoxExaustShoot;
        private System.Windows.Forms.CheckBox checkBoxExaustCharge;
        private System.Windows.Forms.Button buttonSmoke;
        private System.Windows.Forms.Button buttonHeadLight;
    }
}