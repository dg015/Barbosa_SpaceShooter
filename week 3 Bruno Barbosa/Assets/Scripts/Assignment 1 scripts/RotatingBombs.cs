using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBombs : MonoBehaviour
{
    [SerializeField] private Transform spinTarget;
    [SerializeField] private float speed;
    [SerializeField] private Player player;
    [SerializeField] private float currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        spinTarget = GameObject.Find("Player").transform;
        player = GameObject.Find("Player").GetComponent<Player>();
        currentAngle = (Mathf.Atan2(spinTarget.position.y - transform.position.y, spinTarget.position.x - transform.position.x)); // get the angle of where the bomb starts compared to the player 
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    private void followPlayer()
    {
        currentAngle +=  speed * Time.deltaTime; // Increase the speed over time to create sense of aceleration

        float XPosition = Mathf.Cos(currentAngle * Mathf.Rad2Deg) * player.bombRadius; // get the X position of where the bomb should be 
        float YPosition = Mathf.Sin(currentAngle * Mathf.Rad2Deg) * player.bombRadius; // get the Y position of where the bomb should be 

        Vector2 nextAngle = new Vector2(spinTarget.position.x + XPosition , spinTarget.position.y + YPosition); // get the new location of where the bomb will be
        transform.position = nextAngle; //apply that location

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
