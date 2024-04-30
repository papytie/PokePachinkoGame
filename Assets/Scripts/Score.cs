using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(AudioSource))]

public class Score : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; set; }
    
    [SerializeField] float lerpDuration = 5.0f;

    Vector2 endPosition;
    Vector2 startPosition;
    float currentTime = 0;
    PokemonData pokemonData;
    AudioSource audioSource;
    CircleCollider2D circleCollider;

    public void InitScore(Vector2 start, Vector2 end, PokemonData data)
    {
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        circleCollider = GetComponent<CircleCollider2D>();
        pokemonData = data;
        SpriteRenderer.sprite = data.portrait;
        audioSource.clip = data.nameAnnounce;
        startPosition = start;
        endPosition = end;

    }

    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = Vector2.Lerp(startPosition, endPosition, currentTime/lerpDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Marble>())
            audioSource.Play();

    }
}
