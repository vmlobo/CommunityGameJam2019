using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private SpriteRenderer sr;
    private Collider2D playerCollider;
    private Transform flashlight;
    private Rigidbody2D rb;
    public GameObject flashlightCone;
    public Transform crosshair;

    private bool toggleFlashlight;
    private float flashlightCharge;
    public float flashlighDischargeRate;
    public float flashlighChargeRate;

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
        flashlightCharge = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            toggleFlashlight = !toggleFlashlight;
            Debug.Log("flashlightOn: " + toggleFlashlight);
        }

        if (toggleFlashlight && flashlightCharge >= 0)
        {
            flashlightCharge -= flashlighDischargeRate * Time.deltaTime;
        } else if(flashlightCharge <=100)
        {
            flashlightCharge += flashlighChargeRate * Time.deltaTime;
        }

        Debug.Log("flashlightCharge: " + flashlightCharge);

        flashlightCone.SetActive(toggleFlashlight && flashlightCharge >= 0); //TODO implement cooldown after charge depletion
     
    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += movement * Time.deltaTime * speed;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);//TODO -3 is player z
        transform.up = crosshair.position - transform.position;

    }

}
