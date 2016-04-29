using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCo03;

namespace UnitTestProject1
{
    [TestClass]
    public class TestSessionManagement
    {
        [TestMethod]
        public void Test_SessionManagement()
        {
            RfcSessionManagement rfc = new RfcSessionManagement();
            rfc.SessionManagementDemo();
        }
    }
}
