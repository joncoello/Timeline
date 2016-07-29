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
            this.lblInfo = new System.Windows.Forms.Label();
            this.cmdCreate = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimelines)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTimelines
            // 
            this.grdTimelines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTimelines.Location = new System.Drawing.Point(12, 169);
            this.grdTimelines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdTimelines.Name = "grdTimelines";
            this.grdTimelines.Size = new System.Drawing.Size(612, 209);
            this.grdTimelines.TabIndex = 0;
            this.grdTimelines.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdTimelines_RowDoubleClick);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(5);
            this.lblInfo.Size = new System.Drawing.Size(613, 116);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Manage your timelines from here.\r\n\r\nTo create a new time simply use the blank row" +
    " at the top, enter a name then click enter.\r\n\r\nTo edit an existing timeline, dou" +
    "ble click on the row.\r\n";
            // 
            // cmdCreate
            // 
            this.cmdCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCreate.Location = new System.Drawing.Point(529, 141);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(95, 23);
            this.cmdCreate.TabIndex = 2;
            this.cmdCreate.Text = "Create";
            this.cmdCreate.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // frmTimelineMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(636, 390);
            this.Controls.Add(this.cmdCreate);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grdTimelines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTimelineMaintenance";
            this.Text = "frmTimelineMaintenance";
            ((System.ComponentModel.ISupportInitialize)(this.grdTimelines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdTimelines;
        private System.Windows.Forms.Label lblInfo;
        private Janus.Windows.EditControls.UIButton cmdCreate;
    }
}