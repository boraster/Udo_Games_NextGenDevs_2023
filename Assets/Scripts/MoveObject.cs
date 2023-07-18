using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveObject : MonoBehaviour
{
    public float speed = 7.0f;
    private Vector3 direction;

    private void Start()
    {
        direction = new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
    }

    private void Update()
    {
        
        transform.Translate(direction* speed * Time.deltaTime);
    }
}
