using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stop = 2.5f;
    [Header("攻擊冷卻"), Range(0, 50)]
    public float cd = 1.5f;
    [Header("攻擊中心點")]
    public Transform point;
    [Header("攻擊長度"),Range(0f,5f)]
    public float attacklength;

    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;

    private float timer;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();

        ani = GetComponent<Animator>();

        player = GameObject.Find("黑人").transform;

        nav.speed = speed;
        nav.stoppingDistance = stop;
    }
    
    private void Update()
    {
        Track();
        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(point.position, point.forward * attacklength);
    }

    private RaycastHit hit;
     

    private void Attack()
    {
        if(nav.remainingDistance < stop)
        {
            timer += Time.deltaTime;

            Vector3 pos = player.position;
            pos.y = transform.position.y;

            transform.LookAt(pos);

            if (timer >= cd)
            {
                ani.SetTrigger("開扁");
                timer = 0;

                if(Physics.Raycast(point.position, point.forward, out hit, attacklength, 1<<8))
                {
                    hit.collider.GetComponent<player>().damage();
                }
            }
        }
    }

    //追蹤
    private void Track()
    {
        nav.SetDestination(player.position); //目的地

        ani.SetBool("去追他", nav.remainingDistance > stop); //要不要跑
    }
}
