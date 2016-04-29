using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCo03;

namespace UnitTestProject1
{
    [TestClass]
    public class TestTRFC
    {
        [TestMethod]
        public void Test_WriteTCPIC()
        {
            TRfc rfc = new TRfc();
            rfc.WriteTCPIC();
        }

        [TestMethod]
        public void Test_WriteTCPIC2()
        {
            TRfc rfc = new TRfc();
            rfc.WriteTCPIC2();
        }
    }
}
