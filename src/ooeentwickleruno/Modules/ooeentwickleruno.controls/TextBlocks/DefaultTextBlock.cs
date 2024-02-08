using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwickleruno.controls.TextBlocks;

public class DefaultTextBlock : TextBlock
{
    public DefaultTextBlock()
    {
        this.TextWrapping(TextWrapping.Wrap).TextTrimming(TextTrimming.CharacterEllipsis);
    }
}
