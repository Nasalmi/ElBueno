using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boliche : MonoBehaviour
{
    private Animator animator;
    public float velocidad = 3f;
    public int disparosParaDestruir = 3; // Número de disparos necesarios para destruir al enemigo
    public int disparosRecibidos = 0; // Contador de disparos recibidos
    private Transform jugador;
    public GameObject gusanoPrefab;
    public Transform objetivo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // Invocar el método GenerarGusano cada 3 segundos, comenzando después de 3 segundos de espera.
        InvokeRepeating("GenerarGusano", 3f, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        if (objetivo != null)
        {
            Vector2 direccion = (objetivo.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
        }
    }

    public void RecibirDisparo()
    {
        disparosRecibidos++; // Incrementar el contador de disparos recibidos
        
        // Verificar si se ha alcanzado el número de disparos necesarios para destruir al enemigo
        if (disparosRecibidos >= disparosParaDestruir)
        {
            // Si se ha alcanzado, destruir al enemigo
            Destroy(gameObject);
        }
    }

    void GenerarGusano()
    {
        // Instanciar un nuevo Gusano en la posición del Boliche.
        animator.Play("AtaqueBoliche");
        Instantiate(gusanoPrefab, transform.position, Quaternion.identity);
    }


}

