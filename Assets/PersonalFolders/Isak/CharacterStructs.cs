using System;
using FMODUnity;
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
    [Header("Main")]
    public string characterName;
    [Header("Hej-fras")]
    public String hejFras;
    public EventReference hejFrasEvent;
    
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
    public EventReference hejDåFrasEvent;
}

public class CharacterStructs : MonoBehaviour
{
    
}
