using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;

public class Score : MonoBehaviour
{

    private float puntajeTotal;
    private float puntajeMisionActual; // Nuevo atributo para almacenar el puntaje de la misión actual

    public Score()
    {
        puntajeTotal = 0f;
        puntajeMisionActual = 0f; // Inicializar el puntaje de la misión actual
    }

    public void AgregarPuntaje(float puntaje)
    {
        puntajeMisionActual += puntaje; // Agregar el puntaje también al puntaje de la misión actual
        puntajeTotal += puntaje;
        
    }

    public float ObtenerPuntajeTotal()
    {
        return puntajeTotal;
    }

    public float ObtenerPuntajeMisionActual()
    {
        return puntajeMisionActual;
    }

    // Método para calcular el puntaje
    public float CalcularPuntaje(float tiempoReal)
    {
        // Calcula el puntaje basado en el tiempo real
        // Cuanto menos tiempo tarde el jugador, más puntaje obtendrá
        float puntaje = 1000f - tiempoReal; // Puedes ajustar este valor según tus necesidades

        // Asegura que el puntaje esté en el rango de 0 a 1000
        puntaje = Mathf.Clamp(puntaje, 0f, 1000f);

        return puntaje;
    }
}




//public class OtraClase : MonoBehaviour
//{
//    private Score score;

//    void Start()
//    {
//        score = new Score(); // Asegúrate de inicializar la instancia de Score
//    }

//    // Método que se llama cuando finaliza una misión
//    void FinMision()
//    {
//        // Obtener el puntaje total acumulado
//        float puntajeTotal = score.ObtenerPuntajeTotal();

//        // Utilizar el puntaje total como desees
//        Debug.Log("Puntaje total: " + puntajeTotal);
//    }
//}
