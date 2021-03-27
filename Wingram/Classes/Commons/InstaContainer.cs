using Autofac;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingram.Classes.Commons
{
    public class InstaContainer
    {
        private static InstaContainer _instance = new InstaContainer();
        private ConcurrentDictionary<int, IContainer> _containers = new ConcurrentDictionary<int, IContainer>();

        public static InstaContainer Current
        {
            get
            {
                return _instance;
            }
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            foreach (var container in _containers.Values)
            {
                if (container != null)
                {
                    yield return container.Resolve<T>();
                }
            }
        }

        public Autofac.IContainer Build(int number, Func<ContainerBuilder, int, Autofac.IContainer> factory)
        {
            var builder = new ContainerBuilder();
           

            return _containers[number] = factory(builder, number);
        }

        public void Destroy(int id)
        {
            if (_containers.TryRemove(id, out IContainer container))
            {
                container.Dispose();
            }
        }

        public TService Resolve<TService>()
        {
           

            var result = default(TService);
            //if (_containers.TryGetValue(account, out IContainer container))
            if (_containers.TryGetValue(1, out IContainer container))
            {
                result = container.Resolve<TService>();
            }

            return result;
        }

      
    }
}
