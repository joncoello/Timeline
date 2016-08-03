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

            if (data.Tables[1].Rows.Count > 0) {

                int selectedStepID = Convert.ToInt32(data.Tables[1].Rows[0]["TimelineDefinitionStepID"]);
                bool isComplete = Convert.ToBoolean(data.Tables[1].Rows[0]["IsComplete"]);

                var status = ClientTimelineStep.StepStatus.Complete;

                foreach (DataRow row in data.Tables[0].Rows) {

                    int stepID = Convert.ToInt32(row["TimelineDefinitionStepID"]);

                    if (selectedStepID == stepID && !isComplete) {
                        status = ClientTimelineStep.StepStatus.InProgress;
                    }

                    ct.Steps.Add(new ClientTimelineStep() {
                        StepID = stepID,
                        Name = Convert.ToString(row["TimelineDefinitionStepName"]),
                        Status = status
                    });

                    if (status == ClientTimelineStep.StepStatus.InProgress) {
                        status = ClientTimelineStep.StepStatus.NotStarted;
                    }

                }

            }

            return ct;

        }

        public void Patch(int contactID, int timelineDefinitionID, int stepID, bool isComplete) {
            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;
            centralDal.GetDataset(
                "update WF.ContactTimeline set TimelineDefinitionStepID = @stepid, iscomplete = @iscomplete where contactid = @contactid and TimelineDefinitionID = @TimelineDefinitionID",
                new DalParm[] {
                    new DalParm("stepid", SqlDbType.Int, 0, stepID),
                    new DalParm("iscomplete", SqlDbType.Bit, 0, isComplete),
                    new DalParm("contactid", SqlDbType.Int, 0, contactID),
                    new DalParm("timelineDefinitionID", SqlDbType.Int, 0, timelineDefinitionID)
                });
        }

        public void Post(int contactID, int timelineDefinitionID) {

            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;

            string sql =
                "insert into wf.ContactTimeline(ContactID, TimelineDefinitionID, TimelineDefinitionStepID, IsComplete) " +
                "select top 1 @ContactID, @TimelineDefinitionID, TimelineDefinitionStepID, 0 from wf.TimelineDefinitionStep where TimelineDefinitionID = @TimelineDefinitionID order by Position";

            centralDal.GetDataset(sql,
                new DalParm[] {
                    new DalParm("contactid", SqlDbType.Int, 0, contactID),
                    new DalParm("timelineDefinitionID", SqlDbType.Int, 0, timelineDefinitionID)
                });

        }

        public void Delete(int contactID, int timelineDefinitionID) {
            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;

            string sql =
                "delete from wf.ContactTimeline where TimelineDefinitionID = @TimelineDefinitionID and contactid = @contactid";

            centralDal.GetDataset(sql,
                new DalParm[] {
                    new DalParm("contactid", SqlDbType.Int, 0, contactID),
                    new DalParm("timelineDefinitionID", SqlDbType.Int, 0, timelineDefinitionID)
                });
        }
    }

}
