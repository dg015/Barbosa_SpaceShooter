using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    [SerializeField] private bool inProcess = false;

    // Update is called once per frame
    void Update()
    {
        if (!inProcess)
        StartCoroutine(drawConstellation());
    }
    //wrote in 20 minutes

    IEnumerator drawConstellation()
    {
        inProcess = true;
        for (int i = 0; i < starTransforms.Count; i++)
        {
            Debug.Log(i);
            Transform nextStar;
            if (i == starTransforms.Count - 1)//check if its the last star
            {
                nextStar = starTransforms[0];//back to first one in the list
            }
            else
            {
                nextStar = starTransforms[i + 1];//if not then continue as normal
            }
            
            Debug.DrawLine(starTransforms[i].position, nextStar.position,Color.white,drawingTime);
            yield return new WaitForSeconds(drawingTime);//drawing
        }
        inProcess = false;
    }
}
