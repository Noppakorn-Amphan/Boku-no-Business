using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE.LogicalLines
{
    public interface ILogicalLine
    {
        string keyword { get; }
        bool Matches(DIALOGUE_LINE line);
        IEnumerator Execute(DIALOGUE_LINE line);
    }
}
