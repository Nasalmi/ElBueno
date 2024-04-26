using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int disparosParaDestruir = 3; // Número de disparos necesarios para destruir al enemigo
    public int disparosRecibidos = 0; // Contador de disparos recibidos
    private Animator animator;
    private Collider colliderPersonaje;
    public GameObject moscaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("GenerarMosca", 1.8f, 1.8f);
        //colliderPersonaje = GetComponent<Collider>();
        //colliderPersonaje.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void GenerarMosca()
    {
        Instantiate(moscaPrefab, transform.position, Quaternion.identity);
        Instantiate(moscaPrefab, transform.position, Quaternion.identity);
    }
}