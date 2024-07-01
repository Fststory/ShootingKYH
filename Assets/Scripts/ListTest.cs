using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour
{
    public List<int> ages = new List<int>();

    void Start()
    {
        //// 1. 리스트에 값을 넣는 방법
        //ages.Add(20);

        //int student2 = 18;
        //ages.Add(student2);

        //// 2. 리스트에서 값을 지우는 방법
        //// 2-1. 리스트 안에 있는 특정 값을 지우는 방법
        //ages.Remove(18);

        //// 2-2. 리스트 안에 있는 특정 인덱스의 값을 지우는 방법
        //ages.RemoveAt(2);

        // 2-3. 리스트 안에 있는 모든 값을 다 삭제하는 방법(리스트 초기화)
        //ages.Clear();

        // 3. 리스트 안에 값 중에서 특정 값이 있는지 확인하는 방법
        int check = 35;

        //for(int i = 0; i < ages.Count; i++)
        //{
        //    if (ages[i] == check)
        //    {
        //        print(i.ToString() + "번에 찾는 값이 있어요");
        //    }
        //}

        if (ages.Contains(check))
        {
            print("그런 값이 있어요!");
        }

    }

    void Update()
    {
        
    }
}
