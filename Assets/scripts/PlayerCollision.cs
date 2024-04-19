using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public CubeExplosion Explosion;
    public PlayerMovement movement;
    public ShipMovement shipMovement;
    public GameObject ExplosionEffectobject;
    public GameObject WinMessage;
    public GameObject ExplosionEffectobjectE;
    public GameObject ExplosionEffectobject2;
    //public ExplodeEffect ExplodeEffect;
    private Vector3 initialPosition;
    private bool collisionHandled = false;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip Music;
    
    private AudioSource MusicSource;

    private AudioSource audioSource;

    private void Start()
    {
        WinMessage.SetActive(false);
        ExplosionEffectobject.SetActive(false);
        ExplosionEffectobject2.SetActive(false);
        ExplosionEffectobjectE.SetActive(false);
        gameObject.GetComponent<ShipMovement>().enabled = false;
     
        initialPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        
        MusicSource = GetComponent<AudioSource>();
        
        MusicSource.clip = Music;
        MusicSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !collisionHandled)
        {
            MusicSource.Stop();
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            audioSource.clip = deathClip;
            audioSource.Play();
            Explosion.ExplodeCubes();
           
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
            
            StartCoroutine(HandleCollision());
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
      
            ExplosionEffectobject.SetActive(true);
            StartCoroutine(ExplosionEffect());
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<ShipMovement>().enabled = true;
            transform.localScale = new Vector3(2f, 0.5f, 0.5f);

            //GetComponent<Renderer>().material = "square01_001-uhd";
        }
        else if (other.gameObject.CompareTag("Portal_end"))
        {

            ExplosionEffectobject2.SetActive(true);
            StartCoroutine(ExplosionEffect());
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<ShipMovement>().enabled = true;
            transform.localScale = new Vector3(2f, 0.5f, 0.5f);

            //GetComponent<Renderer>().material = "square01_001-uhd";
        }
        else if (other.gameObject.CompareTag("Portal_hit_end"))
        {
            ExplosionEffectobjectE.SetActive(true);
            StartCoroutine(ExplosionEffectEnd());
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            gameObject.GetComponent<ShipMovement>().enabled = false;
            transform.localScale = new Vector3(1f, 1f, 1f);

            //GetComponent<Renderer>().material = "square01_001-uhd";
        }
        else if (other.gameObject.CompareTag("Portal_end_game"))
        {
            WinMessage.SetActive(true);
            MusicSource.Stop();
            
            Destroy(gameObject);
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            Explosion.ExplodeCubes();

            //GetComponent<Renderer>().material = "square01_001-uhd";
        }
    }

   

    IEnumerator HandleCollision()
    {
        
        yield return new WaitForSeconds(0.5f); 
        collisionHandled = true;
    }
    IEnumerator ExplosionEffect()
    {
       
        yield return new WaitForSeconds(1f); // Tempo para a explosão
        ExplosionEffectobject.SetActive(false);
        
    }
    IEnumerator ExplosionEffectEnd()
    {

        yield return new WaitForSeconds(1f); // Tempo para a explosão
        ExplosionEffectobjectE.SetActive(false);

    }
    private void Update()
    {
        if (collisionHandled)
        {
            ResetGame(); // Resetar o jogo após a explosão
        }
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
