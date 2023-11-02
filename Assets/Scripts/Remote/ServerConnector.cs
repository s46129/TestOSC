using BlendShapeOSC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Remote
{
    public class ServerConnector : MonoBehaviour
    {
        private BlendShapeOSCTransformSender _blendShapeOscTransformSender;
        [SerializeField] private Button initialButton;
        [SerializeField] private TMP_InputField ipAddressInputField;
        [SerializeField] private TMP_InputField remotePortInputField;

        private void Start()
        {
            initialButton.onClick.AddListener(InitialSender);
            initialButton.interactable = false;
            remotePortInputField.text = Env.RemotePort;
        }

        public void SetOSCTransFormSender(BlendShapeOSCTransformSender blendShapeOscTransformSender)
        {
            _blendShapeOscTransformSender = blendShapeOscTransformSender;
            initialButton.interactable = true;
        }

        private void InitialSender()
        {
            Env.IPAddress = ipAddressInputField.text;
            Env.RemotePort = remotePortInputField.text;
            if (_blendShapeOscTransformSender == null)
            {
                return;
            }

            _blendShapeOscTransformSender.InitialOSCTransmitter();
        }
    }
}