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


    Vector3 mouseDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        mouseDirection = (mousePosition - player.position).normalized;
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
            Debug.Log("tiemr ran out");
            
            speed -= (speed / DeacelerationTimer) * Time.deltaTime; // aceleration = velocity/ timer
            DeacelerationTimer -= Time.deltaTime;
        }
        if (speed < 0.5)
        {
            Debug.Log("destroyed object");
        }

        
        transform.Translate(mouseDirection * speed * Time.deltaTime);
        speed = Mathf.Clamp(speed, 0, 100);
    }

    /*
     * HOW TO MAKE IT DESSALERATE
     * When fired set the aceleration to max for X seconds
     * when timer reaches 0 start start dessaleration function
     * When speed reaches less then X variable destroy bomb
     * 
     */
}
