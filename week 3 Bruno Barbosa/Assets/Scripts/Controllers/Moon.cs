using Codice.Client.BaseCommands.BranchExplorer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = planetTransform.position + Vector3.up * radius;
        Vector3 localPosition = (transform.position - planetTransform.position).normalized;


        angle = Mathf.Atan2(localPosition.x, localPosition.y) * Mathf.Rad2Deg;

    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius,speed,planetTransform);
    }


    private void OrbitalMotion(float radius, float speed, Transform target)
    {
        //float angle = Vector2.Angle(target.position,transform.position);


        //modulating so when the angle reaches 360 it goes back to 0
        float nextAngle = (angle + speed * Time.deltaTime) % 360f;
        angle = nextAngle;
        float newX = Mathf.Cos(nextAngle * Mathf.Deg2Rad) * radius;
        float newY = Mathf.Sin(nextAngle * Mathf.Deg2Rad) * radius;

        //Debug.Log(nextAngle);
        transform.position = target.position + new Vector3( newX,  newY);



        // to get vector to angle use atan2
    }

}
