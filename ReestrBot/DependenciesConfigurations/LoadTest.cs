using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Interfaces;
using Ninject;
using Ninject.Modules;
using TestData.Providers;

namespace ReestrBot.DependenciesConfigurations
{
    public class LoadTest
    {
        private readonly IKernel _kerne;
        public LoadTest(IKernel kernel)
        {
            _kerne = kernel;
        }

        /// <summary>
        /// Загрузка связок интерфейсов с тестовыми данными
        /// </summary>
        public void Load()
        {
            BindProviders();
        }

        /// <summary>
        /// Прокидывание связок между интерфейсами и тестовыми данными
        /// </summary>
        private void BindProviders()
        {
            _kerne.Bind<IButtonsProvider>().To<ButtonsProviderTest>();
            _kerne.Bind<IPhotosProvider>().To<PhotosProviderTest>();
            _kerne.Bind<IMessagesProvider>().To<MessagesProviderTest>();
        }
    }

}
