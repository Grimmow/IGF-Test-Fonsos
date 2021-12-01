using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]  int coins = 0;
    [SerializeField]  int logs = 0;
    [SerializeField] Text coinText;
    [SerializeField] Text logsText;
    [SerializeField] Text errorText;
    [SerializeField] GameObject woodText;
    [SerializeField] int rayLength;
    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);

        //raycast for interacting
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            //raycast for interactable objs
            if (hit.transform.CompareTag("Tree") && Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.gameObject.GetComponent<TreeInteraction>().Interaction();
            }
        }
    }

    public int GetLogs() { return logs; }
    public Text getErrorsText() { return errorText; }
    public Text GetLogText() { return logsText; }

    public void IncreaseLogsBy(int number)
    {
        logs += number;
    }
    public void IncreaseCoinsBy(int number)
    {
        coins += number;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Woodcutter"))
        {
            woodText.SetActive(true);
            int x = 0;
            for (int i = 0; i < logs; i++)
            {
                IncreaseCoinsBy(3);
                x++;
            }
            coinText.text = "Coins : " + coins;
            other.gameObject.GetComponent<WoodcutterInteraction>().IncreaseLogsBy(x);
            other.gameObject.GetComponent<WoodcutterInteraction>().Replant();
            logs = 0;
            logsText.text = "Logs : " + logs;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Woodcutter"))
        {
            woodText.SetActive(false);
        }
    }
}
