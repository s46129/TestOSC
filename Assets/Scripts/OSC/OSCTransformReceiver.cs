using System;
using System.Collections;
using System.Collections.Generic;
using extOSC;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

namespace OSC
{
    public class OSCTransformReceiver : MonoBehaviour
    {
        [SerializeField] private OSCReceiver oscReceiver;

        [SerializeField] private string address = "/message/transform";
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;


        IEnumerator Start()
        {
            if (oscReceiver == null)
            {
                oscReceiver = gameObject.AddComponent<OSCReceiver>();
            }

            oscReceiver.LocalPort = 7000;
            oscReceiver.Bind(address, MessageReceiver);
            textMeshProUGUI.text = "Getting IP Address.";
            yield
                return new WaitUntil(() => string.Equals(oscReceiver.LocalHost, "0.0.0.0"));
            textMeshProUGUI.text = $"{OSCUtilities.GetLocalHost()} : {oscReceiver.LocalPort}";
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