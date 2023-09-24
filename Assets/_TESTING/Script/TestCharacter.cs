using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;
using TMPro;
using System;

namespace TESTING{

    public class TestCharacter : MonoBehaviour
    {
        public TMP_FontAsset tempFont;

        private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);
        // Start is called before the first frame update
        void Start()
        {
            //Character Kafka = CharacterManager.instance.CreateCharacter("Kafka");
            //Character Saori = CharacterManager.instance.CreateCharacter("Saori");
            //Character Miyako = CharacterManager.instance.CreateCharacter("Miyako");
            //Character Yami = CharacterManager.instance.CreateCharacter("Yami");
            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            /*Character Saori = CharacterManager.instance.CreateCharacter("Saori");
            Character Miyako = CharacterManager.instance.CreateCharacter("Miyako");
            Character Yami = CharacterManager.instance.CreateCharacter("Yami");

            List<string> lines = new List<string>()
            {
                "สวัสดีค่ะ เจ้านาย",
                "เช้านี้อากาศสดใสนะคะ",
                "มาเริ่มทำงานกันเลยดีกว่า",
                "มีอะไรหรอค่ะ?"
            };
            yield return Saori.Say(lines);

            Saori.SetNameColor(Color.black);
            Saori.SetDialogueColor(Color.red);
            Saori.SetNameFont(tempFont);
            Saori.SetDialogueFont(tempFont);

            yield return Saori.Say(lines);

            Saori.ResetConfigurationData();

            yield return Saori.Say(lines);


            lines = new List<string>()
            {
                "สวัสดีค่ะ เจ้านาย",
                "พร้อมสำหรับวันนี้ไหมคะ?"
            };
            yield return Miyako.Say(lines);

            yield return Yami.Say("...");

            lines = new List<string>()
            {
                "narrator \"Bye\""
            };

            yield return DialogueSystem.instance.Say(lines);

            Debug.Log("Finished");*/
            //Test Showing
            /*
            Character FS2 = CharacterManager.instance.CreateCharacter("Female Student 2");
            Character Rae = CharacterManager.instance.CreateCharacter("Raelin");
            yield return null;s*/
            //------------------------------------------------------------------------------------

            //Test Moving
            /*Character Kafka = CreateCharacter("Kafka");
            Character Blade = CreateCharacter("Blade");
            Character SW = CreateCharacter("Silver Wolf");
            Kafka.Show();
            Blade.Show();
            SW.Show();
            yield return new WaitForSeconds(1f);
            Blade.Hide();
            Kafka.Hide();
            SW.Hide();
            yield return new WaitForSeconds(0.5f);
            Blade.Show();
            Kafka.Show();
            SW.Show();
            yield return new WaitForSeconds(1f);
            yield return Blade.Say("ไปทำภารกิจกันได้ยัง?");
            yield return Kafka.Say("ไปกันเถอะ");

            yield return new WaitForSeconds(1f);
            yield return Blade.MoveToPosition(new Vector2(2f,0.5f));
            yield return Kafka.MoveToPosition(new Vector2(2f,0.5f));
            yield return SW.MoveToPosition(new Vector2(2f,0.5f));*/
            //------------------------------------------------------------------------------------

            //TestSprite
            /*Character_Sprite Guard = CreateCharacter("Guard as Generic") as Character_Sprite;

            yield return new WaitForSeconds(1);

            Sprite s1 = Guard.GetSprite("Monk");
            //Guard.SetSprite(s1);
            Guard.TransitionSprite(s1);

            Debug.Log($"Visible = {Guard.isVisible}");*/

            //Character_Sprite Raelin = CreateCharacter("Raelin") as Character_Sprite;

            /*yield return new WaitForSeconds(1);

            Sprite body = Raelin.GetSprite("B4");
            Sprite face = Raelin.GetSprite("P2_Smile");
            Raelin.TransitionSprite(body);
            yield return Raelin.TransitionSprite(face, 1);

            yield return new WaitForSeconds(1);
            Raelin.TransitionSprite(Raelin.GetSprite("P2_Shy"), 1);*/

            //yield return new WaitForSeconds(1);

            //------------------------------------------------------------------------------------
            //TestCharacterColor
            //Raelin.SetColor(Color.red);
            //Raelin.layers[1].SetColor(Color.red);

            /*for (int i = 0; i <= 10; i++)
            {
                yield return Raelin.TransitionColor(Color.red);
                yield return Raelin.TransitionColor(Color.blue);
                yield return Raelin.TransitionColor(Color.yellow);
            }
            yield return Raelin.TransitionColor(Color.white);*/
            //yield return Raelin.TransitionColor(Color.black);

            //TestHighlight
            /*yield return Raelin.UnHighlight();
            
            yield return new WaitForSeconds(1);

            yield return Raelin.TransitionColor(Color.red);

            yield return new WaitForSeconds(1);

            yield return Raelin.Highlight();

            yield return new WaitForSeconds(1);

            yield return Raelin.TransitionColor(Color.white);*/
            //------------------------------------------------------------------------------------

            //TestFlipping
            /*yield return new WaitForSeconds(1);
            yield return Raelin.Flip(0.3f);
        
            yield return Raelin.FaceLeft(0.3f);
            yield return Raelin.FaceRight(immediate:true);*/

            //Test Prioritizing ***DON'T WORK! NO! IT'S WORKKKKKKKKKKKKKK!!!
            Character_Sprite Guard = CreateCharacter("Guard as Generic") as Character_Sprite;
            Character_Sprite GuardRed = CreateCharacter("Guard Red as Generic") as Character_Sprite;
            Character_Sprite Raelin = CreateCharacter("Raelin") as Character_Sprite;
            Character_Sprite FS2 = CreateCharacter("Female Student 2") as Character_Sprite;
            //Character_Sprite Miyako = CreateCharacter("Miyako") as Character_Sprite;

            GuardRed.SetColor(Color.red);

            Raelin.SetPosition(new Vector2(0.3f, 0));
            FS2.SetPosition(new Vector2(0.45f, 0));
            Guard.SetPosition(new Vector2(0.6f, 0));
            GuardRed.SetPosition(new Vector2(0.75f, 0));

            GuardRed.SetPriority(1000);
            FS2.SetPriority(15);
            Raelin.SetPriority(8);
            Guard.SetPriority(30);

            yield return new WaitForSeconds(1);

            CharacterManager.instance.SortCharacters(new string[] { "Female Student 2", "Raelin" });

            yield return new WaitForSeconds(1);

            CharacterManager.instance.SortCharacters();

            //Raelin.SetPriority(1);
            //Raelin.root.SetSiblingIndex(0);

            //Test Animating
            /*Character_Sprite Raelin = CreateCharacter("Raelin") as Character_Sprite;
            Character_Sprite FS2 = CreateCharacter("Female Student 2") as Character_Sprite;

            Raelin.SetPosition(new Vector2(1,0));
            FS2.SetPosition(new Vector2(0,0));

            Raelin.TransitionSprite(Raelin.GetSprite("B3"));
            Raelin.TransitionSprite(Raelin.GetSprite("P2_Smile"), layer: 1);
            Raelin.Animate("Hop");
            yield return Raelin.Say("ฉันกำลังกระโดด");
            Raelin.Animate("Hop");
            yield return new WaitForSeconds(1);
            Raelin.Animate("Shiver", true);
            yield return Raelin.Say("ฉันกำลังสั่น");
            Raelin.Animate("Shiver", false);*/



            yield return null;
        }


        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
