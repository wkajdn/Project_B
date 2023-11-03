using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float range = 3.0f;
    public float fireRate = 1.0f;
    public LayerMask IsEnemy;

    public Collider[] colliderInRange;

    public List<EnemyController> enemiesInRange = new List<EnemyController>();

    public float checkCounter;
    public float checkTime = 0.2f;

    public bool enemiesUpdate;
    void Start()
    {
        checkCounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdate = false;

        checkCounter -= Time.deltaTime;

        if (checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderInRange = Physics.OverlapSphere(transform.position, range, IsEnemy);

            enemiesInRange.Clear();

            foreach (Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }

            enemiesUpdate = true;
        }
    }
}
