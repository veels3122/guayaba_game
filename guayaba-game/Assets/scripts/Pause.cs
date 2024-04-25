using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Pause : MonoBehaviour
{
    public GameObject GrupoMenuPausa;
    private bool Pausa = false;

    void Update()
    {
        // Si se presiona Escape, se alterna la pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausa)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    void Start()
    {
        ResumeGame();
    }

    // Método para pausar el juego
    public void PauseGame()
    {
        GrupoMenuPausa.SetActive(true); // Mostrar menú de pausa
        Time.timeScale = 0; // Pausar el tiempo
        Pausa = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }   

    // Método para reanudar el juego
    public void ResumeGame()
    {
        GrupoMenuPausa.SetActive(false); // Ocultar menú de pausa
        Time.timeScale = 1; // Reanudar el tiempo
        Pausa = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Método para salir del juego (puedes modificarlo según tus necesidades)
    public void QuitGame()
    {
        Application.Quit(); // Salir de la aplicación (solo funciona en compilación)
    }

    public void MainMenu(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
}
