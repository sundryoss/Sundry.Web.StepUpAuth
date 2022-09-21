using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Sundry.Web.StepUpAuth.Extension
{
    public static class NavigationManagerExtensions
    {
        public static void NavigateToMFA(this NavigationManager manager, string loginPath= "authentication/login", string paramName = "acr_values", string paramValue = "http://schemas.openid.net/pape/policies/2007/06/multi-factor")
        {
                InteractiveRequestOptions requestOptions = new()
                {
                    Interaction = InteractionType.SignIn,
                    ReturnUrl = manager.Uri,
                };
                requestOptions.TryAddAdditionalParameter(paramName, paramValue);
                manager.NavigateToLogin(loginPath, requestOptions);
        }

    }


}
