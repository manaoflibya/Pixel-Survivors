using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPresenterData : MonoBehaviour
{
    // ��ü UIModel�� �����ϴ� List (���, �̻�뿡 ������ ���� �����ϸ� ��)
    public List<GameUIModel> modelList = new List<GameUIModel>();

    // ���� ����ϱ� ���ؼ� �����ϴ� List
    public List<GameUIModel> useModelList = new List<GameUIModel>();
}
