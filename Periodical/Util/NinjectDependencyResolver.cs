using System;
using System.Collections.Generic;
using Ninject;
using BLL.Services;
using BLL.Interfaces;
using BLL.Providers;
using System.Web.Mvc;

namespace Periodical.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IEditionsService>().To<EditionsService>();
            kernel.Bind<IArticlesService>().To<ArticlesService>();
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IPeriodicalMembershipProvider>().To<PeriodicalMembershipProvider>();           
        }
    }
}