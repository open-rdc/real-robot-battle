using real_robot_battle;

namespace inverseKinematics
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
            this.posture = new real_robot_battle.Posture();
            ((System.ComponentModel.ISupportInitialize)(this.posture)).BeginInit();
            this.SuspendLayout();
            // 
            // posture
            // 
            this.posture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.posture.Location = new System.Drawing.Point(0, 0);
            this.posture.Name = "posture";
            this.posture.Size = new System.Drawing.Size(488, 469);
            this.posture.TabIndex = 0;
            this.posture.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 469);
            this.Controls.Add(this.posture);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.posture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Posture posture;
    }
}
