using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    private Tower thisTower;

    public GameObject projectile;
    public Transform firePoint;
    public float timeBetweenShot = 1.0f;

    private float shotCounter;

    private Transform target;
    public Transform launcherModel;


    void Start()
    {
        thisTower = GetComponent<Tower>();
    }




    void Update()
    {
        if(target != null)
        {
            launcherModel.rotation =
                Quaternion.Slerp(launcherModel.rotation,
                Quaternion.LookRotation(target.position - transform.position),
                5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(
                0.0f,
                launcherModel.rotation. eulerAngles.y,
                0.0f);
        }

        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0.0f && target != null)
        {
            shotCounter = thisTower.fireRate;

            firePoint.LookAt(target);

            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }

        if (thisTower.enemiesUpdate)
        {
            if (thisTower.enemiesInRange.Count > 0)
            {
                float minDistance = thisTower.range + 1f;
                foreach(EnemyController enemy in thisTower.enemiesInRange)
                {
                    if(enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);

                        if(distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                        }
                    }
                }
            }
            else
            {
                target = null;
            }
        }

    }
}
