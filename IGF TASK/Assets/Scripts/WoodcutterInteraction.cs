using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodcutterInteraction : MonoBehaviour
{
    [SerializeField] int logs;
    [SerializeField] GameObject tree;
    [SerializeField] GameObject[] treePlacement;

    public void IncreaseLogsBy(int num) { logs += num; }

    private void Start()
    {
        InstatiateTrees();
    }

    public void Replant()
    {
        if(logs!=0 && logs % 10 == 0) {
            InstatiateTrees();
        }
    }


    void InstatiateTrees()
    {
        for (int i = 0; i < treePlacement.Length; i++)
        {
            if(treePlacement[i].transform.childCount == 0)
            {
                Instantiate(tree, treePlacement[i].transform);
            }
        }
    }
}
