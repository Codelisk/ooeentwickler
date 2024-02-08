using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.controls.Chips.Base;
using Uno.Toolkit.UI;

namespace ooeentwickleruno.controls.Chips;

public partial class DefaultChipShowGroup : DefaultChipGroup
{
    public DefaultChipShowGroup()
    {
        this.IsTapEnabled = false;
        this.SelectionMode = ChipSelectionMode.None;
        this.Style(StaticResource.Get<Style>("SuggestionChipGroupStyle"));
    }
}
