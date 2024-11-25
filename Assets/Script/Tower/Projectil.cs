using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    private Transform target;

    public float speed = 15f;
    public GameObject impactEffect;
    
    public void seek(Transform _target)
    {
        Debug.Log("Seek");
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
       // transform.LookAt(target);
       // transform.position = Vector3.MoveTowards(transform.position, target.position, distanceThisFrame);
       // Debug.Log("Projectile position: " + transform.position + " | Target position: " + target.position); 
        
    }

    void HitTarget()
    {
       // GameObject effectIns =  (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns,2f);
        Destroy(gameObject);
        Destroy(target);
    }
}
