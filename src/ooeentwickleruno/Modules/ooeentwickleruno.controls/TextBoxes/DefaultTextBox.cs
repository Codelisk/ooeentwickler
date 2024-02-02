using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwickleruno.controls.TextBoxes;
public class DefaultTextBox : TextBox
{
    public DefaultTextBox()
    {
        this.Style(new Style<TextBox>().BasedOn("OutlinedTextBoxStyle"));
    }
}
