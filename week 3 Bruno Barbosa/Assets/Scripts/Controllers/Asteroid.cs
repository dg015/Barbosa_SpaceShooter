using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void OnMouseUpAsButton()
    {
        maxFloatDistance = Random.Range(0, maxFloatDistance);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
