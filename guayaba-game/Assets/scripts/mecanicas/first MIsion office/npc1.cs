using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class npc1 : MonoBehaviour
{
    public GameObject Simbolayuda;
    public GameObject Npc;
    public GameObject panelpregunta;
    public GameObject Panelrespuesta;
    public TextMeshProUGUI TextoPlayer;
    public GameObject PanelNpc1;
    public TextMeshProUGUI TextoNpc1;
    public playercontroller jugador;
    public bool jugadorcerca;
    public bool encontrar;
    public bool ayuda;
    // Start is called before the first frame update
    void Start()
    {
        panelpregunta.SetActive(false);
        PanelNpc1.SetActive(false);
        Panelrespuesta.SetActive(false);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
        encontrar = false;
        ayuda = false;
        Npc.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(ayuda == true)
        {
            Npc.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && ayuda == false && jugadorcerca == true )
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);



            jugador.anim.SetFloat("X", 0);
            jugador.anim.SetFloat("Y", 0);
            jugador.enabled = false;
            panelpregunta.SetActive(false);
            PanelNpc1.SetActive(true);
            Panelrespuesta.SetActive(true);

        }
        if(PanelNpc1 == true && Input.GetKeyDown(KeyCode.Y))
        {
            PanelNpc1.SetActive(false);
            Panelrespuesta.SetActive(false);
            panelpregunta.SetActive(true);
            ayuda = false;
            encontrar = false;
            jugador.enabled = true;

        }
        if(PanelNpc1 == true && Input.GetKeyDown(KeyCode.X))
        {
            Npc.SetActive(true);
            ayuda = true;
            jugador.enabled = true;
            TextoNpc1.text = "las vi al lado de su escritorio";
            TextoPlayer.text = "muchas gracias";
            Simbolayuda.SetActive(false);
            


        }
        if(jugadorcerca== false)
        {
            PanelNpc1.SetActive (false);
            Panelrespuesta.SetActive (false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")

        {
                jugadorcerca = true;
                if (ayuda == false)
                {
                    
                    
                        panelpregunta.SetActive(true);
                    
                }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (encontrar == false)
        {
            if (other.tag == "Player")
            {
                jugadorcerca = false;
                if (ayuda == true)
                {
                    Simbolayuda.SetActive(false);
                    Npc.SetActive(true);
                    
                }
                panelpregunta.SetActive(false);
                PanelNpc1.SetActive(false);
                Panelrespuesta.SetActive(false);
            }
        }
    }
}
