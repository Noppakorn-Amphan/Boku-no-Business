using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        public TextArchitect.BuildMettod bm = TextArchitect.BuildMettod.instant;

        string[] lines = new string[5]
        {
            "สวัสดี",
            "ฉันชื่อ เลขาจัง",
            "นายชื่ออะไรหรอ",
            "ยินดีที่ได้รู้จักนะคุณ...",
            "แล้วเจอกันนะ"
        };
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            //architect.buildMettod = TextArchitect.BuildMettod.typewritter;
            architect.speed = 0.5f;
            architect.buildMettod = TextArchitect.BuildMettod.fade;
        }

        // Update is called once per frame
        void Update()
        {
            if (bm != architect.buildMettod)
            {
                architect.buildMettod = bm;
                architect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();
        
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }
                else
                    //architect.Build(longLine);
                    architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //architect.Append(longLine);
                architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }

    }
}


