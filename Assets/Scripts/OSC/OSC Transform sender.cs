using System;
using extOSC;
using Remote;
using UnityEngine;


namespace OSC
{
    public class OscTransformSender : MonoBehaviour
    {
        private OSCTransmitter _oscTransmitter;

        [SerializeField] private string address = "/message/transform";

        private void Start()
        {
            BindServerConnector();
        }

        private void BindServerConnector()
        {
            var serverConnector = FindObjectOfType<ServerConnector>();
            serverConnector.SetOSCTransFormSender(this);
        }


        public void InitialOSCTransmitter()
        {
            _oscTransmitter = GetComponent<OSCTransmitter>();
            if (_oscTransmitter == null)
            {
                _oscTransmitter = gameObject.AddComponent<OSCTransmitter>();
            }

            _oscTransmitter.RemoteHost = Env.IPAddress;
            _oscTransmitter.RemotePort = 7000;
        }


        public void OnLogic()
        {
            if (_oscTransmitter == null)
            {
                return;
            }

            var rotation = transform.rotation;
            var oscMessage = new OSCMessage(address);
            oscMessage.AddValue(OSCValue.Array(
                OSCValue.Float(rotation.x),
                OSCValue.Float(rotation.y),
                OSCValue.Float(rotation.z),
                OSCValue.Float(rotation.w)));
            _oscTransmitter.Send(oscMessage);
        }
    }
}