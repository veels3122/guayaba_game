using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object1 : MonoBehaviour
{
    Animator anim;

    public GameObject DoorRFalse;
    public GameObject DoorR;
    public GameObject DoorLFalse;
    public GameObject DoorL;
    public GameObject Handpoint;
    private GameObject pickedObject = null;
    public ScriptDoorOfice prueba;
    public GameObject interaccion;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        interaccion.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Soltar();
        

    }

    public void Soltar()
    {
        if(pickedObject != null)
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
        if (other.gameObject.CompareTag("guayaba_infect"))
            {
            if (Input.GetKey(KeyCode.E) && pickedObject == null)
            {

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = Handpoint.transform.position;
                other.gameObject.transform.SetParent(Handpoint.gameObject.transform);

                pickedObject = other.gameObject;






            }

        }
        if (other.gameObject.CompareTag("object"))
            {

            if (Input.GetKey(KeyCode.E) && pickedObject==null)
            {
                
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent <Rigidbody>().isKinematic = true;

                other.transform.position = Handpoint.transform.position;
                other.gameObject.transform.SetParent(Handpoint.gameObject.transform);

                pickedObject = other.gameObject;

                
                  
                
                

            }
        }
        if (other.gameObject.CompareTag("key"))
        {
            interaccion.SetActive(true);

            if (Input.GetKey(KeyCode.E) && pickedObject == null)
            {

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = Handpoint.transform.position;
                other.gameObject.transform.SetParent(Handpoint.gameObject.transform);

                pickedObject = other.gameObject;
                DoorRFalse.SetActive(false);
                DoorR.SetActive(true);
                DoorLFalse.SetActive(false);
                DoorL.SetActive(true);





            }

        }
        else
        {
            interaccion.SetActive(false);
        }

         
    }
    
}
