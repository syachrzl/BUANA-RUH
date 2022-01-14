using UnityEngine.SceneManagement;
using UnityEngine;


public class Opening : MonoBehaviour
{
    public float timer;
    public GameObject loading;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);

        nextScene();
    }

    public void nextScene()
    {
        if(timer > 45)
        {
            loading.SetActive(true);
            SceneManager.LoadScene(1);
        }
    }
}
