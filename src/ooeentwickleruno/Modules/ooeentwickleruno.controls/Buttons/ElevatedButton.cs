using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwickleruno.controls.Buttons;

public partial class ElevatedButton : PrimaryButton
{
    public ElevatedButton()
    {
        this.Style(StaticResource.Get<Style>("ElevatedButtonStyle"));
    }
}
