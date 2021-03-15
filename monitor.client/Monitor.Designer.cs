
namespace monitor.client
{
    partial class Monitor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMonitor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMonitor
            // 
            this.txtMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMonitor.Location = new System.Drawing.Point(0, 0);
            this.txtMonitor.Multiline = true;
            this.txtMonitor.Name = "txtMonitor";
            this.txtMonitor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMonitor.Size = new System.Drawing.Size(800, 450);
            this.txtMonitor.TabIndex = 0;
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMonitor);
            this.Name = "Monitor";
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitor_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMonitor;
    }
}

