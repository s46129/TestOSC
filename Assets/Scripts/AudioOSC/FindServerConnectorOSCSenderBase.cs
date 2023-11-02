using Remote;
using UnityEngine;

namespace AudioOSC
{
    public abstract class FindServerConnectorOSCSenderBase:MonoBehaviour
    {
        private void Start()
        {
            BindServerConnector();
        }

        private void BindServerConnector()
        {
            var serverConnector = FindObjectOfType<ServerConnector>();
            serverConnector.SetOSCTransFormSender(this);
        }

        public abstract void InitialOSCTransmitter();
    }
}