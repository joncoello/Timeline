namespace Timeline.UI.Client.ClientTimelineForm {
    partial class frmClientTimeline {
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
            Janus.Windows.GridEX.GridEXLayout cboDefinition_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientTimeline));
            this.grdSteps = new Janus.Windows.GridEX.GridEX();
            this.cboDefinition = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.cmdCreate = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefinition)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSteps
            // 
            this.grdSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSteps.Location = new System.Drawing.Point(12, 49);
            this.grdSteps.Name = "grdSteps";
            this.grdSteps.Size = new System.Drawing.Size(834, 507);
            this.grdSteps.TabIndex = 0;
            this.grdSteps.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // cboDefinition
            // 
            cboDefinition_DesignTimeLayout.LayoutString = resources.GetString("cboDefinition_DesignTimeLayout.LayoutString");
            this.cboDefinition.DesignTimeLayout = cboDefinition_DesignTimeLayout;
            this.cboDefinition.Location = new System.Drawing.Point(12, 21);
            this.cboDefinition.Name = "cboDefinition";
            this.cboDefinition.SelectedIndex = -1;
            this.cboDefinition.SelectedItem = null;
            this.cboDefinition.Size = new System.Drawing.Size(317, 22);
            this.cboDefinition.TabIndex = 1;
            this.cboDefinition.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // cmdCreate
            // 
            this.cmdCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCreate.Location = new System.Drawing.Point(771, 22);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(75, 23);
            this.cmdCreate.TabIndex = 2;
            this.cmdCreate.Text = "Create";
            this.cmdCreate.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // frmClientTimeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(858, 568);
            this.Controls.Add(this.cmdCreate);
            this.Controls.Add(this.cboDefinition);
            this.Controls.Add(this.grdSteps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmClientTimeline";
            this.Text = "frmClientTimeline";
            ((System.ComponentModel.ISupportInitialize)(this.grdSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefinition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdSteps;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cboDefinition;
        private Janus.Windows.EditControls.UIButton cmdCreate;
    }
}