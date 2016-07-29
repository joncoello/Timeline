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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.GridEX.GridEXLayout cboDefinition_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientTimeline));
            this.grdSteps = new Janus.Windows.GridEX.GridEX();
            this.cboDefinition = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.cmdCreate = new Janus.Windows.EditControls.UIButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cdmForward = new Janus.Windows.EditControls.UIButton();
            this.cmdBack = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefinition)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSteps
            // 
            this.grdSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSteps.ImageList = this.imageList;
            this.grdSteps.Location = new System.Drawing.Point(12, 64);
            this.grdSteps.Name = "grdSteps";
            this.grdSteps.Size = new System.Drawing.Size(834, 492);
            this.grdSteps.TabIndex = 0;
            this.grdSteps.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.grdSteps.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdSteps_FormattingRow);
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
            this.cboDefinition.ValueChanged += new System.EventHandler(this.cboDefinition_ValueChanged);
            // 
            // cmdCreate
            // 
            this.cmdCreate.Location = new System.Drawing.Point(335, 21);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(75, 23);
            this.cmdCreate.TabIndex = 2;
            this.cmdCreate.Text = "Create";
            this.cmdCreate.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "gear.png");
            this.imageList.Images.SetKeyName(1, "check2.png");
            this.imageList.Images.SetKeyName(2, "undo.png");
            this.imageList.Images.SetKeyName(3, "redo.png");
            // 
            // cdmForward
            // 
            this.cdmForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdmForward.ImageIndex = 3;
            this.cdmForward.ImageList = this.imageList;
            this.cdmForward.Location = new System.Drawing.Point(771, 23);
            this.cdmForward.Name = "cdmForward";
            this.cdmForward.Size = new System.Drawing.Size(75, 23);
            this.cdmForward.TabIndex = 3;
            this.cdmForward.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.cdmForward.Click += new System.EventHandler(this.cdmForward_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBack.ImageIndex = 2;
            this.cmdBack.ImageList = this.imageList;
            this.cmdBack.Location = new System.Drawing.Point(690, 23);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 23);
            this.cmdBack.TabIndex = 4;
            this.cmdBack.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // frmClientTimeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(858, 568);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cdmForward);
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
        private System.Windows.Forms.ImageList imageList;
        private Janus.Windows.EditControls.UIButton cdmForward;
        private Janus.Windows.EditControls.UIButton cmdBack;
    }
}