using UnityEngine;

public class MusicController : MonoBehaviour
{
    public LayerMask playerLayer; // Layer para os objetos dos jogadores
    public AudioClip backgroundMusic; // Música de fundo que será reproduzida
    public float maxVolumeDistance = 10f; // Distância máxima para alcançar o volume máximo da música
    public float minVolumeDistance = 2f; // Distância mínima para alcançar o volume mínimo da música

    public bool showVolumeSpheres = true; // Define se as esferas de volume serão exibidas
    public Color minVolumeSphereColor = Color.green; // Cor da esfera de volume para minVolumeDistance
    public Color maxVolumeSphereColor = Color.red; // Cor da esfera de volume para maxVolumeDistance

    private AudioSource audioSource;
    private GameObject player;
    private GameObject minVolumeSphere; // Representação visual da área de volume para minVolumeDistance
    private GameObject maxVolumeSphere; // Representação visual da área de volume para maxVolumeDistance

    void Start()
    {
        // Obtém o componente AudioSource anexado ao GameObject
        audioSource = GetComponent<AudioSource>();

        // Procura por um objeto na camada "Player"
        player = GameObject.FindWithTag("player");

        // Cria as esferas de volume
        minVolumeSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        minVolumeSphere.GetComponent<Renderer>().material.color = minVolumeSphereColor;
        minVolumeSphere.GetComponent<Collider>().enabled = false;

        maxVolumeSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        maxVolumeSphere.GetComponent<Renderer>().material.color = maxVolumeSphereColor;
        maxVolumeSphere.GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        // Se não houver jogador na cena, não há nada para fazer
        if (player == null)
            return;

        // Calcula a distância entre este objeto e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Calcula o volume da música com base na distância do jogador
        float volume = Mathf.Clamp01((maxVolumeDistance - distanceToPlayer) / (maxVolumeDistance - minVolumeDistance));

        // Define o volume da música
        audioSource.volume = volume;

        // Se o volume for maior que zero e a música não estiver sendo reproduzida, comece a reproduzi-la
        if (volume > 0 && !audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
        // Se o volume for zero e a música estiver sendo reproduzida, pare a reprodução
        else if (volume == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Atualiza a posição e o tamanho das esferas de volume
        if (showVolumeSpheres)
        {
            minVolumeSphere.SetActive(true);
            minVolumeSphere.transform.position = transform.position;
            minVolumeSphere.transform.localScale = Vector3.one * (minVolumeDistance * 2f);

            maxVolumeSphere.SetActive(true);
            maxVolumeSphere.transform.position = transform.position;
            maxVolumeSphere.transform.localScale = Vector3.one * (maxVolumeDistance * 2f);
        }
        else
        {
            minVolumeSphere.SetActive(false);
            maxVolumeSphere.SetActive(false);
        }
    }
}
