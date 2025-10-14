using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;

namespace Microsoft.eShopWeb.Web.Pages.Basket;

[Authorize]
public class SuccessModel : PageModel
{
    private readonly IFeatureManager _featureManager;

    public string SpecialMessage { get; private set; } = string.Empty;

    public SuccessModel(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async Task OnGet()
    {
        if (await _featureManager.IsEnabledAsync("EnableHalloweenTheme"))
        {
            SpecialMessage = "🎃 ¡Gracias por tu compra y feliz Halloween! 👻";
        }
    }
}
