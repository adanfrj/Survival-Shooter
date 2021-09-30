using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 1;
    public Transform[] spawnPoints;

    [SerializeField]
    EnemyFactory factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //Get nilai random
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, 3);
        
        //duplikat enemy
        Factory.FactoryMethod(spawnEnemy);
    }
}
