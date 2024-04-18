using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class ExplodeEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem ExplodeParticle = null;
    public Rigidbody rb;
    private bool wantsToEffect = false;

    // Propriedade para controlar quando ativar o efeito de explosão    
    public bool WantsToEffect
    {

        set
        {
            wantsToEffect = value;
            Debug.Log("Valor = " + wantsToEffect);
            if (wantsToEffect)
            {
                Debug.Log("Explode");
                ExplodeParticle.Play();
            }
            else
            {
                Debug.Log("Para");
                ExplodeParticle.Stop();
            }
        }
    }

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        if (!wantsToEffect)
        {
            ExplodeParticle.Stop();
        }
    }
}
*/