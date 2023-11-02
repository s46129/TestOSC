using System;
using extOSC;
using UnityEngine;

namespace AudioOSC
{
    public class AudioOSCSender : FindServerConnectorOSCSenderBase
    {
        private OSCTransmitter _oscTransmitter;

        [SerializeField] private string address = "/message/Character0/Audio";


        public override void InitialOSCTransmitter()
        {
            _oscTransmitter = GetComponent<OSCTransmitter>();
            if (_oscTransmitter == null)
            {
                _oscTransmitter = gameObject.AddComponent<OSCTransmitter>();
            }

            _oscTransmitter.RemoteHost = Env.IPAddress;
            _oscTransmitter.RemotePort = int.Parse(Env.RemotePort);

            Debug.Log($"Initial Transmitter success : {Env.IPAddress}");
        }
    }
}