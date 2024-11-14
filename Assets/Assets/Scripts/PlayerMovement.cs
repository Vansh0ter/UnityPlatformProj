using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public CoinManager cm;
    [SerializeField]
    private float speed = 8f;
    private float horizontal;
    [SerializeField]
    private InputActionAsset inputAction;

    [SerializeField]
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Transform fireSpawn;
    public GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 12f;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bullet = Instantiate(bulletPrefab, fireSpawn.position, fireSpawn.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            float fireDirection;
            if (isFacingRight)
                fireDirection = 1f;
            else
                fireDirection = -1f;
            bulletRb.velocity = new Vector2(fireDirection * bulletSpeed, 0f);
            Destroy(bullet, 0.5f);
        }
    }

    public void EscapeFromLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
            SceneManager.LoadSceneAsync(0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
        if (other.gameObject.CompareTag("Flag"))
        {
            inputAction.Disable();
            cm.Results();
        }
    }
}
