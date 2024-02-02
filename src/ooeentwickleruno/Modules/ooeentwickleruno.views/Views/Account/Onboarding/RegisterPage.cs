using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.viewmodels.ViewModels.Account.Onboarding;

namespace ooeentwickleruno.views.Views.Account.Onboarding;
public partial class RegisterPage : RegionBasePage<RegisterPageViewModel>
{
    protected override UIElement MainContent(RegisterPageViewModel vm)
    {
        return new StackPanel()
            .Children(
            new TextBox().PlaceholderText("Email"),
            new TextBox().PlaceholderText("Password")
            );
    }
}
