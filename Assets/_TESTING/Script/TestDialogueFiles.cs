using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;
namespace TESTING{
    public class TestDialogueFiles : MonoBehaviour
    {
        [SerializeField] private TextAsset fileToRead = null;
        // Start is called before the first frame update
            void Start()
            {
                StartConversation();
            }

            void StartConversation()
            {
                List<string> lines = FileManager.ReadTextAsset(fileToRead);

                
                DialogueSystem.instance.Say(lines);
            }
    }
}
