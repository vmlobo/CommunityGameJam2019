using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private SpriteRenderer sr; 
    private Collider2D playerCollider;
    private Transform flashlight;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public GameObject flashlightCone;
    public Transform crosshair;

    public GameObject menuContainer;
    public Image keyOverlay;

    private bool hasKey;
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
        audioSource = GetComponent<AudioSource>();

        flashlight = transform.GetChild(0);

        toggleFlashlight = false;
        flashlightCharge = 100;
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            toggleFlashlight = !toggleFlashlight; //TODO make blinking a feature, not a bug
            audioSource.Play();
        }

        if (toggleFlashlight && flashlightCharge >= 0)
        {
            flashlightCharge -= flashlighDischargeRate * Time.deltaTime;
        } else if(flashlightCharge <=100)
        {
            flashlightCharge += flashlighChargeRate * Time.deltaTime; //TODO charge only when moving?
        }

        //if (flashlightCharge <= 50) TODO Blinking
        //{
        //    StartCoroutine(Blink(flashlightCharge));
        //}

        //Debug.Log("flashlightCharge: " + flashlightCharge); TODO remove

        flashlightCone.SetActive(toggleFlashlight && flashlightCharge >= 0); //TODO implement cooldown after charge depletion
     
    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += movement * Time.deltaTime * speed;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        transform.up = crosshair.position - transform.position;

    }

    void OnCollisionEnter2D(Collision2D col) //TODO enemies go through hazards
    {
        if(col.gameObject.tag == "Enemy")
        {
            transform.gameObject.SetActive(false);
            menuContainer.SetActive(true);
            Cursor.visible =true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(transform.gameObject.tag + " collided with trigger: " + col.gameObject.tag);
        if (col.gameObject.tag == "Hazard")
        {
            transform.gameObject.SetActive(false);
            menuContainer.SetActive(true);
            Cursor.visible = true;
        }
        if(col.gameObject.tag == "Key")
        {
            hasKey = true;
            col.gameObject.SetActive(false);
            keyOverlay.color = new Color(255, 255, 255, 255);
            
        }
    }

    public bool hasKeyBool()
    {
        return hasKey;
    }

    //IEnumerator Blink(float charge) TODO blinking
    //{


    //    yield return new WaitForSeconds();



    //}

}
