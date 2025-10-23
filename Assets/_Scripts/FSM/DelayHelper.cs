using UnityEngine;
using System.Collections;

public class DelayHelper : MonoBehaviour
{
    public void StartDelay(float delaySeconds)
    {
        StartCoroutine(DelayAction(delaySeconds));
    }

    private IEnumerator DelayAction(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
    }
}
