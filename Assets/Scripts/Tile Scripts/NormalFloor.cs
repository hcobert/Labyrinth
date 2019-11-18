using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("SetAccelerationDefault",SendMessageOptions.DontRequireReceiver);
        other.SendMessage("SetDecelerationDefault", SendMessageOptions.DontRequireReceiver);
        other.SendMessage("SetMaxSpeedDefault", SendMessageOptions.DontRequireReceiver);
    }
}
