using System.Collections;
using extOSC;
using TMPro;
using UnityEngine;

namespace BlendShapeOSC
{
    public class BlendShapeOSCTransformReceiver : MonoBehaviour
    {
        private OSCReceiver _oscReceiver;

        [SerializeField] private string address = "/message/Character0/FaceBlendShape";
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

        IEnumerator Start()
        {
            if (_oscReceiver == null)
            {
                _oscReceiver = gameObject.AddComponent<OSCReceiver>();
            }

            _oscReceiver.LocalPort = int.Parse(Env.RemotePort);
            for (int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
            {
                _oscReceiver.Bind(address + i, MessageReceiver);
            }

            textMeshProUGUI.text = "Getting IP Address.";
            yield
                return new WaitUntil(() => string.Equals(_oscReceiver.LocalHost, "0.0.0.0"));
            textMeshProUGUI.text = $"{OSCUtilities.GetLocalHost()} : {_oscReceiver.LocalPort}";
        }

        private void MessageReceiver(OSCMessage arg0)
        {
            string key = arg0.Address.Replace(address, "");
            var tryParse = int.TryParse(key, out int keyNum);

            if (tryParse == false)
            {
                Debug.LogWarning("Fail to parse : " + key);
                return;
            }

            var parseValue = arg0.ToFloat(out var oscValues);
            if (parseValue)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(keyNum, oscValues);
            }
        }
    }
}