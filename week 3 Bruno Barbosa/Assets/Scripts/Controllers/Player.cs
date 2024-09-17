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


    void Update()
    {

    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }


    private void PlayerMovement()
    {
        
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            //correct version of aceleration starts here
            acelaration += speed * Time.deltaTime; 
            transform.Translate((Vector2.up * Time.deltaTime) * acelaration);
             //ends here
            //adapt the others when at home and update the journal with it
            Debug.Log("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate((Vector2.down * Time.deltaTime) * speed);
            Debug.Log("down");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((Vector2.right * Time.deltaTime) * speed);
            Debug.Log("right");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((Vector2.left * Time.deltaTime) * speed);
            Debug.Log("left");
        }
    }

}
