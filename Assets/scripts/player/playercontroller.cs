using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class playercontroller : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer sr;
    [SerializeField]
    public float moveSpeed = 0.1f;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    [SerializeField]
    public float jumpForce = 1.5f;
    [SerializeField]
    public GameObject graphic;
    private Vector3 origLocalScale;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        origLocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        { rb2d.AddForce(Vector2.left * moveSpeed);
            anim.SetBool("Moving", true);
        }

        if (Input.GetKey(KeyCode.D))
        { rb2d.AddForce(Vector2.right * moveSpeed);
            anim.SetBool("Moving", true);
        }
        if(!Input.GetKey(KeyCode.D)&& !Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Moving", false);

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        { rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); }

        if (Input.GetKey(KeyCode.Space))
            { anim.SetBool("jump", true); }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true)
        {
            anim.SetBool("Grounded", true);
            anim.SetBool("jump", false);
        }
        if (isGrounded == false)
        {
            anim.SetBool("Grounded", false); }

        //Flip the graphic's localScale
        if (Input.GetKeyDown(KeyCode.D))
        {
            graphic.transform.localScale = new Vector3(-origLocalScale.x, transform.localScale.y, transform.localScale.z);

        }
        if (Input.GetKey(KeyCode.A))
        
            graphic.transform.localScale = new Vector3(origLocalScale.x, transform.localScale.y, transform.localScale.z);

        }



    }