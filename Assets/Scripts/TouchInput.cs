using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Verifica se há toque na tela
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Carrega uma nova cena chamada "NomeDaSuaCena"
            SceneManager.LoadScene("Map_Scene");
        }
    }
}
