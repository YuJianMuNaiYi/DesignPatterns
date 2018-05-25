using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton.Third;

namespace Singleton.UnitTest.Third
{
    [TestClass]
    public class CounterFixture
    {
        private const int TestTimes = 10;

        private static IList<Counter> counters;

        /// <summary>
        ///     单线程模式
        /// </summary>
        [TestMethod]
        public void SequentialExecuteCounter()
        {
            var counter1 = Counter.Instance;
            var counter2 = Counter.Instance;

            Assert.IsTrue(counter1 == counter2);
            Assert.AreEqual(counter1.GetHashCode(), counter2.GetHashCode());
            Trace.WriteLine("counter1:" + counter1.GetHashCode());
            Trace.WriteLine("counter2:" + counter2.GetHashCode());

            var counter = Counter.Instance;
            for (var i = 0; i < TestTimes; i++)
            {
                var temp = counter.Next;
                Assert.AreEqual(i + 1, temp);
                Trace.WriteLine(string.Format("{0}----{1}", i + 1, temp));
            }

            counter.Reset();
            Trace.WriteLine("value=0后");
            for (var i = 0; i < TestTimes; i++)
            {
                var temp = counter.Next;
                Assert.AreEqual(i + 1, temp);
                Trace.WriteLine(string.Format("{0}----{1}", i + 1, temp));
            }
        }

        [TestMethod]
        public void ParallelExecuteCounter()
        {
            counters = new List<Counter>();
            TestHarness.Parallel(ThreadBody,ThreadBody,ThreadBody);
            //验证只有唯一实例
            Assert.AreEqual(1,counters.Distinct().Count());
            Trace.WriteLine("counters集合的个数:"+counters.Distinct().Count());
            //验证唯一实例执行正常
            var value = Counter.Instance.Next;
            Assert.AreEqual(1, value);
            Trace.WriteLine(value);
        }
        
        private void ThreadBody()
        {
            for (var i = 0; i < TestTimes; i++)
            {
                Thread.Sleep(new Random().Next()%53);
                counters.Add(Counter.Instance);
            }
        }
    }
}