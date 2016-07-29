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
using Timeline.DomainModel.Models;
using Timeline.DomainModel.Repositories;

namespace Timeline.UI.Client.ClientTimelineForm {

    public partial class frmClientTimeline : Form, ICSSClientFormPlugIn  {

        private int _clientID;

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
        }

        public void RefreshForm() {
            
        }

        public void SaveChanges(object sender, CSSChildSaveEventArgs e) {
            
        }

        #endregion

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

            grdSteps.RootTable = rt;
            grdSteps.ColumnAutoResize = true;
            grdSteps.VisualStyle = VisualStyle.Office2010;
            grdSteps.AlternatingColors = true;
            grdSteps.GroupByBoxVisible = false;

            col = rt.Columns.Add("Name");
            col.EditType = EditType.NoEdit;
            col.Selectable = false;

            col = rt.Columns.Add("Status");
            col.EditType = EditType.NoEdit;
            col.Selectable = false;
            col.Width = 60;
            col.AllowSize = false;

        }

        private void cboDefinition_ValueChanged(object sender, EventArgs e) {

            var definition = (cboDefinition.SelectedItem as TimelineDefinition);

            var repo = new ClientTimelineRepository();

            var timeline = repo.Get(_clientID, definition.TimelineDefinitionID);

            grdSteps.SetDataBinding(timeline.Steps, string.Empty);

        }

    }

}
