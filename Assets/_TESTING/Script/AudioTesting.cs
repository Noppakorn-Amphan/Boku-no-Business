using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;

namespace TESTING
{
    public class AudioTesting : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Running4());
        }

        Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);

        IEnumerator Running()
        {
            Character_Sprite Raelin = CreateCharacter("Raelin") as Character_Sprite;
            Raelin.Show();

            /*yield return new WaitForSeconds(0.5f);

            AudioManager.instance.PlaySoundEffect("Audio/SFX/thunder_strong_01");

            yield return new WaitForSeconds(0.5f);
            Raelin.Animate("Hop");
            Raelin.TransitionSprite(Raelin.GetSprite("B2"));
            Raelin.TransitionSprite(Raelin.GetSprite("P1_Face3"), 1);
            Raelin.Say("!!!!");*/

            yield return new WaitForSeconds(0.5f);

            //AudioManager.instance.PlaySoundEffect("Audio/SFX/RadioStatic", loop: true);
            AudioManager.instance.PlayVoice("Audio/Voices/wakeup");

            yield return Raelin.Say("เสียงนี่หนวกหูจัง ฉันจะไปปิดมัน");

            AudioManager.instance.StopSoundEffect("RadioStatic");

            yield return Raelin.Say("ปิดเรียบร้อยแล้ว");
        }

        IEnumerator Running2()
        {
            //AudioChannel channel = new AudioChannel(1);

            yield return null;
        }

        IEnumerator Running3()
        {
            Character_Sprite Raelin = CreateCharacter("Raelin") as Character_Sprite;
            Raelin.Show();

            yield return new WaitForSeconds(3f);

            GraphicPanelManager.instance.GetPanel("background").GetLayer(0, true).SetTexture("Graphics/BG Images/5");
            AudioManager.instance.PlayTrack("Audio/Music/Calm", startingVolume: 0.7f);
            AudioManager.instance.PlayVoice("Audio/Voices/wakeup");
            yield return new WaitForSeconds(2f);
            AudioManager.instance.PlayTrack("Audio/Music/Happy");

            yield return null;

        }

        IEnumerator Running4()
        {
            Character_Sprite Raelin = CreateCharacter("Raelin") as Character_Sprite;
            Raelin.Show();
            
            GraphicPanelManager.instance.GetPanel("background").GetLayer(0, true).SetTexture("Graphics/BG Images/villagenight");

            AudioManager.instance.PlayTrack("Audio/Ambience/RainyMood", 0);
            AudioManager.instance.PlayTrack("Audio/Music/Calm", 1, pitch: 0.7f );

            yield return Raelin.Say("เราสามารถเล่นเสียงได้หลายช่องทาง");

            AudioManager.instance.StopTrack(1);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}