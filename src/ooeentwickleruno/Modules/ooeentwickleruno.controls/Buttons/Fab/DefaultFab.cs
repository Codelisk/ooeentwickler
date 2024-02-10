using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Material;
using Uno.Themes;

namespace ooeentwickleruno.controls.Buttons.Fab;

public partial class DefaultFab : Button
{
    public DefaultFab()
    {
        this.Style(StaticResource.Get<Style>("SmallFabStyle"));
        this.ControlExtensions(icon: new SymbolIcon().Symbol(Symbol.Add));
    }
}
