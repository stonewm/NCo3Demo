using System;
using System.Collections;
using SAP.Middleware.Connector;

namespace NCo02
{
    public class RfcCall
    {
        // get information from company code
        public ArrayList GetCocdInfo(String cocd)
        {
            var list = new ArrayList();
            RfcDestination dest = DestinationProvider.GetDestination();

            RfcRepository repository = dest.Repository;
            IRfcFunction fm = repository.CreateFunction("BAPI_COMPANYCODE_GETDETAIL");

            fm.SetValue("COMPANYCODEID", cocd); // Populate parameter

            fm.Invoke(dest); // call function

            // BAPI_COMPANYCODE_GETDETAIL returns a structure named COMPANYCODE_DETAIL
            // which contains the information of the company code
            IRfcStructure cocdDetail = fm.GetStructure("COMPANYCODE_DETAIL");

            list = Utils.ToArrayList(cocdDetail);

            return list;
        }

        public ArrayList GetCocdInfo2(String cocd)
        {
            var list = new ArrayList(); // return value

            RfcDestination dest = DestinationProvider.GetDestination();
            RfcFunctionMetadata fmMeta = dest.Repository.GetFunctionMetadata("BAPI_COMPANYCODE_GETDETAIL");
            IRfcFunction fm = fmMeta.CreateFunction();

            fm.SetValue("COMPANYCODEID", cocd);
            fm.Invoke(dest);

            IRfcStructure cocdDetail = fm.GetStructure("COMPANYCODE_DETAIL");
            list = Utils.ToArrayList(cocdDetail);

            return list;
        }

        public void ListFunctionParameters(String fmName)
        {
            RfcDestination dest = DestinationProvider.GetDestination();
            IRfcFunction fm = dest.Repository.CreateFunction(fmName);

            for (int i = 0; i < fm.ElementCount; i++) {
                RfcElementMetadata elementMeta = fm.GetElementMetadata(i);
                if (elementMeta.GetType() == typeof(RfcParameterMetadata)) {
                    RfcParameterMetadata param = (RfcParameterMetadata)elementMeta;
                    System.Console.WriteLine("Name: " + param.Name);
                    System.Console.WriteLine("Data type: " + param.DataType);
                    System.Console.WriteLine("UcLength: " + param.UcLength);
                    System.Console.WriteLine("NucLength: " + param.NucLength);
                    System.Console.WriteLine("Documentation: " + param.Documentation);
                    System.Console.WriteLine("--------------------------");
                }
            }

        }
    }
}
