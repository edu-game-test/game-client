using MetaFramework.Unity.Core;
using NUnit.Framework;

namespace MetaFramework.Unity.Tests
{
    public class SmokeTests
    {
        [SetUp] public void SetUp() => ServiceLocator.Clear();

        [Test]
        public void ServiceLocator_RegisterThenGet_ReturnsSameInstance()
        {
            var svc = new object();
            ServiceLocator.Register(svc);
            Assert.AreSame(svc, ServiceLocator.Get<object>());
        }

        [Test]
        public void ServiceLocator_TryGetMissing_ReturnsFalse()
        {
            Assert.IsFalse(ServiceLocator.TryGet<string>(out _));
        }
    }
}
