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
            // Update the status values based on the decision
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

            // Increment the decision count
            decisionCount++;
        }

        public int GetDecisionCount()
        {
            return decisionCount;
        }
    }
}
