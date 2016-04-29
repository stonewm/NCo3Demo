﻿using SAP.Middleware.Connector;


namespace NCo02
{
    public class DestinationProvider
    {
        private static RfcConfigParameters GetConfigParams()
        {
            RfcConfigParameters configParams = new RfcConfigParameters();

            // Name property is neccessary, otherwise, NonInvalidParameterException will be thrown
            configParams.Add(RfcConfigParameters.Name, "ECC");
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

        public static RfcDestination GetDestination()
        {
            RfcConfigParameters configParams = GetConfigParams();
            RfcDestination dest = RfcDestinationManager.GetDestination(configParams);

            return dest;
        }
    }
}
