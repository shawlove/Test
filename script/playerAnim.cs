using UnityEngine;
using System.Collections;

public class playerAnim : MonoBehaviour {

   
    private fps_playerParamter paramter;
    private  Animator anim;
    private float random;
    private Vector2 currentMove = Vector2.zero;
    private bool currentAttack01 = false;
    private bool currentAttack02 = false;
    private GameObject[] skillBars;
    private int skillState;


    void Start()
    {
        paramter = this.GetComponent<fps_playerParamter>();
        anim = this.GetComponent<Animator>();
 
    }


    void Update()
    {
        animControll();
        skillBarDown();
    }
    
    public void skillAnimEvent()
    {
        print("677");
        anim.SetInteger("skill",0);
    }

    private void skillBarDown()
    {
        skillBars = GameObject.FindGameObjectsWithTag("skillBar");
        if (paramter.isSkillbar01)
        {
            skillState = skillBars[0].GetComponentInChildren<skill>().SkillState;
            anim.SetInteger("skill",skillState);
        }
        if (paramter.isSkillbar02)
        {
            skillState = skillBars[1].GetComponentInChildren<skill>().SkillState;
            anim.SetInteger("skill", skillState);
        }
        if (paramter.isSkillbar03)
        {
            skillState = skillBars[2].GetComponentInChildren<skill>().SkillState;
            anim.SetInteger("skill", skillState);
        }
        if (paramter.isSkillbar04)
        {
            skillState = skillBars[3].GetComponentInChildren<skill>().SkillState;
            anim.SetInteger("skill", skillState);
        }
        //这里想用触发器做，，这样感觉很蠢。以后来改
    }

    private void animControll()
    {
        
        currentMove.x = paramter.inputMoveVector.x;
        currentMove.y = paramter.inputMoveVector.y;

        currentAttack01 = paramter.inputAttack01;
        currentAttack02 = paramter.inputAttack02;
        anim.SetFloat("turn",currentMove.x);
        anim.SetFloat("forward", currentMove.y);
       
        if (currentAttack01)
        {

            if (Random.Range(0f, 10f) < 3f)
            {
                anim.SetInteger("state", 3);
            }
            else
            {
                anim.SetInteger("state", 1);
            }

        }
        else
        {
            anim.SetInteger("state", 0);
        }
       
        if (currentAttack02)
        {
            
            if (Random.Range(0f, 10f) < 3f)
            {
                anim.SetInteger("state", 4);
            }
            else
            {
                anim.SetInteger("state", 2);
            }
            
           
        }
        else
        {
            anim.SetInteger("state", 0);
        }

        if (paramter.isBattle)
        {
            anim.SetFloat("isBattle",0);
        }else
        {
            if (currentMove == Vector2.zero)
            {
                
        
                anim.SetFloat("isBattle", 1);
                
            }

            anim.SetFloat("isBattle", 0);

        }


    }
    IEnumerator waitAndIdle2()
    {
        
            yield return new WaitForSeconds(3.0f);
        
    }
    


}
