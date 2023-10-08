using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;

public class InputPanelTest : MonoBehaviour
{
    public InputPanel inputPanel;

    void Start()
    {
        StartCoroutine(Running());
    }

    IEnumerator Running()
    {
        Character Raelin = CharacterManager.instance.CreateCharacter("Raelin", revealAfterCreation: true);
        yield return Raelin.Say("Hi What is your name?");
        inputPanel.Show("What is your name?");

        while (inputPanel.isWaitingOnUserInput)
            yield return null;

        string characterName = inputPanel.lastInput;

        yield return Raelin.Say($"Nice to meet you {characterName}!");
    }
}
