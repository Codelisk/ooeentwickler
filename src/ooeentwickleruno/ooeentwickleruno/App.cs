using Framework.UnoNative;
using Sample.Presentation;

namespace ooeentwickleruno;

public class App : BaseApp
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);
        containerRegistry.RegisterForNavigation<HeaderView, HeaderViewModel>();
        containerRegistry.RegisterForNavigation<BodyView, BodyViewModel>();
    }
}
