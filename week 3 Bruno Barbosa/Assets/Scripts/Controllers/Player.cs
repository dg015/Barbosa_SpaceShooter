using Codice.Client.BaseCommands.Merge;
using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    [SerializeField] private float acelaration;
    [SerializeField] private float speed;
    [SerializeField] private float DecelerationTime;


    //enemy radar
    [SerializeField] private float radius;
    [SerializeField] private int circlePoints;
    [SerializeField] private List<Vector2> points;

    private void Start()
    {
        points = new List<Vector2>();
    }

    void Update()
    {
        PlayerMovement();
        EnemyRadar(radius, circlePoints);
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        Vector2 nexPoint;

        //first do the math to get points
        for (int i = 0; i < circlePoints; i++)
        {
            float xPos = Mathf.Cos(i);
            float yPos = Mathf.Sin(i);
            points.Add(new Vector2(xPos, yPos) * radius);
            if (i == points.Count - 1)
            {
                nexPoint = points[0];
            }
            else
            {
                nexPoint = points[i+1];
            }



        }

        /*

        for (int i = 0; i < circlePoints; i++)
        {

            if (!hasCompleted)
            {
                //points[i] = new Vector2((Mathf.Cos(i),Mathf.Sin(i)) * radius);
                float xPos = Mathf.Cos(i);
                float yPos = Mathf.Sin(i);
                //points[i] = new Vector2(xPos, yPos) * radius;
                points.Add(new Vector2(xPos, yPos) * radius);


            }
            Debug.DrawLine(points[i], nexPoint, Color.green);
        }
        
        */
    }


    private void PlayerMovement()
    {
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            acelaration += speed * Time.deltaTime; 
            transform.Translate((Vector2.up * Time.deltaTime) * acelaration);
            Debug.Log("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            acelaration += speed * Time.deltaTime;
            transform.Translate((Vector2.down * Time.deltaTime) * acelaration);
            Debug.Log("down");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            acelaration += speed * Time.deltaTime;
            transform.Translate((Vector2.right * Time.deltaTime) * acelaration);
            Debug.Log("right");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            acelaration += speed * Time.deltaTime;
            transform.Translate((Vector2.left * Time.deltaTime) * acelaration);
            Debug.Log("left");
        }
        else if (acelaration > 0)
        {
            
           float DecelarationRate = (speed /DecelerationTime) * Time.deltaTime;
            acelaration -= DecelarationRate;
        }
        
    }

}
