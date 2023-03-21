using Microsoft.AspNetCore.Mvc;
using TodoAppNTier.Common.ResponseObjects;

namespace TodoAppNTier.UI.Extensions
{
    public static class ControllerExtension
    {
        //--------------------------------------------------------------------------
        public static IActionResult ResponseRedirectoAction<T>(this Controller controller, IResponse<T> response, string actionName)
        {
            if (response.ResponseType ==ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName);
        }
        //--------------------------------------------------------------------------



        //--------------------------------------------------------------------------
        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }
        //---------------------------------------------------------------------------






        //--------------------------------------------------------------------------
        public static IActionResult ResponseRedirectoAction(this Controller controller, IResponse response, string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            return controller.RedirectToAction(actionName);
        }
        //--------------------------------------------------------------------------
    }
}
