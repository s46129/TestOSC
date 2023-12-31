using System.Collections.Generic;
using extOSC;
using Remote;
using UnityEngine;

namespace BlendShapeOSC
{
    public class BlendShapeOSCTransformSender : MonoBehaviour
    {
        private OSCTransmitter _oscTransmitter;

        [SerializeField] private string address = "/message/Character0/FaceBlendShape";

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
            _oscTransmitter.RemotePort = int.Parse(Env.RemotePort);

            Debug.Log($"Initial Transmitter success : {Env.IPAddress}");
        }

        public void OnBlendShapeUpdate(Dictionary<int, float> rawData)
        {
            foreach (var valuePair in rawData)
            {
                var addressPath = address + valuePair.Key;
                var oscMessage = new OSCMessage(addressPath);
                oscMessage.AddValue(OSCValue.Float(valuePair.Value));
                _oscTransmitter.Send(oscMessage);
            }
        }
    }
}