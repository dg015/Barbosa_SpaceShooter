using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float ActiviatinDistance;
    [SerializeField] private float distanceFromTarget;
    [SerializeField] private float CurrentDistance;

    private void Update()
    {

        
        CurrentDistance = Vector2.Distance(transform.position, target.position);
        if( CurrentDistance <ActiviatinDistance )
        {
            chaseTarget(target);
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
