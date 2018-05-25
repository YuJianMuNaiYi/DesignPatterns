using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton.UnitTest.Threading
{
    /// <summary>
    /// 桌面应用中细颗粒度
    /// </summary>   
    [TestClass]
    public class DesktopSingletonFixture
    {
        public class ThreadScopedSingleton
        {
            ThreadScopedSingleton() { }

            [ThreadStatic]// 说明每个Instance仅在当前线程内为静态
            private static ThreadScopedSingleton instance;

            public static ThreadScopedSingleton Instance
            {
                get { return instance ?? (instance = new ThreadScopedSingleton()); }
            }
        }

         static IList<ThreadScopedSingleton> registry;

        private const int TestTime = 10;

        [TestMethod]
        public void Test()
        {
            registry=new List<ThreadScopedSingleton>();

            TestHarness.Parallel(ThreadBody,ThreadBody,ThreadBody);

            Assert.AreEqual(3,registry.Distinct().Count());
            Trace.WriteLine("registry集合的个数:"+registry.Distinct().Count());
        }

        void ThreadBody()
        {
            ThreadScopedSingleton instance = ThreadScopedSingleton.Instance;

            for (int i = 0; i < TestTime; i++)
            {
                Assert.IsTrue(instance==ThreadScopedSingleton.Instance);
                Trace.WriteLine("instance:"+instance.GetHashCode());
                Trace.WriteLine("ThreadScopedSingleton:"+ThreadScopedSingleton.Instance.GetHashCode());
            }
            registry.Add(instance);
        }
    }
}
