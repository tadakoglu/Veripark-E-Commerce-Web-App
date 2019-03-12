using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

using BilgiAlani.Varliklar;
using BilgiAlani.Soyut;
using BilgiAlani.Somut;
using Moq;
namespace WebArayuz.Altyapi
{
    public class NinjectBagimlilikCozucu : IDependencyResolver
    {
        
            private IKernel kernel;
            public NinjectBagimlilikCozucu(IKernel kernelParam)
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
                kernel.Bind<IUrunDeposu>().To<EFUrunDeposu>();

            }
        
    }
}