namespace Timeline.DomainModel.Models {

    public class ClientTimelineStep {

        public enum StepStatus {
            NotStarted,
            InProgress,
            Complete
        }

        public string Name { get; set; }
        public StepStatus Status { get; set; }
    }

}