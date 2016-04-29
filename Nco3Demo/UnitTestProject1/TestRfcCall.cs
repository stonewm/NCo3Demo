using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCo02;
using System.Collections;


namespace UnitTestProject1
{
    [TestClass]
    public class TestRfcCall
    {
        [TestMethod]
        public void Test_RfcCall()
        {
            RfcCall rfc = new RfcCall();
            ArrayList list = rfc.GetCocdInfo("0001");

            foreach (String item in list) {
                System.Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void Test_ListFunctionParameters()
        {
            RfcCall rfc = new RfcCall();
            rfc.ListFunctionParameters("RFC_READ_TABLE");
        }

        [TestMethod]
        public void Test_GetCocdInfo2()
        {
            RfcCall rfc = new RfcCall();
            ArrayList list = rfc.GetCocdInfo2("0001");

            foreach (String item in list) {
                System.Console.WriteLine(item);
            }
        }
    }
}
