using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    // Vari�vel est�tica para armazenar o nome da tela anterior
    public static string PreviousScreen { get; private set; }

    // M�todo para definir a tela anterior
    public static void SetPreviousScreen(string screenName)
    {
        PreviousScreen = screenName;
    }
}
