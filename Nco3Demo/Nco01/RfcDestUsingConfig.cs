using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace Nco01
{
    public class RfcDestUsingConfig
    {
        private RfcDestination destination;

        // initialize in constructor
        public RfcDestUsingConfig()
        {
            DestinationConfig destConfig = new DestinationConfig();
            RfcDestinationManager.RegisterDestinationConfiguration(destConfig);
            destination = RfcDestinationManager.GetDestination("ECC");
        }

        public RfcDestination GetDestination()
        {
            return destination;
        }

        public void PingDestination()
        {
            destination.Ping();
        }
    }
}
