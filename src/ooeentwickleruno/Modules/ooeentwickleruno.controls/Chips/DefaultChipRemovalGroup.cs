using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.controls.Chips.Base;
using Uno.Toolkit.UI;

namespace ooeentwickleruno.controls.Chips;
public class DefaultChipRemovalGroup : DefaultChipGroup
{
    public DefaultChipRemovalGroup()
    {
        this.SelectionMode = ChipSelectionMode.None;
        CanRemove = true;
        ItemRemoved += (s, e) =>
        {
            var newItems= new List<object>(this.Items);
            newItems.Remove(e);
            this.ItemsSource = newItems;
            //this.SelectedItems.Remove(e.Item);
        };
        //this.Style(StaticResource.Get<Style>("InputChipGroupStyle"));
    }
}
