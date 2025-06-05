using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 direction = cameraPosition - transform.position;
        direction.y = 0; // Keep the bar upright (ignore vertical tilt)

        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(-direction); // Flip to face the camera
        }
    }
}
