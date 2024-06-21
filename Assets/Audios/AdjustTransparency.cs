using UnityEngine;
using UnityEngine.UI;

public class AdjustTransparency : MonoBehaviour
{
    public LayerMask playerLayer; // Layer para os objetos dos jogadores
    public GameObject imageObject; // Referência para o GameObject da imagem na cena
    public float maxAlphaDistance = 10f; // Distância máxima para alcançar o alpha máximo da imagem
    public float minAlphaDistance = 2f; // Distância mínima para alcançar o alpha mínimo da imagem
    public float maxAlphaValue = 160f; // Valor máximo do alpha da imagem

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
            // Obtém o componente Image do GameObject da imagem
            imageComponent = imageObject.GetComponent<Image>();
            initialColor = imageComponent.color;
            targetColor = initialColor;
        }
        else
        {
            Debug.LogError("GameObject da imagem não especificado.");
        }
    }

    void Update()
    {
        // Se não houver jogador na cena ou o GameObject da imagem não foi especificado, não há nada para fazer
        if (player == null || imageComponent == null)
            return;

        // Calcula a distância entre este objeto e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Calcula o alpha da imagem com base na distância do jogador
        float alpha = Mathf.Clamp01((maxAlphaDistance - distanceToPlayer) / (maxAlphaDistance - minAlphaDistance));

        // Limita o valor máximo do alpha
        alpha = Mathf.Min(alpha, maxAlphaValue / 255f); // Dividimos por 255 para obter o valor na faixa de 0 a 1

        // Define o alvo de cor para a transição de opacidade
        targetColor.a = alpha;

        // Transição de opacidade
        if (imageComponent.color != targetColor)
        {
            imageComponent.color = targetColor;
        }
    }
}
