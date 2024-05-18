using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class fourmission : MonoBehaviour
{
    public MostrarTiempo mostrarTiempo;
    private Score score;
    public Text puntajeMisionText;


    public int contador;
    public GameObject panelmission;
    public TextMeshProUGUI textomission;
    public GameObject panel1;
    public GameObject panelinteraccion;
    public GameObject panelinteraccion2;
    
    public TextMeshProUGUI texto1;
    Animator anim;
    public GameObject Handpoint;
    private GameObject pickedObject = null;
    public bool mision;

    void Start()
    {
        //Variable para implementar el Score
        score = new Score();
        ////////////////////////////////////
        ///
        contador = GameObject.FindGameObjectsWithTag("examinarcilindro").Length + GameObject.FindGameObjectsWithTag("examinarguayabagrande").Length + GameObject.FindGameObjectsWithTag("examinarguayaba").Length + GameObject.FindGameObjectsWithTag("examinarguayaba2").Length + GameObject.FindGameObjectsWithTag("examinarcajas").Length;
       textomission.text = "Examina todos lo recolectado en el laboratorio \n restantes: "+ contador;
        anim = GetComponentInChildren<Animator>();
        panelinteraccion2.SetActive(false);
        mision = false;
        panelmission.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        Soltar();
        if(panelinteraccion2 == true && Input.GetKeyDown(KeyCode.Y))
        {
            pickedObject.GetComponent<ObjectInt>().ActivateObject();
            panelinteraccion.SetActive(false);
            panel1.SetActive(false);
            panelinteraccion2.SetActive(false);
        }
        if(pickedObject == null)
        {
            panelinteraccion2.SetActive(false);
        }
        if(mision == false)
        {
            contador = GameObject.FindGameObjectsWithTag("examinarcilindro").Length + GameObject.FindGameObjectsWithTag("examinarguayabagrande").Length + GameObject.FindGameObjectsWithTag("examinarguayaba").Length + GameObject.FindGameObjectsWithTag("examinarguayaba2").Length + GameObject.FindGameObjectsWithTag("examinarcajas").Length;
            textomission.text = "examina todos lo recolectado en el laboratorio \n restantes: " + contador;

        }
        if(contador == 0)
        { // Pausa el contador del tiempo
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


            textomission.text = "perfecto, con esto ya tenemos para detener esta placa, \n muchas gracias por tu ayuda, \n hasta el proximo caso";
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                panelmission.SetActive(false);
                mision = true;
            }
        }

    }

    public void Soltar()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("r"))
            {
                
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.GetComponent<Rigidbody>().freezeRotation = false;
                pickedObject.GetComponent<Rigidbody>().position = Vector3.zero;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;


            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("examinarcilindro"))
        {
            panelinteraccion.SetActive(true);
            if (Input.GetKey(KeyCode.E) && pickedObject == null)
            {
                panelinteraccion.SetActive(false);

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = Handpoint.transform.position;
                other.gameObject.transform.SetParent(Handpoint.gameObject.transform);

                pickedObject = other.gameObject;
                panel1.SetActive(true);
<<<<<<< HEAD
                texto1.text = "Este contenedor tiene sustancias de agrandamiento de guayabas de forma ilicita, tiene sustancias bastante peligrosas";
=======
                texto1.text = "Aunque el hongo se puede dar naturalmente, mucho fertilizante nitrogenado como este potencia el moho gris... ";
>>>>>>> upstream/main
                panelinteraccion2.SetActive(true);
            }

        }
        if (other.gameObject.CompareTag("examinarguayabagrande"))
        {
            panelinteraccion.SetActive(true);
            if (Input.GetKey(KeyCode.E) && pickedObject == null)
            {
                panelinteraccion.SetActive(false);

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = Handpoint.transform.position;
                other.gameObject.transform.SetParent(Handpoint.gameObject.transform);

                pickedObject = other.gameObject;
                panel1.SetActive(true);
<<<<<<< HEAD
                texto1.text = "Esta guayaba se nota que fue alterada por sustancias, fue alterada desde su nacimiento por lo que veo";
=======
                texto1.text = "Esta guayaba esta muy grande, y se ve normal por fuera pero por dentro esta infectada, tal y como dijo el señor de la ciudad...";
>>>>>>> upstream/main
                panelinteraccion2.SetActive(true);
            }

        }
        if (other.gameObject.CompareTag("examinarguayaba"))
        {
            panelinteraccion.SetActive(true);
            if (Input.GetKey(KeyCode.E) && pickedObject == null)
            {
                panelinteraccion.SetActive(false);

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = Handpoint.transform.position;
                other.gameObject.transform.SetParent(Handpoint.gameObject.transform);

                pickedObject = other.gameObject;
                panel1.SetActive(true);
<<<<<<< HEAD
                texto1.text = "¡Uy!, esta guayaba tiene gusanos por dentro, toca tener mas cuidado con estas sirven de prueba para demostrar el virus que existe hoy dia en las guayabas";
=======
                texto1.text = "Parece que esta guayaba tiene una enfermedad muy comun llamada Botritis cinerea...";
>>>>>>> upstream/main
                panelinteraccion2.SetActive(true);
            }

        }
        if (other.gameObject.CompareTag("examinarguayaba2"))
        {
            panelinteraccion.SetActive(true);
            if (Input.GetKey(KeyCode.E) && pickedObject == null)
            {
                panelinteraccion.SetActive(false);

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = Handpoint.transform.position;
                other.gameObject.transform.SetParent(Handpoint.gameObject.transform);

                pickedObject = other.gameObject;
                panel1.SetActive(true);
<<<<<<< HEAD
                texto1.text = "Esta guayaba esta bastante podrida, como si el experimento les hubiera salido mal, esta contiene como una sustancia desidratante, y que la pudre al poco tiempo";
=======
                texto1.text = "Parece ser que esta fue la primer infectada, ya que la enfermedad esta mas avanzada...";
>>>>>>> upstream/main
                panelinteraccion2.SetActive(true);
            }

        }
        if (other.gameObject.CompareTag("examinarcajas"))
        {
            panelinteraccion.SetActive(true);
            if (Input.GetKey(KeyCode.E) && pickedObject == null)
            {
                panelinteraccion.SetActive(false);

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = Handpoint.transform.position;
                other.gameObject.transform.SetParent(Handpoint.gameObject.transform);

                pickedObject = other.gameObject;
                panel1.SetActive(true);
<<<<<<< HEAD
                texto1.text = "Estas cajas, contienen las sustancias que contaminan a las guayabas, y son las que estan pudriendo al resto de competencia";
=======
                texto1.text = "Uh parece ser que debido a las condiciones en que se encuentra esta caja es que ela hongo se anida, debemos cambiar esas condiciones en el cultivo...";
>>>>>>> upstream/main
                panelinteraccion2.SetActive(true);
            }

        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("examinarcilindro"))
        {
            panelinteraccion.SetActive(false);
            

        }
        if (other.gameObject.CompareTag("examinarguayabagrande"))
        {
            panelinteraccion.SetActive(false);


        }
        if (other.gameObject.CompareTag("examinarguayaba"))
        {
            panelinteraccion.SetActive(false);


        }
        if (other.gameObject.CompareTag("examinarguayaba2"))
        {
            panelinteraccion.SetActive(false);
        }
        if (other.gameObject.CompareTag("examinarcajas"))
        {
            panelinteraccion.SetActive(false);
        }
    }

}
