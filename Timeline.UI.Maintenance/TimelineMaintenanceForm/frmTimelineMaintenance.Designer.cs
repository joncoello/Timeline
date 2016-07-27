namespace Timeline.UI.Maintenance.TimelineMaintenanceForm {
    partial class frmTimelineMaintenance {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grdTimelines = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimelines)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTimelines
            // 
            this.grdTimelines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTimelines.Location = new System.Drawing.Point(0, 0);
            this.grdTimelines.Name = "grdTimelines";
            this.grdTimelines.Size = new System.Drawing.Size(636, 390);
            this.grdTimelines.TabIndex = 0;
            // 
            // frmTimelineMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(636, 390);
            this.Controls.Add(this.grdTimelines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimelineMaintenance";
            this.Text = "frmTimelineMaintenance";
            ((System.ComponentModel.ISupportInitialize)(this.grdTimelines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdTimelines;
    }
}