using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
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
                new DefaultTextBox().PlaceholderText("Gründungsjahr"),
                TitleTextBlock().Text("Programmiersprachen"),
                new DefaultChipSelectionGroup()
                    .ItemsSource(() => vm.ProgrammingLanguages)
                    .SelectedItems(x => x.Bind(() => vm.SelectedProgrammingLanguages).TwoWay())
                    .ItemTemplate<ProgrammingLanguageDto>(x => new TextBlock().Text(() => x.Name)),
                TitleTextBlock().Text("Repositoryverwaltung"),
                new ComboBox()
                    .PlaceholderText("Repositoryverwaltung")
                    .ItemsSource(() => vm.RepositoryHostings)
                    .DisplayMemberPath("Name"),
                new ComboBox()
                    .PlaceholderText("Projektmanagment")
                    .ItemsSource(() => vm.IssueTrackers)
                    .DisplayMemberPath("Name"),
                new NumberBox()
                    .PlaceholderText("Anzahl Entwickler")
                    .SpinButtonPlacementMode(() => NumberBoxSpinButtonPlacementMode.Inline),
                new DefaultTextBox()
                    .PlaceholderText("Was macht Ihre Firma?")
                    .AcceptsReturn(true)
                    .TextWrapping(TextWrapping.Wrap)
                    .MinHeight(200),
                new DefaultTextBox()
                    .MinHeight(200)
                    .PlaceholderText("Wie sieht der Entwicklungsalltag aus in Ihrer Firma?")
                    .AcceptsReturn(true)
                    .TextWrapping(TextWrapping.Wrap),
                new DefaultTextBox().PlaceholderText("Karrierelink"),
                new DefaultTextBox().PlaceholderText("Webseitelink"),
                new ContentControl().RegionManager(regionName: "CompanyBenefitRegion"),
                new DefaultChipSelectionGroup()
                    .ItemsSource(() => vm.Industries)
                    .SelectedItems(x => x.Bind(() => vm.SelectedIndustries).TwoWay())
                    .ItemTemplate<IndustryDto>(x => new TextBlock().Text(() => x.Name))
            );

        return result;
    }
}
