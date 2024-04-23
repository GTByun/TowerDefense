using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

/// <summary>
/// 그리드에 배치된 타워들에 대한 정보를 제공하며, 각 타워들에게 접근할 수 있는 Method가 있음
/// </summary>
public class GridManager : MonoBehaviour
{
    public GridInfo[] gridInfoArr = new GridInfo[9]; //각 그리드에 설치되는 타워의 정보 배열
    public int towerInHand = -1; //손에 가지고 있는 타워. 타워를 설치할 때, 손에 먼저 타워를 저장한 뒤 이 타워를 배치함
    [SerializeField] private GameObject towerPlace; //클릭 감지용 오브젝트
    [SerializeField] private GameObject towerPlaceParent; //towerPlace의 부모
    private StateManager stateManager;
    private TowerInfoManager towerInfoManager;
    private UIController uiController;

    private void Start()
    {
        stateManager = GameManager.instance.stateManager;
        towerInfoManager = GameManager.instance.towerInfoManager;
        uiController = GameManager.instance.uiController;
    }

    /// <summary>
    /// 손에 들고 있는 타워를 변경함. UI를 업데이트함.
    /// </summary>
    /// <param name="tower">변경될 타워의 인덱스</param>
    public void SetHand(int tower)
    {
        towerInHand = tower;
        uiController.UpdateEditModeHUD();
    }
    /// <summary>
    /// 그리드가 클릭되었을 때 호출되는 함수임
    /// </summary>
    /// <param name="index">index번째의 그리드가 클릭됨</param>
    public void GridClicked(int index)
    {
        if (stateManager.gameState == GameState.EditMode)//에딧모드인지를 먼저 체크함
        {
            if (gridInfoArr[index].towerIndex != -1)//이 그리드에 타워가 있다면
            {
                ChangeTower(index);
            }else
            {
                if (towerInHand != -1) CreateTower(index);
            }
        }
    }

    /// <summary>
    /// index번째 그리드에 있는 타워와 손에 있는 타워를 교체함
    /// </summary>
    /// <param name="tower">대상 그리드의 index</param>
    private void ChangeTower(int index)
    {
        int temp = gridInfoArr[index].towerIndex;//temp에 기존 타워 인덱스 저장
        Destroy(gridInfoArr[index].towerObject);//기존 타워 삭제. 일단 함수 실행되는 수가 적으니 Destroy 쓰면 될듯
        gridInfoArr[index].towerObject = null;
        if (towerInHand != -1) //손에 타워가 있다면, 타워 교체 작업
        {
            GameObject obj = GameObject.Instantiate(towerInfoManager.GetObject(towerInHand));//타워 생성 및 초기화
            gridInfoArr[index].towerObject = obj;
            obj.transform.position = gridInfoArr[index].pos;
        }
        gridInfoArr[index].towerIndex = towerInHand;
        SetHand(temp); //손에 있는 타워를 바꿔줌
    }

    /// <summary>
    /// index번째 그리드에 손에 있는 타워를 배치함
    /// </summary>
    /// <param name="index">대상 그리드의 index</param>
    private void CreateTower(int index)
    {
        GameObject obj = GameObject.Instantiate(towerInfoManager.GetObject(towerInHand));//타워 생성 및 초기화
        gridInfoArr[index].towerObject = obj;
        gridInfoArr[index].towerIndex = towerInHand;
        obj.transform.position = gridInfoArr[index].pos;
        SetHand(-1); //손을 비워줌
    }

    /// <summary>
    /// 일회용 TowerPlace 설치 함수
    /// </summary>
    public void SetTowerPlace(float modular)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int index = i * 3 + j;
                Vector2 pos = new(j * modular - modular, modular - i * modular);
                GameObject obj = Instantiate(towerPlace, pos, Quaternion.identity);
                obj.transform.localScale = Vector2.one * modular;
                obj.transform.parent = towerPlaceParent.transform;
                obj.GetComponent<TowerPlace>().towerIndex = index;
                gridInfoArr[index] = new GridInfo(index, obj);
            }
        }
    }

    /// <summary>
    /// 그리드 내에 타워가 하나라도 있는지 확인함. 없을시 -1, 있을시 그 그리드 번호를 반환함
    /// </summary>
    /// <param name="tower">tower 번호의 타워를 찾음</param>
    /// <returns></returns>
    public int HasTower(int tower)
    {
        int result = -1;
        foreach (GridInfo gridInfo in gridInfoArr)
        {
            if (gridInfo.towerIndex == tower)
            {
                result = gridInfo.index; break;
            }
        }
        return result;
    }

    /// <summary>
    /// 이 타워 번호가 모듈이라면, 그리드에서 이미 있는 타워를 지워줌
    /// </summary>
    /// <param name="tower"></param>
    public void CheckModule(int tower)
    {
        if (tower < towerInfoManager.nTower / 2) return; //모듈이 아니라서 반환
        int index = HasTower(tower - towerInfoManager.nTower / 2);
        gridInfoArr[index].ResetTower();
    }

    public void ClearHand()
    {
        SetHand(-1);
    }
}

