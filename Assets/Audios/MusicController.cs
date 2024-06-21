using UnityEngine;

public class MusicController : MonoBehaviour
{
    public LayerMask playerLayer; // Layer para os objetos dos jogadores
    public AudioClip backgroundMusic; // M�sica de fundo que ser� reproduzida
    public float maxVolumeDistance = 10f; // Dist�ncia m�xima para alcan�ar o volume m�ximo da m�sica
    public float minVolumeDistance = 2f; // Dist�ncia m�nima para alcan�ar o volume m�nimo da m�sica

    public bool showVolumeSpheres = true; // Define se as esferas de volume ser�o exibidas
    public Color minVolumeSphereColor = Color.green; // Cor da esfera de volume para minVolumeDistance
    public Color maxVolumeSphereColor = Color.red; // Cor da esfera de volume para maxVolumeDistance

    private AudioSource audioSource;
    private GameObject player;
    private GameObject minVolumeSphere; // Representa��o visual da �rea de volume para minVolumeDistance
    private GameObject maxVolumeSphere; // Representa��o visual da �rea de volume para maxVolumeDistance

    void Start()
    {
        // Obt�m o componente AudioSource anexado ao GameObject
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
        // Se n�o houver jogador na cena, n�o h� nada para fazer
        if (player == null)
            return;

        // Calcula a dist�ncia entre este objeto e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Calcula o volume da m�sica com base na dist�ncia do jogador
        float volume = Mathf.Clamp01((maxVolumeDistance - distanceToPlayer) / (maxVolumeDistance - minVolumeDistance));

        // Define o volume da m�sica
        audioSource.volume = volume;

        // Se o volume for maior que zero e a m�sica n�o estiver sendo reproduzida, comece a reproduzi-la
        if (volume > 0 && !audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
        // Se o volume for zero e a m�sica estiver sendo reproduzida, pare a reprodu��o
        else if (volume == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Atualiza a posi��o e o tamanho das esferas de volume
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
