using Spralis.Web.Services;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Web;

namespace Spralis.Web
{
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAuthorizationService>().To<AuthorizationService>();
            kernel.Bind<IConfigurationService>().To<ConfigurationService>();
            kernel.Bind<IAPIService>().To<ESIService>();
        }
    }
}