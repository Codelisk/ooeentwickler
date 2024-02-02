using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace ooeentwickleruno.controls.Buttons;
public class PrimaryButton : Button
{
    public PrimaryButton()
    {
        this.Style(new Style<Button>().BasedOn("FilledButtonStyle").Setters(s=>s.CornerRadius(6)));
    }
}
