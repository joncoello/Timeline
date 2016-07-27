using MYOB.CSSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timeline.UI.Common {
    public class Menus : CSSMenus {

        public Menus() {
            ProductName = "Timeline";

            var mnuMaintenance = Add("mnuMaintenance", "Maintenance", MenuItemType.Group);
            var mnuTimeline = mnuMaintenance.Add("mnuTimeline", "Timeline", CSSMenuItem.MenuItemType.Group);
            mnuTimeline.Add("mnuTimelines", "Timelines", CSSMenuItem.MenuItemType.Item);
        }

        public override void PluginMenuClicked(object Sender, MenuEventArgs e) {
            
            switch (e.Key) {
                case "mnuTimelines":
                    MessageBox.Show("Hello");
                    break;
            }
            
        }
    }
}
