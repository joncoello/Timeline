using Janus.Windows.GridEX;
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
using Timeline.DomainModel.Repositories;
using Timeline.UI.Common.FormsFactory;

namespace Timeline.UI.Maintenance.TimelineDetailsMaintenanceForm {
    public partial class frmTimelineDetailsMaintenance : Form, ICSSDisplayMainArea {

        private readonly int _definitionID;

        #region ctor
        public frmTimelineDetailsMaintenance(TimelineDetailsMaintenance form) {
            InitializeComponent();
            _definitionID = form.DefinitionID;
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

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            FormatScreen();
            InitGrid();
            LoadData();
        }

        private void FormatScreen() {
            this.Text = "Timeline Details";
        }

        private void InitGrid() {

            GridEXColumn col;
            var rt = new GridEXTable();

            rt.RowHeight = 30;

            grdSteps.RootTable = rt;
            grdSteps.ColumnAutoResize = true;
            grdSteps.VisualStyle = VisualStyle.Office2010;
            grdSteps.AlternatingColors = true;
            grdSteps.GroupByBoxVisible = false;

            col = rt.Columns.Add("Name");
            col.DataMember = "DefinitionStepName";
            col.EditType = EditType.NoEdit;
            col.Selectable = false;

        }

        private void LoadData() {

            var repo = new TimelineDefinitionRepository();
            var definition = repo.Get(_definitionID);
            grdSteps.SetDataBinding(definition.Steps, string.Empty);

            txtName.Text = definition.TimelineDefinitionName;

        }
    }
}
