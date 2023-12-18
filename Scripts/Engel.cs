using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Engel : MonoBehaviour
{
    private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("dgfdg");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene.name);
        }
           
    }
    
}