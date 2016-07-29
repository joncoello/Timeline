using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeline.DomainModel.Models {

    public class ClientTimeline {

        public BindingList<ClientTimelineStep> Steps { get; private set; }

        public ClientTimeline() {
            Steps = new BindingList<ClientTimelineStep>();
        }

    }

}
