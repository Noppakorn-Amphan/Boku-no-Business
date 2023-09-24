using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STATUS{

    public class CompanyManager : MonoBehaviour
    {
        // Company resource variables
        public int employeeNumber;
        public int employeeHappiness;
        public float employeeSkills;
        public int marketing;
        public int reputation;
        public int budget;
        public int work;
        public float working;
        
        public void SetWork(int value)
        {
            work = value;
        }

    }
}
