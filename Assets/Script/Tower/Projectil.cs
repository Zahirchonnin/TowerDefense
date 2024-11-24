using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    private Transform target;

    public float speed = 0.1f;
    public GameObject impactEffect;
    
    public void seek(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        
    }

    void HitTarget()
    {
        GameObject effectIns =  (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns,2f);
        Destroy(gameObject);
    }
}
