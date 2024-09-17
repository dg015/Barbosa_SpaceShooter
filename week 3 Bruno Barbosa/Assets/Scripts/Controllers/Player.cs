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
            //transform.Translate((Vector2.up * Time.deltaTime) *speed);
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
