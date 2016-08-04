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
using Janus.Windows.GridEX;
using Timeline.DomainModel.Repositories;
using Timeline.DomainModel.Models;

namespace Timeline.UI.Homepage {
    public partial class ctlTimelines : HomepageBase {

        #region declarations
        private DataSet _data;
        private BindingList<TimelineDefinition> _defintions;
        private TimelineDefinition _definition;
        #endregion

        #region ctor
        public ctlTimelines() {
            InitializeComponent();

            FormatChart();
            InitCombo();
        } 
        #endregion
        
        #region homepagebase
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
                    LoadComboData();
                }
            }
        }

        public override void RestoreCustomisation(XmlElement Customisation) {

        }

        public override void SaveCustomisation(XmlTextWriter XW) {

        }

        #endregion

        #region setup

        private void InitCombo() {

            GridEXColumn col;

            cboDefinition.DropDownList.ColumnAutoResize = true;
            cboDefinition.DropDownList.TableHeaders = InheritableBoolean.False;
            cboDefinition.DropDownList.ColumnHeaders = InheritableBoolean.False;
            cboDefinition.DropDownList.Height = 100;

            cboDefinition.ComboStyle = ComboStyle.DropDownList;

            col = cboDefinition.DropDownList.Columns.Add("TimelineDefinitionID");
            col.Visible = false;

            col = cboDefinition.DropDownList.Columns.Add("TimelineDefinitionName");

            cboDefinition.ValueMember = "TimelineDefinitionID";
            cboDefinition.DisplayMember = "TimelineDefinitionName";

        }

        private void LoadComboData() {

            var repo = new TimelineDefinitionRepository();
            _defintions = repo.Get();

            cboDefinition.SetDataBinding(_defintions, string.Empty);

            if (this.InvokeRequired && this.IsHandleCreated) {
                this.Invoke(new Action(BindComboData));
            }
            
        }

        private void BindComboData() {
            if (_defintions.Count > 0) {
                cboDefinition.SelectedIndex = 0;
            }
        }

        private void FormatChart() {

            var series = chtTimeline.Series[0];

            series.XValueMember = "Milestone";
            series.YValueMembers = "Count";
            series.ChartType = SeriesChartType.Pie;
            series.Palette = ChartColorPalette.BrightPastel;
            series["PieLabelStyle"] = "Disabled";
            series["PieDrawingStyle"] = "SoftEdge";

            chtTimeline.Titles.Add("main");
            chtTimeline.Titles[0].Font = new Font(chtTimeline.Titles[0].Font, FontStyle.Bold);

        }

        private void GetData() {

            // get data
            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;
            string sql =
                "select tds.TimelineDefinitionStepID, tds.TimelineDefinitionStepName Milestone, count(tds.TimelineDefinitionStepID) [Count] from wf.ContactTimeline ct " +
                "inner join wf.TimelineDefinitionStep tds on tds.TimelineDefinitionStepID = ct.TimelineDefinitionStepID " +
                "where ct.TimelineDefinitionID = @TimelineDefinitionID " +
                "group by tds.TimelineDefinitionStepID, tds.TimelineDefinitionStepName";
            _data = centralDal.GetDataset(sql, new DalParm[] {
                new DalParm("TimelineDefinitionID", SqlDbType.Int, 0, _definition.TimelineDefinitionID)
            });

            // refresh control
            if (this.InvokeRequired && this.IsHandleCreated) {
                this.Invoke(new Action(BindData));
            }
        }

        private void BindData() {

            chtTimeline.DataSource = _data.Tables[0];
            chtTimeline.DataBind();

        }
        #endregion

        #region events
        private void ctlTimelines_DoubleClick(object sender, EventArgs e) {
            var f = new frmOnboarding();
            f.ShowDialog();
        }

        private void cboDefinition_ValueChanged(object sender, EventArgs e) {
            _definition = cboDefinition.SelectedItem as TimelineDefinition;
            if (_definition != null) {
                chtTimeline.Titles[0].Text = "Timeline progress - " + _definition.TimelineDefinitionName;
                var t = new Thread(GetData);
                t.Start();
            }
        } 
        #endregion

    }
}
