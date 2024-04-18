using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameEffect : MonoBehaviour
{
    public GameObject EndExplosionEffect;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        EndExplosionEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                EndExplosionEffect.SetActive(true);
                StartCoroutine(EndExplosionEff());
                //GetComponent<Renderer>().material = "square01_001-uhd";
            }
        }
    IEnumerator EndExplosionEff()
    {

        yield return new WaitForSeconds(1f); // Tempo para a explosão
        EndExplosionEffect.SetActive(false);

    }
}
