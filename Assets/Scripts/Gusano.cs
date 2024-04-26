using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gusano : MonoBehaviour
{
    private Animator animator;
    public float velocidad = 3f;
    public int disparosParaDestruir = 3; // Número de disparos necesarios para destruir al enemigo
    public int disparosRecibidos = 0; // Contador de disparos recibidos
    private Transform jugador;

    void Start()
    {
        // Encuentra el GameObject del jugador al que seguir
        jugador = GameObject.FindGameObjectWithTag("player").transform;
        animator=GetComponent<Animator>();
    }

    void Update()
    {
        // Calcula la dirección del jugador relativa al gusano
        Vector3 direccion = jugador.position - transform.position;
        direccion.z = 0; // Asegura que la dirección sea solo en el plano XY

        // Si el jugador está más cerca horizontalmente que verticalmente, mueve el gusano horizontalmente
        if (Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y))
        {
            MoverGusano(new Vector3(Mathf.Sign(direccion.x), 0, 0));
        }
        // Si el jugador está más cerca verticalmente que horizontalmente, mueve el gusano verticalmente
        else
        {
            MoverGusano(new Vector3(0, Mathf.Sign(direccion.y), 0));
        }
    }

    private void MoverGusano(Vector3 direccion)
    {
        // Mueve el gusano en la dirección especificada con la velocidad especificada
        transform.Translate(direccion * velocidad * Time.deltaTime);

        // Actualiza las animaciones del gusano según la dirección de movimiento
        ActualizarAnimaciones(direccion);
    }

    private void ActualizarAnimaciones(Vector3 direccion)
    {
        if (direccion.x > 0)
        {
            animator.Play("gusRight");
        }
        else if (direccion.x < 0)
        {
            animator.Play("gusLeft");
        }
        else if (direccion.y > 0)
        {
            animator.Play("gusUp");
        }
        else if (direccion.y < 0)
        {
            animator.Play("gusDown");
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

