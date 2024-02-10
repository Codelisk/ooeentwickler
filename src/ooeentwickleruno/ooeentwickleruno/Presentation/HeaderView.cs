using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.Buttons;
using ooeentwickleruno.controls.TextBoxes;

namespace Sample.Presentation;

public partial class HeaderView : RegionBasePage<HeaderViewModel>
{
    public HeaderView() { }

    protected override UIElement MainContent(HeaderViewModel vm)
    {
        return new ElevatedView()
            .Elevation(10)
            .Background("#ffffff")
            .ElevatedContent(
                new StackPanel()
                    .HorizontalAlignment(HorizontalAlignment.Stretch)
                    .Children(
                        new Grid()
                            .HorizontalAlignment(HorizontalAlignment.Stretch)
                            .Margin(100, 0, 100, 0)
                            .ColumnDefinitions("*,auto,auto,auto,auto")
                            .Children(
                                new TextBlock()
                                    .Text("Foodora")
                                    .FontSize(50)
                                    .HorizontalAlignment(HorizontalAlignment.Stretch)
                                    .MaxLines(1),
                                new DefaultTextBox()
                                    .PlaceholderText("Navigiere")
                                    .Grid(1)
                                    .Margin(0, 0, 20, 0)
                                    .Text(x => x.Bind(() => vm.ViewName).Mode(BindingMode.TwoWay)),
                                new PrimaryButton()
                                    .Content("Navigiere")
                                    .Grid(2)
                                    .Command(() => vm.NavigateCommand),
                                new SecondaryButton()
                                    .Content("Login")
                                    .Grid(3)
                                    .Margin(0, 0, 20, 0)
                                    .Command(() => vm.SignInCommand),
                                new PrimaryButton()
                                    .Content("Sign up")
                                    .Grid(4)
                                    .Command(() => vm.RegisterCommand)
                            )
                    )
            );
    }
}
