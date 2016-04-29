using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using NCo03;

namespace UnitTestProject1
{
    [TestClass]
    public class TestTableManipulation
    {
        [TestMethod]
        public void Test_GetCocdList()
        {
            TableManipulation rfc = new TableManipulation();
            DataTable cocdList = rfc.GetCocdList();
            Utils.PrintDataTable(cocdList);
        }

        [TestMethod]
        public void Test_ReadTable()
        {
            TableManipulation rfc = new TableManipulation();
            DataTable ska1 = rfc.ReadTable(); // ska1 table
            Utils.PrintDataTable(ska1);
        }
    }
}
