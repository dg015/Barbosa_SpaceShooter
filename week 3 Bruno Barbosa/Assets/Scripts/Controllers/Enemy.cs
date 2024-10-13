using UnityEngine;
using System.Collections;
using Codice.ThemeImages;
using UnityEngine.UIElements;

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
    [Header("Bomb shooting")]
    [SerializeField] private GameObject DesacelerationBomb;
    [SerializeField] private float bombTimer;
    [SerializeField] private float bombTimerMax;
    [SerializeField] private int numberOfBombs;
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
        float currentDistance = Vector2.Distance(transform.position, target.position); // get distance from player to enemy
        
        if(currentDistance <= StaringAtRadius )
        {
            Debug.DrawLine(transform.position, target.position, Color.yellow); 
            Vector2 playerDirection =  (transform.position - target.position).normalized; // get the direction
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x)* Mathf.Rad2Deg; // since the direction is not enough for the enemy to look at player have 
            //Atan2 to get the angle 
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);// apply rotation with offset
            
        }
        if (bombTimer >0 ) // check if timer is 0
        {
            bombTimer -= Time.deltaTime; // decrase timer 

        }
        if ( currentDistance <= AttackAtRadius )
        {
            if (bombTimer <= 0) // check if it can fire
            {
                Debug.DrawLine(transform.position, target.position, Color.red);
                for (int i = 0; i < numberOfBombs; i++)//loop for burst firing
                {
                    Instantiate(DesacelerationBomb, new Vector2(transform.position.x + i, transform.position.y), transform.rotation * Quaternion.Euler(0, 0, 90)); // adding the 90 degree offset
                    
                }
                bombTimer = bombTimerMax; // reset timer
            }
            
        }

        bombTimer = Mathf.Clamp(bombTimer, 0, bombTimerMax);
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
