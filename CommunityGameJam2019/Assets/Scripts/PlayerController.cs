using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private SpriteRenderer sr;
    private Collider2D playerCollider;
    private Transform flashlight;
    private Rigidbody2D rb;

    private bool toggleFlashlight;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        sr = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        flashlight = transform.GetChild(0);

        toggleFlashlight = false;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += movement * Time.deltaTime * speed;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.up = new Vector3(mousePos.x, mousePos.y, 0);

    }

}
