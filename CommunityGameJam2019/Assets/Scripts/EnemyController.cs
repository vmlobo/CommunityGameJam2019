using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private SpriteRenderer sr; //TODO flip sprite on mov.x<0
    public Transform player;

    private bool inSight;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        inSight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!inSight)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "LightCone")
        {
            inSight = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "LightCone")
        {
            inSight = false;
        }

    }

}
