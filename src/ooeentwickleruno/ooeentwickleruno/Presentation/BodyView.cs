using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.Buttons;

namespace Sample.Presentation;

public partial class BodyView : RegionBasePage<BodyViewModel>
{
    public BodyView() { }

    protected override UIElement MainContent(BodyViewModel vm)
    {
        return new Grid().Children(
            new CardContentControl()
                .Style(StaticResource.Get<Style>("ElevatedCardContentControlStyle"))
                .Width(300)
                .Height(250)
                .Content(
                    new Grid().Children(
                        new Image()
                            .Source(
                                "https://www.simpleimageresizer.com/_uploads/photos/e6cd4d6c/kateryna-ivasiva-86CYiW-WP1g-unsplash_400x300.jpg"
                            )
                            .VerticalAlignment(VerticalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center)
                            .Stretch(Stretch.UniformToFill),
                        new ElevatedButton()
                            .Content(x => x.Bind(() => vm.Test))
                            .Command(x => x.Bind(() => vm.NavigateCommand))
                            .VerticalAlignment(VerticalAlignment.Bottom)
                            .Margin(10)
                    )
                )
        );
    }
}
