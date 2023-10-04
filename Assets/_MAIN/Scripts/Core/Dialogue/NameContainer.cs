using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

namespace DIALOGUE
{
    [System.Serializable] 
    /// <summary>
    /// Thebox that holds the name text on screen. Part of the dialogue container.
    /// </summary>
    public class NameContainer
    {
        [SerializeField] private GameObject root;
        [SerializeField] private TextMeshProUGUI nameText;
        public void Show(string nameToShow = "")
        {
            root.SetActive(true);

            if (nameToShow != string.Empty)
                nameText.text = nameToShow;
        }

        public void Hide()
        {
            root.SetActive(false);
        }

        public void SetNameColor(Color color) => nameText.color = color;
        public void SetNameFont(TMP_FontAsset font) => nameText.font = font;
    }
}
