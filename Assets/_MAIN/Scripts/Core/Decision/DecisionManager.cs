using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace STATUS
{
    public class DecisionManager : MonoBehaviour
    {
        public StatusBar statusBar;
        public Button decisionButtonA; // Reference to the approved decision button
        public Button decisionButtonB; // Reference to the skip decision button

        private int decisionsMade = 0;

        [System.Serializable]
        public struct Decision
        {
            public string message;
            public int employeeCountChange;
            public int employeeHappinessChange;
            public float employeeSkillsChange;
            public int marketingChange;
            public int reputationChange;
            public int budgetChange;
            public int workChange;
            public float workingChange;
        }

        public Decision[] decisions;

        private int currentDecisionIndex = 0;
        private RectTransform buttonTransform;
        private float moveSpeed = 10f; // Speed at which the button moves up
        private bool buttonMoving = false;

        // Assuming you have a TMP_Text reference to display the decision message
        public TMP_Text decisionText;

        // Time delay before showing the buttons again (in seconds)
        public float buttonDelay = 2f;
        private bool buttonsTemporarilyDisabled = false;
        private bool decisionInProgress = false; // Flag to prevent multiple decisions at once

        private void Start()
        {
            // Initialize the first decision
            ShowDecision(currentDecisionIndex);

            // Get the RectTransform of the button
            buttonTransform = decisionButtonA.GetComponent<RectTransform>();

            // Attach the button click events
            decisionButtonA.onClick.AddListener(() => MakeDecision(decisionButtonA));
            decisionButtonB.onClick.AddListener(() => SkipToNextDecision());

            // Check if there are no decisions to show and hide the button
            if (decisions.Length == 0)
            {
                decisionButtonA.gameObject.SetActive(false);
                decisionButtonB.gameObject.SetActive(false);
            }
            else
            {
                // Set the initial visibility of both buttons to true
                decisionButtonA.gameObject.SetActive(true);
                decisionButtonB.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            // Move the button upwards if it's currently moving
            if (buttonMoving)
            {
                buttonTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

                // You can add a condition to stop the button at a certain position
                if (buttonTransform.anchoredPosition.y >= 200f) // Adjust this condition as needed
                {
                    buttonMoving = false;
                }
            }
        }

        public void MakeDecision(Button button)
        {
            // Check if a decision is already in progress
            if (decisionInProgress)
            {
                return;
            }

            decisionInProgress = true;

            // Handle the decision logic (update status, etc.)
            Decision currentDecision = decisions[currentDecisionIndex];

            if (button == decisionButtonA)
            {
                // Apply the changes from the current decision for button A
                statusBar.companyManager.budget += currentDecision.budgetChange;
                statusBar.companyManager.employeeSkills += currentDecision.employeeSkillsChange;
                statusBar.companyManager.marketing += currentDecision.marketingChange;
                statusBar.companyManager.reputation += currentDecision.reputationChange;
                statusBar.companyManager.employeeNumber += currentDecision.employeeCountChange;
                statusBar.companyManager.employeeHappiness += currentDecision.employeeHappinessChange;
                statusBar.companyManager.work += currentDecision.workChange;
                statusBar.companyManager.working += currentDecision.workingChange;
            }

            // Update the StatusBar
            statusBar.UpdateStatusValues();

            // Move to the next decision
            currentDecisionIndex++;

            // Show the next decision (or end the game when there are no more decisions)
            if (currentDecisionIndex < decisions.Length)
            {
                ShowDecision(currentDecisionIndex);
            }
            else
            {
                // End the game or show a win/loss screen
                // You can implement this logic based on your game's requirements
                // In this case, hide both buttons and the text
                decisionButtonA.gameObject.SetActive(false);
                decisionButtonB.gameObject.SetActive(false);
                decisionText.gameObject.SetActive(false);
            }

            // Temporarily disable both buttons after a decision
            decisionButtonA.gameObject.SetActive(false);
            decisionButtonB.gameObject.SetActive(false);

            // Start a timer to re-enable the buttons after a delay
            if (!buttonsTemporarilyDisabled)
            {
                buttonsTemporarilyDisabled = true;
                Invoke("EnableButtons", buttonDelay);
            }

            decisionInProgress = false; // Reset the decision flag
        }

        public void SkipToNextDecision()
        {
            // Check if a decision is already in progress
            if (decisionInProgress)
            {
                return;
            }

            decisionInProgress = true;

            // Move to the next decision
            currentDecisionIndex++;

            // Show the next decision (or end the game when there are no more decisions)
            if (currentDecisionIndex < decisions.Length)
            {
                ShowDecision(currentDecisionIndex);
            }
            else
            {
                // End the game or show a win/loss screen
                // You can implement this logic based on your game's requirements
                // In this case, hide both buttons and the text
                decisionButtonA.gameObject.SetActive(false);
                decisionButtonB.gameObject.SetActive(false);
                decisionText.gameObject.SetActive(false);
            }

            // Temporarily disable both buttons after a decision
            decisionButtonA.gameObject.SetActive(false);
            decisionButtonB.gameObject.SetActive(false);

            // Start a timer to re-enable the buttons after a delay
            if (!buttonsTemporarilyDisabled)
            {
                buttonsTemporarilyDisabled = true;
                Invoke("EnableButtons", buttonDelay);
            }

            decisionInProgress = false; // Reset the decision flag
        }

        // Function to re-enable the buttons after the delay
        private void EnableButtons()
        {
            if (currentDecisionIndex < decisions.Length)
            {
                decisionButtonA.gameObject.SetActive(true);
                decisionButtonB.gameObject.SetActive(true);
            }
            buttonsTemporarilyDisabled = false;
        }


        private void ShowDecision(int index)
        {
            // Check if the index is within the valid range
            if (index >= 0 && index < decisions.Length)
            {
                // Display the decision message
                decisionText.text = decisions[index].message;

                // Make the text visible again
                decisionText.gameObject.SetActive(true);
            }
            else
            {
                // Handle the case where the index is out of bounds
                Debug.LogError("Invalid decision index: " + index);
            }
        }
    }
}
