using extOSC;
using UnityEngine;
using UnityEngine.Serialization;

namespace OSC
{
    public class OscTransformSender : MonoBehaviour
    {
        private OSCTransmitter _oscTransmitter;

        [SerializeField] private string address = "/message/transform";
        [SerializeField] private string oscTransmitterRemoteHost;

        void Start()
        {
            _oscTransmitter = gameObject.AddComponent<OSCTransmitter>();
            _oscTransmitter.RemoteHost = oscTransmitterRemoteHost;
            _oscTransmitter.RemotePort = 7000;
        }

        void Update()
        {
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