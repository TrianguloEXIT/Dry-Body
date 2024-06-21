using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 50f; // Velocidade de flutuação do texto
    public float floatAmplitude = 30f; // Amplitude do movimento de flutuação

    private RectTransform rectTransform;
    private Vector2 startPosition;
    private float floatTimer;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        floatTimer += Time.deltaTime * floatSpeed;
        float newY = startPosition.y + Mathf.Sin(floatTimer) * floatAmplitude;
        rectTransform.anchoredPosition = new Vector2(startPosition.x, newY);
    }
}
