using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.Buttons;
using ooeentwickleruno.controls.TextBlocks;
using ooeentwickleruno.controls.TextBoxes;
using ooeentwickleruno.viewmodels.ViewModels.Account.Onboarding;
using Uno.Extensions.Markup.Generator;

namespace ooeentwickleruno.views.Views.Account.Onboarding;

public partial class RegisterPage : RegionBasePage<RegisterPageViewModel>
{
    protected override UIElement MainContent(RegisterPageViewModel vm)
    {
        return new Border()
            .BorderThickness(1)
            .BorderBrush("#CDCDCD")
            .Margin(0, 30, 0, 0)
            .Padding(50)
            .HorizontalAlignment(HorizontalAlignment.Center)
            .Child(
                new StackPanel()
                    .Spacing(30)
                    .Children(
                        new TitleTextBlock().Text("Erstelle deinen Account"),
                        new DefaultTextBox()
                            .PlaceholderText("Email")
                            .Text(x => x.Bind(() => vm.Email).Mode(BindingMode.TwoWay)),
                        new DefaultTextBox()
                            .PlaceholderText("Password")
                            .Text(x => x.Bind(() => vm.Password).Mode(BindingMode.TwoWay)),
                        new PrimaryExpandButton()
                            .Content("Account erstellen")
                            .HorizontalAlignment(HorizontalAlignment.Stretch)
                            .Command(() => vm.RegisterCommand)
                    )
            );
    }
}
