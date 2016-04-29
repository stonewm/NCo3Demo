/**
 * Author: Stone Wang(stone.wangmin@qq.com)
 * Date: 2016/3/26
 */

using SAP.Middleware.Connector;
using NCo02;
using System.Data;

namespace NCo03
{
    public class TableManipulation
    {
        public DataTable GetCocdList()
        {
            // method purpose: get company code list from SAP system

            DataTable cocdDataTable = null;

            RfcDestination dest = DestinationProvider.GetDestination();
            IRfcFunction fm = dest.Repository.CreateFunction("BAPI_COMPANYCODE_GETLIST");
            fm.Invoke(dest);

            IRfcTable cocdRfcTable = fm.GetTable("COMPANYCODE_LIST");
            cocdDataTable = Utils.ToDataTable(cocdRfcTable);

            return cocdDataTable;
        }

        public DataTable ReadTable()
        {
            // purpose: 
            // read table SKA1 with criteria: KTOPL = Z900
            // and returns a DataTable

            RfcDestination dest = DestinationProvider.GetDestination();
            IRfcFunction fm = dest.Repository.CreateFunction("RFC_READ_TABLE");

            fm.SetValue("QUERY_TABLE", "SKA1");
            fm.SetValue("DELIMITER", "~");

            // OPTIONS table parameter
            IRfcTable options = fm.GetTable("OPTIONS");

            options.Append(); // create a new row
            options.SetValue("TEXT", "KTOPL = 'Z900' ");

            // FIELDS table parameter
            IRfcTable fields = fm.GetTable("FIELDS");
            fields.Append();
            fields.CurrentRow.SetValue("FIELDNAME", "KTOPL");

            fields.Append();
            fields.CurrentRow.SetValue("FIELDNAME", "SAKNR");

            fm.Invoke(dest);

            // DATA table paramter (output)
            IRfcTable data = fm.GetTable("DATA");
            DataTable dTable = Utils.ToDataTable(data);

            return dTable;
        }
    }
}
