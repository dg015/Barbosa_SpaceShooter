using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingBom : MonoBehaviour
{
    //aceleration
    [SerializeField] private float speed;
    [SerializeField] private float acelerationIndex;
    [SerializeField] private float desacelerationIndex;
    [SerializeField] private float acelerationTimer;
    //desaceleration
    [SerializeField] private float DeacelerationTimer;
    //player
    [SerializeField] private Transform player;
    [SerializeField] private bool isEnemy;

    Vector3 mouseDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));

        mouseDirection = (mousePosition - player.position).normalized;
        mouseDirection.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }



    private void Movement()
    {
        if (acelerationTimer > 0)
        {
            speed += acelerationIndex * Time.deltaTime; // adding speed
            acelerationTimer -= Time.deltaTime;// decreading it over time
        }
        else
        {
            speed -= (speed / DeacelerationTimer) * Time.deltaTime; // formula: aceleration = velocity/ timer
            DeacelerationTimer -= Time.deltaTime; // desacelarate over time
            /*WHY DECREASE THE DacelarationTimer?
            Since the speed is decreasing, Deceleration adapts over time, 
            making the object decelerate faster at first and then slower as it nears 0,
            this ensures that the object stops at 0s
            */
        }
        if (speed < 0.5)
        {
            Destroy(gameObject);
        }

        mouseDirection.z = 0;
        if (isEnemy) // boolean to check if the bomb will be shot by the player or enemy
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);//if enemy makes it go foward 
        }
        else
        {
            transform.Translate(mouseDirection * speed * Time.deltaTime);//if player for the first frame go towards the mouse direction
        }
        
        speed = Mathf.Clamp(speed, 0, 100); // clamp the speed to make sure it doest go bellow 0
    }

    /*
     * HOW TO MAKE IT DESSALERATE
     * When fired set the aceleration to max for X seconds
     * when timer reaches 0 start start dessaleration function
     * When speed reaches less then X variable destroy bomb
     * 
     */
}
