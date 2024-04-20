using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    // Variável estática para armazenar o nome da tela anterior
    public static string PreviousScreen { get; private set; }

    // Método para definir a tela anterior
    public static void SetPreviousScreen(string screenName)
    {
        PreviousScreen = screenName;
    }
}
