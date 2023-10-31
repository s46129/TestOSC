using System;
using OSC;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Remote
{
    public class ServerConnector : MonoBehaviour
    {
        private OscTransformSender _oscTransformSender;
        [SerializeField] private Button initialButton;
        [SerializeField] private TMP_InputField ipAddressInputField;

        private void Start()
        {
            initialButton.onClick.AddListener(InitialSender);
            initialButton.interactable = false;
        }

        public void SetOSCTransFormSender(OscTransformSender oscTransformSender)
        {
            _oscTransformSender = oscTransformSender;
            initialButton.interactable = true;
        }

        private void InitialSender()
        {
            Env.IPAddress = ipAddressInputField.text;
            if (_oscTransformSender == null)
            {
                return;
            }

            _oscTransformSender.InitialOSCTransmitter();
        }

        private void Update()
        {
            if (_oscTransformSender == null)
            {
                return;
            }

            _oscTransformSender.OnLogic();
        }
    }
}