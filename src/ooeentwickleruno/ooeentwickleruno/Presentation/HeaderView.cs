using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.Buttons;

namespace Sample.Presentation;
public partial class HeaderView : RegionBasePage<HeaderViewModel>
{
    public HeaderView()
    {
    }

    protected override UIElement MainContent(HeaderViewModel vm)
    {
        return new ElevatedView().Elevation(10).Background("#ffffff").ElevatedContent(
            new StackPanel().HorizontalAlignment(HorizontalAlignment.Stretch).Children(
            new Grid().HorizontalAlignment(HorizontalAlignment.Stretch).Margin(100, 0, 100, 0)
            .ColumnDefinitions("*,auto,auto")
            .Children(
            new TextBlock().Text("Foodora").FontSize(50).HorizontalAlignment(HorizontalAlignment.Stretch),
            new SecondaryButton().Content("Login").Grid(1).Margin(0,0,20,0),
            new PrimaryButton().Content("Sign up").Grid(2)
            )
            ));
    }
}
