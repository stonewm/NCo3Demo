using System;
using SAP.Middleware.Connector;
using NCo02;

namespace NCo03
{
    public class TRfc
    {
        public void WriteTCPIC2()
        {
            String[] lines = new String[] { "Hello", "Hello again" };

            RfcTransaction trans = new RfcTransaction();
            RfcTID tid = trans.Tid;            

            RfcDestination dest = DestinationProvider.GetDestination();
            IRfcFunction fm = dest.Repository.CreateFunction("STFC_WRITE_TO_TCPIC");

            IRfcTable tcpicData = fm.GetTable("TCPICDAT");
            tcpicData.Append(lines.Length); // insert lines according to lines.Length
            for (int i = 0; i < lines.Length; i++) {
                tcpicData[i].SetValue("LINE", lines[i]);
            }

            trans.AddFunction(fm);
            trans.Commit(dest);
        }
    }
}
