using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _038_Listen
{
    class IndexedListViewItem : ListViewItem
    {
        public Guid Uid
        {
            get;
        }
        public IndexedListViewItem(Guid Uid, String Name) : base(Name)
        {
            this.Uid = Uid;
        }
    }
}
