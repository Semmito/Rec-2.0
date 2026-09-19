using Assets.Scripts.titaniumabc.Development.Misc_testing;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.titaniumabc.Development.Inputs_system
{
    public class RigLocomotion : MonoBehaviour
    {
        GameObject rig;
        void MoveForward()
        {
            float moveSpeed = 0.05f;
            rig.transform.position += rig.GetComponentInChildren(typeof(Camera), false).transform.forward * moveSpeed;
        }
        void MoveBack()
        {
            float moveSpeed = -0.05f;
            rig.transform.position += rig.GetComponentInChildren(typeof(Camera), false).transform.forward * moveSpeed;
        }
        void MoveRight()
        {
            float moveSpeed = 0.05f;
            rig.transform.position += rig.GetComponentInChildren(typeof(Camera), false).transform.right * moveSpeed;
        }
        void MoveLeft()
        {
            float moveSpeed = -0.05f;
            rig.transform.position += rig.GetComponentInChildren(typeof(Camera), false).transform.right * moveSpeed;
        }

        void TurnPlayer()
        {
            // Vector2 turnDir = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        }
        void Jump()
        {
            float jumpVelocity = 5f;
            rig.GetComponent<Rigidbody>().AddForce(rig.transform.up * jumpVelocity, ForceMode.Impulse);
        }
        void Awake()
        {
            rig = GameObject.Find("Player Rig");
            if (rig != null) Debug.Log("Rig is not null");
            if (VRInputSystem.HasInstance()) Debug.Log("VRInputSystem has instance.");

            VRInputSystem.instance.OnLeftJoyStickForward += MoveForward;
            VRInputSystem.instance.OnLeftJoyStickBack += MoveBack;
            VRInputSystem.instance.OnLeftJoyStickRight += MoveRight;
            VRInputSystem.instance.OnLeftJoyStickLeft += MoveLeft;

            VRInputSystem.instance.OnButtonAPressed += Jump;

            // VRInputSystem.instance.OnRightJoyStickRight += TurnPlayer;
        }
    }
}