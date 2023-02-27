using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rigidbody2d;
    private bool isGrounded = true;
    private Animator animator;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rigidbody2d.velocity = new Vector2(horizontal * moveSpeed, rigidbody2d.velocity.y);

        animator.SetFloat("Direction", horizontal);
        //Debug.Log(horizontal);
        if (horizontal != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //Debug.Log("now is " + i);
            if (i == 1)
            {
                isGrounded = false;
            }
            else
            {
                isGrounded = true;
                animator.SetBool("isJumping", true);
            }
            i++;
            if (i == 2)
            {
                i = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}