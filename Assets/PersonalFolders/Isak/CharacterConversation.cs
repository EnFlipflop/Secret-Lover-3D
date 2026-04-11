using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterConversation : MonoBehaviour
{
    public CharacterScriptable characterLines;
    public TextMeshProUGUI button1, button2, button3;
    [SerializeField] private TextMeshProUGUI subtitles, namePlateText;
    private int conversationIndex1, conversationIndex2, conversationIndex3;
    [SerializeField] private GameObject subtitlesAndNameplate;
    [SerializeField] private float questionCD = 2;
    private bool onCD, hasInteracted;
    [SerializeField] private Button guessButton;
    public Person person;

    public void StartCharacterInteraction()
    {
        Debug.Log("StartCharacterInteraction");
        conversationIndex1 = 0;
        conversationIndex2 = 0;
        conversationIndex3 = 0;
        button1.text = characterLines.characterSystem.firstQuestion.question;
        button2.text = characterLines.characterSystem.secondQuestion.question;
        button3.text = characterLines.characterSystem.thirdQuestion.question;
        subtitles.text = characterLines.characterSystem.hejFras;
        RuntimeManager.PlayOneShot(characterLines.characterSystem.hejFrasEvent);
        namePlateText.text = characterLines.characterSystem.characterName;
        subtitles.text = characterLines.characterSystem.hejFras;
        //subtitlesAndNameplate.SetActive(false);
        onCD = false;
        if (!hasInteracted)
        {
            GameManager.Instance.talkedTo++;
            hasInteracted = true;
        }
        guessButton.gameObject.SetActive(false);
        if (GameManager.Instance.talkedTo == 8)
        {
            guessButton.gameObject.SetActive(true);
        }

        person = GetComponentInParent<Person>();
    }

    public void QuestionLine1()
    {
        if (onCD)
            return;
        ClickSound();
        //subtitlesAndNameplate.SetActive(true);
        conversationIndex1++;
        switch (conversationIndex1)
        {
           case 1: subtitles.text = characterLines.characterSystem.firstQuestion.answer;
               button1.text = characterLines.characterSystem.q1FollowUpQuestion1.question;
               Prat();
               break;   
           case 2: subtitles.text = characterLines.characterSystem.q1FollowUpQuestion1.answer;
               button1.text = characterLines.characterSystem.q1FollowUpQuestion2.question;
               Prat();
               break;
           case 3: subtitles.text = characterLines.characterSystem.q1FollowUpQuestion2.answer;
               button1.text = characterLines.characterSystem.firstQuestion.question;
               Prat();
               break;
           case 4: 
               conversationIndex1 = 0;
               QuestionLine1();
               break;
        }

        StartCooldown();
    }
    
    public void QuestionLine2()
    {
        ClickSound();
        subtitlesAndNameplate.SetActive(true);
        conversationIndex2++;
        switch (conversationIndex2)
        {
            case 1: subtitles.text = characterLines.characterSystem.secondQuestion.answer;
                button2.text = characterLines.characterSystem.q2FollowUpQuestion1.question;
                Prat();
                break;   
            case 2: subtitles.text = characterLines.characterSystem.q2FollowUpQuestion1.answer;
                button2.text = characterLines.characterSystem.q2FollowUpQuestion2.question;
                Prat();
                break;
            case 3: subtitles.text = characterLines.characterSystem.q2FollowUpQuestion2.answer;
                button2.text = characterLines.characterSystem.secondQuestion.question;
                Prat();
                break;
            case 4: 
                conversationIndex2 = 0;
                QuestionLine2();
                break;
        }
        StartCooldown();
    }

    public void QuestionLine3()
    {
        ClickSound();
        subtitlesAndNameplate.SetActive(true);
        conversationIndex3++;
        switch (conversationIndex3)
        {
            case 1: subtitles.text = characterLines.characterSystem.thirdQuestion.answer;
                button3.text = characterLines.characterSystem.q3FollowUpQuestion1.question;
                Prat();
                break;   
            case 2: subtitles.text = characterLines.characterSystem.q3FollowUpQuestion1.answer;
                button3.text = characterLines.characterSystem.q3FollowUpQuestion2.question;
                Prat();
                break;
            case 3: subtitles.text = characterLines.characterSystem.q3FollowUpQuestion2.answer;
                button3.text = characterLines.characterSystem.thirdQuestion.question;
                Prat();
                break;
            case 4: 
                conversationIndex3 = 0;
                QuestionLine3();
                break;
        }
        StartCooldown();
    }

    public void ClickSound()
    {
        RuntimeManager.PlayOneShot(characterLines.characterSystem.paperClick);
    }

    private void StartCooldown()
    {
        onCD = true;
        StartCoroutine(nameof(cooldown));
    }

    private IEnumerator cooldown()
    {
        button1.GetComponentInParent<Button>().interactable = false;
        button2.GetComponentInParent<Button>().interactable = false;
        button3.GetComponentInParent<Button>().interactable = false;
        yield return new WaitForSeconds(questionCD);
        button1.GetComponentInParent<Button>().interactable = true;
        button2.GetComponentInParent<Button>().interactable = true;
        button3.GetComponentInParent<Button>().interactable = true;
        onCD = false;
    }

    public void MakeGuess()
    {
        Person person = GetComponent<Person>();
        GameManager.Instance.Guess(person.UniqueIdentifier);
    }

    public void End()
    {
        subtitles.text = characterLines.characterSystem.hejDåFras;
        RuntimeManager.PlayOneShot(characterLines.characterSystem.hejDåFrasEvent);
    }

    public void Leave()
    {
        person.OnInteractEnd();
        GameManager.Instance.interacting = false;
    }

    private void Prat()
    {
        RuntimeManager.PlayOneShot(characterLines.characterSystem.conversation);
    }
}
