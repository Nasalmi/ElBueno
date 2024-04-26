using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; // Necesario para trabajar con UI en Unity
using TMPro; // Necesario para trabajar con TextMeshPro en Unity

public class Login : MonoBehaviour
{
    public TMP_InputField emailInputField; // Arrastra aquí tu InputField de email desde el Inspector
    public TMP_InputField passwordInputField;
    public Text userInfoDisplay; // Arrastra aquí tu InputField de contraseña desde el Inspector

    // Función que se llama al presionar el botón de login
    public void OnLoginButtonClicked()
    {
        StartCoroutine(Logear(emailInputField.text, passwordInputField.text));
    }

    IEnumerator Logear(string email, string password)
    {
        string url = "http://nasalmi.duckdns.org/api/login";
        string jsonData = JsonUtility.ToJson(new LoginData
        {
            username = email,
            password = password
        });

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            // Enviar la solicitud y esperar la respuesta
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error en el login: " + www.error);
                Debug.LogError("Detalles del error: " + www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Login exitoso: " + www.downloadHandler.text);
                HandleLoginSuccess(www.downloadHandler.text);
                
            }
        }
    }

    IEnumerator FetchUserData(string userId)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://52.3.170.212:8080/api/users/" + userId))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error fetching user data: " + www.error);
            }
            else
            {
                Debug.Log("Received user data: " + www.downloadHandler.text);
                Debug.Log("User data: " + www.downloadHandler.text);
            }
        }
    }

    void HandleLoginSuccess(string jsonResponse)
    {
        TokenResponse response = JsonUtility.FromJson<TokenResponse>(jsonResponse);
        PlayerPrefs.SetString("token", response.token);
        PlayerPrefs.Save();

        FetchUserData(response.userId);

        // Aquí puedes implementar lo que debe suceder tras un login exitoso
        // Por ejemplo, cargar otra escena o actualizar la UI
    }

    [System.Serializable]
    public class LoginData
    {
        public string username;
        public string password;
    }

    [System.Serializable]
    public class TokenResponse
    {
        public string userId;
        public string token;
    }
}