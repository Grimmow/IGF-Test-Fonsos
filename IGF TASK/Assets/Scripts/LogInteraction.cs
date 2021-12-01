using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class LogInteraction : MonoBehaviour
{
    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<Player>().GetLogs() < 3)
            {
                collision.gameObject.GetComponent<Player>().IncreaseLogsBy(1);
                collision.gameObject.GetComponent<Player>().GetLogText().text = "Logs : " + collision.gameObject.GetComponent<Player>().GetLogs();
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Player>().getErrorsText().text = "Can't carry anymore.";
                await Task.Delay(3000);
                collision.gameObject.GetComponent<Player>().getErrorsText().text = "";
            }
        }
    }
}
