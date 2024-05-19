using UnityEngine;
using UnityEngine.UI;

public class MostrarTiempo : MonoBehaviour
{
    private float tiempoInicio;
    private bool tiempoPausado;
    private float tiempoTotalGlobal;
    public Text ShowTimer;
    private Score score;

    void Start()
    {
        // Iniciar el cronómetro al inicio del juego
        tiempoInicio = Time.time;
        tiempoPausado = false;
        tiempoTotalGlobal = 0f;
        score = GetComponent<Score>(); // Obtener la referencia a la clase Score
    }

    void Update()
    {
        if (!tiempoPausado)
        {
            // Calcular el tiempo transcurrido
            float tiempoTranscurrido = ObtenerTiempoActual();

            // Calcular minutos y segundos
            int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
            int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);

            // Actualizar el texto con el tiempo transcurrido en formato mm:ss
            ShowTimer.text = "Timer: " + minutos.ToString("00") + ":" + segundos.ToString("00");
        }
    }

    // Método para pausar o reanudar el tiempo
    public void PausarTiempo(bool pausar)
    {
        tiempoPausado = pausar;
    }

    // Método para obtener el tiempo actual, teniendo en cuenta el tiempo total global
    public float ObtenerTiempoActual()
    {
        return Time.time - tiempoInicio + tiempoTotalGlobal;
    }

    // Método para agregar tiempo global
    public void AgregarTiempoGlobal(float tiempoMision)
    {
        tiempoTotalGlobal += tiempoMision;

        // Calcular el puntaje basado en el tiempo de la misión y agregarlo al puntaje total
        float puntajeMision = score.CalcularPuntaje(tiempoMision);
        score.AgregarPuntaje(puntajeMision);
    }

    // Método para reiniciar el tiempo global
    public void ReiniciarTiempoGlobal()
    {
        tiempoInicio = Time.time;
        tiempoTotalGlobal = 0f;
    }

    public float ObtenerTiempoTotalGlobal()
    {
        return tiempoTotalGlobal;
    }
}
