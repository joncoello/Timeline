using MYOB.CSSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeline.UI.Common.FormsFactory {
    public class TimelineDetailsMaintenance : FrameworkForm {

        public int DefinitionID { get; private set; }

        public TimelineDetailsMaintenance(int definitionID) {
            DefinitionID = definitionID;
        }

        protected override string AssemblyName {
            get {
                return "Timeline.UI.Maintenance.TimelineDetailsMaintenanceForm";
            }
        }

        protected override string ClassName {
            get {
                return "frmTimelineDetailsMaintenance";
            }
        }
    }
}
