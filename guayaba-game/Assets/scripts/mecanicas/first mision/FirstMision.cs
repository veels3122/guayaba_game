using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstMision : MonoBehaviour
{
    public int NumObjetivos;
    public TextMeshProUGUI TextMision;
    public GameObject ButtonMision;

    // Start is called before the first frame update
    void Start()
    {
        NumObjetivos= GameObject.FindGameObjectsWithTag("Table").Length;
        TextMision.text = "encuentra las tablas que estan flojas" +
            "\n restantes: " + NumObjetivos;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
