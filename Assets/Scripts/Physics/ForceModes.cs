using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForceModes : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField]private ForceMode forceMode;
     [SerializeField]private Transform firePos;
     [SerializeField] private float force;
     private Rigidbody rb;
     private bool firing;
   


    private void ApplyForceChoice(ForceMode mode)
    {
        var instantiatedProjectile = Instantiate(projectile, firePos.position, firePos.rotation);
            rb = instantiatedProjectile.GetComponent<Rigidbody>();
            rb.AddForce(force * firePos.position, mode);
            firing = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firing = true;
        }
    }

    private void FixedUpdate()
    {
        if (firing)
        {
            ApplyForceChoice(forceMode);
        }
            
       
    }

}
