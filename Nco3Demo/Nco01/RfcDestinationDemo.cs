using SAP.Middleware.Connector;

namespace Nco01
{
    public class RfcDestinationDemo
    {
        private RfcConfigParameters GetConfigParams()
        {
            RfcConfigParameters configParams = new RfcConfigParameters();

            // Name property is neccessary, otherwise, NonInvalidParameterException will be thrown
            configParams.Add(RfcConfigParameters.Name, "ECC"); 
            configParams.Add(RfcConfigParameters.AppServerHost, "192.168.65.100");
            configParams.Add(RfcConfigParameters.SystemNumber, "00"); // instance number
            configParams.Add(RfcConfigParameters.SystemID, "D01");

            configParams.Add(RfcConfigParameters.User, "STONE");
            configParams.Add(RfcConfigParameters.Password, "123456");
            configParams.Add(RfcConfigParameters.Client, "001");
            configParams.Add(RfcConfigParameters.Language, "EN");
            configParams.Add(RfcConfigParameters.PoolSize, "5");
            configParams.Add(RfcConfigParameters.MaxPoolSize, "10");
            configParams.Add(RfcConfigParameters.IdleTimeout, "30");

            return configParams;
        }

        public RfcDestination GetDestination()
        {
            RfcConfigParameters configParams = this.GetConfigParams();
            RfcDestination dest = RfcDestinationManager.GetDestination(configParams);
            
            return dest;
        }

        public void PingDestination()
        {
            RfcDestination destination = this.GetDestination();
            destination.Ping();
        }
    }
}
