using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI _maxText;
    public int[,] Numbers = new int[4, 4];
    private int[] _newNumber = new int[10];
    private int _maxNumber = 0;
    private int _maxCount = 0;

    private void Awake()
    {
        if(Instance == null)
        Instance = this;
    }

    private void Start()
    {
        for(int i=0; i<4; i++)
        {
            for(int j=0; j<4; j++)
            {
                Numbers[i, j] = 1;
            }
        }

        for(int i=0; i<10; i++)
        {
            if (i == 0)
                _newNumber[i] = 2;
            else
                _newNumber[i] = _newNumber[i-1] * 2;
        }
    }

    private void Update()
    {
        _maxText.text = _maxNumber.ToString();
        if(Input.GetMouseButtonDown(0))
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Numbers[i, j] != 1)
                        count++;
                }
            }

            if (count == 16)
                GameOver();

            else
            {
                float x = Input.mousePosition.x - 594;
                float y = Input.mousePosition.y - 1022;
                if (System.Math.Abs(x) >= System.Math.Abs(y))
                {
                    if (x > 0)
                        MoveRight();
                    else
                        MoveLeft();
                }
                else
                {
                    if (y > 0)
                        MoveUp();
                    else
                        MoveDown();
                }
            }
            
        }
    }

    private void GameOver()
    {
        _maxNumber = 1;
        _maxCount = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Numbers[i, j] = 1;


            }
        }
    }

    private void MoveDown()
    {
        Debug.Log("down");
        for (int j = 0; j < 4; j++)
        {
            for (int i = 3; i > 0; i--)
            {
                if ((Numbers[i, j]) == 1)
                {
                    if ((Numbers[i - 1, j]) != 1)
                    {
                        Numbers[i, j] = Numbers[i - 1, j];
                        Numbers[i - 1, j] = 1;
                    }
                }
                else if (Numbers[i - 1, j] == Numbers[i, j])
                {
                    Numbers[i, j] = Numbers[i - 1, j] + Numbers[i, j];
                    Numbers[i - 1, j] = 1;
                    if (Numbers[i, j] > _maxNumber)
                    {
                        _maxCount++;
                        _maxNumber = Numbers[i, j];
                    }
                }

            }
        }
        MakeRandomSlot();
    }

    private void MoveUp()
    {
        Debug.Log("up");
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((Numbers[i, j]) == 1)
                {
                    if ((Numbers[i+1, j]) != 1)
                    {
                        Numbers[i, j] = Numbers[i+1, j];
                        Numbers[i+1, j] = 1;
                    }
                }
                else if (Numbers[i+1, j] == Numbers[i, j])
                {
                    Numbers[i, j] = Numbers[i+1, j] + Numbers[i, j];
                    Numbers[i+1, j] = 1;
                    if (Numbers[i, j] > _maxNumber)
                    {
                        _maxCount++;
                        _maxNumber = Numbers[i, j];
                    }
                }

            }
        }
        MakeRandomSlot();
    }

    private void MoveLeft()
    {
        Debug.Log("left");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if ((Numbers[i, j]) == 1)
                {
                    if ((Numbers[i, j +1]) != 1)
                    {
                        Numbers[i, j] = Numbers[i, j + 1];
                        Numbers[i, j + 1] = 1;
                    }
                }
                else if (Numbers[i, j + 1] == Numbers[i, j])
                {
                    Numbers[i, j] = Numbers[i, j+ 1] + Numbers[i, j];
                    Numbers[i, j + 1] = 1;
                    if (Numbers[i, j] > _maxNumber)
                    {
                        _maxCount++;
                        _maxNumber = Numbers[i, j];
                    }
                }

            }
        }
        MakeRandomSlot();
    }

    private void MoveRight()
    {
        Debug.Log("right");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 3; j > 0; j--)
            {
                if ((Numbers[i, j]) == 1)
                {
                    if ((Numbers[i, j - 1]) != 1)
                    {
                        Numbers[i, j] = Numbers[i, j - 1];
                        Numbers[i, j - 1] = 1;
                    }
                }
                else if (Numbers[i, j - 1] == Numbers[i, j])
                {
                    Numbers[i, j] = Numbers[i, j - 1] + Numbers[i, j];
                    Numbers[i, j - 1] = 1;
                    if (Numbers[i, j] > _maxNumber)
                    {
                        _maxCount++;
                        _maxNumber = Numbers[i, j];
                    }
                }


            }


        }

        MakeRandomSlot();
    }

    

    private void MakeRandomSlot()
    {
        bool flag = false;
        int count = 0;
        int newNum = 0;
        int rnd = 0;
        if (_maxCount < 4)
            newNum = 2;
        else if (_maxCount < 13)
        {
            rnd = Random.Range(0, _maxCount - 3);
            newNum = _newNumber[rnd];
        }
        else
            newNum = _newNumber[Random.Range(0, 10)];

        for(int i=0; i<4; i++)
        {
            for(int j=0; j<4; j++)
            {
                if (Numbers[i, j] != 1)
                    count++;
            }
        }


        while (!flag)
        {
            int line = Random.Range(0, 4);
            int column = Random.Range(0, 4);

            if (Numbers[line, column] == 1)
            {
                Numbers[line, column] = newNum;
                flag = true;
            }
                
        }
    }
}
