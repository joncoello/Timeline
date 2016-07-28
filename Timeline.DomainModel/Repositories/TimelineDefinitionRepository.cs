using MYOB.CSS;
using MYOB.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeline.DomainModel.Models;

namespace Timeline.DomainModel.Repositories {
    public class TimelineDefinitionRepository {

        public BindingList<TimelineDefinition> Get() {

            var definitions = new BindingList<TimelineDefinition>();

            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;

            string sql =
                "select * from wf.timelinedefinition";

            var data = centralDal.GetDataset(sql);

            //return new List<TimelineDefinition>() {
            //    new TimelineDefinition() { TimelineDefinitionID=1, TimelineDefinitionName = "Personal Tax" },
            //    new TimelineDefinition() { TimelineDefinitionID=2, TimelineDefinitionName = "Accounts Production" }
            //};

            foreach (DataRow row in data.Tables[0].Rows) {
                definitions.Add(new TimelineDefinition() {
                    TimelineDefinitionID = Convert.ToInt32(row["TimelineDefinitionID"]),
                    TimelineDefinitionName = Convert.ToString(row["TimelineDefinitionName"])
                });
            }

            return definitions;

        }

        public TimelineDefinitionDetails Get(int definitionID) {

            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;

            string sql =
                "select * from wf.timelinedefinition where TimelineDefinitionID = @TimelineDefinitionID";

            var data = centralDal.GetDataset(sql, new DalParm[] {
                new DalParm("@TimelineDefinitionID", SqlDbType.VarChar, 0, definitionID)
            });

            var d = new TimelineDefinitionDetails() {
                TimelineDefinitionID = Convert.ToInt32(data.Tables[0].Rows[0]["TimelineDefinitionID"]),
                TimelineDefinitionName = Convert.ToString(data.Tables[0].Rows[0]["TimelineDefinitionName"])
            };

            d.Steps.Add(new DefinitionStep() { DefinitionStepID = 1, DefinitionStepName = "Step 1" });
            d.Steps.Add(new DefinitionStep() { DefinitionStepID = 1, DefinitionStepName = "Step 2" });
            d.Steps.Add(new DefinitionStep() { DefinitionStepID = 1, DefinitionStepName = "Step 3" });
            d.Steps.Add(new DefinitionStep() { DefinitionStepID = 1, DefinitionStepName = "Step 4" });

            return d;

        }

        public void Post(TimelineDefinition timelineDefinition) {

            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;

            string sql =
                "insert into wf.timelinedefinition " +
                "values(@name) " +
                "select SCOPE_IDENTITY()";

            var data = centralDal.GetDataset(sql, new DalParm[] {
                new DalParm("@name", SqlDbType.VarChar, 0, timelineDefinition.TimelineDefinitionName)
            });

            timelineDefinition.TimelineDefinitionID = Convert.ToInt32(data.Tables[0].Rows[0][0]);
            
        }

    }
}
