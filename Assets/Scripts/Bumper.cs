using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class Bumper : MonoBehaviour
{
    [SerializeField] float muteTime = 2f;
    [SerializeField] bool pitchVariation = true;

    SpriteRenderer spriteRenderer;
    PokemonData currentPokemonData;
    AudioSource audioSource;

    bool isMute = false;
    float startTime = 0;

    public void InitBumper()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (isMute && Time.time >= startTime + muteTime)
        {
            isMute = false;
            SetData(PokedexData.Instance.GetRandomInTable(PokedexData.Instance.globalLootTable));
        }
    }

    public void PlaySound()
    {
        audioSource.pitch = pitchVariation ? Random.Range(.1f,3) : 1;
        audioSource.Play();
        isMute = true;
        startTime = Time.time;
    }

    public void SetData(PokemonData data)
    {
        currentPokemonData = data;
        spriteRenderer.sprite = data.icon;
        audioSource.clip = data.cry;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isMute && collision.gameObject.GetComponent<Marble>()) 
        {
            PlaySound();
        }
    }
}
