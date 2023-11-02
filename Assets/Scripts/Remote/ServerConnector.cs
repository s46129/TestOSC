using AudioOSC;
using BlendShapeOSC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Remote
{
    public class ServerConnector : MonoBehaviour
    {
        private FindServerConnectorOSCSenderBase OscTransformSender;
        [SerializeField] private Button initialButton;
        [SerializeField] private TMP_InputField ipAddressInputField;
        [SerializeField] private TMP_InputField remotePortInputField;

        private void Start()
        {
            initialButton.onClick.AddListener(InitialSender);
            initialButton.interactable = false;
            remotePortInputField.text = Env.RemotePort;
        }


        private void InitialSender()
        {
            Env.IPAddress = ipAddressInputField.text;
            Env.RemotePort = remotePortInputField.text;
            if (OscTransformSender == null)
            {
                return;
            }

            OscTransformSender.InitialOSCTransmitter();
        }
        

        public void SetOSCTransFormSender(FindServerConnectorOSCSenderBase findServerConnectorOSCSenderBase)
        {
            OscTransformSender = findServerConnectorOSCSenderBase;
            initialButton.interactable = true; 
        }
    }
}