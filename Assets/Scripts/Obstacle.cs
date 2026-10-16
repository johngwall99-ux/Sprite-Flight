using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float maxSpinSpeed = 10f;
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    public float minSpeed = 50f;
    public float maxSpeed = 150f;
    Rigidbody2D rb;

    public GameObject impactEffectPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);

        rb = GetComponent<Rigidbody2D>();
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;

        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);

        float randomTorgue = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomTorgue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point;
        GameObject impactEffect = Instantiate(impactEffectPrefab, contactPoint, Quaternion.identity);

        Destroy(impactEffect, 1f);
    }
}
