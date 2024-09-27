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
    [SerializeField] private List<Vector3> points;
    [SerializeField] private bool isComplete;


    private void Start()
    {
        points = new List<Vector3>();
    }

    void Update()
    {
        PlayerMovement();

        EnemyRadar(radius, circlePoints);
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
                Debug.Log("in the end");
            }
            else
            {
                nexPoint = points[i + 1];// since the lists starts at 0 I should be i instead of i + 1
                Debug.Log("going trough");

            }
            Debug.DrawLine(transform.position +  points[i],transform.position + nexPoint, Color.white);
        }
    }

    //Notes:  A circle is 360 -> divide it by the number points 
    // ex = 360/5 = 72degrees


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
