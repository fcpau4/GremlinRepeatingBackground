using UnityEngine;


public class Gremlin : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    public float jumpPower;
    public bool IsRunning;
    public static Gremlin player;
    public LayerMask groundLayer;
    public PolygonCollider2D coll2d;
    private Rigidbody2D rb2d;
    private Animator anim;
    




    // Use this for initialization
    void Start()
    {
        player = this;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll2d = GetComponent<PolygonCollider2D>();
    }



    void Update()
    {


        if (!HealthManager.IsDead)
        {
            //Jump.
            if (Input.GetKey(KeyCode.Space) && IsGrounded())
            {
                Jump();
            }



            //Walk.
            if (Input.GetKey(KeyCode.D) && IsGrounded())
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
                IsRunning = true;
            }

            //Stop Walkling
            if (Input.GetKeyUp(KeyCode.D) || !IsGrounded())
            {
                IsRunning = false;
            }

            anim.SetBool("IsRunning", IsRunning);

        }
        else
        {
            anim.SetTrigger("Dead");
        }
       
    }



    void Jump()
    {
        if (coll2d.bounds.max.y < jumpHeight)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }
    }


    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;

        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            Debug.Log("Grounded");
            return true;
        }else
        {
            Debug.Log("Air");
            return false;
        }
    }


}
		
       
