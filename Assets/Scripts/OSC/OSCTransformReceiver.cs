using System.Collections;
using System.Collections.Generic;
using extOSC;
using UnityEngine;

public class OSCTransformReceiver : MonoBehaviour
{
    private OSCReceiver _oscReceiver;

    [SerializeField] private string address = "/message/transform";

    void Start()
    {
        _oscReceiver = gameObject.AddComponent<OSCReceiver>();
        _oscReceiver.LocalPort = 7000;
        _oscReceiver.Bind(address, MessageReceivered);
    }

    private void MessageReceivered(OSCMessage arg0)
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