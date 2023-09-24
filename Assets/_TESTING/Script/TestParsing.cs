using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace TESTING
{
    public class TestParsing : MonoBehaviour
    {
        [SerializeField] private TextAsset file;
        // Start is called before the first frame update
        void Start()
        {
            SentFileToParse();
        }

        void SentFileToParse()
        {
            List<string> lines = FileManager.ReadTextAsset(file);

            foreach(string line in lines)
            {
                if (line == string.Empty)
                    continue;
                    
                DIALOGUE_LINE dl = DialogueParser.Parse(line);
            }
        }
    }
}