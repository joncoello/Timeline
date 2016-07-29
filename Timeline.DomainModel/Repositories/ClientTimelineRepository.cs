using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeline.DomainModel.Models;

namespace Timeline.DomainModel.Repositories {

    public class ClientTimelineRepository {

        public ClientTimeline Get(int clientID, int definitionID) {

            var ct = new ClientTimeline();

            ct.Steps.Add(new ClientTimelineStep() {
                Name = "Step1",
                Status = ClientTimelineStep.StepStatus.Complete
            });

            ct.Steps.Add(new ClientTimelineStep() {
                Name = "Step2",
                Status = ClientTimelineStep.StepStatus.Complete
            });

            ct.Steps.Add(new ClientTimelineStep() {
                Name = "Step3",
                Status = ClientTimelineStep.StepStatus.InProgress
            });

            ct.Steps.Add(new ClientTimelineStep() {
                Name = "Step4",
                Status = ClientTimelineStep.StepStatus.NotStarted
            });

            return ct;

        }

    }

}
