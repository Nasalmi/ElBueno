using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemigo : MonoBehaviour
{
    public GameObject balaenemigo;
    public LayerMask pared;
    public LayerMask player;
    private Rigidbody2D rb;
    public float velocidad = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

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
        if (player == (player | (1 << collision.gameObject.layer)))
        {
            // Si la colisión fue con un objeto en la capa de la pared, destruir la bala
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
