using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody rb;
    private float speed = 9.5f;
    private float jumpPower = 11.2f;
    private float smoothSpeed = 5f;
    private float currentSpeed = 0f;
    [SerializeField] public ParticleSystem SparkEffectobject = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //GetComponent<Renderer>().material
    }

    void Update()
    {
        // Verifica se a tecla de espaço está sendo pressionada para fazer a nave subir
        if (Input.GetKey(KeyCode.Space))
        {
            //ativa o efeito de particulas
            SparkEffectobject.Play();
            currentSpeed = Mathf.Lerp(currentSpeed, jumpPower, Time.deltaTime * smoothSpeed);
        }
        else
        {
            //Desativa o efeito de particulas
            SparkEffectobject.Stop();
            // Se a tecla de espaço não está sendo pressionada, a nave desce
            currentSpeed = Mathf.Lerp(currentSpeed, -jumpPower, Time.deltaTime * smoothSpeed);
        }

        // Ajusta a inclinação da nave com base na velocidade vertical
        transform.rotation = Quaternion.Euler(0, 0, -currentSpeed * 1f);

        // Movimento horizontal constante, mesmo no chão
        rb.velocity = new Vector3(-speed, currentSpeed, 0f);
    }
}