using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.UnoNative.Views.Pages;
using ooeentwickleruno.controls.Buttons;
using ooeentwickleruno.controls.TextBoxes;

namespace ooeentwickleruno.views.Views.DataCreation;

public partial class CreateDistrictView : RegionBasePage<CreateDistrictViewModel>
{
    protected override UIElement MainContent(CreateDistrictViewModel vm)
    {
        return new StackPanel().Children(
            new ComboBox()
                .PlaceholderText("Gemeinden")
                .ItemsSource(() => vm.Districts)
                .SelectedItem(x => x.Bind(() => vm.District).Mode(BindingMode.TwoWay))
                .ItemTemplate<DistrictDto>(x => new TextBlock().Text(() => x.Name)),
            new DefaultTextBox()
                .PlaceholderText("Name")
                .Text(x => x.Bind(() => vm.District.Name).Mode(BindingMode.TwoWay)),
            new PrimaryButton()
                .Content("Logo hinzufügen")
                .Command(x => x.Bind(() => vm.AddLogoCommand)),
            new PrimaryButton().Content("Speichern").Command(x => x.Bind(() => vm.SaveCommand))
        );
    }
}
