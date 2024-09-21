using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public bool hasReached;
    Vector3 TargetLocation;

    public void AsteroidMovement()
    {
      
        //check for when the code is run for the first time(vector will be 0) or if it has arrived
        if( TargetLocation == Vector3.zero || hasReached )
        {
          //create new random location
         // Debug.Log("Im working"+ TargetLocation);
          TargetLocation = new Vector2((Random.Range(-maxFloatDistance, maxFloatDistance)), (Random.Range(-maxFloatDistance, maxFloatDistance)));
          hasReached = false;
        }
        //get distance between asteroid and target position
        float distanceFromTarget = Vector2.Distance(transform.position, TargetLocation);

        //draw line to the location just to make it easier
        Debug.DrawLine(transform.position, (TargetLocation - transform.position).normalized, Color.blue);
        //check if its in the arrival radius
        if (distanceFromTarget > arrivalDistance)
        {
            //move the asteroid in the direciton of the target position
            Vector3 direction = (TargetLocation - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            
            //Debug.Log("walking toawrds location");
        }
        else
        {
            //Debug.Log("arrived");
            hasReached = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
}
