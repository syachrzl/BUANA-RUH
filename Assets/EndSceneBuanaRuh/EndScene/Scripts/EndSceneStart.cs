using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneStart : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }
}
