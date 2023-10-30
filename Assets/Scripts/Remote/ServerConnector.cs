using System;
using OSC;
using UnityEngine;
using UnityEngine.UI;

namespace Remote
{
    public class ServerConnector : MonoBehaviour
    {
        private OscTransformSender _oscTransformSender;
        [SerializeField] private Button initialButton;

        private void Start()
        {
            initialButton.onClick.AddListener(InitialSender);
            initialButton.interactable = false;
        }

        public void SetIPAddress(string address)
        {
            Env.IPAddress = address;
        }

        public void SetOSCTransFormSender(OscTransformSender oscTransformSender)
        {
            _oscTransformSender = oscTransformSender;
            initialButton.interactable = true;
        }

        private void InitialSender()
        {
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