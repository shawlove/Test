using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
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
    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }
    public bool IsAttacked
    {
        get
        {
            return isAttacked;
        }
        set
        {
            isAttacked = value;
        }
    }
    private bool isAttacked;
    private int hp;
    private int maxHp=100;
    private string _name;
    private int id;
    private string type;
    private RectTransform blood;
    private Animation anim;

    void Start()
    {
        hp = maxHp;
        blood = transform.FindChild("EnemyStatu/Panel/EnemyBloodStrip/EnemyBlood").GetComponent<RectTransform>();
        anim = GetComponent<Animation>();
        anim["touchHead"].speed = 2;
    }

    void Update()
    {
        blood.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,0.007f,hp*0.00192f);
        if (isAttacked)
        {
            print("爱丽丝                ");
            anim.Play("touchHead",PlayMode.StopSameLayer);
            isAttacked = false;
        }
        anim.PlayQueued("idle01",QueueMode.CompleteOthers,PlayMode.StopSameLayer);
        if (hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    /*
    private void stopAnimClip()
    {
        anim.Play();
    }*/


	}

