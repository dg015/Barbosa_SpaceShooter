using UnityEngine;
using System.Collections;

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
