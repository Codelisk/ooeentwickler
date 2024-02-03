using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.TextBlocks;
using ooeentwickleruno.viewmodels.ViewModels.Company;

namespace ooeentwickleruno.views.Views.Company;
public partial class CreateCompanyPage : RegionBasePage<CreateCompanyPageViewModel>
{
    private static DefaultTextBlock TitleTextBlock()
    {
        return new DefaultTextBlock();
    }
    protected override UIElement MainContent(CreateCompanyPageViewModel vm)
    {
        return new StackPanel().Children(
            TitleTextBlock().Text("Gründungsjahr"),
            TitleTextBlock().Text("Programmiersprachen"),
            TitleTextBlock().Text("Repositoryverwaltung"),
            TitleTextBlock().Text("Projektmanagment"),
            TitleTextBlock().Text("Anzahl Entwickler"),
            TitleTextBlock().Text("Was macht Ihre Firma?"),
            TitleTextBlock().Text("Wie sieht der Entwicklungsalltag aus in Ihrer Firma?"),
            TitleTextBlock().Text("Karrierelink"),
            TitleTextBlock().Text("Webseitelink"),
            TitleTextBlock().Text("Benefits"),
            TitleTextBlock().Text("Branchen")
            );
    }
}
