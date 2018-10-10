using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pokno.Infrastructure.Models
{
    public class TreeViewOperation
    {
        public static void ClearTreeViewSelection(TreeView tv)
        {
            if (tv != null)
            {
                ClearTreeViewItemsControlSelection(tv.Items, tv.ItemContainerGenerator);
                tv.Focus();
            }
        }

        private static void ClearTreeViewItemsControlSelection(ItemCollection ic, ItemContainerGenerator icg)
        {
            if ((ic != null) && (icg != null))
            {
                for (int i = 0; i < ic.Count; i++)
                {
                    TreeViewItem tvi = icg.ContainerFromIndex(i) as TreeViewItem;
                    if (tvi != null)
                    {
                        ClearTreeViewItemsControlSelection(tvi.Items, tvi.ItemContainerGenerator);
                        if (tvi.IsSelected)
                        {
                            tvi.ExpandSubtree();
                        }
                       
                        tvi.IsSelected = false;
                    }

                    
                }
            }
        }



    }
}
