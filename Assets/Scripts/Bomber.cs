using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public float velocidad = 3f;
    public int disparosParaDestruir = 3; 
    public int disparosRecibidos = 0; 

    private Rigidbody2D rb;
    private Vector2 direccionMovimiento = Vector2.one.normalized; // Movimiento inicial en diagonal

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento en la dirección diagonal
        rb.velocity = direccionMovimiento * velocidad;
    }

    // Detectar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int paredLayer = LayerMask.NameToLayer("pared"); // Obtener el índice de capa de "Pared"
    
        // Verificar si el objeto de colisión está en la capa de "Pared"
        if (collision.gameObject.layer == paredLayer)
        {
            // Calcular el nuevo vector de dirección para el rebote diagonal
            Vector2 normal = collision.contacts[0].normal;
            direccionMovimiento = Vector2.Reflect(direccionMovimiento, normal);
        }
    }
    
    // Método para recibir disparo
    public void RecibirDisparo()
    {
        disparosRecibidos++;

        if (disparosRecibidos >= disparosParaDestruir)
        {
            Destroy(gameObject);
        }
    }
}

