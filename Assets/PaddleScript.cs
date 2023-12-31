using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rigidbody;
    private KeyCode up;
    private KeyCode down;
    private bool contactTop = false;
    private bool contactBottom = false;
    // Start is called before the first frame update
    void Start()
    {
        up = KeyCode.W;
        down = KeyCode.S;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(up) && !contactTop)
        {
            rigidbody.transform.Translate(movementVector(true) * Time.deltaTime); 
        }
        if(Input.GetKey(down) && !contactBottom)
        {
            rigidbody.transform.Translate(movementVector(false) * Time.deltaTime);
        }
    }

    private Vector2 movementVector(bool direction)
    {
        if(direction)
        {
            return new Vector2(0, movementSpeed);
        } else
        {
            return new Vector2(0, movementSpeed * -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "topWall":
                contactTop = true;
                break;
            case "bottomWall":
                contactBottom = true;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        contactTop = false;
        contactBottom = false;
    }
}
