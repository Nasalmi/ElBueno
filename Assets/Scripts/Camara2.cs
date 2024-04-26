using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2 : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector2 minValues, maxValues;  // Límites para la posición de la cámara
    bool changedCameraValues = false; // Flag para controlar si se cambiaron los valores de la cámara

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.position + offset;

        // Comprobar si la posición x del jugador es mayor que 6.19 y aún no se han cambiado los valores de la cámara
        if (player.position.x >= 6.19f)
        {
            ChangeCameraTienda(); // Cambiar a la cámara de la tienda
        }
        else if (player.position.x <= -12.4f)
        {
            ChangeCameraTesoro(); // Cambiar a la cámara del tesoro
        }
        else if (player.position.x <= 6.19f)
        {
            ChangeCameraArena(); // Cambiar a la cámara de la arena
        }

 
        // Clampeo de la posición deseada dentro de los límites establecidos
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minValues.x, maxValues.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minValues.y, maxValues.y);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Si deseas que la cámara mire siempre al objetivo
        // transform.LookAt(target);
    }

    // Función para cambiar los valores de la cámara
    void ChangeCameraTienda()
    {
        offset = new Vector3(15.8f, -6f, offset.z); // Cambiar el valor de offset
        minValues = new Vector3(15.8f, -6f); // Cambiar el valor de minValues
        maxValues = new Vector3(15.8f, -6f); // Cambiar el valor de maxValues
        changedCameraValues = true; // Establecer la bandera en true para indicar que los valores se han cambiado
    }

    void ChangeCameraArena()
    {
        offset = new Vector3(-4f,0f, offset.z); // Cambiar el valor de offset
        minValues = new Vector3(-3f, -13f); // Cambiar el valor de minValues
        maxValues = new Vector3(-3f, 0f); // Cambiar el valor de maxValues
        changedCameraValues = true; // Establecer la bandera en true para indicar que los valores se han cambiado
    }

    void ChangeCameraTesoro()
    {
        offset = new Vector3(-21.8f, -6f, offset.z); // Cambiar el valor de offset
        minValues = new Vector3(-21.8f, -6f); // Cambiar el valor de minValues
        maxValues = new Vector3(-21.8f, -6f); // Cambiar el valor de maxValues
        changedCameraValues = true; // Establecer la bandera en true para indicar que los valores se han cambiado
    }
}
