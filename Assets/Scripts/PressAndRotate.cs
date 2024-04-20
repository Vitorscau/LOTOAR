using System.Linq;
using UnityEngine;

public class PressAndRotate : MonoBehaviour
{
    // Sensibilidade da rotação
    public float rotationSpeed = 0.5f;

    // Referência à câmera
    private Camera mainCamera;

    // Eixo de rotação
    [SerializeField]
    private Vector3 rotationAxis = Vector3.forward;

    // Variáveis para armazenar o estado do toque
    private bool isTouching = false;
    private Vector2 lastTouchPosition;

    void Start()
    {
        mainCamera = FindGameObjectsAll("Main Camera").GetComponent<Camera>();
        // Obtenção da referência à câmera principal se não for definida.
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // Verifica se há um toque na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Se o toque começou, armazena a posição inicial do toque
            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
                lastTouchPosition = touch.position;
            }
            // Se o toque está em andamento e o dedo ainda está pressionando
            else if (touch.phase == TouchPhase.Moved && isTouching)
            {
                // Calcula o movimento do toque
                Vector2 currentTouchPosition = touch.position;
                float deltaX = currentTouchPosition.x - lastTouchPosition.x;

                // Calcula a rotação com base no movimento horizontal
                float rotationAmount = deltaX * rotationSpeed * Time.deltaTime;

                // Rotaciona o GameObject
                transform.Rotate(rotationAxis, rotationAmount, Space.World);

                // Atualiza a posição do último toque para a próxima iteração
                lastTouchPosition = currentTouchPosition;
            }
            // Se o toque terminou, marca que não estamos mais tocando
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
            }
        }
    }
    public static GameObject FindGameObjectsAll(string name) => Resources.FindObjectsOfTypeAll<GameObject>().First(x => x.name == name);
}
