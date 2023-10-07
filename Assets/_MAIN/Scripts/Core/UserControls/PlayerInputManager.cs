using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


namespace DIALOGUE{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInput input;
        private List<(InputAction action, Action<InputAction.CallbackContext> command)> actions = new List<(InputAction action, Action<InputAction.CallbackContext> command)> ();
        private void Awake()
        {
            input = GetComponent<PlayerInput> ();

            InitializaAction();
        }

        private void InitializaAction()
        {
            actions.Add((input.actions["Next"], OnNext));
        }

        private void OnEnable()
        {
            foreach (var InputAction in actions)
                InputAction.action.performed += InputAction.command;
        }

        private void OnDisable()
        {
            foreach (var InputAction in actions)
                InputAction.action.performed -= InputAction.command;
        }

        public void OnNext(InputAction.CallbackContext c)
        {
            DialogueSystem.instance.OnUserPrompt_Next();
        }
    }
}
