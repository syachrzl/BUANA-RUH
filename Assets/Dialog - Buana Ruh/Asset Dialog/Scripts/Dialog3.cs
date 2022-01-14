using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog3 : MonoBehaviour
{
    [SerializeField] private TextWriter3 textWriter;
    [SerializeField] private Text messageText;
    [SerializeField] private float timeTyping = 0.3f;
    [SerializeField] private string[] message;

    [HideInInspector] public int index = 0;



    private void Update()
    {
        if (message.Length >= index)
        {
            if (textWriter.statusDone == true)
            {
                textWriter.statusDone = false;
                textWriter.AddWriter(messageText, message[index], timeTyping);
                index++;
            }
            if (message.Length == index)
            {
                Invoke("DelayDisable", 5f);
            }
        }
    }

    private void DelayDisable()
    {
        gameObject.SetActive(false);
    }
}
