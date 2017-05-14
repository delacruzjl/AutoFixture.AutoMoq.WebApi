using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace AutoFixture.AutoMoq.ApiControllerConventions
{

    public class ApiControllerConventions : CompositeCustomization
    {
        public ApiControllerConventions()
            : base(
                new HttpRequestMessageCustomization(),
                new ApiControllerCustomizationBase(),
                new AutoMoqCustomization())
        {
        }
    }

}
