using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public float tiempoDisparo = 0.5f;
    private float cronometroDisparo = 0f;
    public float velocidad = 5f;
    private BulletPool bulletPool;
    private Rigidbody2D rb;

    void Start()
    {
        animator=GetComponent<Animator>();
        bulletPool = FindObjectOfType<BulletPool>(); // Encuentra el objeto BulletPool en la escena
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hor, vert) * velocidad;

        /*
         if(Input.GetKey("a"))
        {
            gameObject.transform.Translate(-6f * Time.deltaTime, 0, 0);
            animator.Play("Izq");
        }
        if(Input.GetKey("d"))
        {
            gameObject.transform.Translate(6f * Time.deltaTime, 0, 0);
            animator.Play("Der");
        }
        if(Input.GetKey("s"))
        {
            gameObject.transform.Translate(0, -6f * Time.deltaTime, 0);
            animator.Play("Abajo");
        }
        if(Input.GetKey("w"))
        {
            gameObject.transform.Translate(0, 6f * Time.deltaTime, 0);
            animator.Play("Arriba");
        }
        if(Input.GetKeyDown("up"))
        {
            animator.Play("Arriba");
        }
        if(Input.GetKeyDown("down"))
        {
            animator.Play("Abajo");
            
        }
        if (Input.GetKeyDown("left"))
        {
            animator.Play("Izq");
            
        }
        if(Input.GetKeyDown("right"))
        {
            animator.Play("Der");
            
        }*/

        cronometroDisparo += Time.deltaTime;

        if (Input.GetKeyDown("up") && cronometroDisparo >= tiempoDisparo)
        {
            Disparar(Vector2.up, velocidad);
        }
        else if (Input.GetKeyDown("down") && cronometroDisparo >= tiempoDisparo)
        {
            Disparar(Vector2.down, velocidad);
        }
        else if (Input.GetKeyDown("left") && cronometroDisparo >= tiempoDisparo)
        {
            Disparar(Vector2.left, velocidad);
        }
        else if (Input.GetKeyDown("right") && cronometroDisparo >= tiempoDisparo)
        {
            Disparar(Vector2.right, velocidad);
        }
    }
    //El disparar fuer<a del disparo por favor. 
    public void Disparar(Vector2 direction, float velocidad)
    {
        //LLamamos a la script publica en la pool balas pasandole la direction a la que tiene que ir
        //la bala.
        bulletPool.Disparar(direction);
    }

}
