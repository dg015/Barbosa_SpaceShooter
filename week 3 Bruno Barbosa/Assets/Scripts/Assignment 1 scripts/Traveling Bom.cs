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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
}
