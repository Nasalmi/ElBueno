using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielagos : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objetivo;
    public float velocidad = 3f;
    public int disparosParaDestruir = 3; // Número de disparos necesarios para destruir al enemigo
    public int disparosRecibidos = 0; // Contador de disparos recibidos
    void Start()
    {
        
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
}
