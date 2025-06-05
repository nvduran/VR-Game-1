using UnityEngine;
using System.Collections;

public class TargetDummyManager : MonoBehaviour
{
    public void RespawnDummyAfterDelay(TargetDummyHealth dummy, float delay)
    {
        StartCoroutine(RespawnRoutine(dummy, delay));
    }

    private IEnumerator RespawnRoutine(TargetDummyHealth dummy, float delay)
    {
        yield return new WaitForSeconds(delay);
        dummy.ResetDummy();
    }
}
