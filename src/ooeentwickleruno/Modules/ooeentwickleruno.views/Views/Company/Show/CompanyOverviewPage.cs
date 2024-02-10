using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.controls.TextBlocks;
using ooeentwickleruno.viewmodels.Models;
using ooeentwickleruno.viewmodels.ViewModels.Company.Show;
using Uno.Toolkit.UI;

namespace ooeentwickleruno.views.Views.Company.Show;

public partial class CompanyOverviewPage : RegionBasePage<CompanyOverviewPageViewModel>
{
    protected override UIElement MainContent(CompanyOverviewPageViewModel vm)
    {
        return new ItemsRepeater()
            .HorizontalAlignment(HorizontalAlignment.Stretch)
            .VerticalAlignment(VerticalAlignment.Stretch)
            .ItemsSource(() => vm.Companies)
            .ItemTemplate<CompanyOverviewModel>(x =>
                new Card()
                    .BorderThickness(3)
                    .BorderBrush("#F4F4F4")
                    .Style(StaticResource.Get<Style>("OutlinedCardStyle"))
                    .HeaderContent(() => x.Company)
                    .HeaderContentTemplate<CompanyDto>(x =>
                    {
                        return new TitleTextBlock()
                            .Text(() => x.Name)
                            .HorizontalAlignment(HorizontalAlignment.Center);
                    })
                    .SubHeaderContent(() => x.CompanyLocation)
                    .SubHeaderContentTemplate<CompanyLocationDto>(x =>
                        new DefaultTextBlock()
                            .Inlines(
                                new Run().Text(() => x.Street),
                                new Run().Text(", "),
                                new Run().Text(() => x.Zipcode),
                                new Run().Text(" "),
                                new Run().Text(() => x.City)
                            )
                            .Foreground("#7C8796")
                            .HorizontalAlignment(HorizontalAlignment.Center)
                    )
                    .SupportingContent(() => x)
                    .SupportingContentTemplate<CompanyOverviewModel>(x =>
                    {
                        return new StackPanel()
                            .HorizontalAlignment(HorizontalAlignment.Stretch)
                            .Children(
                                new Divider().HorizontalAlignment(HorizontalAlignment.Stretch),
                                new DefaultTextBlock()
                                    .Text(y =>
                                        y.Bind(() => x.Languages)
                                            .Convert(
                                                (languages) =>
                                                    string.Join(", ", languages.Select(x => x.Name))
                                            )
                                    )
                                    .HorizontalAlignment(HorizontalAlignment.Center),
                                new Divider(),
                                new DefaultTextBlock()
                                    .Text(y =>
                                        y.Bind(() => x.Frameworks)
                                            .Convert(
                                                (frameworks) =>
                                                    string.Join(
                                                        ", ",
                                                        frameworks.Select(x => x.Name)
                                                    )
                                            )
                                    )
                                    .HorizontalAlignment(HorizontalAlignment.Center),
                                new Divider(),
                                new DefaultTextBlock()
                                    .Text(y => y.Bind(() => x.RepositoryHosting.Name))
                                    .HorizontalAlignment(HorizontalAlignment.Center),
                                new Divider(),
                                new DefaultTextBlock()
                                    .Text(y => y.Bind(() => x.IssueTracker.Name))
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                            );
                    })
            );
    }
}
