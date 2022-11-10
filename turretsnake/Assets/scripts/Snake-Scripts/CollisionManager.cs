using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    RaycastHit m_Hit;
    bool m_IsHit;
    float m_MaxDistance;
    GridPosition true_position;

    [SerializeField] public bool perma_eat;

    float eat_Timer = 0;
   [SerializeField] float eat_Timer_max;

    private void Start()
    {
        true_position = GetComponent<GridPosition>();

        m_MaxDistance = 0.3f;
    }

    public bool CanGoTo(Vector3 dir)
    {
        bool passable = true; //Returns true if we hit something we cannot pass
        m_IsHit = Physics.BoxCast(true_position.GetFullPosition(), transform.localScale / 3f, dir, out m_Hit, transform.rotation, m_MaxDistance);
        if (m_IsHit)
        {
            //Output the name of the Collider your Box hit
            //Debug.Log("Hit : " + m_Hit.collider.name);
            //Debug.DrawLine(transform.position, m_Hit.point);

            if (m_Hit.transform.CompareTag("SnakeComponent") && m_Hit.transform.GetComponent<SnakeComponent2>().prev == null)
            {
                if (!Input.GetKey(KeyCode.Space) && !perma_eat)
                //if(!perma_eat)
                {
                    passable = false;
                }
                else
                {
                    if (eat_Timer > eat_Timer_max)
                    {
                        passable = true;
                        eat_Timer = 0;
                    }
                    else
                    {
                        passable = false;
                    }

                    eat_Timer += Time.deltaTime;
                } //eat related

            }
            else if (m_Hit.transform.CompareTag("Impassable") || m_Hit.transform.CompareTag("Base"))
            {
                passable = false;
            }

        }

        return passable;
    }




}
