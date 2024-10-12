using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingBom : MonoBehaviour
{
    //aceleration
    [SerializeField] private float speed;
    [SerializeField] private float acelerationIndex;
    [SerializeField] private float desacelerationIndex;
    //desaceleration
    [SerializeField] private float currentAceleration;
    [SerializeField] private float currentDesacelerationIndex;
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
        transform.Translate(mouseDirection * speed * Time.deltaTime);
    }
}
