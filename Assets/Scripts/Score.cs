using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Score : MonoBehaviour, IToken
{
    public SpriteRenderer SpriteRenderer { get; set; }
    
    [SerializeField] float speed = 1.0f;

    Vector2 endPosition;
    Vector2 startPosition;

    public void InitToken()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;

    }

    public void SetSprite(Sprite newSprite)
    {
        SpriteRenderer.sprite = newSprite;
    }

    void MoveAlong(float time)
    {
        transform.position = Vector2.Lerp(startPosition, endPosition, time);
    }

    void Update()
    {
        //MoveAlong(Time.time*speed);
    }
}
