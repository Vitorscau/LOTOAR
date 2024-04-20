using System.Linq;
using UnityEngine;

public class PulsatingIcon : MonoBehaviour
{
    public float pulseSpeed = 1.0f; // Velocidade da pulsa��o
    public float minScale = 0.5f; // Escala m�nima
    public float maxScale = 1.5f; // Escala m�xima

    private Vector3 baseScale; // Escala base do �cone

    void Start()
    {
        baseScale = transform.localScale; // Armazena a escala base
    }

    void Update()
    {
        // Calcula a nova escala baseada no tempo
        float scale = Mathf.PingPong(Time.time * pulseSpeed, maxScale - minScale) + minScale;

        // Aplica a nova escala ao �cone
        transform.localScale = baseScale * scale;
    }

    
}
