using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class muerte : MonoBehaviour
{
    public GameObject deathScreenUI; // Arrastra el panel de la UI de muerte aquí desde el inspector..
    private int level;
    private int wave;
    private int[] monstersKilled;
    private int totalGold;
    public TextMeshProUGUI levelText;

    // Método para activar la pantalla de muerte
    public void ShowDeathScreen()
    {   
        // Asignar los valores de la partida
        level = FindObjectOfType<Player>().level;
        wave = FindObjectOfType<Player>().wave;
        monstersKilled = FindObjectOfType<Player>().monstersKilled;
        totalGold = FindObjectOfType<Player>().totalGold;
        int totalMonstersKilled = 0;
        for (int i = 0; i < monstersKilled.Length; i++)
        {
            totalMonstersKilled += monstersKilled[i];
        }
        // Escribir el texto con los valores de la partida
        // 30 Monsters killed
        //   200 Gold Coins Gained

         //   You Cleared Level 4
         //   And Got to Wave 9

        levelText.text = "" + totalMonstersKilled + " Monsters killed\n" + totalGold + " Gold Coins Gained" + "\n\nYou Cleared Level " + level + "\nAnd Got to Wave " + wave;
        deathScreenUI.SetActive(true);
        Time.timeScale = 0; // Detiene el juego
    }

    // Método vinculado al botón Restart
    public void RestartGame()
    {
        Time.timeScale = 1; // Reanuda el tiempo del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarga la escena
    }

    // Método vinculado al botón Menu
    public void GoToMenu()
    {
        Time.timeScale = 1; // Reanuda el tiempo del juego
        SceneManager.LoadScene("Inicio"); // Cambia a la escena del menú
    }
}
