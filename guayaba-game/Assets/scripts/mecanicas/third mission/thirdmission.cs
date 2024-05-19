using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class thirdmission : MonoBehaviour
{
    public MostrarTiempo mostrarTiempo;
    private Score score;
    public Text puntajeMisionText;


    public bool mission_3; 
    public GameObject panelmission;
    public TextMeshProUGUI textomission;
    public GameObject panel1;
    public TextMeshProUGUI texto1;
    public GameObject panel2;
    public TextMeshProUGUI texto2;
    public GameObject panelinteraccion;
    public int numobjetos;
    public GameObject simbolnpc;
    public playercontroller jugador;
    public bool jugadorcerca;
    public bool aceptarmission;
    public GameObject objetos;
    // Start is called before the first frame update
    void Start()
    {
        //Variable para implementar el Score
        score = new Score();
        ////////////////////////////////////

        panelmission.SetActive(false);
        simbolnpc.SetActive(true);
        numobjetos = GameObject.FindGameObjectsWithTag("pruebas").Length;
        textomission.text = "Encuentre y agarre los objetos que se ven de dudosa procedencia"+
            "\n restantes: " + numobjetos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
        mission_3 = false;
        aceptarmission = false;



    }

    // Update is called once per frame
    void Update()
    {
        if(aceptarmission == true)
        {
            simbolnpc.SetActive (false);
        }
        if(aceptarmission == false && Input.GetKeyDown(KeyCode.E) && mission_3 == false && jugadorcerca == true )
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);



            jugador.anim.SetFloat("X", 0);
            jugador.anim.SetFloat("Y", 0);
            jugador.enabled = false;
            panelinteraccion.SetActive(false);
            panel1.SetActive(true);
            panel2.SetActive(true);
            texto1.text = "Esta listo para encontrar los objetos sospechosos?";
            texto2.text = "Presiona 'Y'- Claro vamos a encontrar de donde vienen esas guayabas \n presiona 'X'- Dame un momento ";

        }
        if(panel1 == true &&panel2 == true && jugadorcerca == true &&Input.GetKeyDown(KeyCode.Y))
        {
            panel2.SetActive (false);
            panel1.SetActive (false);
            panelmission.SetActive(true);
            jugador.enabled = true;
            jugadorcerca = false;
            panelinteraccion.SetActive (false);
            aceptarmission = true;
        }
        if (panel1 == true && panel2 == true && jugadorcerca == true && Input.GetKeyDown(KeyCode.X))
        {
            panel2.SetActive(false);
            panel1.SetActive(false);
            jugador.enabled = true;
            jugadorcerca = false;
            panelinteraccion.SetActive(true); 
            aceptarmission = false;
        }
        if (mission_3 == false)
        {
            numobjetos = GameObject.FindGameObjectsWithTag("pruebas").Length;
            textomission.text = "Encuentre y agarre los objetos que se ven de dudosa procedencia" +
                "\n restantes: " + numobjetos;
        }
        if(numobjetos == 0)
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


            mission_3 = true;
            textomission.text = "¡Bien hecho! con esto tenemos lo suficiente para detener esa plaga en las guayabas \n presiona 'ESC' y dirigete al laboratorio en el mapa ";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(mission_3 == false)
            {
                jugadorcerca = true;
                if(aceptarmission == false)
                {
                    panelinteraccion.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (mission_3 == false)
        {
            if (other.tag == "Player")
            {
                jugadorcerca = false;
                if(aceptarmission == true)
                {
                    objetos.SetActive(true);
                }
                panelinteraccion.SetActive(false);
            }
        }
    }
}
