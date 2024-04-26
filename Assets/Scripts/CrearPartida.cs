using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class crearPartida : MonoBehaviour
{

    // Método para llamar al final de la partida
    public void mandarDatos(string userId, int level, int wave, float timeSpent, int[] monstersKilled, int totalGold, int totalHearts)
    {
        StartCoroutine(guardarDatos(userId, level, wave, timeSpent, monstersKilled, totalGold, totalHearts));
    }

    IEnumerator guardarDatos(string userId, int level, int wave, float timeSpent, int[] monstersKilled, int totalGold, int totalHearts)
    {
        // Crear el objeto de datos del juego
        GameData gameData = new GameData
        {
            user_id = userId,
            level = level,
            wave = wave,
            time_spent = timeSpent,
            monsters_killed = monstersKilled,
            total_gold = totalGold,
            total_hearts = totalHearts,
            date = System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ") // Formato de fecha ISO 8601
        };
        Debug.Log(gameData);

        string jsonData = JsonUtility.ToJson(gameData);

        using (UnityWebRequest www = new UnityWebRequest("http://52.3.170.212:8080/api/gameUser", "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error enviando datos del juego: " + www.error);
            }
            else
            {
                Debug.Log("Datos del juego enviados correctamente: " + www.downloadHandler.text);
            }
        }
    }

    [System.Serializable]
    public class GameData
    {
        public string user_id;
        public int level;
        public int wave;
        public float time_spent;
        public int[] monsters_killed;
        public int total_gold;
        public int total_hearts;
        public string date;
    }
}
