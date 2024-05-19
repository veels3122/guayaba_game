using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

public class LoginManager : MonoBehaviour
{
    public InputField userInputField;
    public InputField passInputField;
    public Button loginButton;
    public Text textError;

    // Agrega la clase SessionManager como se mencionó antes
    public static class SessionManager
    {
        private static string _currentUser;

        public static string CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
    }

    private const string ConnectionString = "workstation id=Game_Unity.mssql.somee.com;packet size=4096;user id=sebasv07_SQLLogin_1;pwd=xfzfabdceh;data source=Game_Unity.mssql.somee.com;persist security info=False;initial catalog=Game_Unity;TrustServerCertificate=True";

    private void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClick);
    }

    private void OnLoginButtonClick()
    {
        // Obtener el nombre de usuario y contraseña ingresados por el usuario
        string inputUserName = userInputField.text;
        string inputPassword = passInputField.text;

        // Intentamos buscar el usuario en la base de datos
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Abrimos la conexión
                connection.Open();

                // Query para buscar el usuario en la tabla Users
                string query = "SELECT Password FROM Users WHERE NameUser = @UserName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Pasamos el nombre de usuario como parámetro
                    command.Parameters.AddWithValue("@UserName", inputUserName);

                    // Ejecutamos la consulta y obtenemos el resultado
                    object result = command.ExecuteScalar();

                    // Si el resultado es nulo, el usuario no existe
                    if (result == null)
                    {
                        Debug.Log("Usuario no registrado.");
                        textError.text = "Error: Usuario no registrado.";
                        return;
                    }

                    // Si el usuario existe, comparamos la contraseña
                    string storedPassword = (string)result;
                    if (storedPassword == inputPassword)
                    {
                        // La contraseña es correcta
                        Debug.Log("Inicio de sesión exitoso para el usuario: " + inputUserName);
                        textError.text = ("Inicio de sesión exitoso para el usuario: " + inputUserName);
                        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

                        // Guardamos el nombre de usuario en la sesión actual
                        SessionManager.CurrentUser = inputUserName;

                        // Aquí puedes cargar la escena deseada después del inicio de sesión exitoso
                    }
                    else
                    {
                        // La contraseña es incorrecta
                        Debug.Log("Usuario o contraseña inválidos para el usuario: " + inputUserName);
                        textError.text = "Error: Usuario o contraseña inválidos.";
                    }
                }
            }
        }
        // Si ocurre algún error al conectar con la base de datos, lo capturamos
        catch (Exception ex)
        {
            // Mostramos el mensaje de error en la consola de Unity y en el texto de error
            Debug.LogError("Error al buscar el usuario en la base de datos: " + ex.Message);
            textError.text = "Error: No se pudo verificar el usuario.";
        }
    }
}
