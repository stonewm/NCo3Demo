using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nco01;

namespace UnitTestProject1
{
    [TestClass]
    public class TestRfcConfig
    {
        [TestMethod]
        public void TestPingUsingConfig()
        {
            RfcDestUsingConfig rfc = new RfcDestUsingConfig();
            rfc.PingDestination();
        }
    }
}
