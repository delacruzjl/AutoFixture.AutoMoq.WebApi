namespace AutoFixture.AutoMoq.WebApi {

    public class ApiControllerConventions : CompositeCustomization {
        public ApiControllerConventions()
            : base(
                new HttpRequestMessageCustomization(),
                new ApiControllerCustomizationBase(),
                new AutoMoqCustomization()) {
        }
    }

}
