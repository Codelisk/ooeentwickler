using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.Buttons;
using ooeentwickleruno.controls.Buttons.Fab;
using ooeentwickleruno.controls.Chips;
using ooeentwickleruno.controls.TextBlocks;
using ooeentwickleruno.controls.TextBoxes;
using ooeentwickleruno.viewmodels.ViewModels.Company.CreateCompany;
using Uno.Material;
using Uno.Toolkit.UI;

namespace ooeentwickleruno.views.Views.Company.Create;

public partial class CreateCompanyPage : RegionBasePage<CreateCompanyPageViewModel>
{
    private static DefaultTextBlock TitleTextBlock()
    {
        return new DefaultTextBlock();
    }

    protected override UIElement MainContent(CreateCompanyPageViewModel vm)
    {
        var result = new StackPanel()
            .MaxWidth(700)
            .Padding(50)
            .Children(
                new DefaultTextBox()
                    .PlaceholderText("Name")
                    .Text(x => x.Bind(() => vm.Company.Name).Mode(BindingMode.TwoWay)),
                new ComboBox()
                    .PlaceholderText("Bezirk")
                    .ItemsSource(() => vm.AllDistricts)
                    .SelectedItem(x => x.Bind(() => vm.SelectedDistrict).TwoWay())
                    .DisplayMemberPath("Name"),
                TitleTextBlock().Text("Ort"),
                new DefaultTextBox()
                    .PlaceholderText("Gründungsjahr")
                    .Text(x => x.Bind(() => vm.Company.FoundingYear).Mode(BindingMode.TwoWay)),
                new DefaultTextBox()
                    .PlaceholderText("Straße")
                    .Text(x =>
                        x.Bind(() => vm.SelectedCompanyLocation.Street).Mode(BindingMode.TwoWay)
                    ),
                new DefaultTextBox()
                    .PlaceholderText("Plz")
                    .Text(x =>
                        x.Bind(() => vm.SelectedCompanyLocation.Zipcode).Mode(BindingMode.TwoWay)
                    ),
                new DefaultTextBox()
                    .PlaceholderText("Ort")
                    .Text(x =>
                        x.Bind(() => vm.SelectedCompanyLocation.City).Mode(BindingMode.TwoWay)
                    ),
                TitleTextBlock().Text("Programmiersprachen"),
                new DefaultChipSelectionGroup()
                    .ItemsSource(() => vm.AllProgrammingLanguages)
                    .SelectedItems(x => x.Bind(() => vm.SelectedProgrammingLanguages).TwoWay())
                    .ItemTemplate<ProgrammingLanguageDto>(x => new TextBlock().Text(() => x.Name)),
                TitleTextBlock().Text("Frameworks"),
                new DefaultChipSelectionGroup()
                    .ItemsSource(() => vm.AllProgrammingFrameworks)
                    .SelectedItems(x => x.Bind(() => vm.SelectedProgrammingFrameworks).TwoWay())
                    .ItemTemplate<ProgrammingFrameworkDto>(x => new TextBlock().Text(() => x.Name)),
                TitleTextBlock().Text("Repositoryverwaltung"),
                new ComboBox()
                    .PlaceholderText("Repositoryverwaltung")
                    .SelectedItem(x => x.Bind(() => vm.SelectedRepositoryHosting).TwoWay())
                    .ItemsSource(() => vm.AllRepositoryHostings)
                    .DisplayMemberPath("Name"),
                new ComboBox()
                    .PlaceholderText("Projektmanagment")
                    .SelectedItem(x => x.Bind(() => vm.SelectedIssueTracker).TwoWay())
                    .ItemsSource(() => vm.AllIssueTrackers)
                    .DisplayMemberPath("Name"),
                new NumberBox()
                    .PlaceholderText("Anzahl Entwickler")
                    .Value(x => x.Bind(() => vm.Company.DeveloperCount).Mode(BindingMode.TwoWay))
                    .SpinButtonPlacementMode(() => NumberBoxSpinButtonPlacementMode.Inline),
                new DefaultTextBox()
                    .PlaceholderText("Was macht Ihre Firma?")
                    .AcceptsReturn(true)
                    .Text(x => x.Bind(() => vm.Company.Description).Mode(BindingMode.TwoWay))
                    .TextWrapping(TextWrapping.Wrap)
                    .MinHeight(200),
                new DefaultTextBox()
                    .MinHeight(200)
                    .PlaceholderText("Wie sieht der Entwicklungsalltag aus in Ihrer Firma?")
                    .AcceptsReturn(true)
                    .Text(x =>
                        x.Bind(() => vm.Company.HowWeDevelopDescription).Mode(BindingMode.TwoWay)
                    )
                    .TextWrapping(TextWrapping.Wrap),
                new DefaultTextBox()
                    .PlaceholderText("Karrierelink")
                    .Text(x => x.Bind(() => vm.Company.CareerLink).Mode(BindingMode.TwoWay)),
                new DefaultTextBox()
                    .PlaceholderText("Webseitelink")
                    .Text(x => x.Bind(() => vm.Company.WebsiteLink).Mode(BindingMode.TwoWay)),
                new ContentControl().RegionManager(regionName: "CompanyBenefitRegion"),
                new DefaultChipSelectionGroup()
                    .ItemsSource(() => vm.AllIndustries)
                    .SelectedItems(x => x.Bind(() => vm.SelectedIndustries).TwoWay())
                    .ItemTemplate<IndustryDto>(x => new TextBlock().Text(() => x.Name)),
                new PrimaryButton().Content("Logo").Command(() => vm.AddLogoCommand),
                new PrimaryButton()
                    .Content("Präsentationsbild")
                    .Command(() => vm.AddPresentationImageCommand),
                new Button().Content("Hinzufügen").Command(() => vm.AddCompanyCommand)
            );

        return result;
    }
}
