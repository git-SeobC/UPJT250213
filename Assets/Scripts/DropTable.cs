using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// CreateAssetMenu 설정
// ()안에 fileName, menuName, order를 설정할 수 있음
// fileName : 생성되는 에셋의 이름
// menuName : Create를 통해 만들어지는 메뉴의 이름을 설정. /를 넣을 경우 경로가 추가
// order : 메뉴 중에서 몇번째 위치에 표시될지 설정하는 값, 값이 작을 수록 마지막에 표시

[CreateAssetMenu(fileName = "DropTable", menuName = "DropTable/drop table", order = 3)]
public class DropTable : ScriptableObject
{
    public List<GameObject> drop_table;
}
