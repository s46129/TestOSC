using OSC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Remote
{
    public class ServerConnector : MonoBehaviour
    {
        private OscTransformSender _oscTransformSender;
        [SerializeField] private Button initialButton;
        [SerializeField] private TMP_InputField ipAddressInputField;
        [SerializeField] private TMP_InputField portInputField;

        private void Start()
        {
            initialButton.onClick.AddListener(InitialSender);
            initialButton.interactable = false;
            portInputField.text = Env.RemotePort;
        }

        public void SetOSCTransFormSender(OscTransformSender oscTransformSender)
        {
            _oscTransformSender = oscTransformSender;
            initialButton.interactable = true;
        }

        private void InitialSender()
        {
            Env.IPAddress = ipAddressInputField.text;
            Env.RemotePort = portInputField.text;
            if (_oscTransformSender == null)
            {
                return;
            }

            _oscTransformSender.InitialOSCTransmitter();
        }

    }
}
