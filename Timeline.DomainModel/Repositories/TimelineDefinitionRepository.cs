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
        
    }
}
