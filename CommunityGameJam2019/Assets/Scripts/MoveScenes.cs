using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
    [SerializeField] private string newLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().hasKeyBool())
            {
                SceneManager.LoadScene(newLevel);
            }
            else Debug.Log("needs key"); //TODO TEXTO A PEDIR A CHAVENA
        }
    }
}
