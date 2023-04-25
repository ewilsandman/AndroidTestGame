using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandlerScript : MonoBehaviour
{
    private int currentPlayer = 0;
    [SerializeField] private int[,] positions = new int[3, 3];
    [SerializeField] private Text activePlayerText;
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                positions[j, k] = 0;
            }
        }
        currentPlayer = Random.Range(1, 3);
        ProcessTurn();
    }

    private void ProcessTurn()
    {
        currentPlayer = currentPlayer == 1 ? 2 : 1;
        activePlayerText.text = "Current player: " + currentPlayer;
        activePlayerText.color = currentPlayer == 1 ? Color.green : Color.red;
    }

    private void StopGame(int won)
    {
        activePlayerText.text = "The winner is: " + won;
        activePlayerText.color = won == 1 ? Color.green : Color.red;
        currentPlayer = 0;
    }

    public int HandleClick(int x, int y)
    {
        if (currentPlayer != 0) // stops game when player has won
        {
            ProcessTurn();
            positions[x - 1, y - 1] = currentPlayer == 1 ? 2 : 1;
            int possibleWinner = CheckWin();
            if (possibleWinner != 0)
            {
                StopGame(possibleWinner);
            }
            return currentPlayer == 1 ? 2 : 1;
        }
        return 0;
    }

    public int CheckWin()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (x is 0 or 2 && y is 0 or 2) // eliminates edge tiles that cannot be used also WTF is this
                {

                }
                else if (positions[x, y] == 0) // if the tile has no owner it cannot possibly win
                {
                    
                }
                else
                {
                    if (x == 1)
                    {
                        if (positions [x,y] == positions[x +1,y] && positions [x,y] == positions[x -1,y])
                        {
                            return positions[x, y];
                        }
                        
                    }
                    if (y == 1)
                    {
                        if (positions[x, y] == positions[x, y + 1] && positions[x, y] == positions[x, y - 1]) 
                        {
                            return positions[x, y];
                        }
                        
                    }

                    if (x == 1 && y == 1)
                    {
                        if (positions [x,y] == positions[x -1,y +1] && positions [x,y] == positions[x +1,y -1])
                        {
                            return positions[x, y];
                        }
                        if (positions [x,y] == positions[x +1,y +1] && positions [x,y] == positions[x -1,y -1])
                        {
                            return positions[x, y];
                        }
                    }
                }

            }
        }
        return 0;
    }

}
