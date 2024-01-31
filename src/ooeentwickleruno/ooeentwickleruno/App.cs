using Framework.UnoNative;
using Framework.UnoNative.Services;
using Sample.Presentation;
using Uno.Core.Collections;
using ooeentwickleruno.apiclient;

namespace ooeentwickleruno;

public class App : BaseApp
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);
        containerRegistry.RegisterForNavigation<HeaderView, HeaderViewModel>();
        containerRegistry.RegisterForNavigation<BodyView, BodyViewModel>();
    }
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddApi<AuthenticationService>();
    }
}
