using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class Bumper : MonoBehaviour
{
    public float BumperStrength => bumperStrength;

    [SerializeField] float bumperStrength = 100f;
    [SerializeField] float muteTime = 2f;
    [SerializeField] bool pitchVariation = true;

    SpriteRenderer spriteRenderer;
    PokemonData currentPokemonData;
    AudioSource audioSource;

    bool isMute = false;
    float startTime = 0;

    Vector2 contact;
    Vector2 velocity;

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

    public Vector2 GetBumpDirection(Vector2 contactPosistion, Vector2 marbleVelocity)
    {
        contact = contactPosistion;
        velocity = marbleVelocity;
        Vector2 center = transform.position;
        Vector2 initialDirection = (center - contactPosistion).normalized;
        return Vector2.Reflect(marbleVelocity, -initialDirection).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Marble marble = collider.GetComponent<Marble>();
        if (!isMute && marble != null) 
        {
            PlaySound();
        }
    }
    private void OnDrawGizmos()
    {
        if (contact.x != 0 || contact.y != 0)
        {
            Vector2 center = transform.position;
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(contact, .05f);
            Gizmos.DrawLine(contact, center);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(center, center + GetBumpDirection(contact, velocity));
        }
    }
}
