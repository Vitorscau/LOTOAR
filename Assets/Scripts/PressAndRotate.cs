using System.Linq;
using UnityEngine;

public class PressAndRotate : MonoBehaviour
{
    // Sensibilidade da rota��o
    public float rotationSpeed = 0.5f;

    // Refer�ncia � c�mera
    private Camera mainCamera;

    // Eixo de rota��o
    [SerializeField]
    private Vector3 rotationAxis = Vector3.forward;

    // Vari�veis para armazenar o estado do toque
    private bool isTouching = false;
    private Vector2 lastTouchPosition;

    void Start()
    {
        mainCamera = FindGameObjectsAll("Main Camera").GetComponent<Camera>();
        // Obten��o da refer�ncia � c�mera principal se n�o for definida.
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // Verifica se h� um toque na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Se o toque come�ou, armazena a posi��o inicial do toque
            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
                lastTouchPosition = touch.position;
            }
            // Se o toque est� em andamento e o dedo ainda est� pressionando
            else if (touch.phase == TouchPhase.Moved && isTouching)
            {
                // Calcula o movimento do toque
                Vector2 currentTouchPosition = touch.position;
                float deltaX = currentTouchPosition.x - lastTouchPosition.x;

                // Calcula a rota��o com base no movimento horizontal
                float rotationAmount = deltaX * rotationSpeed * Time.deltaTime;

                // Rotaciona o GameObject
                transform.Rotate(rotationAxis, rotationAmount, Space.World);

                // Atualiza a posi��o do �ltimo toque para a pr�xima itera��o
                lastTouchPosition = currentTouchPosition;
            }
            // Se o toque terminou, marca que n�o estamos mais tocando
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
            }
        }
    }
    public static GameObject FindGameObjectsAll(string name) => Resources.FindObjectsOfTypeAll<GameObject>().First(x => x.name == name);
}
