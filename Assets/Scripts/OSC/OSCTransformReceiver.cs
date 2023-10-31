using System.Collections;
using extOSC;
using TMPro;
using UnityEngine;


namespace OSC
{
    public class OSCTransformReceiver : MonoBehaviour
    {
        private OSCReceiver _oscReceiver;

        [SerializeField] private string address = "/message/transform";
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;


        IEnumerator Start()
        {
            if (_oscReceiver == null)
            {
                _oscReceiver = gameObject.AddComponent<OSCReceiver>();
            }

            _oscReceiver.LocalPort = 7000;
            _oscReceiver.Bind(address, MessageReceiver);
            textMeshProUGUI.text = "Getting IP Address.";
            yield
                return new WaitUntil(() => string.Equals(_oscReceiver.LocalHost, "0.0.0.0"));
            textMeshProUGUI.text = $"{OSCUtilities.GetLocalHost()} : {_oscReceiver.LocalPort}";
        }

        private void MessageReceiver(OSCMessage arg0)
        {
            arg0.ToArray(out var oscValues);
            transform.rotation = new Quaternion(
                oscValues[0].FloatValue,
                oscValues[1].FloatValue,
                oscValues[2].FloatValue,
                oscValues[3].FloatValue
            );
        }
    }
}