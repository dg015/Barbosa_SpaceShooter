using UnityEngine;
using System.Collections;
using Codice.ThemeImages;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] private Transform target;
    [Header("Basic enemy movement")]
    [SerializeField] private float ActiviatinDistance;
    [SerializeField] private float distanceFromTarget;
    [SerializeField] private float CurrentDistance;
    [Header("Enemy Turret")]
    [SerializeField] private float StaringAtRadius;
    [SerializeField] private float AttackAtRadius;
    [SerializeField] private GameObject DesacelerationBomb;


    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        GetTarget(target);
        /*
        CurrentDistance = Vector2.Distance(transform.position, target.position);
        if( CurrentDistance <ActiviatinDistance )
        {
            chaseTarget(target);
        }
        */
    }

    private void GetTarget(Transform target)
    {
        float currentDistance = Vector2.Distance(transform.position, target.position);
        if(currentDistance <= StaringAtRadius )
        {
            Debug.DrawLine(transform.position, target.position, Color.yellow);
            Vector2 playerDirection =  (transform.position - target.position).normalized;
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x)* Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
            
        }
        if ( currentDistance <= AttackAtRadius )
        {
            Debug.DrawLine(transform.position, target.position, Color.red);
            //do stuff
        }


    }


    private void chaseTarget(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        if(CurrentDistance > distanceFromTarget )
        {
            
            transform.Translate(direction * CurrentDistance * Time.deltaTime);   
           
        }
        


    }

}
