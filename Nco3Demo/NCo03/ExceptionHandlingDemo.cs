using System;
using SAP.Middleware.Connector;

namespace NCo03
{
    public class ExceptionHandlingDemo
    {
        public void WriteTCPIC()
        {
            // the folowing lines will be added to TCPIC table in SAP system
            String[] lines = new String[] { 
                "轻轻的我走了，", 
                "正如我轻轻的来，",
                "我轻轻的招手，",
                "作别西天的云彩。"};

            try {
                RfcDestination dest = NCo02.DestinationProvider.GetDestination();
                IRfcFunction fm = dest.Repository.CreateFunction("STFC_WRITE_TO_TCPIC");

                IRfcTable tcpicData = fm.GetTable("TCPICDAT");
                tcpicData.Append(lines.Length); // insert lines according to lines.Length
                for (int i = 0; i < lines.Length; i++) {
                    tcpicData[i].SetValue("LINE", lines[i]);
                }

                fm.Invoke(dest);
            }
            catch (RfcCommunicationException ex) {
                // network problem
                System.Console.WriteLine(ex.ToString());
            }
            catch (RfcLogonException ex) {
                // user could not log on
                System.Console.WriteLine(ex.ToString());
            }
            catch (RfcAbapBaseException ex) {
                // ABAP excpeption
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
}
