using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Queue;

namespace UnitTestQueue
{
    [TestClass]
    public class UnitTestQueue
    {
        [TestMethod]
        public void CreateQueue()
        {
            var queue = new Queue<int>(100);
            Assert.IsNotNull(queue);
        }

        [TestMethod]
        public void PutElementQueue()
        {
            var queue = new Queue<int>(100);
            queue.Put(1);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetElementQueue()
        {
            var queue = new Queue<int>(100);
            queue.Put(1);
            var resVal = queue.Get();
            Assert.AreEqual(1, resVal);
        }

        [TestMethod]
        public void PutExtraElementToQueue()
        {
            var queue = new Queue<int>(10);
            for (int i = 0; i < 10; i++)
                queue.Put(i);
            Assert.ThrowsException<InvalidOperationException>(() => queue.Put(10));
        }

        [TestMethod]
        public void GetExtraElementFromQueue()
        {
            var queue = new Queue<int>(10);
            Assert.ThrowsException<InvalidOperationException>(() => queue.Get());
        }

        [TestMethod]
        public void CheckFiFoQueue()
        {
            var queue = new Queue<int>(10);
            for (int i = 0; i < 10; i++)
                queue.Put(i);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, queue.Get());
            }
        }
    }
}
