using System.Collections;
using UnityEngine;

namespace TESTING
{
    public class TestChoicePanel : MonoBehaviour
    {
        ChoicePanel panel;

        void Start() 
        {
            StartCoroutine(ShowPanelAfterDelay());
        }

        IEnumerator ShowPanelAfterDelay()
        {
            // Wait for a short delay (you can adjust the time as needed)
            yield return new WaitForSeconds(0.1f);

            // Obtain the ChoicePanel instance
            panel = ChoicePanel.instance;

            string[] choices = new string[]
            {
                "Witness? Is that camera on?",
                "Oh, nah!",
                "I didn't see nothin'!",
                "Matta' Fact- I'm blind in my left eye and 43% blind in my right eye."
            };

            // Show the panel
            panel.Show("Did you wintness Anything Strange?", choices);

            while (panel.isWaitingOnUserChoice)
                yield return null;

            var decision = panel.lastDecision;

            Debug.Log($"Made choice {decision.answerIndex} '{decision.choices[decision.answerIndex]}'");
        }
    }
}
