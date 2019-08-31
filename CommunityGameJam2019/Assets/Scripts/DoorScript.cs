using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private string newLevel;
    private Transform text;


    private void Start()
    {
        text = transform.GetChild(0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().hasKeyBool())
            {
                //SceneManager.LoadScene(newLevel);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //TODO testar e fazer if p ultimo nivel
            }
            else
            {
                StartCoroutine(PopText());
            }
        }
    }

    IEnumerator PopText()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        text.gameObject.SetActive(false);
    }

}
