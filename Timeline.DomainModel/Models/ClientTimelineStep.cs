using System;
using System.ComponentModel;

namespace Timeline.DomainModel.Models {

    public class ClientTimelineStep : INotifyPropertyChanged {

        public enum StepStatus {
            NotStarted,
            InProgress,
            Complete
        }

        public string Name { get; set; }

        private StepStatus _status;
        public StepStatus Status {
            get {
                return _status;
            }
            set {
                if (value != _status) {
                    _status = value;
                    FirePropertyChanged("Status");
                }
            }
        }

        public int StepID { get; set; }

        internal void FirePropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}