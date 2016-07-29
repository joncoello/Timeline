namespace Timeline.UI.Homepage {
    partial class ctlTimelines {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Janus.Windows.GridEX.GridEXLayout cboDefinition_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTimelines));
            this.chtTimeline = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboDefinition = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            ((System.ComponentModel.ISupportInitialize)(this.chtTimeline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefinition)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(395, 1);
            // 
            // chtTimeline
            // 
            this.chtTimeline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chtTimeline.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtTimeline.Legends.Add(legend1);
            this.chtTimeline.Location = new System.Drawing.Point(3, 3);
            this.chtTimeline.Name = "chtTimeline";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtTimeline.Series.Add(series1);
            this.chtTimeline.Size = new System.Drawing.Size(405, 361);
            this.chtTimeline.TabIndex = 0;
            this.chtTimeline.Text = "chart1";
            // 
            // cboDefinition
            // 
            this.cboDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            cboDefinition_DesignTimeLayout.LayoutString = resources.GetString("cboDefinition_DesignTimeLayout.LayoutString");
            this.cboDefinition.DesignTimeLayout = cboDefinition_DesignTimeLayout;
            this.cboDefinition.Location = new System.Drawing.Point(3, 370);
            this.cboDefinition.Name = "cboDefinition";
            this.cboDefinition.SelectedIndex = -1;
            this.cboDefinition.SelectedItem = null;
            this.cboDefinition.Size = new System.Drawing.Size(405, 22);
            this.cboDefinition.TabIndex = 1;
            // 
            // ctlTimelines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboDefinition);
            this.Controls.Add(this.chtTimeline);
            this.Name = "ctlTimelines";
            this.Size = new System.Drawing.Size(411, 395);
            this.Controls.SetChildIndex(this.chtTimeline, 0);
            this.Controls.SetChildIndex(this.cboDefinition, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chtTimeline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefinition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtTimeline;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cboDefinition;
    }
}
