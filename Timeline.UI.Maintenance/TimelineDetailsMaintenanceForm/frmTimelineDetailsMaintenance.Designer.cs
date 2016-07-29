namespace Timeline.UI.Maintenance.TimelineDetailsMaintenanceForm {
    partial class frmTimelineDetailsMaintenance {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grdSteps = new Janus.Windows.GridEX.GridEX();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cmdMoveUp = new Janus.Windows.EditControls.UIButton();
            this.cmdMoveDown = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSteps)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(111, 26);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(329, 22);
            this.txtName.TabIndex = 1;
            // 
            // grdSteps
            // 
            this.grdSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSteps.Location = new System.Drawing.Point(12, 154);
            this.grdSteps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdSteps.Name = "grdSteps";
            this.grdSteps.Size = new System.Drawing.Size(554, 311);
            this.grdSteps.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.Location = new System.Drawing.Point(12, 66);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblInfo.Size = new System.Drawing.Size(685, 68);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Edit a timeline from here.\r\n\r\nMake changes to the list of milestones and their or" +
    "der in the grid below.\r\n";
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMoveUp.Location = new System.Drawing.Point(573, 154);
            this.cmdMoveUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(125, 28);
            this.cmdMoveUp.TabIndex = 4;
            this.cmdMoveUp.Text = "move up";
            this.cmdMoveUp.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMoveDown.Location = new System.Drawing.Point(573, 190);
            this.cmdMoveDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(123, 28);
            this.cmdMoveDown.TabIndex = 5;
            this.cmdMoveDown.Text = "move down";
            this.cmdMoveDown.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // frmTimelineDetailsMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(709, 478);
            this.Controls.Add(this.cmdMoveDown);
            this.Controls.Add(this.cmdMoveUp);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grdSteps);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTimelineDetailsMaintenance";
            this.Text = "frmTimelineDetailsMaintenance";
            ((System.ComponentModel.ISupportInitialize)(this.grdSteps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private Janus.Windows.GridEX.GridEX grdSteps;
        private System.Windows.Forms.Label lblInfo;
        private Janus.Windows.EditControls.UIButton cmdMoveUp;
        private Janus.Windows.EditControls.UIButton cmdMoveDown;
    }
}