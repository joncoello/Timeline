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
                new TimelineDefinition() { TimelineDefinitionID=2, TimelineDefinitionName = "Accounts Production" }
            };

        }

        public TimelineDefinitionDetails Get(int definitionID) {

            var d = new TimelineDefinitionDetails() {
                TimelineDefinitionID = 1,
                TimelineDefinitionName = "Personal Tax"
            };

            d.Steps.Add(new DefinitionStep() { DefinitionStepID = 1, DefinitionStepName = "Step 1" });
            d.Steps.Add(new DefinitionStep() { DefinitionStepID = 1, DefinitionStepName = "Step 2" });
            d.Steps.Add(new DefinitionStep() { DefinitionStepID = 1, DefinitionStepName = "Step 3" });
            d.Steps.Add(new DefinitionStep() { DefinitionStepID = 1, DefinitionStepName = "Step 4" });

            return d;

        }
    }
}
