using UnityEngine;
using UnityEngine.UI;

public class AdjustTransparency : MonoBehaviour
{
    public LayerMask playerLayer; // Layer para os objetos dos jogadores
    public GameObject imageObject; // Refer�ncia para o GameObject da imagem na cena
    public float maxAlphaDistance = 10f; // Dist�ncia m�xima para alcan�ar o alpha m�ximo da imagem
    public float minAlphaDistance = 2f; // Dist�ncia m�nima para alcan�ar o alpha m�nimo da imagem
    public float maxAlphaValue = 160f; // Valor m�ximo do alpha da imagem

    private GameObject player;
    private Image imageComponent;
    private Color initialColor;
    private Color targetColor;

    void Start()
    {
        // Procura por um objeto na camada "Player"
        player = GameObject.FindWithTag("player");

        if (imageObject != null)
        {
            // Obt�m o componente Image do GameObject da imagem
            imageComponent = imageObject.GetComponent<Image>();
            initialColor = imageComponent.color;
            targetColor = initialColor;
        }
        else
        {
            Debug.LogError("GameObject da imagem n�o especificado.");
        }
    }

    void Update()
    {
        // Se n�o houver jogador na cena ou o GameObject da imagem n�o foi especificado, n�o h� nada para fazer
        if (player == null || imageComponent == null)
            return;

        // Calcula a dist�ncia entre este objeto e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Calcula o alpha da imagem com base na dist�ncia do jogador
        float alpha = Mathf.Clamp01((maxAlphaDistance - distanceToPlayer) / (maxAlphaDistance - minAlphaDistance));

        // Limita o valor m�ximo do alpha
        alpha = Mathf.Min(alpha, maxAlphaValue / 255f); // Dividimos por 255 para obter o valor na faixa de 0 a 1

        // Define o alvo de cor para a transi��o de opacidade
        targetColor.a = alpha;

        // Transi��o de opacidade
        if (imageComponent.color != targetColor)
        {
            imageComponent.color = targetColor;
        }
    }
}
