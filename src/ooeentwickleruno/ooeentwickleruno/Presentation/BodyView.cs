using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Framework.UnoNative.Views.Pages;
using Microsoft.UI.Xaml.Media.Imaging;
using ooeentwickleruno.controls.Buttons;
using ooeentwickleruno.viewmodels.Models;

namespace Sample.Presentation;

public partial class BodyView : RegionBasePage<BodyViewModel>
{
    public BodyView() { }

    protected override UIElement MainContent(BodyViewModel vm)
    {
        return new Grid().Children(
            new ItemsRepeater()
                .Layout(new UniformGridLayout())
                .ItemsSource(() => vm.Districts)
                .ItemTemplate<DistrictBitmapModel>(x =>
                {
                    var result = new CardContentControl()
                        .Style(StaticResource.Get<Style>("ElevatedCardContentControlStyle"))
                        .Width(300)
                        .Assign(out var card)
                        .Height(250)
                        .Content(
                            new Grid().Children(
                                new Image()
                                    .Source(() => x.Bitmap)
                                    .VerticalAlignment(VerticalAlignment.Center)
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                    .Stretch(Stretch.UniformToFill),
                                new ElevatedButton()
                                    .Content(() => x.District.Name)
                                    .VerticalAlignment(VerticalAlignment.Bottom)
                                    .Margin(10)
                            )
                        );
                    result.Tapped += (s, e) =>
                    {
                        var dc = GetDataContext();
                        dc.DistrictTappedAsync(
                                (
                                    (s as CardContentControl).DataContext as DistrictBitmapModel
                                ).District
                            )
                            .SafeFireAndForget();
                    };
                    return result;
                })
        );
    }
}
