using System.Web.Mvc;

namespace IU.Plan.Web.Bindings
{
    public class BrowserValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new BrowserValueProvider(controllerContext);
        }
    }
}