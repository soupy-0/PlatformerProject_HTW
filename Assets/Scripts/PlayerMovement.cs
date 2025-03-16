using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private float speed = 8f;
    private float defaultSpeed;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;

    private float speedPowerUp = 5f;
    
    
    [Header("Dash Settings")] 
    [SerializeField] private float dashingPower = 80f;
    [SerializeField] private float dashingTime = 0.3f;
    [SerializeField] private float dashingCooldown = 1f;
    [Space]
    [Space]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        
        
        horizontal = Input.GetAxisRaw("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical");
        

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 0.5f);
        }
        
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        
        
        Flip();

        
       
        
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
    
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        
        yield return new WaitForSeconds(dashingTime);
        
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void SpeedPowerUp()
    {
        speed *= 1.5f;
        Debug.Log("Speed Up");
        Invoke(nameof(ResetSpeed), speedPowerUp);
    }

    private void ResetSpeed()
    {
        speed = defaultSpeed;
        Debug.Log("Speed Reset");
    }
    
}
