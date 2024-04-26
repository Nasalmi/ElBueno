using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 5;
    public Transform posDisparo;
    private int balaActual = 0;

    private List<GameObject> bullets;

    void Start()
    {
        // Inicializar la lista de balas
        bullets = new List<GameObject>();

        // Instanciar y desactivar las balas
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    // Método para obtener una bala del pool
    public void Disparar(Vector2 direccion)
    {
        if(balaActual < poolSize)
        {
            bullets[balaActual].GetComponent<Bullet>().direction = direccion;
            bullets[balaActual].transform.position = posDisparo.transform.position;
            bullets[balaActual].SetActive(true);
            balaActual++;
        } else
        {
            balaActual = 0;
            bullets[balaActual].GetComponent<Bullet>().direction = direccion;
            bullets[balaActual].transform.position = posDisparo.transform.position;
            bullets[balaActual].SetActive(true);
        }
    }
}
