using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private const string HORIZONTAL = "Horizontal";
    public float velocidade;

    public Transform player;
    public Transform ground;

    private Animator animator;
    private Rigidbody2D rigidBody;

    public bool isGrounded;
    public bool isJumped;

    public float force = 300;
    public float jumpTime = 0.3f;
    public float jumpDelay = 0.3f;

	// Use this for initialization
	void Start () {
        animator = player.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        Movimentar();

	}

    void Movimentar()
    {
        isGrounded = Physics2D.Linecast(this.transform.position, ground.position, 1 << LayerMask.NameToLayer("Plataformas"));
        animator.SetFloat("walk", Mathf.Abs(Input.GetAxis(HORIZONTAL)));

        if (Input.GetAxisRaw(HORIZONTAL) > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw(HORIZONTAL) < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetButtonDown("Jump") && isGrounded && !isJumped)
        {
            rigidBody.AddForce(transform.up * force);
            jumpTime = jumpDelay;
            animator.SetTrigger("jump");
            isJumped = true;
        }

        jumpTime -= Time.deltaTime;
        
        if(jumpTime <= 0 && isGrounded && isJumped)
        {
            animator.SetTrigger("ground");
            isJumped = false;
        }
    }
}
