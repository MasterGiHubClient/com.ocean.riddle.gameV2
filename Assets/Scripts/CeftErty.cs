using System;
using System.Collections.Generic;

public class CeftErty
{
        private static CeftErty _instance;
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static CeftErty Instance => _instance ??= new CeftErty();
        
        private CeftErty()
        {
        }

        public void Register<TContract>(TContract obj)
        {
                var key = typeof(TContract);
                
                if (_services.ContainsKey(key))
                        throw new ArgumentException($"{key} instance is already registered");

                _services[key] = obj;
        }

        public TContract Get<TContract>()
        {
                var key = typeof(TContract);

                if (!_services.ContainsKey(key))
                        throw new ArgumentException($"{key} is not registered");

                return (TContract) _services[key];
        }

        public TContract Unregister<TContract>()
        {
                var obj = Get<TContract>();

                _services.Remove(typeof(TContract));

                return obj;
        }
}