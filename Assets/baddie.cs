using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baddie : MonoBehaviour
{
    [SerializeField]
   public float projectileForce;

    [SerializeField]
   public float projectileFireRate;

   public float timeSinceLastFire;

    public Transform spawnPointLeft;
    public Transform spawnPointRright;

    [SerializeField]
    public GameObject projectilePreFab;


    // Start is called before the first frame update
    void Start()
    {
        if (projectileFireRate <= 0)
            projectileFireRate = 2.0f;

        if (projectileForce <= 0)
            projectileForce = 7.0F;
     }
    public void Death()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
   /*      if (!anim.GetBool("Fire"))
         {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            { 
                anim.SetBool("Fire", true);
            }
         }*/
    }
        public void Fire()
        {
            timeSinceLastFire = Time.time;

            GameObject temp = Instantiate(projectilePreFab, spawnPointLeft.position, spawnPointLeft.rotation);
        
           // temp.velocity = projectileForce;
        }
       
}

