using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = RandomVector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 RandomVector()
    {
        int[] xDirections = { -1, 1 };
        var x = xDirections[Mathf.RoundToInt(Random.Range(0, xDirections.Length))] * speed;
        var y = Random.Range(-0.95f, 0.95f);
        Debug.Log(y);
        Debug.Log(x);
        return new Vector2(x, y);
    }
}
