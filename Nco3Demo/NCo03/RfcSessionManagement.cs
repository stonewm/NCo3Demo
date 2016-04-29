using SAP.Middleware.Connector;
using NCo02; 

namespace NCo03
{
    public class RfcSessionManagement
    {
        public void SessionManagementDemo()
        {
            /* 
             * Shows how to use RfcSessionManager to ensure that multiple functions
             * can be used in the same user session
             * RfcSessionManager is a simple implemenation of IRfcSessionProvider
             * that uses thread-Id as the session-Id
             * 
             * ZINCREMENT_COUNTER & ZGET_COUNTER were copied
             * from INCREMENT_COUNTER & GET_COUNER respectively
             */

            RfcDestination dest = DestinationProvider.GetDestination();

            IRfcFunction fmIncCounter = dest.Repository.CreateFunction("ZINCREMENT_COUNTER");
            IRfcFunction fmGetCounter = dest.Repository.CreateFunction("ZGET_COUNTER");
            
            // keep the current connection to backend SAP system 
            // to be used exclusively for current session
            RfcSessionManager.BeginContext(dest);
            int currentCounter = 0;

            try {
                // increment counter for 5 times
                for (int i = 0; i < 5; i++) {
                    fmIncCounter.Invoke(dest);
                }

                // then get the counter
                fmGetCounter.Invoke(dest);
                currentCounter = fmGetCounter.GetInt("GET_VALUE");

            }
            finally {
                // release the connection
                RfcSessionManager.EndContext(dest);
            }

            System.Console.WriteLine(currentCounter);
        }
    }
}
