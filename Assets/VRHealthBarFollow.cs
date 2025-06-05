using UnityEngine;
using UnityEngine.UI;

public class VRHealthBarFollow : MonoBehaviour
{
    public Transform playerCamera; // assign main VR camera here

    void LateUpdate()
    {
        // Position canvas 0.2 meters below the camera, facing forward
        transform.position = playerCamera.position + playerCamera.forward * 0.7f + Vector3.down * 0.2f;
        transform.rotation = Quaternion.LookRotation(playerCamera.forward, Vector3.up);
    }
}
