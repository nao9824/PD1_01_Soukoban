using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //配列の宣言
    int[] map;
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number,int moveFrom,int moveTo) {
    if(moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }
        //移動先に箱がいたら
        if (map[moveTo] == 2) { 
        //どの方向に移動させるかを算出
        int velocity = moveTo - moveFrom;
        bool success = MoveNumber(2, moveTo, moveTo + velocity);
        //もし箱が移動失敗したら、プレイヤーも移動失敗
        if(!success) { return false; }
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 1, 0, 2, 0, 2, 0, 0, 0 };
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex, playerIndex - 1);

            PrintArray();
        }
    }
}
