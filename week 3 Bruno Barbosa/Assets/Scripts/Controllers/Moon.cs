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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius,speed,planetTransform);
    }


    private void OrbitalMotion(float radius, float speed, Transform target)
    {


        float angle = Vector2.Angle(target.position,transform.position);



        float nextAngle = angle * speed * Time.deltaTime;


        float newX = Mathf.Cos(nextAngle) * radius;
        float newY = Mathf.Sin(nextAngle) * radius;
        Debug.Log(nextAngle);
        transform.position = new Vector2(target.position.x + newX, target.position.y + newY);

       

    }

}
