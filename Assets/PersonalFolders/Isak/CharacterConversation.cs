using System;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterConversation : MonoBehaviour
{
    public CharacterScriptable characterLines;
    public TextMeshProUGUI button1, button2, button3;
    [SerializeField] private TextMeshProUGUI subtitles, namePlateText;
    private int conversationIndex1, conversationIndex2, conversationIndex3;

    private void Start()
    {
        StartCharacterInteraction();
        
    }

    public void StartCharacterInteraction()
    {
        conversationIndex1 = 0;
        conversationIndex2 = 0;
        conversationIndex3 = 0;
        button1.text = characterLines.characterSystem.firstQuestion.question;
        button2.text = characterLines.characterSystem.secondQuestion.question;
        button3.text = characterLines.characterSystem.thirdQuestion.question;
        subtitles.text = characterLines.characterSystem.hejFras;
        RuntimeManager.PlayOneShot(characterLines.characterSystem.hejFrasEvent);
        namePlateText.text = characterLines.characterSystem.characterName;
    }

    public void QuestionLine1()
    {
        conversationIndex1++;
        switch (conversationIndex1)
        {
           case 1: subtitles.text = characterLines.characterSystem.firstQuestion.answer;
               button1.text = characterLines.characterSystem.q1FollowUpQuestion1.question;
               break;   
           case 2: subtitles.text = characterLines.characterSystem.q1FollowUpQuestion1.answer;
               button1.text = characterLines.characterSystem.q1FollowUpQuestion2.question;
               break;
           case 3: subtitles.text = characterLines.characterSystem.q1FollowUpQuestion2.answer;
               button1.text = characterLines.characterSystem.firstQuestion.question;
               break;
           case 4: 
               conversationIndex1 = 0;
               QuestionLine1();
               break;
        }
         
        
        
    }
    
    public void QuestionLine2()
    {
        conversationIndex2++;
        switch (conversationIndex2)
        {
            case 1: subtitles.text = characterLines.characterSystem.secondQuestion.answer;
                button2.text = characterLines.characterSystem.q2FollowUpQuestion1.question;
                break;   
            case 2: subtitles.text = characterLines.characterSystem.q2FollowUpQuestion1.answer;
                button2.text = characterLines.characterSystem.q2FollowUpQuestion2.question;
                break;
            case 3: subtitles.text = characterLines.characterSystem.q2FollowUpQuestion2.answer;
                button2.text = characterLines.characterSystem.secondQuestion.question;
                break;
            case 4: 
                conversationIndex2 = 0;
                QuestionLine2();
                break;
        }
    }

    public void QuestionLine3()
    {
        conversationIndex3++;
        switch (conversationIndex3)
        {
            case 1: subtitles.text = characterLines.characterSystem.thirdQuestion.answer;
                button3.text = characterLines.characterSystem.q3FollowUpQuestion1.question;
                break;   
            case 2: subtitles.text = characterLines.characterSystem.q3FollowUpQuestion1.answer;
                button3.text = characterLines.characterSystem.q3FollowUpQuestion2.question;
                break;
            case 3: subtitles.text = characterLines.characterSystem.q3FollowUpQuestion2.answer;
                button3.text = characterLines.characterSystem.thirdQuestion.question;
                break;
            case 4: 
                conversationIndex3 = 0;
                QuestionLine3();
                break;
        }
    }
}
