using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

public class LogPosition : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Awake()
    {
        
    }
    void FixedUpdate()
    {
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch) || Keyboard.current.rKey.isPressed)
        {
            Transform right = GameObject.Find("Player Rig/XR Origin/Camera offset/Controller (R)").GetComponent<Transform>();
            Debug.Log($"X: {right.position.x},Y: {right.position.y},Z: {right.position.z}");
        }
        else if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch) || Keyboard.current.lKey.isPressed)
        {
            Transform left = GameObject.Find("Player Rig/XR Origin/Camera offset/Controller (L)").GetComponent<Transform>();
            Debug.Log($"X: {left.position.x},Y: {left.position.y},Z: {left.position.z}");
        }
    }
}
