using MYOB.CSS;
using MYOB.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Timeline.DomainModel.Models;

namespace Timeline.DomainModel.Repositories {

    public class TimelineDefinitionDetailsRepository {

        public TimelineDefinitionDetails Get(int definitionID) {

            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;

            string sql =
                "select * from wf.timelinedefinition where TimelineDefinitionID = @TimelineDefinitionID " +
                "select * from wf.timelinedefinitionstep where TimelineDefinitionID = @TimelineDefinitionID order by position ";

            var data = centralDal.GetDataset(sql, new DalParm[] {
                new DalParm("@TimelineDefinitionID", SqlDbType.VarChar, 0, definitionID)
            });

            var d = new TimelineDefinitionDetails() {
                TimelineDefinitionID = Convert.ToInt32(data.Tables[0].Rows[0]["TimelineDefinitionID"]),
                TimelineDefinitionName = Convert.ToString(data.Tables[0].Rows[0]["TimelineDefinitionName"])
            };

            foreach (DataRow row in data.Tables[1].Rows) {
                d.Steps.Add(new DefinitionStep() {
                    DefinitionStepID = Convert.ToInt32(row["TimelineDefinitionStepID"]),
                    DefinitionStepName = Convert.ToString(row["TimelineDefinitionStepName"])
                });
            }

            return d;

        }
        
        public void Post(TimelineDefinitionDetails timelineDefinition) {

            var centralDal = CssContext.Instance.GetDAL(string.Empty) as DAL;

            var doc = new XDocument(
                new XElement("definition",
                    timelineDefinition.Steps.Select(
                        s => new XElement("step",
                        new XAttribute("id", s.DefinitionStepID),
                        new XAttribute("name", s.DefinitionStepName),
                        new XAttribute("position", timelineDefinition.Steps.IndexOf(s))
                        ))));

            var xml = doc.ToString();

            var data = centralDal.RunSpReturnDs("WF.TimelineDefinition_Save", new DalParm[] {
                new DalParm("@TimelineDefinitionID", SqlDbType.Int, 0, timelineDefinition.TimelineDefinitionID),
                new DalParm("@TimelineDefinitionName", SqlDbType.VarChar, 0, timelineDefinition.TimelineDefinitionName),
                new DalParm("@steps", SqlDbType.Xml, 0, xml)
            });

            timelineDefinition.TimelineDefinitionID = Convert.ToInt32(data.Tables[0].Rows[0][0]);

        }

    }

}
