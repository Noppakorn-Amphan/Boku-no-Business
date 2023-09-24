using UnityEngine;
using STATUS;

public class TestDecision : MonoBehaviour
{
    public TestDecision decisionManager; // Reference to the DecisionManager script in your game

    private void Start()
    {
        // Assuming you have assigned the DecisionManager script in the Unity Inspector
        if (decisionManager == null)
        {
            Debug.LogError("DecisionManager reference is not assigned. Please assign it in the Inspector.");
        }
    }

    public void MakeDecision()
    {
        // Call the MakeDecision method in the DecisionManager script
        decisionManager.MakeDecision();
    }
}
