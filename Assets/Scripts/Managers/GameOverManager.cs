using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       
    public float restartDelay = 5f; 
    public Text warningText; 
    public GameObject gameOverPanel;
    
    Animator anim;                          
    float restart;                    

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
    }
  
    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("Near Enemy : {0} m",Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            gameOverPanel.SetActive(true);
            restart += Time.deltaTime;
            if (restart >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}