using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("SetAcceleration", 0.01, SendMessageOptions.DontRequireReceiver);
        other.SendMessage("SetDeceleration", 0, SendMessageOptions.DontRequireReceiver);
        other.SendMessage("SetMaxSpeedDefault", SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.SendMessage("SetAccelerationDefault", SendMessageOptions.DontRequireReceiver);
        other.SendMessage("SetDecelerationDefault", SendMessageOptions.DontRequireReceiver);
        other.SendMessage("SetMaxSpeedDefault", SendMessageOptions.DontRequireReceiver);
    }
}
