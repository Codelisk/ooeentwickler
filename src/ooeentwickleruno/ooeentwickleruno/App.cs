using Framework.UnoNative;
using Framework.UnoNative.Services;
using ooeentwickleruno.apiclient;
using Sample.Presentation;
using Uno.Core.Collections;
using Windows.UI.Core;

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
        new ooeentwickleruno.apiclient.ModuleInitializer().Configure<AuthenticationService>(
            services
        );
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        base.ConfigureModuleCatalog(moduleCatalog);

        moduleCatalog.AddModule<ooeentwickleruno.controls.ModuleInitializer>();
        moduleCatalog.AddModule<ooeentwickleruno.services.ModuleInitializer>();
        moduleCatalog.AddModule<ooeentwickleruno.views.ModuleInitializer>();
        moduleCatalog.AddModule<ooeentwickleruno.viewmodels.ModuleInitializer>();
    }
}
