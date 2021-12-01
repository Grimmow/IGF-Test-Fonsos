using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : MonoBehaviour
{
    [SerializeField] Material materialPlaceHolder;
    [SerializeField] Material yellow;
    [SerializeField] Material orange;
    [SerializeField] Material red;
    [SerializeField] Material deepRed;
    [SerializeField] GameObject log;
    [SerializeField] Transform[] logInstatiatePoints;
    bool firstTime = true;

    private void Start()
    {
        materialPlaceHolder = GetComponent<MeshRenderer>().material;
    }

    public void Interaction()
    {
        if (firstTime)
        {
            //checking for the first interaction with the object
            materialPlaceHolder.color = yellow.color;
            firstTime = false;
        }
        else
        {
            if(materialPlaceHolder.color == yellow.color)
            {
                materialPlaceHolder.color = orange.color;
            }
            else if(materialPlaceHolder.color == orange.color)
            {
                materialPlaceHolder.color = red.color;
            }
            else if(materialPlaceHolder.color == red.color)
            {
                materialPlaceHolder.color= deepRed.color;
            }
            else if(materialPlaceHolder.color == deepRed.color)
            {
                //drop wood
                for (int i = 0; i < logInstatiatePoints.Length; i++)
                {
                    Instantiate(log, logInstatiatePoints[i].position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
}
