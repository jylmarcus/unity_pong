using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    private Vector2 direction;
    [SerializeField] private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        transform.name = transform.name.Replace("(Clone)", "").Trim();
        direction = RandomVector();
        rigidBody.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 RandomVector()
    {
        int[] xDirections = { -1, 1 };
        var x = xDirections[Mathf.RoundToInt(Random.Range(0, xDirections.Length))];
        var y = Random.Range(-0.95f, 0.95f);
        return new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 surfaceNormal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, surfaceNormal);
        rigidBody.velocity = direction * (speed + 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(ball, new Vector3(0, 0, 0), transform.rotation);
        Destroy(gameObject);
    }
}
