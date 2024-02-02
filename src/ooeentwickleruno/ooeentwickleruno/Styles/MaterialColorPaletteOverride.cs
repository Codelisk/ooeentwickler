using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwickleruno.Styles;
public sealed partial class MaterialColorPaletteOverride : ResourceDictionary
{
    private const string PrimaryColor = "#FFFFFF";
    private const string SecondaryColor = "#000000";
    public MaterialColorPaletteOverride()
    {
        this.Build
        (
            r => r
                .Add(Uno.Themes.Markup.Theme.Colors.Primary.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Primary.Inverse, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Primary.Container, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnPrimary.Default, light: SecondaryColor, dark: SecondaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnPrimary.Container, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Secondary.Default, light: SecondaryColor, dark: SecondaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Secondary.Container, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnSecondary.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnSecondary.Container, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Tertiary.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Tertiary.Container, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnTertiary.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnTertiary.Container, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Error.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Error.Container, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnError.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnError.Container, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Background.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnBackground.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Surface.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Surface.Variant, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Surface.Inverse, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Surface.Tint, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnSurface.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnSurface.Variant, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.OnSurface.Inverse, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Outline.Default, light: PrimaryColor, dark: PrimaryColor)
.Add(Uno.Themes.Markup.Theme.Colors.Outline.Variant, light: PrimaryColor, dark: PrimaryColor));

    }
}
