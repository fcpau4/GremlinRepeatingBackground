using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gremlin : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public LayerMask layerMaskForGrounded;
    public float isGroundedRayLength = 0.1f;

    private Rigidbody2D rb2d;
    private Animator anim;



	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	


	void Update()
    {
        //Jump.
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(0, jumpHeight);
        }

        //Walk to the Right.
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        }

        //Walk to the Left.
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.x);
        }


        if (isGrounded())
        {
            anim.SetFloat("velocity", rb2d.velocity.x);
        }else
        {
            anim.SetBool("grounded", isGrounded());
        }

    }

    public bool isGrounded()
    {
      
            Vector2 currentPosition = transform.position;
            currentPosition.y = GetComponent<Collider2D>().bounds.min.y + 0.1f;

            float lengthRay = isGroundedRayLength + 2f;

            Debug.DrawRay(currentPosition, Vector3.down * lengthRay, Color.green);
            bool grounded = Physics2D.Raycast(currentPosition, Vector2.down, isGroundedRayLength, 1 << LayerMask.NameToLayer("Ground"));

            return grounded;
        
    }

}
