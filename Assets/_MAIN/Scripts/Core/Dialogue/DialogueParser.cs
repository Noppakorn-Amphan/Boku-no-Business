using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DIALOGUE
{
    public class DialogueParser
    {
        private const string commandRegexPattern = @"[\w\[\]]*[^\s]\(";
        public static DIALOGUE_LINE Parse(string rawLine)
        {
            //Debug.Log($"Parsing line - '{rawLine}'");
            
            (string speaker, string dialogue, string commands) = RipContent(rawLine);

            //Debug.Log($"Speaker ='{speaker}'\nDialogue = '{dialogue}'\nCommands = '{commands}'");

            return new DIALOGUE_LINE(rawLine ,speaker, dialogue, commands);
        }
        private static (string, string, string) RipContent(string rawLine)
        {
            string speaker = "", dialogue = "", commands = "";

            int dialogueStart = -1;
            int dialogueEND = -1;
            bool isEscaped = false;

            for(int i = 0; i < rawLine.Length; i++)
            {
                char current = rawLine[i];
                if (current == '\\')
                    isEscaped = !isEscaped;
                else if (current == '"' && !isEscaped)
                {
                    if (dialogueStart == -1)
                        dialogueStart = i;
                    else if (dialogueEND == -1)
                        dialogueEND = i;
                }
                else
                    isEscaped = false;
            }
            //Debug.Log(rawLine.Substring(dialogueStart + 1, (dialogueEND - dialogueStart) -1));

            //Identify Command Pattern
            Regex commandRegex = new Regex(commandRegexPattern);
            MatchCollection matches = commandRegex.Matches(rawLine);
            int commandStart = -1;
            foreach (Match match in matches)
            {
                if (match.Index < dialogueStart || match.Index > dialogueEND)
                {
                    commandStart = match.Index;
                    break;
                }
            }

            if (commandStart != -1 && (dialogueStart == -1 && dialogueEND == -1))
                return ("", "", rawLine.Trim());

            //If we are here then we either have dialogue or a multi word argument in a command. Figure out if this is dialogue.
            if (dialogueStart != -1 && dialogueEND != -1 && (commandStart == -1 || commandStart > dialogueEND))
            {
                //we know that we have vaild dialogue
                speaker = rawLine.Substring(0, dialogueStart).Trim();
                dialogue = rawLine.Substring(dialogueStart + 1, dialogueEND - dialogueStart -1).Replace("\\\"","\"");
                if(commandStart != -1)
                    commands = rawLine.Substring(commandStart).Trim();
            }
            else if (commandStart != -1 && dialogueStart > commandStart)
                commands = rawLine;
            else
                dialogue = rawLine;

            return (speaker, dialogue, commands);
        }
    }
}