using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public EnnvirementMapManager EnnvirementMapManagerCom = null;
    public bool isOver;
    public Rigidbody ActorDody = null;
    float MaxX = 0f;

    void Start()
    {
        /*string[] templayer = new string[] {"Tree"};
        m_TreeLayerMask = LayerMask.GetMask(templayer);*/

        EnnvirementMapManagerCom.UpdateForwardNBackMove((int)this.transform.position.x);
        isOver = false;
    }
    public enum E_DirectionType
    {
        UP = 0,
        Down,
        Left,
        Right,
    }

    [SerializeField]
    protected E_DirectionType m_DirectionType = E_DirectionType.UP;
    /*protected int m_TreeLayerMask = -1;
    protected bool ISCheckDirectionViewMove(E_DirectionType p_movetype)
    {
        Vector3 direction = Vector3.zero;
        switch (p_movetype)
        {
            case E_DirectionType.UP:
                {
                    direction = Vector3.right;
                }
                break;
            case E_DirectionType.Down:
                {
                    direction = Vector3.left;
                }
                break;
            case E_DirectionType.Left:
                {
                    direction = Vector3.forward;
                }
                break;
            case E_DirectionType.Right:
                {
                    direction = Vector3.back;
                }
                break;
            default:
                Debug.LogErrorFormat("SetActorMove Error : {0}", p_movetype);
                break;

        }

        RaycastHit hitobj;
        if (Physics.Raycast(this.transform.position, direction, out hitobj, 1f, m_TreeLayerMask))
        {
            return false;
        }

        return true;
    }*/
    protected void SetActorMove(E_DirectionType p_movetype)
    {
        /*if(ISCheckDirectionViewMove(p_movetype)) 
        {
            return;
        }
        */
        Vector3 offsetpos = Vector3.zero;

        switch (p_movetype) 
        {
            case E_DirectionType.UP:
                {
                    offsetpos = Vector3.right;
                }
                break;
            case E_DirectionType.Down:
                {
                    offsetpos = Vector3.left;
                }
                break;
            case E_DirectionType.Left:
                {
                    offsetpos = Vector3.forward;
                }
                break;
            case E_DirectionType.Right:
                {
                    offsetpos = Vector3.back;
                }
                break;
            default:
                Debug.LogErrorFormat("SetActorMove Error : {0}", p_movetype);
                break;

        }

        this.transform.position += offsetpos;
        EnnvirementMapManagerCom.UpdateForwardNBackMove((int)this.transform.position.x);
    }

    public void ScoreUp()
    {
        float nowX = this.transform.position.x;
        if(nowX > MaxX) 
        {
            MaxX = nowX;
            gm.score++;
        }
    }
    // Update is called once per frame

    void Update()
    {
        if (isOver == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SetActorMove(E_DirectionType.UP);
                ScoreUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SetActorMove(E_DirectionType.Down);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SetActorMove(E_DirectionType.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SetActorMove(E_DirectionType.Right);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isOver = true;
            gm.GameOver();
        }
        else if (other.CompareTag("Coin") && gm.end != true)
        {
            gm.GetScore();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}

