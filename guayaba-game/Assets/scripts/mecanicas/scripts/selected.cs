using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 8;

    public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoreconocido = null;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        mask = LayerMask.GetMask("raycast detect");
        TextDetect.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //raycast
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            //aqui se agregan los tipos de colores que se quieran que tengan lso objetos con sus tag
            Deselected();
            if (hit.collider.tag == "object")
            {
               
                SelectedObject(hit.transform);
                OnGUI();
                

            }
            if(hit.collider.tag == "Door")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<ScriptDoor>().ChangeDoorState();
                }
            }
            if (hit.collider.tag == "interact")
            {
             SelectedObjectNT(hit.transform);
                
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    
                    hit.collider.transform.GetComponent<ObjectInt>().ActivateObject();
                    

                }
            }

           
        }
        else
        {
            Deselected();
        }


    }
    private void SelectedObjectNT(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.red;
        ultimoreconocido = transform.gameObject;
    }
    private void SelectedObject(Transform transform) 
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoreconocido = transform.gameObject;


    }
    void Deselected()
    {
        if (ultimoreconocido)
        {
            ultimoreconocido.GetComponent<Renderer>().material.color = Color.clear;
            ultimoreconocido = null;
        }
    }
    private void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero); 
        
        if (ultimoreconocido)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }

    }


}
