using System.Linq;
using UnityEngine;

public class PulsatingIcon : MonoBehaviour
{
    public float pulseSpeed = 1.0f; // Velocidade da pulsação
    public float minScale = 0.5f; // Escala mínima
    public float maxScale = 1.5f; // Escala máxima

    private Vector3 baseScale; // Escala base do ícone

    void Start()
    {
        baseScale = transform.localScale; // Armazena a escala base
    }

    void Update()
    {
        // Calcula a nova escala baseada no tempo
        float scale = Mathf.PingPong(Time.time * pulseSpeed, maxScale - minScale) + minScale;

        // Aplica a nova escala ao ícone
        transform.localScale = baseScale * scale;
    }

    
}
