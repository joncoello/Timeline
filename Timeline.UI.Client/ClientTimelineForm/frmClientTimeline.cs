using Central.CSSContactAPI;
using Janus.Windows.GridEX;
using MYOB.CSS;
using MYOB.CSSInterface;
using MYOB.DAL;
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

namespace Timeline.UI.Client.ClientTimelineForm {

    public partial class frmClientTimeline : Form, ICSSClientFormPlugIn {

        #region declarations
        private int _clientID;
        private ClientTimeline _timeline;
        private int _contactID;
        private TimelineDefinition _definition;
        #endregion

        #region ctor
        public frmClientTimeline() {
            InitializeComponent();

            FormatScreen();
        }
        #endregion

        #region ICSSClientFormPlugIn

        public int Position {
            get {
                return 3;
            }
        }

        public bool CheckSecurityPermission(AvailableArea Origin) {
            return true;
        }

        public void CloseForm(object sender, CSSChildEventArgs e) {
            this.Close();
        }

        public void LoadClient(int ClientId, ICSSHost Host) {
            _clientID = ClientId;
            var dal = CssContext.Instance.GetDAL(string.Empty) as DAL;
            var centralGateway = new CentralGateway(dal);
            var client = centralGateway.FindClient(_clientID, CssContext.Instance.Host.EmployeeId);
            _contactID = client.Contact.ContactId;
        }

        public void RefreshForm() {

        }

        public void SaveChanges(object sender, CSSChildSaveEventArgs e) {

        }

        #endregion

        #region load
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitCombo();
            LoadComboData();

            InitGrid();

        }

        private void FormatScreen() {
            this.Text = "Timelines";
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = SystemColors.Window;
        }

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
            var defintions = repo.Get();

            cboDefinition.SetDataBinding(defintions, string.Empty);

            if (defintions.Count > 0) {
                cboDefinition.SelectedIndex = 0;
            }

        }

        private void InitGrid() {

            GridEXColumn col;
            var rt = new GridEXTable();

            rt.RowHeight = 30;

            grdSteps.ColumnAutoResize = true;
            grdSteps.VisualStyle = VisualStyle.Office2010;
            grdSteps.AlternatingColors = true;
            grdSteps.GroupByBoxVisible = false;

            col = rt.Columns.Add("Name");
            col.EditType = EditType.NoEdit;
            col.Selectable = false;

            col = rt.Columns.Add("Status");
            col.EditType = EditType.NoEdit;
            //col.BoundMode = ColumnBoundMode.Unbound;
            col.Caption = string.Empty;
            col.Selectable = false;
            col.Width = 40;
            col.AllowSize = false;
            col.CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center;

            grdSteps.RootTable = rt;

        }
        #endregion

        #region events

        private void cboDefinition_ValueChanged(object sender, EventArgs e) {

            _definition = (cboDefinition.SelectedItem as TimelineDefinition);

            var repo = new ClientTimelineRepository();

            _timeline = repo.Get(_contactID, _definition.TimelineDefinitionID);

            grdSteps.SetDataBinding(_timeline.Steps, string.Empty);

        }

        private void grdSteps_FormattingRow(object sender, RowLoadEventArgs e) {

            e.Row.Cells["Status"].Text = string.Empty;

            var step = e.Row.DataRow as ClientTimelineStep;

            switch (step.Status) {
                case ClientTimelineStep.StepStatus.NotStarted:
                    e.Row.Cells["Status"].ImageIndex = -1;
                    break;
                case ClientTimelineStep.StepStatus.InProgress:
                    e.Row.Cells["Status"].ImageIndex = 0;
                    break;
                case ClientTimelineStep.StepStatus.Complete:
                    e.Row.Cells["Status"].ImageIndex = 1;
                    break;
            }

        }

        private void cmdBack_Click(object sender, EventArgs e) {

            var lastInProgressStep = _timeline.Steps.LastOrDefault(s => s.Status == ClientTimelineStep.StepStatus.InProgress);

            if (lastInProgressStep != null && lastInProgressStep != _timeline.Steps[0]) {
                lastInProgressStep.Status = ClientTimelineStep.StepStatus.NotStarted;
            }

            var lastCompleteStep = _timeline.Steps.LastOrDefault(s => s.Status == ClientTimelineStep.StepStatus.Complete);

            if (lastCompleteStep != null) {

                lastCompleteStep.Status = ClientTimelineStep.StepStatus.InProgress;

                
                
            }
            
        }

        private void cdmForward_Click(object sender, EventArgs e) {

            var firstInProgressStep = _timeline.Steps.FirstOrDefault(s => s.Status == ClientTimelineStep.StepStatus.InProgress);

            if (firstInProgressStep != null) {

                firstInProgressStep.Status = ClientTimelineStep.StepStatus.Complete;

                var firstNotStartedStep = _timeline.Steps.FirstOrDefault(s => s.Status == ClientTimelineStep.StepStatus.NotStarted);

                if (firstNotStartedStep != null) {
                    firstNotStartedStep.Status = ClientTimelineStep.StepStatus.InProgress;

                    var repo = new ClientTimelineRepository();
                    repo.Post(_contactID, _definition.TimelineDefinitionID, firstNotStartedStep.StepID);

                }

            }

        } 

        #endregion

    }

}
