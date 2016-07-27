using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeline.DomainModel.Models;

namespace Timeline.DomainModel.Repositories {
    public class TimelineDefinitionRepository {

        public List<TimelineDefinition> Get() {


            return new List<TimelineDefinition>() {
                new TimelineDefinition() { TimelineDefinitionID=1, TimelineDefinitionName = "Personal Tax" },
                new TimelineDefinition() { TimelineDefinitionID=1, TimelineDefinitionName = "Accounts Production" }
            };
        }

    }
}
