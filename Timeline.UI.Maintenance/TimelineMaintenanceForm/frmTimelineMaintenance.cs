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
using Timeline.UI.Common.FormsFactory;

namespace Timeline.UI.Maintenance.TimelineMaintenanceForm {
    public partial class frmTimelineMaintenance : Form, ICSSDisplayMainArea {

        #region ctor
        public frmTimelineMaintenance(TimelineMaintenance form) {
            InitializeComponent();
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

    }
}
