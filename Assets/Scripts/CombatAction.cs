using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatAction : MonoBehaviour
{
    public KeyCode hitKey;

    [SerializeField] private int health = 10;
    [SerializeField] private string armTag;
    [SerializeField] private string bodyTag;
    private int dyingHash, isHitHash, hittingHash;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dyingHash = Animator.StringToHash("Dying");
        isHitHash = Animator.StringToHash("isHit");
        hittingHash = Animator.StringToHash("Hitting");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(bodyTag))
        {
            // Debug.Log(other.gameObject);
            other.GetComponentInParent<Animator>().SetTrigger(isHitHash);
            other.GetComponentInChildren<CombatAction>().health--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(hitKey))
        {
            anim.SetTrigger(hittingHash);
        }

        if (health <= 0)
        {
            anim.SetBool(dyingHash,true);
        }
    }
}
