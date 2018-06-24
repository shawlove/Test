﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class skill : MonoBehaviour {

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public int SkillState
    {
        get
        {
            return skillState;
        }
        set
        {
            skillState = value;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
        set
        {
            sprite = value;
        }
    }
    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
        }
    }

    private int skillState;
    private  string _name;
    private int damage;
    private int id;
    private string description;
    private Sprite sprite;
    private Image image;
    private Text text;
    private int count=0;
    private GameObject lcontent;
    private GameObject ucontent;
    private skill[] _lskills;
    private skill[] _uskills;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprite;
        text = GameObject.FindGameObjectWithTag("skillDescription").GetComponent<Text>();
        item.addEventTrigger(transform, EventTriggerType.PointerClick, MouseClick);
        lcontent = GameObject.FindGameObjectWithTag("learnedSkills");
        ucontent = GameObject.FindGameObjectWithTag("unlearnedSkills");
    }

        


    public void MouseClick(BaseEventData data)
    {
        _lskills = lcontent.GetComponentsInChildren<skill>();
        _uskills = ucontent.GetComponentsInChildren<skill>();
        if (count==0)
        {
            
            text.text = description;
            count++;
            image.color = Color.green;
            foreach (skill s in _lskills)
            {
                if (transform.parent.parent == ucontent.transform && s.count == 1)
                {
                    s.count--;
                    s.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                if (transform.parent.parent == lcontent.transform && s.count == 1 && s.id != id)
                {
                    s.count--;
                    s.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
            }
            foreach (skill s in _uskills)
            {
                if (transform.parent.parent == lcontent.transform&&s.count==1)
                {
                    s.count--;
                    s.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                if (transform.parent.parent==ucontent.transform&&s.count==1&&s.id!=id)
                {
                    s.count--;
                    s.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
            }

        }
        else
        {
            text.text = "";
            count--;
            image.color = new Color(1,1,1,1);
        }
        
    }
}
