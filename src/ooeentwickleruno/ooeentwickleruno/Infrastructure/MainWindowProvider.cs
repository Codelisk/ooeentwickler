using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Services.Services.Application;

namespace ooeentwickleruno.Infrastructure;

internal class MainWindowProvider : IMainWindowProvider<Window>
{
    public Window MainWindow
    {
        get => App._window;
    }
}
