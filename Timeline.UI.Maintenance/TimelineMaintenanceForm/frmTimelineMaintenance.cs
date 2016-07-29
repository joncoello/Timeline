using Janus.Windows.GridEX;
using MYOB.CSS;
using MYOB.CSSInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timeline.DomainModel.Models;
using Timeline.DomainModel.Repositories;
using Timeline.UI.Common.FormsFactory;

namespace Timeline.UI.Maintenance.TimelineMaintenanceForm {
    public partial class frmTimelineMaintenance : Form, ICSSDisplayMainArea {

        #region declarations
        private readonly TimelineDefinitionRepository _repo;
        private BindingList<TimelineDefinition> definitions; 
        #endregion

        #region ctor
        public frmTimelineMaintenance(TimelineMaintenance form) {
            InitializeComponent();
            _repo = new TimelineDefinitionRepository();
        } 
        #endregion

        #region ICSSDisplayMainArea
        public int CollectionID { get; set; }

        public void CloseForm(object sender, CSSCancelEventArgs e) {
            this.Close();
        }

        public SideBarGroups Register() {
            this.Show();
            return new SideBarGroups("");
        }
        #endregion

        #region setup
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            FormatScreen();
            InitGrid();
            LoadData();
        }

        private void FormatScreen() {
            this.Text = "Timelines";
        }

        private void InitGrid() {

            GridEXColumn col;
            var rt = new GridEXTable();

            rt.RowHeight = 30;

            grdTimelines.RootTable = rt;
            grdTimelines.ColumnAutoResize = true;
            grdTimelines.VisualStyle = VisualStyle.Office2010;
            grdTimelines.AlternatingColors = true;
            grdTimelines.GroupByBoxVisible = false;
            
            col = rt.Columns.Add("Name");
            col.DataMember = "TimelineDefinitionName";
            
        }

        private void LoadData() {

            definitions = _repo.Get();
            grdTimelines.SetDataBinding(definitions, string.Empty);

        }
        #endregion

        #region event

        private void grdTimelines_RowDoubleClick(object sender, RowActionEventArgs e) {
            var d = grdTimelines.GetRow().DataRow as TimelineDefinition;
            var f = new TimelineDetailsMaintenance(d.TimelineDefinitionID);
            CssContext.Instance.Host.Register(f);
        }

        private void cmdCreate_Click(object sender, EventArgs e) {
            var d = grdTimelines.GetRow().DataRow as TimelineDefinition;
            var f = new TimelineDetailsMaintenance(0);
            CssContext.Instance.Host.Register(f);
        }

        #endregion

    }
}
