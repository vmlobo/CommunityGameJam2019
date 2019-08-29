using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private SpriteRenderer sr; //TODO flip sprite on mov.x<0
    public Transform player;

    private bool inSight;
    public float speed;
    public float eyeRange;

    private Transform eyeLContainer;
    private Transform eyeRContainer;

    private Transform eyeL;
    private Transform eyeR;

    // Start is called before the first frame update
    void Start()
    {
        inSight = false;
        eyeLContainer = transform.GetChild(0);
        eyeL = eyeLContainer.GetChild(0);
        eyeRContainer = transform.GetChild(1);
        eyeR = eyeRContainer.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!inSight)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        Vector3 directionL = (new Vector3(player.position.x, player.position.y, eyeL.position.z) - eyeLContainer.position).normalized;
        Vector3 directionR = (new Vector3(player.position.x, player.position.y, eyeR.position.z) - eyeRContainer.position).normalized;

        eyeL.position = eyeLContainer.position + directionL * eyeRange;
        eyeR.position = eyeRContainer.position + directionL * eyeRange;

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
