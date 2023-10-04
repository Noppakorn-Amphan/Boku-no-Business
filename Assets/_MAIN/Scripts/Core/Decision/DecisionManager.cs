using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace STATUS
{
    public class DecisionManager : MonoBehaviour
    {
        // Singleton instance
        public static DecisionManager instance;

        public StatusBar statusBar; // Reference to your StatusBar script

        public Button approveButton;
        public Button disapproveButton;
        public TMP_Text decisionText; // Reference to your decision text

        private int employeeCountChange = 0;
        private int employeeHappinessChange = 0;
        private float employeeSkillChange = 0;
        private int marketingChange = 0;
        private int reputationChange = 0;
        private int budgetChange = 0;
        private int workChange = 0;
        private float workingChange = 0;

        private float buttonActivationDelay = 0.5f; // Delay in seconds before buttons become active

        private bool isButtonsActivated = false;

        private int decisionCount = 0; // Track the number of decisions

        private void Awake()
        {
            // Ensure there's only one instance of DecisionManager
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                // Destroy duplicates
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // Attach click event handlers to the approve and disapprove buttons
            approveButton.onClick.AddListener(ApproveDecision);
            disapproveButton.onClick.AddListener(DisapproveDecision);

            // Initially, disable the buttons and set the alpha to 0
            SetButtonsActive(false);
        }

        public void MakeDecision(
            int employeeCountChange,
            int employeeHappinessChange,
            float employeeSkillChange,
            int marketingChange,
            int reputationChange,
            int budgetChange,
            int workChange,
            float workingChange)
        {
            // Set the change values
            this.employeeCountChange = employeeCountChange;
            this.employeeHappinessChange = employeeHappinessChange;
            this.employeeSkillChange = employeeSkillChange;
            this.marketingChange = marketingChange;
            this.reputationChange = reputationChange;
            this.budgetChange = budgetChange;
            this.workChange = workChange;
            this.workingChange = workingChange;

            // Disable the buttons immediately upon making a decision
            SetButtonsActive(false);

            // Increment the decision count
            decisionCount++;

            // Start the button activation countdown
            StartCoroutine(ActivateButtonsWithDelay());
        }

        public int GetDecisionCount()
        {
            return decisionCount;
        }

        private IEnumerator ActivateButtonsWithDelay()
        {
            yield return new WaitForSeconds(buttonActivationDelay);

            // Activate the buttons after the delay
            SetButtonsActive(true);
            isButtonsActivated = true;
        }

        private void Update()
        {
            if (isButtonsActivated)
            {
                // You can add additional logic here if needed
            }
        }

        private void SetButtonsActive(bool active)
        {
            approveButton.gameObject.SetActive(active);
            disapproveButton.gameObject.SetActive(active);

            // Optionally set alpha for decision text as well if needed
            // decisionText.gameObject.SetActive(active);
        }

        private void ApproveDecision()
        {
            // Update the status values based on the approved decision
            statusBar.companyManager.employeeNumber += employeeCountChange;
            statusBar.companyManager.employeeHappiness += employeeHappinessChange;
            statusBar.companyManager.employeeSkills += employeeSkillChange;
            statusBar.companyManager.marketing += marketingChange;
            statusBar.companyManager.reputation += reputationChange;
            statusBar.companyManager.budget += budgetChange;
            statusBar.companyManager.work += workChange;
            statusBar.companyManager.working += workingChange;

            // Update the status values in the StatusBar
            statusBar.UpdateStatusValues();

            // Call DecisionMade to track the decision
            statusBar.DecisionMade();

            SetButtonsActive(false);
        }

        private void DisapproveDecision()
        {
            // Hide the buttons when the decision is disapproved
            SetButtonsActive(false);

            // Call DecisionMade to track the decision
            statusBar.DecisionMade();
        }
    }
}
