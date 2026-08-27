using System;
using System.Collections.Generic;
using Game.Services;

namespace Game.Core
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Initialize()
        {
            Register<AuthService>(new AuthService());
            Register<BattleService>(new BattleService());
            Register<SummonService>(new SummonService());
            Register<HeroService>(new HeroService());
        }

        public static void Register<T>(T service) where T : class =>
            _services[typeof(T)] = service;

        public static T Get<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var service))
                return (T)service;
            throw new InvalidOperationException($"Service {typeof(T).Name} not registered.");
        }
    }
}
