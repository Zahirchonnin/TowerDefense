//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage;
    public int towerType;
    private Transform target;
    public float range = 17.5f;
    public Transform partToRotate;
    private float turnSpeed = 7f;

    public float fireRate = 1f;
    private float fireCountDown;

    public GameObject projectilPrefab;

    public Transform firePoint;


    public string enemyTag = "enemy";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f , 0.5f);
               
    }

    // Update is called once per frame
    void Update()
    {
        if(target ==null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f)
        {
            Shoot();

            fireCountDown = 1/ fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void UpdateTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = range * 4;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject projectilGO = Instantiate(projectilPrefab, firePoint.position,firePoint.rotation);
        Projectil projectil = projectilGO.GetComponent<Projectil>();

        if(projectil != null)
        {
            projectil.seek(target);
        }
    }

}
