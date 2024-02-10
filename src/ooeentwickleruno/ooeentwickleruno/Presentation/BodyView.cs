using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using Microsoft.UI.Xaml.Media.Imaging;
using ooeentwickleruno.controls.Buttons;

namespace Sample.Presentation;

public partial class BodyView : RegionBasePage<BodyViewModel>
{
    public BodyView() { }

    protected override UIElement MainContent(BodyViewModel vm)
    {
        return new Grid().Children(
            new ItemsRepeater()
                .ItemsSource(() => vm.Districts)
                .ItemTemplate<(DistrictDto, BitmapImage)>(x =>
                {
                    return new CardContentControl()
                        .Style(StaticResource.Get<Style>("ElevatedCardContentControlStyle"))
                        .Width(300)
                        .Height(250)
                        .Content(
                            new Grid().Children(
                                new Image()
                                    .Source(() => x.Item2)
                                    .VerticalAlignment(VerticalAlignment.Center)
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                    .Stretch(Stretch.UniformToFill),
                                new ElevatedButton()
                                    .Content(() => x.Item1)
                                    .Command(x => x.Bind(() => vm.NavigateCommand))
                                    .VerticalAlignment(VerticalAlignment.Bottom)
                                    .Margin(10)
                            )
                        );
                })
        );
    }
}
