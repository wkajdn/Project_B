using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody rb;

    public float moveSpeed;
    public float damagedAmount;
    private bool hasDamaged;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage((int)damagedAmount);
            hasDamaged = true;
        }

        Destroy(gameObject);
    }


}
