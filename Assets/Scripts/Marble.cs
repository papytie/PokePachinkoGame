using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Marble : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Rigidbody2D Rigidbody => rb2D;
    public CircleCollider2D CircleCollider => circleCollider;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;
    CircleCollider2D circleCollider;

    Vector2 startPos;
    Vector2 endPos;
    Vector2 storedDirection;
    Vector2 storedVelocity;
    float moveDuration = .5f;
    bool isRepositioning = false;
    float currentTime = 0;
    Bumper currentBumper;

    public void InitMarble()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void InitPreview()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = null;
        rb2D = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (isRepositioning) 
        {
            currentTime += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, currentTime/moveDuration);
            rb2D.AddTorque(10);

            if (currentTime >= moveDuration) 
            {
                isRepositioning = false;
                currentTime = 0;
                rb2D.gravityScale = 1;  
                Bounce(storedDirection, storedVelocity);
                Time.timeScale = 1;
            }
        }
    }

    public void SetSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    void Bounce(Vector3 bumpDirection, Vector2 velocity)
    {
        float velocityStrength = velocity.magnitude;
        rb2D.velocity = bumpDirection * (velocityStrength * .95f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bumper bumper = collider.gameObject.GetComponent<Bumper>();
        if (bumper != null)
        {
            currentBumper = bumper;

            storedVelocity = rb2D.velocity;
            rb2D.velocity = Vector2.zero;

            storedDirection = bumper.GetBumpDirection(transform.position, storedVelocity);

            rb2D.gravityScale = 0;

            startPos = transform.position;
            endPos = bumper.transform.position;

            Time.timeScale = .5f;
            isRepositioning = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
    }

}
