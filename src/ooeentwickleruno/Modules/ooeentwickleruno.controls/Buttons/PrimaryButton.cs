using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ooeentwickleruno.controls.Buttons.Base;

namespace ooeentwickleruno.controls.Buttons;

public class PrimaryButton : BaseButton
{
    public PrimaryButton()
    {
        this.Style(new Style<Button>().BasedOn("FilledButtonStyle"));
    }
}
