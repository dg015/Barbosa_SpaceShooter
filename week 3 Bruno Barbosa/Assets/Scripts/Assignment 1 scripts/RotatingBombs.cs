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
        transform.position = transform.position - spinTarget.position;

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
