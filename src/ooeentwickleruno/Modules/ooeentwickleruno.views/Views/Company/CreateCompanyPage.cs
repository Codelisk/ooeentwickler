using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.TextBlocks;
using ooeentwickleruno.controls.TextBoxes;
using ooeentwickleruno.viewmodels.ViewModels.Company;
using Uno.Toolkit.UI;

namespace ooeentwickleruno.views.Views.Company;
public partial class CreateCompanyPage : RegionBasePage<CreateCompanyPageViewModel>
{
    private static DefaultTextBlock TitleTextBlock()
    {
        return new DefaultTextBlock();
    }
    protected override UIElement MainContent(CreateCompanyPageViewModel vm)
    {
        return
            new StackPanel().MaxWidth(700).Padding(50).Children(
            new DefaultTextBox().PlaceholderText("Gründungsjahr"),
            TitleTextBlock().Text("Programmiersprachen"),
            new ChipGroup().Style(StaticResource.Get<Style>("SuggestionChipGroupStyle"))
            .SelectionMode(ChipSelectionMode.Multiple)
            .ItemsSource(() => vm.ProgrammingLanguages)
            .SelectedItems(x => x.Bind(() => vm.SelectedProgrammingLanguages).TwoWay())
            .ItemTemplate<ProgrammingLanguageDto>(x => new TextBlock().Text(() => x.Name)),
            TitleTextBlock().Text("Repositoryverwaltung"),
            new ComboBox().PlaceholderText("Repositoryverwaltung").ItemsSource(() => vm.RepositoryHostings).DisplayMemberPath("Name"),
            new ComboBox().PlaceholderText("Projektmanagment").ItemsSource(() => vm.IssueTrackers).DisplayMemberPath("Name"),
            new NumberBox().PlaceholderText("Anzahl Entwickler").SpinButtonPlacementMode(() => NumberBoxSpinButtonPlacementMode.Inline),
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
            TitleTextBlock().Text("Benefits"),
            TitleTextBlock().Text("Branchen"),
            new Button().Command(() => vm.TestCommand).Height(1000)
            );
    }
}
