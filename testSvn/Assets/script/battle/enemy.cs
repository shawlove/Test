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
    public GameObject PlayerObj
    {
        get
        {
            return playerObj;
        }
        set
        {
            playerObj = value;
        }
    }
    public Vector3 _position;
    private GameObject playerObj;
    private bool isAttacked;
    private int hp;
    private int maxHp=100;
    private string _name;
    private int id;
    private string type;
    private RectTransform blood;
    private Animation anim;
    private NavMeshAgent navMeshAgent;
    private float toOther;
    private float attackDistance;
    private float range;

    void Start()
    {
        _position = new Vector3(-79,0.1f,40);
        range = 10f;
        attackDistance = 3f;
        hp = maxHp;
        blood = transform.FindChild("EnemyStatu/Panel/EnemyBloodStrip/EnemyBlood").GetComponent<RectTransform>();
        anim = GetComponent<Animation>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim["touchHead"].speed = 2;
        playerObj = null;
    }

    void Update()
    {
        blood.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,0.007f,hp*0.00192f);
        if ((transform.position-_position).magnitude>=range)
        {
            
            if (playerObj!=null)
            {
                playerObj = null;//失去目标
            }           
            navMeshAgent.SetDestination(_position);
            if (transform.position==_position)
            {
                navMeshAgent.Stop();
            }
        }
        if (playerObj!=null)
        {

             toOther = (playerObj.transform.position - transform.position).magnitude;
            playerBattle battle = playerObj.GetComponent<playerBattle>();
            navMeshAgent.SetDestination(playerObj.transform.position);
            if (toOther<=attackDistance)
            {
                //navMeshAgent.Stop();
                //攻击动画   
               // anim.Play("choice",PlayMode.StopSameLayer);
                //attack(battle);
                StartCoroutine(waitAttack(2f,battle));
            }
        }
        if (isAttacked)
        {
            anim.Play("touchHead",PlayMode.StopSameLayer);
            isAttacked = false;
        }
        anim.PlayQueued("idle01",QueueMode.CompleteOthers,PlayMode.StopSameLayer);
        if (hp<=0)
        {
            Destroy(this.gameObject);
        }
        /*if (playerObj!=null)
        {
            navMeshAgent.SetDestination(playerObj.transform.position);
        }*/

    }

   /* IEnumerator waitWalk(GameObject g,float distance)
    {
        print(toOther);
        if (anim.IsPlaying("touchHead"))
        {
            yield return new WaitForSeconds(1.5f);
            navMeshAgent.SetDestination(g.transform.position);
        }
        
        if (toOther<=distance)
        {
            print("到攻击距离了");
            navMeshAgent.Stop();
            //攻击
        }
    }*/


    IEnumerator waitAttack(float interval,playerBattle battle)
    {
        anim.Play("choice", PlayMode.StopSameLayer);
        attack(battle);
        yield return new WaitForSeconds(interval);
    }

    private void attack(playerBattle battle)
    {
        float dot = 0.5f;
        int _damage = 20;
        float _dot = 0;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 v = new Vector3(transform.position.x,playerObj.transform.position.y,transform.position.z);
        Vector3 _toOther = playerObj.transform.position - v;
        _dot = Vector3.Dot(forward,_toOther);
        if (toOther<=attackDistance&&dot*attackDistance<_dot)
        {
            battle.CurrntHp -= _damage;
        }
    }




    /*
    private void stopAnimClip()
    {
        anim.Play();
    }*/


	}

