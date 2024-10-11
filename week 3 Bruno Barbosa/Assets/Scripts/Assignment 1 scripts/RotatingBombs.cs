using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBombs : MonoBehaviour
{
    [SerializeField] private Transform spinTarget;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    private void followPlayer()
    {
        spinTarget = GameObject.Find("Player").transform;

        float currentAngle = Mathf.Atan2(spinTarget.position.y - transform.position.y, spinTarget.position.x - transform.position.x);
        Debug.Log("atan2:"+currentAngle);
        Debug.Log("Vector 3 angle" + Vector3.Angle(  transform.position,spinTarget.position));
        float XPosition = Mathf.Cos(currentAngle);
        float YPosition = Mathf.Sin(currentAngle);



        

        /* rationale
        start for loop
        Get the angle between bomb and player
        Increase the angle
        Get the location of what would be the increased angle
        translate the bomb to the locaiton of the new location
        use % so it goes back to 0
        */
    }
}
