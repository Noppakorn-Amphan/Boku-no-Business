using CHARACTERS;
using UnityEngine;
using TMPro;

namespace DIALOGUE{

    [CreateAssetMenu(fileName = "Dialogue System Configuration", menuName = "Dialogue System/Dialogue Configuration Asset")]
    public class DialogueSystemConfigurationSO : ScriptableObject
    {
        public const float DEFAULT_FONTSIZE_DIALOGUE = 48;
        public const float DEFAULT_FONTSIZE_NAME = 54;
        public CharacterConfigSO characterConfigurationAsset;

        public Color defaultTextColor = Color.white;
        public TMP_FontAsset defaultFont;

        public float dialogueFontScale = 1f;
        public float defaultDialogueFontSize = DEFAULT_FONTSIZE_NAME;
        public float defaultNameFontSize = DEFAULT_FONTSIZE_DIALOGUE;
    }
}
