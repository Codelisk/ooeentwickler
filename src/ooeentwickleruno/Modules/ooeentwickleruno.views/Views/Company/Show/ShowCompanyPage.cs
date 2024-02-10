using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.Chips;
using ooeentwickleruno.controls.Chips.Base;
using ooeentwickleruno.controls.Chips.SingleChip;
using ooeentwickleruno.controls.Lists;
using ooeentwickleruno.controls.TextBlocks;
using ooeentwickleruno.viewmodels.ViewModels.Company.Show;
using Uno.Toolkit.UI;

namespace ooeentwickleruno.views.Views.Company.Show;

public partial class ShowCompanyPage : RegionBasePage<ShowCompanyPageViewModel>
{
    protected override UIElement MainContent(ShowCompanyPageViewModel vm)
    {
        return new Grid()
            .Padding(0, 30, 0, 0)
            .Background("#F4F4F4")
            .Children(
                new StackPanel().Children(
                    new Image()
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .Stretch(Stretch.UniformToFill)
                        .Height(360)
                        .Source(() => vm.CompanyPresentationImage),
                    new Grid()
                        .MaxWidth(1200)
                        .Margin(20, 0, 20, 0)
                        .Background(Colors.White)
                        .Children(
                            new Border()
                                .BorderThickness(2)
                                .CornerRadius(4)
                                .VerticalAlignment(VerticalAlignment.Center)
                                .HorizontalAlignment(HorizontalAlignment.Center)
                                .BorderBrush("#F4F4F4")
                                .Translation(new System.Numerics.Vector3(0, -50, 0))
                                .Child(
                                    new Image()
                                        .Width(140)
                                        .Height(140)
                                        .Source(() => vm.CompanyLogo)
                                        .VerticalAlignment(VerticalAlignment.Stretch)
                                        .HorizontalAlignment(HorizontalAlignment.Stretch)
                                        .Stretch(Stretch.UniformToFill)
                                )
                        ),
                    new ElevatedView()
                        .Translation(new System.Numerics.Vector3(0, -50, 0))
                        .MaxWidth(1200)
                        .HorizontalAlignment(HorizontalAlignment.Stretch)
                        .CornerRadius(3)
                        .Background(Colors.White)
                        .Margin(20, 0, 20, 20)
                        .Elevation(1)
                        .ElevatedContent(
                            new StackPanel()
                                .MaxWidth(1000)
                                .Spacing(20)
                                .Children(
                                    new StackPanel()
                                        .Spacing(10)
                                        .HorizontalAlignment(HorizontalAlignment.Center)
                                        .Children(
                                            new TitleTextBlock()
                                                .Text("Show Company Page")
                                                .VerticalAlignment(VerticalAlignment.Top)
                                                .HorizontalAlignment(HorizontalAlignment.Center)
                                                .HorizontalTextAlignment(TextAlignment.Center),
                                            new DefaultTextBlock()
                                                .Inlines(
                                                    new Run().Text(() => vm.CompanyLocation.Street),
                                                    new Run().Text(", "),
                                                    new Run().Text(
                                                        () => vm.CompanyLocation.Zipcode
                                                    ),
                                                    new Run().Text(" "),
                                                    new Run().Text(() => vm.CompanyLocation.City)
                                                )
                                                .Foreground("#7C8796")
                                                .HorizontalAlignment(HorizontalAlignment.Center),
                                            new ItemsRepeater()
                                                .ItemsSource(() => vm.CompanyIndustries)
                                                .ItemTemplate<IndustryDto>(x =>
                                                    new DefaultTextBlock()
                                                        .Text(() => x.Name)
                                                        .Foreground("#7C8796")
                                                        .Margin(5)
                                                        .HorizontalAlignment(
                                                            HorizontalAlignment.Center
                                                        )
                                                ),
                                            new Divider().HorizontalAlignment(
                                                HorizontalAlignment.Stretch
                                            ),
                                            new StackPanel().Children(
                                                new DefaultChipShowGroup()
                                                    .ItemsSource(
                                                        () => vm.CompanyProgrammingLanguages
                                                    )
                                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                                    .ItemTemplate<ProgrammingLanguageDto>(x =>
                                                        new TextBlock().Text(() => x.Name)
                                                    ),
                                                new DefaultChipShowGroup()
                                                    .ItemsSource(() => vm.InfrastructureNames)
                                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                                    .ItemTemplate<string>(x =>
                                                        new TextBlock().Text(() => x)
                                                    ),
                                                new DefaultChipShowGroup()
                                                    .ItemsSource(
                                                        () => vm.CompanyProgrammingFrameworks
                                                    )
                                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                                    .ItemTemplate<ProgrammingFrameworkDto>(x =>
                                                        new TextBlock().Text(() => x.Name)
                                                    )
                                            ),
                                            new Divider().HorizontalAlignment(
                                                HorizontalAlignment.Stretch
                                            )
                                        ),
                                    new DefaultTextBlock().Text(() => vm.Company.Description),
                                    new TitleTextBlock()
                                        .Text("Wie wird bei uns entwickelt?")
                                        .VerticalAlignment(VerticalAlignment.Top)
                                        .HorizontalAlignment(HorizontalAlignment.Center)
                                        .HorizontalTextAlignment(TextAlignment.Center),
                                    new DefaultTextBlock().Text(
                                        () => vm.Company.HowWeDevelopDescription
                                    ),
                                    new TitleTextBlock()
                                        .Text("Benefits")
                                        .VerticalAlignment(VerticalAlignment.Top)
                                        .HorizontalAlignment(HorizontalAlignment.Center)
                                        .HorizontalTextAlignment(TextAlignment.Center),
                                    new DefaultItemsRepeater()
                                        .ItemsSource(() => vm.CompanyCompanyBenefits)
                                        .ItemTemplate<CompanyBenefitDto>(x =>
                                            new CardContentControl()
                                                .BorderBrush("#F4F4F4")
                                                .CornerRadius(5)
                                                .Margin(20)
                                                .Padding(10)
                                                .BorderThickness(3)
                                                .Style(
                                                    StaticResource.Get<Style>(
                                                        "OutlinedCardContentControlStyle"
                                                    )
                                                )
                                                .ContentTemplate(() =>
                                                {
                                                    return new Grid()
                                                        .Width(200)
                                                        .Height(200)
                                                        .Children(
                                                            new StackPanel()
                                                                .Spacing(10)
                                                                .HorizontalAlignment(
                                                                    HorizontalAlignment.Center
                                                                )
                                                                .Children(
                                                                    new DefaultBoldTextBlock()
                                                                        .FontSize(20)
                                                                        .HorizontalAlignment(
                                                                            HorizontalAlignment.Center
                                                                        )
                                                                        .Text(() => x.Title),
                                                                    new Divider().Width(100),
                                                                    new DefaultTextBlock()
                                                                        .HorizontalTextAlignment(
                                                                            TextAlignment.Center
                                                                        )
                                                                        .Text(() => x.Description)
                                                                )
                                                        );
                                                })
                                        )
                                )
                        )
                )
            );
    }
}
