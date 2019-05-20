using Ninject;
using TextLand.BL.Modules;

namespace TextLand.WebApi
{
    internal class NinjectBootstrap
    {
        public static IKernel GetKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(new[] { new BlModule() });
            return kernel;
        }
    }
}
