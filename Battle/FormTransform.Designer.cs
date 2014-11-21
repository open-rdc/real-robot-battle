namespace Battle
{
    partial class FormTransform
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxSquence = new System.Windows.Forms.ComboBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonDown = new System.Windows.Forms.Button();
            this.checkBoxFrontLight = new System.Windows.Forms.CheckBox();
            this.checkBoxHeadBoostLight = new System.Windows.Forms.CheckBox();
            this.checkBoxExaustShoot = new System.Windows.Forms.CheckBox();
            this.checkBoxExaustCharge = new System.Windows.Forms.CheckBox();
            this.checkBoxHeadLight = new System.Windows.Forms.CheckBox();
            this.buttonSmoke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxSquence
            // 
            this.comboBoxSquence.FormattingEnabled = true;
            this.comboBoxSquence.Items.AddRange(new object[] {
            "ヘッドライトON",
            "前進",
            "スチーム",
            "リフト",
            "肩が出る",
            "眼が光る",
            "スチーム",
            "移動",
            "ポージング"});
            this.comboBoxSquence.Location = new System.Drawing.Point(24, 24);
            this.comboBoxSquence.Name = "comboBoxSquence";
            this.comboBoxSquence.Size = new System.Drawing.Size(504, 52);
            this.comboBoxSquence.TabIndex = 0;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(544, 24);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(232, 48);
            this.buttonExecute.TabIndex = 1;
            this.buttonExecute.Text = "EXECUTE";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(24, 168);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(232, 48);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.Text = "UP";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(24, 232);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(480, 48);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "LIFT";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(272, 168);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(232, 48);
            this.buttonDown.TabIndex = 5;
            this.buttonDown.Text = "DOWN";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // checkBoxFrontLight
            // 
            this.checkBoxFrontLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxFrontLight.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFrontLight.Location = new System.Drawing.Point(24, 320);
            this.checkBoxFrontLight.Name = "checkBoxFrontLight";
            this.checkBoxFrontLight.Size = new System.Drawing.Size(192, 40);
            this.checkBoxFrontLight.TabIndex = 6;
            this.checkBoxFrontLight.Text = "FRONT LIGHT";
            this.checkBoxFrontLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxFrontLight.UseVisualStyleBackColor = true;
            this.checkBoxFrontLight.CheckedChanged += new System.EventHandler(this.checkBoxFrontLight_CheckedChanged);
            // 
            // checkBoxHeadBoostLight
            // 
            this.checkBoxHeadBoostLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxHeadBoostLight.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHeadBoostLight.Location = new System.Drawing.Point(232, 376);
            this.checkBoxHeadBoostLight.Name = "checkBoxHeadBoostLight";
            this.checkBoxHeadBoostLight.Size = new System.Drawing.Size(272, 40);
            this.checkBoxHeadBoostLight.TabIndex = 7;
            this.checkBoxHeadBoostLight.Text = "HEAD BOOST LIGHT";
            this.checkBoxHeadBoostLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxHeadBoostLight.UseVisualStyleBackColor = true;
            this.checkBoxHeadBoostLight.CheckedChanged += new System.EventHandler(this.checkBoxHeadBoostLight_CheckedChanged);
            // 
            // checkBoxExaustShoot
            // 
            this.checkBoxExaustShoot.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxExaustShoot.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExaustShoot.Location = new System.Drawing.Point(24, 432);
            this.checkBoxExaustShoot.Name = "checkBoxExaustShoot";
            this.checkBoxExaustShoot.Size = new System.Drawing.Size(192, 40);
            this.checkBoxExaustShoot.TabIndex = 8;
            this.checkBoxExaustShoot.Text = "EXAUST SHOOT";
            this.checkBoxExaustShoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxExaustShoot.UseVisualStyleBackColor = true;
            this.checkBoxExaustShoot.CheckedChanged += new System.EventHandler(this.checkBoxExaustShoot_CheckedChanged);
            // 
            // checkBoxExaustCharge
            // 
            this.checkBoxExaustCharge.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxExaustCharge.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExaustCharge.Location = new System.Drawing.Point(232, 432);
            this.checkBoxExaustCharge.Name = "checkBoxExaustCharge";
            this.checkBoxExaustCharge.Size = new System.Drawing.Size(272, 40);
            this.checkBoxExaustCharge.TabIndex = 9;
            this.checkBoxExaustCharge.Text = "EXAUST CHARGE";
            this.checkBoxExaustCharge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxExaustCharge.UseVisualStyleBackColor = true;
            this.checkBoxExaustCharge.CheckedChanged += new System.EventHandler(this.checkBoxExaustCharge_CheckedChanged);
            // 
            // checkBoxHeadLight
            // 
            this.checkBoxHeadLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxHeadLight.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHeadLight.Location = new System.Drawing.Point(24, 376);
            this.checkBoxHeadLight.Name = "checkBoxHeadLight";
            this.checkBoxHeadLight.Size = new System.Drawing.Size(192, 40);
            this.checkBoxHeadLight.TabIndex = 10;
            this.checkBoxHeadLight.Text = "HEAD LIGHT";
            this.checkBoxHeadLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxHeadLight.UseVisualStyleBackColor = true;
            this.checkBoxHeadLight.CheckedChanged += new System.EventHandler(this.checkBoxHeadLight_CheckedChanged);
            // 
            // buttonSmoke
            // 
            this.buttonSmoke.Font = new System.Drawing.Font("Optimus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSmoke.Location = new System.Drawing.Point(232, 320);
            this.buttonSmoke.Name = "buttonSmoke";
            this.buttonSmoke.Size = new System.Drawing.Size(272, 40);
            this.buttonSmoke.TabIndex = 11;
            this.buttonSmoke.Text = "SMOKE";
            this.buttonSmoke.UseVisualStyleBackColor = true;
            this.buttonSmoke.Click += new System.EventHandler(this.buttonSmoke_Click);
            // 
            // FormTransform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 44F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.buttonSmoke);
            this.Controls.Add(this.checkBoxHeadLight);
            this.Controls.Add(this.checkBoxExaustCharge);
            this.Controls.Add(this.checkBoxExaustShoot);
            this.Controls.Add(this.checkBoxHeadBoostLight);
            this.Controls.Add(this.checkBoxFrontLight);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.comboBoxSquence);
            this.Font = new System.Drawing.Font("Optimus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.Name = "FormTransform";
            this.Text = "FormTransform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSquence;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.CheckBox checkBoxFrontLight;
        private System.Windows.Forms.CheckBox checkBoxHeadBoostLight;
        private System.Windows.Forms.CheckBox checkBoxExaustShoot;
        private System.Windows.Forms.CheckBox checkBoxExaustCharge;
        private System.Windows.Forms.CheckBox checkBoxHeadLight;
        private System.Windows.Forms.Button buttonSmoke;
    }
}