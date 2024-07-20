using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class RingAnimator : MonoBehaviour
{
    private float speed = 12;

    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
