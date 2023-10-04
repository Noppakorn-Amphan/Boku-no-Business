using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;
using STATUS;
using TMPro;

public class Test03 : MonoBehaviour
{
    private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);

    // Reference to your DecisionManager instance
    public DecisionManager decisionManager;

    void Start()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        Character_Sprite Miyako = CreateCharacter("Miyako") as Character_Sprite;

        // Example 1: Train employees' skills
        yield return Miyako.Say("Boss, our company has employees with few skills. Should we train their skills? (Budget -1, Employee Skills +0.5)");
        decisionManager.MakeDecision(-1, 0, 0.5f, 0, 0, -1, 0, 0);

        // Wait for a certain amount of time (e.g., 2 seconds) before the next decision
        yield return new WaitForSeconds(2.0f);

        // Example 2: Hire more employees
        yield return Miyako.Say("Boss, our company has a small number of employees. Should I recruit more employees? (Budget -1, Marketing -1, Number of employees +5)");
        decisionManager.MakeDecision(5, 0, 0, -1, 0, -1, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 3: Increase marketing efforts
        yield return Miyako.Say("Boss, our company's marketing efforts are weak. Should we invest more in marketing? (Budget -1, Marketing +2)");
        decisionManager.MakeDecision(0, 0, 0, 2, 0, -1, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 4: Improve employee happiness
        yield return Miyako.Say("Boss, our employees are not happy. Should we work on improving their happiness? (Budget -1, Employee Happiness +5)");
        decisionManager.MakeDecision(0, 5, 0, 0, 0, -1, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 5: Increase work hours
        yield return Miyako.Say("Boss, we need to finish projects faster. Should we increase working hours? (Budget -1, Work +10, Employee Happiness -2)");
        decisionManager.MakeDecision(0, -2, 0, 0, 0, -1, 10, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 6: Reduce budget for cost-cutting
        yield return Miyako.Say("Boss, we need to cut costs. Should we reduce the budget? (Budget -5, Employee Happiness -1)");
        decisionManager.MakeDecision(0, -1, 0, 0, 0, -5, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 7: Focus on reputation
        yield return Miyako.Say("Boss, our company's reputation is suffering. Should we focus on improving our reputation? (Budget -2, Reputation +5)");
        decisionManager.MakeDecision(0, 0, 0, 0, 5, -2, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 8: Expand the company
        yield return Miyako.Say("Boss, we have the opportunity to expand the company. Should we invest in expansion? (Budget -10, Employee Happiness +3, Number of employees +20)");
        decisionManager.MakeDecision(20, 3, 0, 0, 0, -10, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 9: Reduce working hours for work-life balance
        yield return Miyako.Say("Boss, our employees are burnt out. Should we reduce working hours for better work-life balance? (Budget -1, Work -5, Employee Happiness +5)");
        decisionManager.MakeDecision(0, 5, 0, 0, 0, -1, -5, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 10: Launch a new product
        yield return Miyako.Say("Boss, we have a new product ready. Should we launch it? (Budget -3, Marketing +5, Reputation +3)");
        decisionManager.MakeDecision(0, 0, 0, 5, 3, -3, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 11: Cut employee count for cost reduction
        yield return Miyako.Say("Boss, we need to reduce costs. Should we lay off some employees? (Budget +2, Employee Happiness -5, Number of employees -10)");
        decisionManager.MakeDecision(-10, -5, 0, 0, 0, 2, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 12: Increase employee training
        yield return Miyako.Say("Boss, our employees need more training. Should we invest in their skills? (Budget -2, Employee Skills +1)");
        decisionManager.MakeDecision(0, 0, 1, 0, 0, -2, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 13: Focus on R&D
        yield return Miyako.Say("Boss, we should invest in research and development. Should we allocate more budget to R&D? (Budget -3, Employee Skills +2)");
        decisionManager.MakeDecision(0, 0, 2, 0, 0, -3, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 14: Collaborate with another company
        yield return Miyako.Say("Boss, we have the opportunity to collaborate with another company. Should we pursue this collaboration? (Budget -1, Reputation +2)");
        decisionManager.MakeDecision(0, 0, 0, 0, 2, -1, 0, 0);

        yield return new WaitForSeconds(2.0f);

        // Example 15: Cut marketing expenses
        yield return null;    
        }
}
