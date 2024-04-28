using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Score : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; set; }
    
    [SerializeField] float lerpDuration = 5.0f;

    Vector2 endPosition;
    Vector2 startPosition;
    float currentTime = 0;
    PokemonData pokemonData;

    public void InitScore(Vector2 start, Vector2 end, PokemonData data)
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        pokemonData = data;
        SpriteRenderer.sprite = data.portrait;
        startPosition = start;
        endPosition = end;

    }

    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = Vector2.Lerp(startPosition, endPosition, currentTime/lerpDuration);
    }
}
