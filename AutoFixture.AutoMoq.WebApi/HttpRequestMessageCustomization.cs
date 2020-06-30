using AutoFixture.Dsl;
using AutoFixture.Kernel;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace AutoFixture.AutoMoq.WebApi {
    public class HttpRequestMessageCustomization : ICustomization {
        public void Customize(IFixture fixture) {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            ComposeFakeRequest(fixture, config);
        }

        private static void ComposeFakeRequest(IFixture fixture, HttpConfiguration config) {
            fixture.Customize(CustomizeRequestComposer());

            Func<ICustomizationComposer<HttpRequestMessage>, ISpecimenBuilder> CustomizeRequestComposer() {
                return composer => composer
                    .Without(request => request.Content)
                    .Do(request => request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config);
            }
        }
    }
}
