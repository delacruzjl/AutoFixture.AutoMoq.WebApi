using AutoFixture.Kernel;
using System;
using System.Net.Http;
using System.Web.Http;

namespace AutoFixture.AutoMoq.WebApi {
    internal class ApiControllerCustomizationBase : ICustomization {
        public void Customize(IFixture fixture) {
            fixture.Customizations.Add(
            new FilteringSpecimenBuilder(
                new Postprocessor(
                    new MethodInvoker(
                        new ModestConstructorQuery()),
                    new ApiControllerFiller()),
                new ApiControllerSpecification()));
        }

        private class ApiControllerFiller : ISpecimenCommand {
            public void Execute(object specimen, ISpecimenContext context) {
                var target = specimen as ApiController;
                GuardSpecimenInputs(specimen, context, target);

                target.Request = (HttpRequestMessage)context.Resolve(typeof(HttpRequestMessage));
            }

            private static void GuardSpecimenInputs(
                object specimen, ISpecimenContext context, ApiController target) {

                if (specimen == null)
                    throw new ArgumentNullException("specimen");

                if (context == null)
                    throw new ArgumentNullException("context");

                if (target == null)
                    throw new ArgumentException(
                        "The specimen must be an instance of ApiController.",
                        "specimen");
            }
        }

        private class ApiControllerSpecification : IRequestSpecification {
            public bool IsSatisfiedBy(object request) {
                var requestType = request as Type;
                if (requestType == null)
                    return false;

                return typeof(ApiController).IsAssignableFrom(requestType);
            }
        }

    }
}
