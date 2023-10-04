using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;

namespace TESTING
{
    public class TestGraphicLayer : MonoBehaviour {
        void Start()
        {
            StartCoroutine(Running());
        }

        IEnumerator Running()
        {
            /*GraphicPanel panel = GraphicPanelManager.instance.GetPanel("Background");
            GraphicLayer layer = panel.GetLayer(0, true);

            yield return new WaitForSeconds(1);
        
            //layer.SetTexture("Graphics/BG Images/2");

            //layer.currentGraphic.renderer.material.SetColor("_Color", Color.red);

            Texture blendTex = Resources.Load<Texture>("Graphics/Transition Effects/hurricane");
            layer.SetTexture("Graphics/BG Images/2", blendingTexture: blendTex);

            yield return new WaitForSeconds(3);

            //layer.SetVideo("Graphics/BG Videos/Fantasy Landscape", transitionSpeed: 0.01f, useAudio: true);
            layer.SetVideo("Graphics/BG Videos/Fantasy Landscape", blendingTexture: blendTex);

            yield return new WaitForSeconds(3);

            layer.currentGraphic.FadeOut();

            yield return new WaitForSeconds(1);

            Debug.Log(layer.currentGraphic);*/

            GraphicPanel panel = GraphicPanelManager.instance.GetPanel("Background");
            GraphicLayer layer0 = panel.GetLayer(0, true);
            GraphicLayer layer1 = panel.GetLayer(1, true);

            layer0.SetVideo("Graphics/BG Videos/Nebula");
            layer1.SetTexture("Graphics/BG Images/Spaceshipinterior");

            yield return new WaitForSeconds(2);

            GraphicPanel cinematic = GraphicPanelManager.instance.GetPanel("Cinematic");
            GraphicLayer cinLayer = cinematic.GetLayer(0, true);

            Character Raelin = CharacterManager.instance.CreateCharacter("Raelin", true);

            yield return Raelin.Say("นี่นาย ลองดูรูปนี้หน่อยสิ");

            cinLayer.SetTexture("Graphics/Gallery/pup");

            yield return DialogueSystem.instance.Say("Narrator", "ฉันคิดว่าฉันไม่เหมาะกับสุนัข ฉันชอบแมวมากกว่า");

            cinLayer.Clear();

            yield return new WaitForSeconds(2);

            panel.Clear();
        }
    }
}