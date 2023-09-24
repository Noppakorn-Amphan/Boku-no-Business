using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;
using STATUS;
using TMPro;


namespace TESTING
{
    public class Test01 : MonoBehaviour
    {
        public TMP_FontAsset tempFont;
        private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);
        
        void Start()
        {
            StartCoroutine(Test());
        }

        IEnumerator Test(){
            //Create Character
            /*Character_Sprite Raelin = CreateCharacter("Raelin") as Character_Sprite;
            yield return Raelin.Say("สวัสดีค่ะหัวหน้า");

            yield return new WaitForSeconds(0.5f);
            Sprite body = Raelin.GetSprite("B4");
            Sprite face = Raelin.GetSprite("P2_Smile");
            Raelin.TransitionSprite(body);
            yield return Raelin.TransitionSprite(face, 1);

            yield return Raelin.Say("วันนี้ฉันจะมาสอนการเล่นนะคะ");

            yield return new WaitForSeconds(0.5f);
            body = Raelin.GetSprite("B2");
            face = Raelin.GetSprite("P1_Open");
            Raelin.TransitionSprite(body);
            yield return Raelin.TransitionSprite(face, 1);

            yield return Raelin.Say("สมมุติว่านี่คือสถานการณ์ตัวอย่าง");
            yield return Raelin.Say("หัวหน้าคะ บริษัทเรามีพนักงานบริษัทเรามีทักษะน้อยควรฝึกทักษะของพนักงานเราไหมคะ?  ( งบประมาณ -1 ทักษะพนักงาน +0.5 )");
            yield return StartCoroutine(ShowDecisionPanelDelayed(3));

            yield return new WaitForSeconds(5);
            yield return Raelin.Say("เป็นอย่างไรบ้างค่ะ?");

            yield return new WaitForSeconds(0.5f);
            body = Raelin.GetSprite("B3");
            face = Raelin.GetSprite("P2_Face2");
            Raelin.TransitionSprite(body);
            yield return Raelin.TransitionSprite(face, 1);

            yield return Raelin.Say("ต่อมาจะลองสอนขายงานนะคะ");

            //Move
            yield return Raelin.MoveToPosition(new Vector2(1.2f,0.5f));
            yield return new WaitForSeconds(0.5f);
            body = Raelin.GetSprite("B1");
            face = Raelin.GetSprite("P1_Smile");
            Raelin.TransitionSprite(body);
            yield return Raelin.TransitionSprite(face, 1);
            yield return Raelin.Say("ด้านบนหัวของฉันคือปุ่มขายงานค่ะ");
            yield return Raelin.MoveToPosition(new Vector2(1.2f,1.5f));
            yield return Raelin.MoveToPosition(new Vector2(1.2f,0.5f));

            yield return Raelin.Say("หัวหน้าสามารถขายงานได้ตลอดเวลาเลยนะคะ");

            yield return new WaitForSeconds(0.5f);
            body = Raelin.GetSprite("B2");
            face = Raelin.GetSprite("P1_Normal");
            Raelin.TransitionSprite(body);
            yield return Raelin.TransitionSprite(face, 1);

            yield return Raelin.Say("แต่ในการขายงานจะต้องใช้ 1 งานและ 1 การตลาด");
            yield return Raelin.Say("อย่ากดเล่นนะคะ");

            yield return Raelin.MoveToPosition(new Vector2(0.5f,0.5f));

            yield return new WaitForSeconds(0.5f);
            body = Raelin.GetSprite("B4");
            face = Raelin.GetSprite("P2_Shy");
            Raelin.TransitionSprite(body);
            yield return Raelin.TransitionSprite(face, 1);

            //Move
            yield return Raelin.Say("สำหรับวันนี้ Test01 มีแค่นี้");
            yield return Raelin.Say("เจอกันครั้งหน้าค่ะ >w<");
            yield return Raelin.MoveToPosition(new Vector2(-2f,0.5f));*/
            yield return null;
        }


/*
        IEnumerator ShowDecisionPanelDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);

            // Show the decision panel with the question
            decisionManager.ShowDecisionPanel();

            // Disable the TestDecision script to prevent the buttons from appearing again
            enabled = false;
        }


        public void MakeDecisionA()
        {
            // Call the MakeDecisionA() function in the DecisionManager
            decisionManager.MakeDecisionA();
        }

        public void MakeDecisionB()
        {
            // Call the MakeDecisionB() function in the DecisionManager
            decisionManager.MakeDecisionB();
        }*/
        void Update()
        {

        }
    }
}
