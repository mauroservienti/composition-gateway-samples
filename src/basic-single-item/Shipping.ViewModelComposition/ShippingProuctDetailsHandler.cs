using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Shipping.ViewModelComposition
{
    public class ShippingProuctDetailsHandler : ServiceComposer.ViewModelComposition.IHandleRequests
    {
        public bool Matches(RouteData routeData, string httpVerb, HttpRequest request)
        {
            var controller = (string)routeData.Values["controller"];

            return HttpMethods.IsGet(httpVerb)
                && controller.ToLowerInvariant() == "sample"
                && routeData.Values.ContainsKey("id");
        }

        public Task Handle(string requestId, dynamic vm, RouteData routeData, HttpRequest request)
        {
            vm.ProductName = "Some product name";
            vm.ProductDescription = "This product is amazing, check it out!";

            return Task.CompletedTask;
        }
    }
}
