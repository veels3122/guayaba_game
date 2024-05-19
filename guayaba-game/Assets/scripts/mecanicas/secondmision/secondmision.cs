using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class secondmision : MonoBehaviour
{
    public MostrarTiempo mostrarTiempo;
    private Score score;
    public Text puntajeMisionText;


    public Pause pause;
    public GameObject panel;
    public GameObject SimbolMision;
    public playercontroller jugador;
    public GameObject Panel_Interacion;
    public GameObject PanelDialog;
    public GameObject PanelMision2;

    public TextMeshProUGUI TextMision2;
    public bool JugadorCerca;
    public bool aceptarmision;
    public GameObject[] objetivos;
    public int NumDeObjetivos;
    public GameObject boton;



    // Start is called before the first frame update
    void Start()
    {
        //Variable para implementar el Score
        score = new Score();
        ////////////////////////////////////


        NumDeObjetivos = GameObject.FindGameObjectsWithTag("guayaba_infect").Length;
        TextMision2.text = "¡¡Ayudame!! a recoger las Guayabas infectadas" +
                           "\n Restantes: " + NumDeObjetivos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
        SimbolMision.SetActive(true);
        Panel_Interacion.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& aceptarmision == false && JugadorCerca==true)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);



            jugador.anim.SetFloat("X", 0);
            jugador.anim.SetFloat("Y", 0);
            jugador.enabled = false;
            Panel_Interacion.SetActive(false);
            PanelDialog.SetActive(true);
            
        }
        if (PanelDialog == true && Input.GetKeyDown(KeyCode.Y) && JugadorCerca == true)
        {
            Si();
            panel.SetActive(false);

        }
        if (PanelDialog == true && Input.GetKeyDown(KeyCode.X) && JugadorCerca == true)
        {
            No();
        }
        NumDeObjetivos = GameObject.FindGameObjectsWithTag("guayaba_infect").Length;
        TextMision2.text = "¡¡Ayudame!! a recoger las Guayabas infectadas" +
                           "\n Restantes: " + NumDeObjetivos;

        if (NumDeObjetivos <= 0)
        {
            // Pausa el contador del tiempo
            mostrarTiempo.PausarTiempo(true);
            // Obtener el tiempo transcurrido en segundos
            float tiempoActual = mostrarTiempo.ObtenerTiempoActual();
            // Obtener el tiempo total global desde MostrarTiempo
            float tiempoGlobal = mostrarTiempo.ObtenerTiempoTotalGlobal();
            // Calcular el puntaje para esta misión usando el tiempo global
            float puntajeMision = score.CalcularPuntaje(tiempoActual);
            // Agregar el puntaje de esta misión al puntaje total
            score.AgregarPuntaje(puntajeMision);
            // Mostrar el tiempo actual en el registro
            int minutos = Mathf.FloorToInt(tiempoActual / 60);
            int segundos = Mathf.FloorToInt(tiempoActual % 60);
            Debug.Log("Timer: " + minutos.ToString("00") + ":" + segundos.ToString("00"));
            puntajeMisionText.text = "Puntaje: " + ((int)puntajeMision);
            // Mostrar mensaje de misión completada

            TextMision2.text = "¡Bien hecho! ahora a la TIENDA para buscar más pruebas \n presiona ESC para ir al MAPA y dirigirte a ese escenario.";
            
            
            if (NumDeObjetivos <= 0 && Input.GetKeyDown(KeyCode.T))
            {
                PanelMision2.SetActive(false);
                pause.IsPaused = true;
             
            }


        }
      
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            JugadorCerca = true;
            if (aceptarmision == false)
            {
                Panel_Interacion.SetActive(true);
            }
            panel.SetActive(false);
        }
        



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            JugadorCerca = false;
            if (aceptarmision == false) { panel.SetActive(true); }
            if(aceptarmision == true)
            {
                panel.SetActive(false);
            }
        
            Panel_Interacion.SetActive(false);
        }
    }
    public void No()
    {
        jugador.enabled = true;

        PanelDialog.SetActive(false);

        Panel_Interacion.SetActive(true);

    }

    public void Si()
    {
        jugador.enabled = true;
        aceptarmision= true;

        
        JugadorCerca = false;
        SimbolMision.SetActive(false);
        Panel_Interacion.SetActive(false);
        PanelDialog.SetActive(false);
        PanelMision2.SetActive(true);
    }





}
