using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;
using STATUS;
using TMPro;

public class Test02 : MonoBehaviour
{
    public GameObject objectToEnableOrDisable;
    public TMP_FontAsset tempFont;
    private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);
    void Start()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test(){
        Character_Sprite Miyako = CreateCharacter("Miyako") as Character_Sprite;
        Miyako.SetPosition(new Vector2(2f,0.5f));
        yield return Miyako.Flip();
        yield return Miyako.TransitionColor(Color.black);
        yield return Miyako.MoveToPosition(new Vector2(1f,0.5f));
        yield return new WaitForSeconds(1);
        yield return Miyako.TransitionColor(Color.white);
        yield return Miyako.Say("ยินดีต้อนรับค่ะ หัวหน้า");
        yield return Miyako.Say("สำหรับวันนี้จะเป็น Test02 นะคะ");
        yield return Miyako.Say("เราจะลองให้คุณตัดสินใจ 8 สถานการณ์");
        yield return Miyako.Say("มาเริ่มกันเลย!");
        yield return new WaitForSeconds(2);
        objectToEnableOrDisable.SetActive(true);
        yield return Miyako.Say("หัวหน้าคะ บริษัทเรามีจำนวนพนักงานน้อย ควรรับสมัครพนักงานไหมคะ? (งบประมาณ -1 การตลาด -1 จำนวนพนักงาน +5) ");
        yield return Miyako.Say("หัวหน้าคะ บริษัทเรามีพนักงานบริษัทเรามีทักษะน้อย ควรฝึกทักษะของพนักงานเราไหมคะ?");
        yield return Miyako.Say("หัวหน้าคะ บริษัทเรามีชื่อเสียง และการตลาดที่แย่  จะเสียเงินโฆษณาไหมคะ?  (การตลาด +1 ชื่อเสียง + 1 งบประมาณ -1) ");
        yield return Miyako.Say("หัวหน้าคะ บริษัทเรามีงานน้อย ควรกดดันพนักงาน เพื่อเพิ่มการทำงานไหมคะ? (ความสุขพนักงาน -10 การทำงาน + 0.5)");
        yield return Miyako.Say("หัวหน้าคะ พนักงานของเราต้องการวันหยุด  ทำอย่างไงดีคะ (ความสุขพนักงาน +10 -การทำงาน 0.5)");
        yield return Miyako.Say("หัวหน้าคะ ตอนนี้มีคนตกงานจำนวนมากเนื่องจาก พิษเศรษฐกิจ เราต้องการรับคนพวกนี้ทำงานไหมคะ? (ทักษะการทำงาน -0.5 งบประมาณ 1 จำนวนพนักงาน +5 ) ");
        yield return Miyako.Say("หัวหน้าคะ เราต้องการโปรโมท บริษัทเพิ่มไหมคะ? ( การตลาด +2 จำนวนพนักงานเดือนนี้ -5 )  ");
        yield return Miyako.Say("หัวหน้าคะ เราจะนำงานที่ทำได้มาโปรโมทเพื่อ เพิ่มชื่อเสียงไหมคะ? ( งาน -2  ชื่อเสียง +2 ) ");
        yield return Miyako.Say("หมดแล้วคะ");
        yield return Miyako.Say("ขอบคุณสำหรับการ Test ครั้งนี้นะคะ");


        yield return null;
    }

    void Update()
    {
        
    }
}
