using System;
using SAP.Middleware.Connector;

namespace Nco01
{
    class DestinationConfig : IDestinationConfiguration
    {
        public bool ChangeEventsSupported()
        {
            return false; // 不支持ChangeEvent
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destinationName)
        {
            // get logon parameteres according to destinationName
            // the following is logon paramters for 'ECC'
            if ("ECC".Equals(destinationName)) {
                RfcConfigParameters configParams = new RfcConfigParameters();
                configParams.Add(RfcConfigParameters.AppServerHost, "192.168.65.100");
                configParams.Add(RfcConfigParameters.SystemNumber, "00"); // instance number
                configParams.Add(RfcConfigParameters.SystemID, "D01");

                configParams.Add(RfcConfigParameters.User, "STONE");
                configParams.Add(RfcConfigParameters.Password, "tomandjerry");
                configParams.Add(RfcConfigParameters.Client, "001");
                configParams.Add(RfcConfigParameters.Language, "EN");
                configParams.Add(RfcConfigParameters.PoolSize, "5");
                configParams.Add(RfcConfigParameters.MaxPoolSize, "10");
                configParams.Add(RfcConfigParameters.IdleTimeout, "30");

                return configParams;
            }
            else {
                return null;
            }
        }
    }
}
