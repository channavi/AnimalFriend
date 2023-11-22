using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnvirementMapManager : MonoBehaviour
{
    public enum E_EnvirementType
    {
        Grass = 0,
        Road,

        Max
    }

    public enum E_LastRoadType
    {
        Grass = 0,
        Road,

        Max
    }

    //public GameObject[] EnvirmentObjectArray = new GameObject[(int)E_EnvirementType.Max];
    [Header("[복제용길]")]
    public Road DefaultRoad = null;
    public TreeSpawn GrassRoad = null;

    public Transform ParentTransform = null;

    public int MinPosX = -20;
    public int MaxPosX = 20;

    public int FrontOffsetPosX = 10;
    public int BackOffsetPosX = 10;

    void Start()
    {

    }

    public int GroupRandomRoadLine(int p_posx)
    {
        int randomcount = Random.Range(1, 4);

        for (int i= 0; i < randomcount; ++i)
        {
            GeneratorRoadLine(p_posx + i);
        }

        return randomcount;
    }

    public int GroupRandomGrassLine(int p_posx)
    {
        int randomcount = Random.Range(1, 3);

        for (int i = 0; i < randomcount; ++i)
        {
            GeneratorGrassLine(p_posx + i);
        }

        return randomcount;
    }



    public void GeneratorRoadLine(int p_posx)
    {
        GameObject cloneobj = GameObject.Instantiate(DefaultRoad.gameObject);
        cloneobj.SetActive(true);
        Vector3 offsetpos = Vector3.zero;
        offsetpos.x = (float)p_posx;
        cloneobj.transform.SetParent(ParentTransform);
        cloneobj.transform.position = offsetpos;

        cloneobj.name = "RoadLine_" + p_posx.ToString();

        int randomrot = Random.Range(0, 2);
        if (randomrot == 1)
        {
            cloneobj.transform.rotation = Quaternion.Euler(0, 180f, 0f);
        }
    }

    public void GeneratorGrassLine(int p_posx)
    {
        GameObject cloneobj = GameObject.Instantiate(GrassRoad.gameObject);
        cloneobj.SetActive(true);
        Vector3 offsetpos = Vector3.zero;
        offsetpos.x = (float)p_posx;
        cloneobj.transform.SetParent(ParentTransform);
        cloneobj.transform.position = offsetpos;

        cloneobj.name = "GrassLine_"+ p_posx.ToString();

        m_LineMapList.Add(cloneobj.transform);
        m_LineMapDic.Add(p_posx, cloneobj.transform);
    }

    protected E_LastRoadType m_LastRoadType = E_LastRoadType.Max;
    protected List<Transform> m_LineMapList = new List<Transform>();
    protected Dictionary<int, Transform> m_LineMapDic = new Dictionary<int, Transform>();
    protected int m_LastLinePos = 0;
    public void UpdateForwardNBackMove(int p_posx)
    {
        if(m_LineMapList.Count <= 0)
        {
            m_LastRoadType = E_LastRoadType.Grass;
            int i = 0;
            //초기용 라인들 세팅

            for(i = MinPosX; i<MaxPosX; ++i) 
            {
                int offsetval = 0;
                if( i < 0)
                {
                    GeneratorGrassLine(i);
                }
                else
                {
                    if(m_LastRoadType == E_LastRoadType.Grass)
                    {
                        offsetval = GroupRandomRoadLine(i);
                        m_LastRoadType = E_LastRoadType.Road;
                    }
                    else
                    {
                        offsetval = GroupRandomGrassLine(i);
                        m_LastRoadType= E_LastRoadType.Grass;
                    }

                    i += offsetval - 1;
                }
               
            }
            m_LastLinePos = i;
        }

        //새롭게 생성

        if (m_LastLinePos < p_posx + FrontOffsetPosX)
        {
            int offsetval = 0;
            if (m_LastRoadType == E_LastRoadType.Grass)
            {
                offsetval = GroupRandomRoadLine(m_LastLinePos);
                m_LastRoadType = E_LastRoadType.Road;
            }
            else
            {
                offsetval = GroupRandomGrassLine(m_LastLinePos);
                m_LastRoadType = E_LastRoadType.Grass;
            }

            m_LastLinePos += offsetval;
        }

        //많이 지나갔으면 지우기
    }

}
