using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace STATUS
{
    [System.Serializable]
    public class StatusElement
    {
        public TMP_Text nameText;
        public TMP_Text valueText;
    }

    public class StatusBar : MonoBehaviour
    {
        [SerializeField] private StatusElement employeeCount;
        [SerializeField] private StatusElement employeeHappiness;
        [SerializeField] private StatusElement employeeSkill;
        [SerializeField] private StatusElement marketing;
        [SerializeField] private StatusElement reputation;
        [SerializeField] private StatusElement budget;
        [SerializeField] private StatusElement work;
        [SerializeField] private StatusElement working;
        [SerializeField] private TMP_Text monthAndYear;

        public CompanyManager companyManager;

        private int currentMonth = 1;
        private int currentYear = 1;

        private string[] thaiMonthNames = new string[]
        {
            "มกราคม",
            "กุมภาพันธ์",
            "มีนาคม",
            "เมษายน",
            "พฤษภาคม",
            "มิถุนายน",
            "กรกฎาคม",
            "สิงหาคม",
            "กันยายน",
            "ตุลาคม",
            "พฤศจิกายน",
            "ธันวาคม"
        };

        private void Start()
        {
            UpdateStatusValues();
        }

        private void Update()
        {
            UpdateStatusValues();
        }

        public void UpdateStatusValues() // Change the accessibility to public
        {
            employeeCount.valueText.text = companyManager.employeeNumber.ToString();
            employeeHappiness.valueText.text = companyManager.employeeHappiness.ToString();
            employeeSkill.valueText.text = companyManager.employeeSkills.ToString();
            marketing.valueText.text = companyManager.marketing.ToString();
            reputation.valueText.text = companyManager.reputation.ToString();
            budget.valueText.text = companyManager.budget.ToString();
            work.valueText.text = companyManager.work.ToString();

            float workingValue = (companyManager.employeeNumber * companyManager.employeeSkills) / 10f;
            working.valueText.text = workingValue.ToString();

            string monthName = GetThaiMonthName(currentMonth);
            string formattedMonthAndYear = "ปีที่ " + currentYear.ToString() + "\n" + monthName;
            monthAndYear.text = formattedMonthAndYear;
        }

        private string GetThaiMonthName(int monthNumber)
        {
            if (monthNumber < 1 || monthNumber > 12)
                return "";

            return thaiMonthNames[monthNumber - 1];
        }

        // Sell Work button functionality
        public void SellWork()
        {
            if (companyManager.work > 0)
            {
                companyManager.work--;
                companyManager.marketing--;
                companyManager.budget++;

                UpdateStatusValues();
            }
        }
    }
}
