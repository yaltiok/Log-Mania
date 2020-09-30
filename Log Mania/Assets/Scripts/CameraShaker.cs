using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public IEnumerator Shake(float duration, float strength) 
    {
        Vector3 startingPos = transform.localPosition;

        float timePassed = 0f;

        while (timePassed < duration)
        {
            float x = Random.Range(-1f,1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;

            transform.localPosition = new Vector3(x, y, startingPos.z);

            timePassed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = startingPos;

    }
}
