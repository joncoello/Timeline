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

namespace Timeline.UI.Maintenance.TimelineDetailsMaintenanceForm {
    public partial class frmTimelineDetailsMaintenance : Form, ICSSDisplayMainArea {

        public frmTimelineDetailsMaintenance(TimelineDetailsMaintenance form) {
            InitializeComponent();
        }

        public int CollectionID { get; set; }

        public void CloseForm(object sender, CSSCancelEventArgs e) {
            this.Close();
        }

        public SideBarGroups Register() {
            this.Show();
            return new SideBarGroups("");
        }
    }
}
