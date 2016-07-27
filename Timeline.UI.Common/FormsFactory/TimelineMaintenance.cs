using MYOB.CSSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeline.UI.Common.FormsFactory {
    public class TimelineMaintenance : FrameworkForm {
        protected override string AssemblyName {
            get {
                return "Timeline.UI.Maintenance.TimelineMaintenanceForm";
            }
        }

        protected override string ClassName {
            get {
                return "frmTimelineMaintenance";
            }
        }
    }
}
