using System;

namespace DeveloperSample.Container
{
    using System;
    using System.Collections.Generic;

    public class Container
    {
        private Dictionary<Type, Type> typeMappings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException($"{implementationType.Name} does not implement {interfaceType.Name}");
            }

            typeMappings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        private object Get(Type type)
        {
            if (typeMappings.ContainsKey(type))
            {
                var implementationType = typeMappings[type];
                return Activator.CreateInstance(implementationType);
            }

            return Activator.CreateInstance(type);
        }
    }

}