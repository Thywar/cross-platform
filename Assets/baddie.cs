using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baddie : MonoBehaviour
{
    [SerializeField]
    float proectileForce;
    [SerializeField]
    float projectileFireRate;

    float timeSinceLastFire;

    public Transform spawnPointLeft;
    public Transform spawnPointRright;

    public Projectile projectilePreFab;


    // Start is called before the first frame update
    void Start()
    {
        if (projectileFireRate <= 0)
            projectileFireRate = 2.0f;

        if (projectileForce <= 0)
            projectileForce = 7.0F;

    }
    public override void Death()
    {
        base.Death();

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
         if (!anim.GetBool("Fire"))
         {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            { 
                anim.SetBool("Fire", true);
            }
         }
    }
        public void Fire()
        {
            timeSinceLastFire = Time.time;

            projectileFireRate temp = Instant(projectilePreFab, spawnPointLeft.position, spawnPointLeft.rptation);

            temp.speed = projectileForce;
        }
        public void ReturnToIdle()
        {
            anim.SetBool("Fire", false);
        }
    
}

