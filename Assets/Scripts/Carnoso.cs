using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnoso : MonoBehaviour
{
    private Animator animator; 
    public Transform objetivo;
    public float velocidad = 3f;
    public int disparosParaDestruir = 3; // Número de disparos necesarios para destruir al enemigo
    public int disparosRecibidos = 0; // Contador de disparos recibidos


    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivo != null)
        {
            Vector2 direccion = (objetivo.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
            ActualizarAnimaciones(direccion);
        }
    }

    private void ActualizarAnimaciones(Vector3 direccion)
    {
        if (direccion.x > 0)
        {
            animator.Play("ArribaCarnoso");
        }
        else if (direccion.x < 0)
        {
            animator.Play("CarnosoIzq");
        }
        else if (direccion.y > 0)
        {
            animator.Play("ArribaCarnoso");
        }
        else if (direccion.y < 0)
        {
            animator.Play("ArribaCarnoso");
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
