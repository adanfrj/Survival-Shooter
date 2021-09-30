using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerDetector : MonoBehaviour
{
    public GameOverManager warning;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !other.isTrigger)
        {
            float enemyDistance = Vector3.Distance(transform.position,other.transform.position);
            warning.ShowWarning(enemyDistance);
        }
    }
}
