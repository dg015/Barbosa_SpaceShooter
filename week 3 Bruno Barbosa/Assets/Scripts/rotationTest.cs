using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationTest : MonoBehaviour
{
    public float AngularSpeed;
    public float currentRotation;
    [Range(0.0f, 180f)]
    public float TargetAngle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.up);
        //currentRotation = Mathf.Atan2(transform.up.y,transform.up.x) * Mathf.Rad2Deg;
        currentRotation = transform.rotation.eulerAngles.z;
        if (currentRotation + 90 < TargetAngle)
        {
            transform.Rotate(0, 0, 1 * AngularSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("stopped");
        }
    }
}
