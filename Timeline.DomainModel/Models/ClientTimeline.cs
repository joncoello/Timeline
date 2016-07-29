using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeline.DomainModel.Models {

    public class ClientTimeline {

        public List<ClientTimelineStep> Steps { get; private set; }

        public ClientTimeline() {
            Steps = new List<ClientTimelineStep>();
        }

    }

}
