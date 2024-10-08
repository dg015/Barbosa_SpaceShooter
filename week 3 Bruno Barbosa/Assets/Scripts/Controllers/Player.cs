using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    [SerializeField] private float acelaration;
    [SerializeField] private float speed;
    [SerializeField] private float DecelerationTime;


    [Header("Enemy radar")]
    [SerializeField] private float radius;
    [SerializeField] private int circlePoints;
    [SerializeField] private List<Vector3> points;
    [SerializeField] private bool isComplete;


    [Header("Power Ups")]
    [SerializeField] private int numberOfPowerUps;
    [SerializeField] private GameObject powerUp;


    [Header("rotating bombs")]
    [SerializeField] private int numberOfBombs;
    [SerializeField] private float bombRadius;


    private void Start()
    {
        points = new List<Vector3>();
    }

    void Update()
    {
        PlayerMovement();

        EnemyRadar(radius, circlePoints);
        if (Input.GetKeyDown(KeyCode.P))
        {
            spawnPowerUps(radius, numberOfPowerUps);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            spawnRotatingBombs(bombRadius, numberOfBombs);
        }
        
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        float angleDivision = 2 * Mathf.PI / circlePoints;// dividing cicle
        
        Vector3 nexPoint = Vector3.zero;
        points.Clear();


        //first do the math to get points
        for (int i = 0; i < circlePoints; i++)
        {

            float angle = angleDivision * i;
            float xPos = Mathf.Cos(angle);
            float yPos = Mathf.Sin(angle);
            
            points.Add(new Vector3(xPos, yPos) * radius);

        }
        for (int i = 0; i < circlePoints; i++)
        {
            if (i == circlePoints - 1)
            {
                nexPoint = points[0];
                //Debug.Log("in the end");
            }
            else
            {
                nexPoint = points[i + 1];// since the lists starts at 0 I should be i instead of i + 1
               // Debug.Log("going trough");

            }
            Debug.DrawLine(transform.position +  points[i],transform.position + nexPoint, Color.white);
        }
    }

    public void spawnPowerUps(float radius, int numberOfPowerUps)
    {
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            float angleDivision = 2 * Mathf.PI / numberOfPowerUps;// dividing cicle
            float angle = angleDivision * i; //multiply the value by i, which is the iteration so it spawns at the correct location
           
            float x = Mathf.Cos(angle) * radius; //get an random X location by using the the angle multiplying it by radius guarantees it will be inside of the circle
            float y = Mathf.Sin(angle) * radius; //get an random Y location by using the the angle


            Vector3 location = new Vector2(x, y);
            Instantiate(powerUp,transform.position + location, Quaternion.identity);
        }
        
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

    private void spawnRotatingBombs(float radius, int numberOfBombs)
    {
       float angleDivisionOffset = numberOfBombs / 360;
       for ( int i = 0; i < numberOfBombs; i++)
        {
            Vector3 position = new Vector3(angleDivisionOffset * i, angleDivisionOffset * 1,1);
            Instantiate(bombPrefab, position, Quaternion.identity);   
        }


    }

}
