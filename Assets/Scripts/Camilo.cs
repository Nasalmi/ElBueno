using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camilo : MonoBehaviour
{
    public Transform objetivo;
    public GameObject balaPrefab; // Prefab de la bala
    public float velocidad = 3f;
    public int disparosParaDestruir = 3;
    public int disparosRecibidos = 0;
    public float tiempoEntreDisparos = 3f; // Tiempo entre cada disparo
    private float tiempoUltimoDisparo = 0f; // Tiempo del último disparo

    void Update()
    {
        if (objetivo != null)
        {
            Vector2 direccion = (objetivo.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

            // Verificar si es tiempo de disparar
            if (Time.time >= tiempoUltimoDisparo + tiempoEntreDisparos)
            {
                // Disparar balas en todas las direcciones
                Disparo(Vector2.up); // Arriba
                Disparo(Vector2.down); // Abajo
                Disparo(Vector2.left); // Izquierda
                Disparo(Vector2.right); // Derecha

                // Actualizar el tiempo del último disparo
                tiempoUltimoDisparo = Time.time;
            }
        }
    }


    void Disparo(Vector2 direccion)
    {
        // Instanciar la bala en la posición del personaje
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);

        // Obtener el componente Rigidbody2D de la bala
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();

        // Aplicar fuerza a la bala en la dirección dada
        rbBala.AddForce(direccion * velocidad, ForceMode2D.Impulse);
    }

    public void RecibirDisparo()
    {
        disparosRecibidos++;
        if (disparosRecibidos >= disparosParaDestruir)
        {
            Destroy(gameObject);
        }
    }
}
