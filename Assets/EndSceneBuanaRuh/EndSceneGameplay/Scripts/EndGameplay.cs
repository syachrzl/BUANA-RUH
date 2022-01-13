using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameplay : MonoBehaviour
{
    private Animator transition;

    [HideInInspector] public bool statusEnd;

    void Start()
    {
        transition = GetComponent<Animator>();
    }

    private void Update()
    {
        if (statusEnd == true)
        {
            transition.SetBool("transisi", true);
            Invoke("LoadScene", 2f);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("true");
            statusEnd = true;
        }
    }
}
