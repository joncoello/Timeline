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

namespace Timeline.UI.Client.ClientTimelineForm {

    public partial class frmClientTimeline : Form, ICSSClientFormPlugIn  {

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
            
        }

        public void RefreshForm() {
            
        }

        public void SaveChanges(object sender, CSSChildSaveEventArgs e) {
            
        }

        #endregion

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            //FormatScreen();
            InitGrid();
            LoadData();
        }

        private void FormatScreen() {
            this.Text = "Timelines";
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = SystemColors.Window;
        }

        private void InitGrid() {
            
        }

        private void LoadData() {
            
        }
    }

}
