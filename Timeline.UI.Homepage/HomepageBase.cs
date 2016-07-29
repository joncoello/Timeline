using MYOB.CSSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Timeline.UI.Homepage {

    public class HomepageBase : HomePageItem {

        internal HomepageBase() {} // prevent central creating abse type

        public override string ApplicationName {
            get {
                return "Timeline";
            }
        }

        public override string DisplayName {
            get {
                throw new NotImplementedException();
            }
        }

        public override void DefaultSettings() {
            throw new NotImplementedException();
        }

        public override void LoadData(bool Cache, bool StartNewThread) {
            throw new NotImplementedException();
        }

        public override void RestoreCustomisation(XmlElement Customisation) {
            throw new NotImplementedException();
        }

        public override void SaveCustomisation(XmlTextWriter XW) {
            throw new NotImplementedException();
        }
    }

}
