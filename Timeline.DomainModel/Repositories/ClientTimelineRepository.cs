using MYOB.CSS;
using MYOB.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeline.DomainModel.Models;

namespace Timeline.DomainModel.Repositories {

    public class ClientTimelineRepository {

        public ClientTimeline Get(int contactID, int definitionID) {

            var ct = new ClientTimeline();

            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;

            var data =
                centralDal.GetDataset(
                    "select * from wf.TimelineDefinitionStep where TimelineDefinitionID = @timelineDefinitionID order by position " +
                    "select * from wf.ContactTimeline where contactID = @contactID and TimelineDefinitionID = @TimelineDefinitionID",
                    new DalParm[] {
                        new DalParm("@contactID", System.Data.SqlDbType.Int, 0, contactID),
                        new DalParm("@timelineDefinitionID", System.Data.SqlDbType.Int, 0, definitionID)
                    });

            var s = ClientTimelineStep.StepStatus.Complete;

            foreach (DataRow row in data.Tables[0].Rows) {
                ct.Steps.Add(new ClientTimelineStep() {
                    Name = Convert.ToString(row["TimelineDefinitionStepName"]),
                    Status = s
                });

                if (s == ClientTimelineStep.StepStatus.Complete) {
                    s = ClientTimelineStep.StepStatus.InProgress;
                } else if (s == ClientTimelineStep.StepStatus.InProgress) {
                    s = ClientTimelineStep.StepStatus.NotStarted;
                }

            }

            return ct;

        }

    }

}
