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
using MYOB.CSS;
using MYOB.DAL;

namespace Timeline.UI.Homepage {
    public partial class ctlTimelines : HomepageBase {

        private DataSet data;

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
            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;
            string sql =
                "select tds.TimelineDefinitionStepID, tds.TimelineDefinitionStepName Milestone, count(tds.TimelineDefinitionStepID) [Count] from wf.ContactTimeline ct " +
                "inner join wf.TimelineDefinitionStep tds on tds.TimelineDefinitionStepID = ct.TimelineDefinitionStepID " +
                "where ct.TimelineDefinitionID = @TimelineDefinitionID " +
                "group by tds.TimelineDefinitionStepID, tds.TimelineDefinitionStepName";
            data = centralDal.GetDataset(sql, new DalParm[] {
                new DalParm("TimelineDefinitionID", SqlDbType.Int, 0, 1)
            });

            // refresh control
            if (this.InvokeRequired && this.IsHandleCreated) {
                this.Invoke(new Action(BindData));
            }
        }

        private void BindData() {
            
            chtTimeline.DataSource = data.Tables[0];
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
