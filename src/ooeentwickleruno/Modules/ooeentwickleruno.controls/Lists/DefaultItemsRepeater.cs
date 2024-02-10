using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwickleruno.controls.Lists;

public class DefaultItemsRepeater : ItemsRepeater
{
    public DefaultItemsRepeater()
    {
        this.Layout(new UniformGridLayout()).HorizontalAlignment(HorizontalAlignment.Center);
    }
}
