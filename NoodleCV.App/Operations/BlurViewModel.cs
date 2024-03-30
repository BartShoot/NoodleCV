using NoodleCV.App.CustomControls.ViewModel;

namespace NoodleCV.App.Operations;

public class BlurViewModel
{
    public CustomDropDownViewModel CustomDropDownViewModel { get; } = new(0, "Blur type",
        ["Box filter", "Gaussian blur", "Median blur", "Bilateral filtering"]);

    public CustomSliderViewModel CustomSliderViewModel { get; } = new(5, 100, "Blur Strength");
}