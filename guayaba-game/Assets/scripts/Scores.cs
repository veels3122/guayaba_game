using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;

public class Score : MonoBehaviour
{

    private float puntajeTotal;
    private float puntajeMisionActual; // Nuevo atributo para almacenar el puntaje de la misi�n actual

    public Score()
    {
        puntajeTotal = 0f;
        puntajeMisionActual = 0f; // Inicializar el puntaje de la misi�n actual
    }

    public void AgregarPuntaje(float puntaje)
    {
        puntajeMisionActual += puntaje; // Agregar el puntaje tambi�n al puntaje de la misi�n actual
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

    // M�todo para calcular el puntaje
    public float CalcularPuntaje(float tiempoReal)
    {
        // Calcula el puntaje basado en el tiempo real
        // Cuanto menos tiempo tarde el jugador, m�s puntaje obtendr�
        float puntaje = 1000f - tiempoReal; // Puedes ajustar este valor seg�n tus necesidades

        // Asegura que el puntaje est� en el rango de 0 a 1000
        puntaje = Mathf.Clamp(puntaje, 0f, 1000f);

        return puntaje;
    }
}




//public class OtraClase : MonoBehaviour
//{
//    private Score score;

//    void Start()
//    {
//        score = new Score(); // Aseg�rate de inicializar la instancia de Score
//    }

//    // M�todo que se llama cuando finaliza una misi�n
//    void FinMision()
//    {
//        // Obtener el puntaje total acumulado
//        float puntajeTotal = score.ObtenerPuntajeTotal();

//        // Utilizar el puntaje total como desees
//        Debug.Log("Puntaje total: " + puntajeTotal);
//    }
//}
