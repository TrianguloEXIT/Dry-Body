using UnityEngine;

public class test : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimentação do jogador
    public bool Terlanterna;
    private Rigidbody2D rb;
    public Animator anim;
    public float moveHorizontal, moveVertical;
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o componente Rigidbody2D do jogador
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
        // Obtém os inputs de movimento horizontal e vertical
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

       
        

        // Normaliza o vetor de movimento para garantir movimento nas direções ortogonais apenas
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        if (Terlanterna == (false))
        {
            moversemlaterna();
            

        }
        else if (Terlanterna == (true))
        {
            anim.SetBool("Run_noflashlight", true);
            anim.SetBool("Get_flashlight", true);
            

            if (moveVertical != 0f || moveHorizontal != 0f)
            {
                anim.SetBool("Run_flashlight", true);

            }
            else
            {

                anim.SetBool("Run_flashlight", false);

            }
        }
      
        rb.velocity = movement * moveSpeed;

    }
   public void moversemlaterna()
    {

        if (moveVertical != 0f || moveHorizontal != 0f)
        {
            anim.SetBool("Run_noflashlight", true);
           

        }
        else
        {

            anim.SetBool("Run_noflashlight", false);

        }

 }

}





