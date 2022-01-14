using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter1 : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;

    [HideInInspector] public bool statusDone = true;
    [HideInInspector] public bool statusAktif = true;

    [SerializeField] private float timeBetweenMessage = 3f;


    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
    }
    private void Update()
    {
        
        if (statusAktif == true)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);

                if(characterIndex >= textToWrite.Length)
                {
                    Invoke("DelayMessage", timeBetweenMessage);
                    statusAktif = false;
                    return;
                }

            }
        }
    }

    private void DelayMessage()
    {
        statusDone = true;
        statusAktif = true;
    }
}
