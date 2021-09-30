using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningManager : MonoBehaviour
{
    public Text warningText; 
    Animator warningAnim;
    

    void Start()
    {
        warningText.gameObject.SetActive(false);
    }


    void Awake()
    {
        warningAnim = GetComponent<Animator>();
    }
    
    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m",Mathf.RoundToInt(enemyDistance));
        warningAnim.SetTrigger("Warning");
    }

}
