using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100; //darah awal
    public int currentHealth;
    public float sinkSpeed = 2.5f; 
    public int scoreValue = 10; //nilai skor
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        //Mendapatkan reference kompomnen
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        //Setting current health
        currentHealth = startingHealth;
    }


    void Update ()
    {
        //Jika sinking
        if (isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        //Jika mati
        if (isDead)
            return;

        //putar audio
        enemyAudio.Play ();

        //kurangi darah
        currentHealth -= amount;

        // ubah posisi partikel
        hitParticles.transform.position = hitPoint;

        //play sistem partikel
        hitParticles.Play();

        //apabila darah <0 maka mati
        if (currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        //disable navmesh component
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;

        //atur rigidbody ke kimematic
        GetComponent<Rigidbody> ().isKinematic = true;
        isSinking = true;

        //skor bertambah
        ScoreManager.score += scoreValue;

        //hancurkan game object
        Destroy (gameObject, 2f);
    }
}
