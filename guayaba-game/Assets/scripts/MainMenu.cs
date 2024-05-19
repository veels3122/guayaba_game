using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text userNameText; // Añade un campo de texto para mostrar el nombre de usuario

    private void Start()
    {
        // Verifica si hay un nombre de usuario almacenado en la sesión actual
        if (LoginManager.SessionManager.CurrentUser != null)
        {
            // Asigna el nombre de usuario al texto
            userNameText.text = "Usuario: " + LoginManager.SessionManager.CurrentUser;
        }
        else
        {
            // Si no hay un nombre de usuario almacenado, muestra un mensaje de error o carga la escena de inicio de sesión
            Debug.LogWarning("No se ha iniciado sesión.Error en el programa...");
           // SceneManager.LoadScene("Login");
        }
    }

    public void CargarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }

    public void Salir()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
        //Application.Quit();
    }
}
