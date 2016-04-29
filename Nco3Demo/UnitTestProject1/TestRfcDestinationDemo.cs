using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nco01;

namespace UnitTestProject1
{
    [TestClass]
    public class TestRfcDestinationDemo
    {
        [TestMethod]
        public void TestPing()
        {
            RfcDestinationDemo rfc = new RfcDestinationDemo();
            rfc.PingDestination();
        }
    }
}
