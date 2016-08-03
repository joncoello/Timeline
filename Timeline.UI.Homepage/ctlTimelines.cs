using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace Timeline.UI.Homepage {
    public partial class ctlTimelines : HomepageBase {
        private DataTable data;

        public ctlTimelines() {
            InitializeComponent();

            FormatChart();
        }

        private void FormatChart() {

            var series = chtTimeline.Series[0];

            series.XValueMember = "Milestone";
            series.YValueMembers = "Count";
            series.ChartType = SeriesChartType.Pie;
            series.Palette = ChartColorPalette.BrightPastel;
            series["PieLabelStyle"] = "Disabled";
            series["PieDrawingStyle"] = "SoftEdge";

        }

        public override string DisplayName {
            get {
                return "Timeline";
            }
        }

        public override void DefaultSettings() {

        }

        public override void LoadData(bool Cache, bool StartNewThread) {
            if (!Cache) {
                if (StartNewThread) {
                    var t = new Thread(GetData);
                    t.Start();
                } else {
                    GetData();
                }
            }
        }

        private void GetData() {

            Thread.Sleep(2000);

            // get data
            data = new DataTable();
            data.Columns.Add("Milestone", typeof(string));
            data.Columns.Add("Count", typeof(int));

            data.Rows.Add("Information requested", 232);
            data.Rows.Add("Information received", 132);
            data.Rows.Add("Processing return", 86);
            data.Rows.Add("In review", 91);
            data.Rows.Add("Client Approval", 42);
            data.Rows.Add("Submitted", 23);

            // refresh control
            if (this.InvokeRequired && this.IsHandleCreated) {
                this.Invoke(new Action(BindData));
            }
        }

        private void BindData() {
            
            chtTimeline.DataSource = data;
            chtTimeline.DataBind();

        }

        public override void RestoreCustomisation(XmlElement Customisation) {
            
        }

        public override void SaveCustomisation(XmlTextWriter XW) {
            
        }

        private void ctlTimelines_DoubleClick(object sender, EventArgs e) {
            var f = new frmOnboarding();
            f.ShowDialog();
        }
    }
}
