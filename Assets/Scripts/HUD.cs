using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] hearts;
    public TextMeshProUGUI oro;
    public TextMeshProUGUI vel;
    public TextMeshProUGUI dmg;

    public TextMeshProUGUI info;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHearts(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < maxHealth);
        }

        for (int i = 0; i <maxHealth; i++)
        {   
            // Activamos solo el primer hijo para activar solo el negro
            Debug.Log(i < currentHealth);
            hearts[i].transform.GetChild(0).GetChild(1).gameObject.SetActive(i < currentHealth);

        }
    }

    public void UpdateStats(int nuevoOro, int nuevaVel, int nuevoDmg) {
        // Aqui cambiamos el texto de Oro, Vel, y Dmg
        oro.text = "" + nuevoOro;
        vel.text = "" + nuevaVel;
        dmg.text = "" + nuevoDmg;
    }

    public void UpdateInfo(float time, int level) {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        info.text = "Time: " + niceTime + "\n" +
                "Level: " + level;
    }
}
