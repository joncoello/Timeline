using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Timeline.UI.Homepage {
    public partial class ctlTimelines : HomepageBase {

        public ctlTimelines() {
            InitializeComponent();
        }

        public override string DisplayName {
            get {
                return "Timeline";
            }
        }

        public override void DefaultSettings() {
            
        }

        public override void LoadData(bool Cache, bool StartNewThread) {
            
        }

        public override void RestoreCustomisation(XmlElement Customisation) {
            
        }

        public override void SaveCustomisation(XmlTextWriter XW) {
            
        }

    }
}
