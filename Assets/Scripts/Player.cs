using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string userID;
    private string userName;
    public int level;
    public int wave;
    public float timeSpent;
    public int totalGold;
    public int totalHearts;
    public int[] monstersKilled;
    public muerte pantallaMuerte; // Arrastra el script Muerte aquí desde el inspector.
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        wave = 1;
        timeSpent = 0;
        totalGold = 5;
        totalHearts = 3;
        monstersKilled = new int[5];
        for (int i = 0; i < monstersKilled.Length; i++)
        {
            monstersKilled[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Datos de prueba para probar la funcion de insertar Partidas
            userID = "66281a64df33ad6f9f40dc89";
            level = 5;
            wave = 9;
            timeSpent = 120;
            totalGold = 100;
            totalHearts = 20;
            monstersKilled[0] = 10;
            monstersKilled[1] = 5;
            monstersKilled[2] = 3;
            monstersKilled[3] = 2;
            monstersKilled[4] = 1;
            // Borrar esta línea cuando se implemente la funcionalidad de muerte
            Morir();
        }
    }

    void Morir()
    {
        pantallaMuerte.ShowDeathScreen();
        

        this.GetComponent<crearPartida>().mandarDatos(userID, level, wave, timeSpent, monstersKilled, totalGold, totalHearts);

    }
}
