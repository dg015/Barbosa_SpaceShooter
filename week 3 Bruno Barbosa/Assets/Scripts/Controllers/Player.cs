using Codice.Client.BaseCommands.Merge;
using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        PlayerMovement();
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        for (int i = 0; i < circlePoints; i++)
        {


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

}
