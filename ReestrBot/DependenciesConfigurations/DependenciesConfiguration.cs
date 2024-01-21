using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Ninject;
using Ninject.Modules;

namespace ReestrBot.DependenciesConfigurations
{
    internal class DependenciesConfiguration : NinjectModule
    {

        private readonly IKernel _kernel;

        public DependenciesConfiguration(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Загрузка связок интерфейсов с реализацией 
        /// </summary>
        public override void Load()
        {
            // Работа с тестовыми данными
            new LoadTest(_kernel).Load();
            // Работа с боевыми данными
            //new LoadProd(_kernel).Load();
        }
    }
}
