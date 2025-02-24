using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public float minVelocityThreshold = 0.1f;
    void Start()
    {
        Vector2 initialDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
        rb.linearVelocity = initialDirection * speed;
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude < minVelocityThreshold)
        {
            rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
        }
        else
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Vector2 newDirection = Vector2.Reflect(rb.linearVelocity, normal);
        if(UnityEngine.Random.RandomRange(0,100)%3==0)
        {
            float randomAngle = Random.Range(-30f, 30f);
            newDirection = Quaternion.Euler(0, 0, randomAngle) * newDirection;
        }
       

        rb.linearVelocity = newDirection.normalized * rb.linearVelocity.magnitude;
        if (collision.collider.CompareTag("bottomwall"))
        {
            GameManager.Instance.Lifes--;
            GameManager.Instance.LifesTxt.text = "Lives:"+GameManager.Instance.Lifes.ToString();
            if (GameManager.Instance.Lifes==0)
            GameManager.Instance.OnGameFailed();
        }
    }
   
}
