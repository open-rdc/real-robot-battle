namespace Battle
{
    partial class PictureBoxAttackPoint
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
            isTerminate = true;
        }

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxAttackPoint
            // 
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxAttackPoint_MouseMove);
            this.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.PictureBoxAttackPoint_LoadCompleted);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxAttackPoint_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
