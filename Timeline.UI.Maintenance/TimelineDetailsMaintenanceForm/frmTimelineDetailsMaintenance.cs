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
using Timeline.DomainModel.Models;

namespace Timeline.UI.Maintenance.TimelineDetailsMaintenanceForm {
    public partial class frmTimelineDetailsMaintenance : Form, ICSSDisplayMainArea {

        #region declarations
        private readonly int _definitionID;
        private readonly TimelineDefinitionDetailsRepository repo;
        private TimelineDefinitionDetails definition; 
        #endregion

        #region ctor
        public frmTimelineDetailsMaintenance(TimelineDetailsMaintenance form) {
            InitializeComponent();
            _definitionID = form.DefinitionID;
            repo = new TimelineDefinitionDetailsRepository();
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

        #region setup screen
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
            grdSteps.AllowAddNew = InheritableBoolean.True;

            col = rt.Columns.Add("Name");
            col.DataMember = "DefinitionStepName";

        }

        private void LoadData() {

            if (_definitionID == 0) {
                definition = new TimelineDefinitionDetails() {
                    TimelineDefinitionName = "New timeline"
                };
            } else {
                definition = repo.Get(_definitionID);
            }

            grdSteps.SetDataBinding(definition.Steps, string.Empty);

            txtName.Text = definition.TimelineDefinitionName;

        } 
        #endregion

        #region event
        private void cmdMoveUp_Click(object sender, EventArgs e) {

            var step = grdSteps.GetRow().DataRow as DefinitionStep;
            int index = definition.Steps.IndexOf(step);
            if (index > 0) {
                definition.Steps.Remove(step);
                definition.Steps.Insert(index - 1, step);

                // select row
                var row = grdSteps.GetRows().FirstOrDefault(r => (r.DataRow as DefinitionStep) == step);
                grdSteps.MoveToRowIndex(row.RowIndex);
            }

        }

        private void cmdMoveDown_Click(object sender, EventArgs e) {

            var step = grdSteps.GetRow().DataRow as DefinitionStep;
            int index = definition.Steps.IndexOf(step);
            if (index < definition.Steps.Count - 1) {
                definition.Steps.Remove(step);
                definition.Steps.Insert(index + 1, step);

                // select row
                var row = grdSteps.GetRows().FirstOrDefault(r => (r.DataRow as DefinitionStep) == step);
                grdSteps.MoveToRowIndex(row.RowIndex);
            }

        }

        private void cmdSave_Click(object sender, EventArgs e) {
            definition.TimelineDefinitionName = txtName.Text;
            repo.Post(definition);
        } 
        #endregion

    }
}
