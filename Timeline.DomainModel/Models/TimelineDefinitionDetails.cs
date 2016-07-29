using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeline.DomainModel.Models {

    public class TimelineDefinitionDetails {

        public int TimelineDefinitionID { get; set; }
        public string TimelineDefinitionName { get; set; }
        public BindingList<DefinitionStep> Steps { get; private set; }

        public TimelineDefinitionDetails() {
            Steps = new BindingList<DefinitionStep>();
        }

    }

}
