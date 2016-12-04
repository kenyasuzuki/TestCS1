namespace TestCS1
{
    partial class CyclicAccess
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webView = new System.Windows.Forms.WebBrowser();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.checkAccess = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webView.Location = new System.Drawing.Point(0, 200);
            this.webView.MinimumSize = new System.Drawing.Size(20, 20);
            this.webView.Name = "webView";
            this.webView.ScriptErrorsSuppressed = true;
            this.webView.Size = new System.Drawing.Size(284, 261);
            this.webView.TabIndex = 0;
            this.webView.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webView_DocumentCompleted);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.OnTick);
            // 
            // checkAccess
            // 
            this.checkAccess.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkAccess.AutoSize = true;
            this.checkAccess.Location = new System.Drawing.Point(21, 29);
            this.checkAccess.Name = "checkAccess";
            this.checkAccess.Size = new System.Drawing.Size(51, 22);
            this.checkAccess.TabIndex = 1;
            this.checkAccess.Text = "アクセス";
            this.checkAccess.UseVisualStyleBackColor = true;
            // 
            // CyclicAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.checkAccess);
            this.Controls.Add(this.webView);
            this.MaximizeBox = false;
            this.Name = "CyclicAccess";
            this.Text = "CyclicAccess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webView;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox checkAccess;
    }
}

