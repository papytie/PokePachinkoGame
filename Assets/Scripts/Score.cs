using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Score : MonoBehaviour, IToken
{
    public SpriteRenderer SpriteRenderer { get; set; }
    
    [SerializeField] float duration = 5.0f;

    Vector2 endPosition;
    Vector2 startPosition;
    float currentTime = 0;

    public void InitToken()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void InitLerpPos(Vector2 start, Vector2 end)
    {
        startPosition = start;
        endPosition = end;
    }

    public void SetSprite(Sprite newSprite)
    {
        SpriteRenderer.sprite = newSprite;
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = Vector2.Lerp(startPosition, endPosition, currentTime/duration);
    }
}
