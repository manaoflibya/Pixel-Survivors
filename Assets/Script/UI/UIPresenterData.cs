using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPresenterData : MonoBehaviour
{
    // 전체 UIModel을 저장하는 List (사용, 미사용에 구분이 없이 생성하면 들어감)
    public List<GameUIModel> modelList = new List<GameUIModel>();

    // 당장 사용하기 위해서 저장하는 List
    public List<GameUIModel> useModelList = new List<GameUIModel>();
}
