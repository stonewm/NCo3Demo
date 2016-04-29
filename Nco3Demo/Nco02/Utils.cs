using SAP.Middleware.Connector;
using System;
using System.Collections;

namespace NCo02
{
    public class Utils
    {
        public static ArrayList ToArrayList(IRfcStructure stru)
        {
            var list = new ArrayList();
            for (int i = 0; i < stru.ElementCount; i++) {
                // get column name from position
                RfcElementMetadata colMeta = stru.GetElementMetadata(i);
                list.Add(String.Format("{0}: {1}",
                    colMeta.Name, // column name
                    stru.GetString(colMeta.Name))); // get value from column name
            }

            return list;
        }
    }
}
