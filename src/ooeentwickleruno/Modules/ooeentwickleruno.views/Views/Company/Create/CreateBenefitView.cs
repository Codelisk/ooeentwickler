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
using Uno.Toolkit.UI;

namespace ooeentwickleruno.views.Views.Company.Create;

public partial class CreateBenefitView : RegionBasePage<CreateBenefitViewModel>
{
    protected override UIElement MainContent(CreateBenefitViewModel vm)
    {
        var result = new WrapPanel()
            .Orientation(Orientation.Horizontal)
            .Children(
                new StackPanel()
                    .Spacing(10)
                    .VerticalAlignment(VerticalAlignment.Center)
                    .Children(
                        new DefaultTextBlock().Text("Firmenbenefit"),
                        new DefaultTextBox()
                            .PlaceholderText("Titel")
                            .Text(x =>
                                x.Bind(() => vm.CurrentBenefitTitle).Mode(BindingMode.TwoWay)
                            )
                            .AcceptsReturn(true)
                            .TextWrapping(TextWrapping.Wrap)
                            .Width(200),
                        new DefaultTextBox()
                            .Text(x =>
                                x.Bind(() => vm.CurrentBenefitDescription).Mode(BindingMode.TwoWay)
                            )
                            .PlaceholderText("Beschreibung")
                            .AcceptsReturn(true)
                            .TextWrapping(TextWrapping.Wrap)
                            .Width(200)
                    ),
                new DefaultFab()
                    .VerticalAlignment(VerticalAlignment.Center)
                    .VerticalContentAlignment(VerticalAlignment.Center)
                    .Command(x => x.Bind(() => vm.TestCommand)),
                new DefaultChipRemovalGroup()
                    .Assign(out var benefitChipGroup)
                    .ItemsSource(() => vm.SelectedBenefits)
                    .CanRemove(true)
                    .ItemTemplate<CompanyBenefitDto>(x => new TextBlock().Text(() => x.Title))
            );

        benefitChipGroup.ItemRemoved += (s, e) =>
        {
            ((s as ChipGroup).DataContext as CreateBenefitViewModel).SelectedBenefits.Remove(
                e.Item as CompanyBenefitDto
            );
        };
        return result;
    }
}
