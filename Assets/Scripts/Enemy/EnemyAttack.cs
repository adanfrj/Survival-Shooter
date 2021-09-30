using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        //serang gameobject dengan tag player
        player = GameObject.FindGameObjectWithTag ("Player");

        //get komponen player health
        playerHealth = player.GetComponent <PlayerHealth> ();

        //get komponen animator
        anim = GetComponent <Animator> ();

        //get enemy health
        enemyHealth = GetComponent<EnemyHealth>();
    }

    //Method callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter (Collider other)
    {
        //jika player didalam range
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    //Method callback jika ada suatu object keluar dari trigger
    void OnTriggerExit (Collider other)
    {
        //jika player diluar range
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
        {
            Attack ();
        }

        //jika darah player < 0
        if (playerHealth.currentHealth <= 0)
        {
            //mentrigger animasi PlayerDead jika darah player kurang dari sama dengan 0
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        //Reset timer
        timer = 0f;
        //jika darah player > 0
        if (playerHealth.currentHealth > 0)
        {
            //Taking Damage
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
