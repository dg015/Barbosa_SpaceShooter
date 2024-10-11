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
        Debug.Log("atan2:"+currentAngle * Mathf.Rad2Deg);

        float XPosition = Mathf.Cos(currentAngle) * Mathf.Rad2Deg;
        float YPosition = Mathf.Sin(currentAngle) * Mathf.Rad2Deg;

        //Vector2 nextAngle = new Vector2(XPosition + 1, YPosition+  1);
        //transform.position = nextAngle;

        

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
