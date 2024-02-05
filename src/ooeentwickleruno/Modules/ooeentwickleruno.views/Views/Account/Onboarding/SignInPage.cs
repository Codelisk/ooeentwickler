using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using Microsoft.UI.Xaml;
using ooeentwickleruno.controls.Buttons;
using ooeentwickleruno.controls.TextBlocks;
using ooeentwickleruno.controls.TextBoxes;
using ooeentwickleruno.viewmodels.ViewModels.Account.Onboarding;

namespace ooeentwickleruno.views.Views.Account.Onboarding;
public partial class SignInPage : RegionBasePage<SignInPageViewModel>
{
    protected override UIElement MainContent(SignInPageViewModel vm)
    {
        return new Border().CornerRadius(6).BorderThickness(1).BorderBrush("#CDCDCD").Margin(0, 30, 0, 0).Padding(50).HorizontalAlignment(HorizontalAlignment.Center).Child(new StackPanel().Spacing(30)
            .Children(
            new TitleTextBlock().Text("Einloggen"),
            new StackPanel().Orientation(Orientation.Horizontal).Children(
            new DefaultBoldTextBlock().Text("Kein Account?").VerticalAlignment(VerticalAlignment.Center),
            new SecondaryButton().Content("Account erstellen").Margin(12,0,0,0).VerticalAlignment(VerticalAlignment.Center)
            ),
            new DefaultTextBox().PlaceholderText("Email").Text(x => x.Bind(() => vm.Email).TwoWay()),
            new DefaultTextBox().PlaceholderText("Password").Text(x => x.Bind(() => vm.Password).TwoWay()),
            new PrimaryExpandButton().Content("Einloggen").HorizontalAlignment(HorizontalAlignment.Stretch).Command(() => vm.SignInCommand)
            ));
    }
}
