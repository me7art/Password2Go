using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class DIContainer
    {
        Dictionary<Type, object> _resolutions = new Dictionary<Type, object>();

        public void Register<T>(T instance)
            where T : class
        {
            _resolutions.Add(typeof(T), instance);
        }

        /// <summary>
        /// Home rule: use Resolve only in constructors!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return (T)(
                _resolutions
                .Where(x => x.Key == typeof(T))
                .Select(x => x.Value).Single()
                );
        }

        public bool CanResolve<T>()
        {
            return
                _resolutions.ContainsKey(typeof(T));
        }
    }
}
