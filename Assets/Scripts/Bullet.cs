using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask pared;
    public LayerMask enemigo;
    public LayerMask enemigo1;
    public LayerMask enemigo2;
    public LayerMask enemigo3;
    public LayerMask enemigo4;
    public LayerMask enemigo5;
    public LayerMask enemigo6;
    public LayerMask enemigo7;
    public LayerMask enemigo8;
    public LayerMask enemigo9;
    public Transform posDisparo;
    public GameObject lagrimaPrefab;
    public float velocidad = 5f;
    public Vector2 direction;
    private Rigidbody2D rb;

    private float tiempoVidaBala = 10f;
    private float cronometroTiempoBala = 0f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Con esto le ponemos velocidad y direccion
        rb.velocity = direction * velocidad;
        //Con esto generamos un tiempo de vida a la bala (Por si acaso de buguea y se sale del mapa o no colisiona con un enemigo)
        cronometroTiempoBala += Time.deltaTime;
        if(cronometroTiempoBala >= tiempoVidaBala)
        {
            gameObject.SetActive(false);
            cronometroTiempoBala = 0;
        }
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si la colisión ocurrió con un objeto en la capa de la pared
        if (pared == (pared | (1 << collision.gameObject.layer)))
        {
            // Si la colisión fue con un objeto en la capa de la pared, destruir la bala
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
        //MURCIELAGO
        if (enemigo == (enemigo | (1 << collision.gameObject.layer)))
        {
            Murcielagos murcielago = collision.gameObject.GetComponent<Murcielagos>();
            if (murcielago != null)
            {
                murcielago.RecibirDisparo();
                
            }
            gameObject.SetActive(false);
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            
        }
        //GUSANO
        if (enemigo1 == (enemigo1 | (1 << collision.gameObject.layer)))
        {
            Gusano gusano = collision.gameObject.GetComponent<Gusano>();
            if (gusano != null)
            {
                gusano.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        //CARNOSO
        if (enemigo2 == (enemigo2 | (1 << collision.gameObject.layer)))
        {
            Carnoso carnoso = collision.gameObject.GetComponent<Carnoso>();
            if (carnoso != null)
            {
                carnoso.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        //BOMBER
        if (enemigo3 == (enemigo3 | (1 << collision.gameObject.layer)))
        {
            Bomber bomber = collision.gameObject.GetComponent<Bomber>();
            if (bomber != null)
            {
                bomber.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        //BOLICHE
        if (enemigo4 == (enemigo4 | (1 << collision.gameObject.layer)))
        {
            Boliche boliche = collision.gameObject.GetComponent<Boliche>();
            if (boliche != null)
            {
                boliche.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        if (enemigo5 == (enemigo5 | (1 << collision.gameObject.layer)))
        {
            AranaLarga aranaLarga = collision.gameObject.GetComponent<AranaLarga>();
            if (aranaLarga != null)
            {
                aranaLarga.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        if (enemigo5 == (enemigo5 | (1 << collision.gameObject.layer)))
        {
            AranaPeque aranaPeque = collision.gameObject.GetComponent<AranaPeque>();
            if (aranaPeque != null)
            {
                aranaPeque.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        if (enemigo6 == (enemigo6 | (1 << collision.gameObject.layer)))
        {
            Aspito aspito = collision.gameObject.GetComponent<Aspito>();
            if (aspito != null)
            {
                aspito.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        if (enemigo7 == (enemigo7 | (1 << collision.gameObject.layer)))
        {
            Camilo camilo = collision.gameObject.GetComponent<Camilo>();
            if (camilo != null)
            {
                camilo.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        if (enemigo8 == (enemigo8 | (1 << collision.gameObject.layer)))
        {
            Spawner spawner = collision.gameObject.GetComponent<Spawner>();
            if (spawner != null)
            {
                spawner.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }
        if (enemigo9 == (enemigo9 | (1 << collision.gameObject.layer)))
        {
            Mosca mosca = collision.gameObject.GetComponent<Mosca>();
            if (mosca != null)
            {
                mosca.RecibirDisparo();
            }
            //Destroy(gameObject); // Destruir la bala después de colisionar con el enemigo
            gameObject.SetActive(false);
        }

    }
}
