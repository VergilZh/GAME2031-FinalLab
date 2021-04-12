using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grant_Controll : MonoBehaviour
{
    public float moveForce;
    public float jumpForce;
    public CameraMove camera;
    public GameObject startPoint;
    Animator animator;
    Rigidbody2D body;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveForce, transform.position.y);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + jumpForce * 0.01f);
                body.gravityScale = 10;
            }
            Debug.Log(touch.position.x);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + jumpForce * 0.1f);
            body.gravityScale = 10;
        }

        body.velocity = Vector3.zero;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        { 
            gameObject.transform.position = startPoint.transform.position;
            body.gravityScale = 0;
            camera.transform.position = new Vector3(1, 1, -10);
        }
    }
}
