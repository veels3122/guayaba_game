using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 10f;

    public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoreconocido = null;



    // Start is called before the first frame update
    void Start()
    {
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
            Deselected();
            SelectedObject(hit.transform);

            if(hit.collider.tag == "interact")
            {
                if(Input.GetKeyDown(KeyCode.E)) 
                {
                    hit.collider.transform.GetComponent<ObjectInt>().ActivateObject();


                }
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            Deselected();
        }


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
            ultimoreconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoreconocido = null;
        }
    }

    void OnGUI()
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
