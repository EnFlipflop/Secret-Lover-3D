using System;
using JetBrains.Annotations;
using UnityEngine;
[Serializable]
public struct CharacterQuestion
{
    public string question;
    public string answer;
}
[Serializable]
public struct CharacterSystem
{
    [Header("...")]
    public string characterName;
    public string ett;

    [Header("...")] 
    [Header("Hej-fras")]
    public String hejFras;
    
    [Header("QuestionLine 1")]
    public CharacterQuestion firstQuestion;
    public CharacterQuestion q1FollowUpQuestion1;
    public CharacterQuestion q1FollowUpQuestion2;
    [Header("QuestionLine 2")]
    public CharacterQuestion secondQuestion;
    public CharacterQuestion q2FollowUpQuestion1;
    public CharacterQuestion q2FollowUpQuestion2;
    [Header("QuestionLine 3")]
    public CharacterQuestion thirdQuestion;
    public CharacterQuestion q3FollowUpQuestion1;
    public CharacterQuestion q3FollowUpQuestion2;
    [Header("Hejdå-fras")]
    public String hejDåFras;
    public string test;
}

public class CharacterStructs : MonoBehaviour
{
    
}
