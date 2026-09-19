using System;
using System.Collections;
using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.titaniumabc.Development.Misc_testing
{
    public class VRInputSystem : MonoBehaviour
    {
        public static VRInputSystem instance;
        public bool debugMode = false;
        public Action OnButtonAPressed;
        public Action OnButtonBPressed;
        public Action OnButtonXPressed;
        public Action OnButtonYPressed;

        public Action OnLeftGripPressed;
        public Action OnLeftTriggerPressed;
        public Action OnRightGripPressed;
        public Action OnRightTriggerPressed;

        public Action OnLeftJoyStickForward;
        public Action OnLeftJoyStickBack;
        public Action OnLeftJoyStickRight;
        public Action OnLeftJoyStickLeft;
        public Action OnLeftJoyStickDown;

        public Action OnRightJoyStickForward;
        public Action OnRightJoyStickBack;
        public Action OnRightJoyStickRight;
        public Action OnRightJoyStickLeft;
        public Action OnRightJoyStickDown;

        public static bool HasInstance()
        {
            return instance != null;
        }
        void Awake()
        {
            instance = GameObject.Find("Player Rig/XR Origin").GetComponent<VRInputSystem>();
            if (debugMode)
            {
                Debug.Log("Beginning Action incremation");
                Debug.Log("Buttons...");
                OnButtonAPressed += delegate () { Debug.Log("Button A Pressed: Oculus VR Controller"); };
                OnButtonBPressed += delegate () { Debug.Log("Button B Pressed: Oculus VR Controller"); };
                OnButtonXPressed += delegate () { Debug.Log("Button X Pressed: Oculus VR Controller"); };
                OnButtonYPressed += delegate () { Debug.Log("Button Y Pressed: Oculus VR Controller"); };
                Debug.Log("Triggers + Grips... ");
                OnRightTriggerPressed += delegate () { Debug.Log("Button Right Trigger Pressed: Oculus VR Controller"); };
                OnRightGripPressed += delegate () { Debug.Log("Button Right Grip Pressed: Oculus VR Controller"); };
                OnLeftTriggerPressed += delegate () { Debug.Log("Button Left Trigger Pressed: Oculus VR Controller"); };
                OnLeftGripPressed += delegate () { Debug.Log("Button Left Grip Pressed: Oculus VR Controller"); };
                Debug.Log("Right Joystick...");
                OnRightJoyStickForward += delegate () { Debug.Log("Button Right Joystick Forward: Oculus VR Controller"); };
                OnRightJoyStickBack += delegate () { Debug.Log("Button Right Joystick Back: Oculus VR Controller"); };
                OnRightJoyStickRight += delegate () { Debug.Log("Button Right Joystick Right: Oculus VR Controller"); };
                OnRightJoyStickLeft += delegate () { Debug.Log("Button Right Joystick Left: Oculus VR Controller"); };
                OnRightJoyStickDown += delegate () { Debug.Log("Button Right Joystick Down: Oculus VR Controller"); };
                Debug.Log("Left Joystick...");
                OnLeftJoyStickForward += delegate () { Debug.Log("Button Left Joystick Forward: Oculus VR Controller"); };
                OnLeftJoyStickBack += delegate () { Debug.Log("Button Left Joystick Back: Oculus VR Controller"); };
                OnLeftJoyStickRight += delegate () { Debug.Log("Button Left Joystick Right: Oculus VR Controller"); };
                OnLeftJoyStickLeft += delegate () { Debug.Log("Button Left Joystick Left: Oculus VR Controller"); };
                OnLeftJoyStickDown += delegate () { Debug.Log("Button Left Joystick Down: Oculus VR Controller"); };
            }
        }
        private void FixedUpdate()
        {
            OVRInput.FixedUpdate();

            
        }
        private void LateUpdate()
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) OnButtonAPressed.Invoke();
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch)) OnButtonBPressed.Invoke();
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch)) OnButtonXPressed.Invoke();
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch)) OnButtonYPressed.Invoke();

            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)) OnRightTriggerPressed.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)) OnRightGripPressed.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)) OnLeftTriggerPressed.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)) OnLeftGripPressed.Invoke();

            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.RTouch)) OnRightJoyStickForward.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch)) OnRightJoyStickBack.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch)) OnRightJoyStickRight.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch)) OnRightJoyStickLeft.Invoke();
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.RTouch)) OnRightJoyStickDown.Invoke();

            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch)) OnLeftJoyStickForward.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch)) OnLeftJoyStickBack.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch)) OnLeftJoyStickRight.Invoke();
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch)) OnLeftJoyStickLeft.Invoke();
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.LTouch)) OnLeftJoyStickDown.Invoke();
        }
        void Update()
        {
            OVRInput.Update();
        }
    }
}