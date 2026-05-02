using System;
using System.Collections;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Isak.Typography.Typewriter;

public class CharacterConversation : MonoBehaviour
{
    public CharacterScriptable characterLines;

    public TextMeshProUGUI button1, button2, button3, leaveButton;
    [SerializeField] private TextMeshProUGUI subtitles, namePlateText;

    private int conversationIndex1, conversationIndex2, conversationIndex3;

    [SerializeField] private GameObject subtitlesAndNameplate;
    [SerializeField] private float questionCD = 2;

    private bool onCD, hasInteracted;
    public bool textFinished;

    [SerializeField] private Button guessButton;

    public Person person;

    private void OnEnable()
    {
        TypewriterEffect.CompleteTextRevealed += OnTextFinished;
    }

    private void OnDisable()
    {
        TypewriterEffect.CompleteTextRevealed -= OnTextFinished;
    }

    private void OnTextFinished(TMP_Text text)
    {
        if (text == subtitles)
            textFinished = true;
    }

    public void StartCharacterInteraction()
    {
        textFinished = true;
        conversationIndex1 = 0;
        conversationIndex2 = 0;
        conversationIndex3 = 0;

        button1.text = characterLines.characterSystem.firstQuestion.question;
        button2.text = characterLines.characterSystem.secondQuestion.question;
        button3.text = characterLines.characterSystem.thirdQuestion.question;

        namePlateText.text = characterLines.characterSystem.characterName;

        SetSubtitles(characterLines.characterSystem.hejFras);
        RuntimeManager.PlayOneShot(characterLines.characterSystem.hejFrasEvent);

        onCD = false;

        if (!hasInteracted)
        {
            GameManager.Instance.talkedTo++;
            hasInteracted = true;
        }

        guessButton.gameObject.SetActive(GameManager.Instance.talkedTo >= 5);

        person = GetComponentInParent<Person>();
    }

    public void QuestionLine1()
    {
        if (onCD) return;

        ClickSound();
        conversationIndex1++;

        switch (conversationIndex1)
        {
            case 1:
                SetSubtitles(characterLines.characterSystem.firstQuestion.answer);
                button1.text = characterLines.characterSystem.q1FollowUpQuestion1.question;
                break;

            case 2:
                SetSubtitles(characterLines.characterSystem.q1FollowUpQuestion1.answer);
                button1.text = characterLines.characterSystem.q1FollowUpQuestion2.question;
                break;

            case 3:
                SetSubtitles(characterLines.characterSystem.q1FollowUpQuestion2.answer);
                button1.text = characterLines.characterSystem.firstQuestion.question;
                break;

            case 4:
                conversationIndex1 = 0;
                QuestionLine1();
                return;
        }

        Prat();
        StartCooldown();
    }

    public void QuestionLine2()
    {
        if (onCD) return;

        ClickSound();
        conversationIndex2++;

        switch (conversationIndex2)
        {
            case 1:
                SetSubtitles(characterLines.characterSystem.secondQuestion.answer);
                button2.text = characterLines.characterSystem.q2FollowUpQuestion1.question;
                break;

            case 2:
                SetSubtitles(characterLines.characterSystem.q2FollowUpQuestion1.answer);
                button2.text = characterLines.characterSystem.q2FollowUpQuestion2.question;
                break;

            case 3:
                SetSubtitles(characterLines.characterSystem.q2FollowUpQuestion2.answer);
                button2.text = characterLines.characterSystem.secondQuestion.question;
                break;

            case 4:
                conversationIndex2 = 0;
                QuestionLine2();
                return;
        }

        Prat();
        StartCooldown();
    }

    public void QuestionLine3()
    {
        if (onCD) return;

        ClickSound();
        conversationIndex3++;

        switch (conversationIndex3)
        {
            case 1:
                SetSubtitles(characterLines.characterSystem.thirdQuestion.answer);
                button3.text = characterLines.characterSystem.q3FollowUpQuestion1.question;
                break;

            case 2:
                SetSubtitles(characterLines.characterSystem.q3FollowUpQuestion1.answer);
                button3.text = characterLines.characterSystem.q3FollowUpQuestion2.question;
                break;

            case 3:
                SetSubtitles(characterLines.characterSystem.q3FollowUpQuestion2.answer);
                button3.text = characterLines.characterSystem.thirdQuestion.question;
                break;

            case 4:
                conversationIndex3 = 0;
                QuestionLine3();
                return;
        }

        Prat();
        StartCooldown();
    }

    private void SetSubtitles(string text)
    {
        textFinished = false;
        subtitles.text = text;
    }

    private void StartCooldown()
    {
        onCD = true;
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        SetButtonsInteractable(false);

        // Wait until typewriter finishes
        yield return new WaitUntil(() => textFinished);

        // Optional extra delay
        yield return new WaitForSeconds(questionCD);

        SetButtonsInteractable(true);

        onCD = false;
    }

    private void SetButtonsInteractable(bool state)
    {
        button1.GetComponentInParent<Button>().interactable = state;
        button2.GetComponentInParent<Button>().interactable = state;
        button3.GetComponentInParent<Button>().interactable = state;
        leaveButton.GetComponentInParent<Button>().interactable = state;
    }

    public void ClickSound()
    {
        RuntimeManager.PlayOneShot(characterLines.characterSystem.paperClick);
    }

    public void MakeGuess()
    {
        GameManager.Instance.Guess(person.UniqueIdentifier);
    }

    public void End()
    {
        SetSubtitles(characterLines.characterSystem.hejDåFras);
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

    public void ResetOnLeave()
    {
        //textFinished = true;
    }
}