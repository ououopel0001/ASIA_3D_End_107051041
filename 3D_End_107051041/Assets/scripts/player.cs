using UnityEngine;
using Invector.vCharacterController;

public class player : MonoBehaviour
{
    private float hp = 100;
    private Animator ani;

    private int atkCount;

    private float timer;
    [Header("連擊間隔"),Range(0,3)]
    public float interval = 1;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(atkCount<3)
        {
            if (timer < interval)
            {
                timer += Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    atkCount++;
                    timer = 0;                   
                }
            }
            else
            {
                atkCount = 0;
                timer = 0;
            }
        }

        if (atkCount == 3) atkCount = 0;
        ani.SetInteger("連擊", atkCount);

    }

    public void damage(float Damage)
    {
        hp -= Damage;
        ani.SetTrigger("被打到");

        if(hp<=0)
        {
            dead();
        }
    }

    private void dead()
    {
        ani.SetTrigger("死囉");
        vThirdPersonController vt = GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
        vt.lockRotation = true;
    }
}
