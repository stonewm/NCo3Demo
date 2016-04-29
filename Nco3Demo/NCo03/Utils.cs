using SAP.Middleware.Connector;
using System.Data;

namespace NCo03
{
    public class Utils
    {
        public static DataTable ToDataTable(IRfcTable itab)
        {
            // purpose: convert IRfcTable to DataTable

            DataTable dataTable = new DataTable();

            // dataTable column definition
            for (int i = 0; i < itab.ElementCount; i++) {
                RfcElementMetadata metadata = itab.GetElementMetadata(i);
                dataTable.Columns.Add(metadata.Name);
            }

            // line items
            for (int rowIdx = 0; rowIdx < itab.RowCount; rowIdx++) {
                DataRow dRow = dataTable.NewRow();

                // each line is a structure                
                for (int idx = 0; idx < itab.ElementCount; idx++) {
                    dRow[idx] = itab[rowIdx].GetObject(idx);
                }

                // or: 
                // IRfcTable.CurrentIndex can be used to handle current line
                //for (int idx = 0; idx < itab.ElementCount; idx++) {
                //    itab.CurrentIndex = idx;
                //    dRow[idx] = itab.GetObject(idx); // CurrentIndex indicates the current line
                //}

                dataTable.Rows.Add(dRow);
            }

            return dataTable;
        }

        //public static DataTable ToDataTable(IRfcTable itab)
        //{
        //    // purpose: convert IRfcTable to DataTable

        //    DataTable dataTable = new DataTable();

        //    // dataTable column definition
        //    for (int i = 0; i < itab.ElementCount; i++) {
        //        RfcElementMetadata metadata = itab.GetElementMetadata(i);
        //        dataTable.Columns.Add(metadata.Name);
        //    }

        //    // line items
        //    foreach (IRfcStructure currenRow in itab) {
        //        DataRow dRow = dataTable.NewRow();
        //        for (int idx = 0; idx < currenRow.ElementCount; idx++) {
        //            dRow[idx] = currenRow.GetObject(idx);
        //        }
        //        dataTable.Rows.Add(dRow);
        //    }

        //    return dataTable;
        //}


        public static void PrintDataTable(DataTable dataTable)
        {
            // purpose: print data table in console

            foreach (DataRow row in dataTable.Rows) {
                foreach (DataColumn col in dataTable.Columns) {
                    System.Console.Write(row[col].ToString() + "\t");
                }
                System.Console.WriteLine();
            }
        }
    }
}
