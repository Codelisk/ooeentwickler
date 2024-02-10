using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.controls.TextBlocks;
using ooeentwickleruno.viewmodels.ViewModels.Company.Show;
using Uno.Toolkit.UI;

namespace ooeentwickleruno.views.Views.Company.Show;

public partial class CompanyOverviewPage : RegionBasePage<CompanyOverviewPageViewModel>
{
    protected override UIElement MainContent(CompanyOverviewPageViewModel vm)
    {
        return new Grid()
            .HorizontalAlignment(HorizontalAlignment.Stretch)
            .VerticalAlignment(VerticalAlignment.Stretch)
            .Children(
                new Card()
                    .BorderThickness(3)
                    .BorderBrush("#F4F4F4")
                    .Style(StaticResource.Get<Style>("OutlinedCardStyle"))
                    .HeaderContent("Miele")
                    .SubHeaderContent(
                        "Stockham 44, 4664 Laakirchen\nMiele ist ein Unternehmen, das sich auf die Herstellung von Haushaltsgeräten spezialisiert hat."
                    )
                    .SubHeaderContentTemplate<string>(x => new DefaultTextBlock().Text(() => x))
                    .SupportingContent("test")
                    .SupportingContentTemplate(() =>
                    {
                        return new StackPanel()
                            .HorizontalAlignment(HorizontalAlignment.Stretch)
                            .Children(
                                new Divider().HorizontalAlignment(HorizontalAlignment.Stretch),
                                new DefaultTextBlock()
                                    .Text("C#, Java")
                                    .HorizontalAlignment(HorizontalAlignment.Center),
                                new Divider(),
                                new DefaultTextBlock()
                                    .Text("Jire, Github")
                                    .HorizontalAlignment(HorizontalAlignment.Center),
                                new Divider(),
                                new DefaultTextBlock()
                                    .Text("Xamarin Forms, Maui")
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                            );
                    })
            );
    }
}
