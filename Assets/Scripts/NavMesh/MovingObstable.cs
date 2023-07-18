using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstable : MonoBehaviour
{
    public float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * (speed *Time.deltaTime));
    }
}
