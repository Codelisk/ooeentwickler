using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.controls.Buttons.Base;

namespace ooeentwickleruno.controls.Buttons;
public class SecondaryButton : BaseButton
{
    public SecondaryButton()
    {
        this.Style(new Style<Button>().BasedOn("OutlinedButtonStyle"));
    }
}
