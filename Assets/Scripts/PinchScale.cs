using System.Linq;
using UnityEngine;

public class PinchScale : MonoBehaviour
{
    // Vari�veis para armazenar a escala inicial e a escala m�nima/m�xima permitida.
    public float initialScale = 1f;
    public float minScale = 0.5f;
    public float maxScale = 3f;

    // Vari�veis para armazenar a sensibilidade do pinch e a refer�ncia � c�mera.
    public float pinchSensitivity = 0.01f;
    private Camera mainCamera;

    // Vari�veis para armazenar o estado inicial do "pinch".
    private Vector2 initialPinchPosition1;
    private Vector2 initialPinchPosition2;
    private float initialDistance;

    
    void Start()
    {
        mainCamera = FindGameObjectsAll("Main Camera").GetComponent<Camera>();
        // Configura��o da escala inicial do GameObject.
        transform.localScale = Vector3.one * initialScale;

        // Obten��o da refer�ncia � c�mera principal se n�o for definida.
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // Verifica se houve o movimento de "pinch" na tela.
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                // Salva as posi��es iniciais dos dedos e a dist�ncia inicial entre eles.
                initialPinchPosition1 = touch1.position;
                initialPinchPosition2 = touch2.position;
                initialDistance = Vector2.Distance(initialPinchPosition1, initialPinchPosition2);
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                // Calcula a dist�ncia atual entre os dedos.
                Vector2 currentPinchPosition1 = touch1.position;
                Vector2 currentPinchPosition2 = touch2.position;
                float currentDistance = Vector2.Distance(currentPinchPosition1, currentPinchPosition2);

                // Calcula a diferen�a de dist�ncia entre o "pinch" atual e o inicial.
                float pinchDelta = currentDistance - initialDistance;

                // Calcula a escala atual do GameObject com base na diferen�a de dist�ncia.
                float scaleFactor = 1f + pinchDelta * pinchSensitivity;
                Vector3 newScale = transform.localScale * scaleFactor;

                // Garante que a escala esteja dentro dos limites definidos.
                newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
                newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
                newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

                // Aplica a nova escala ao GameObject.
                transform.localScale = newScale;

                // Atualiza a dist�ncia inicial para a pr�xima itera��o.
                initialDistance = currentDistance;
            }
        }
    }
    public static GameObject FindGameObjectsAll(string name) => Resources.FindObjectsOfTypeAll<GameObject>().First(x => x.name == name);
}
