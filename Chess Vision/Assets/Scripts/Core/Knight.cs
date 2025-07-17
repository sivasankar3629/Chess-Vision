using System;
using System.Collections.Generic;
using Chess.Scripts.Core;
using UnityEngine;

public class Knight : ChessPlayerPlacementHandler
{
    public override void ShowPossibleMovement()
    {



        // Possible movement directions
        Vector2[] directions =
        {
            new Vector2(1, 2),
            new Vector2(2,1),
            new Vector2(-1,2),
            new Vector2(2,-1),
            new Vector2(-1,-2),
            new Vector2(-2,-1),
            new Vector2(-2,1),
            new Vector2(1,-2)

        };

        // Highlighting the directions
        foreach (var dir in directions)
        {
             int nextPossibleRow = (Int32)(currentRow + dir.x );
             int nextPossibleColumn = (Int32)(currentColumn + dir.y );
             //Debug.Log(nextPossibleRow + " " + nextPossibleColumn);
             if (IsNextCellInvalid(nextPossibleRow, nextPossibleColumn))
             {
                if (ChessBoardPlacementHandler.Instance.GetTile(nextPossibleRow, nextPossibleColumn).GetComponentInChildren<ChessPlayerPlacementHandler>().IsWhite() != IsWhite())
                {
                    GameObject highlight = ChessBoardPlacementHandler.Instance.Highlight(nextPossibleRow, nextPossibleColumn);
                    highlight.GetComponent<SpriteRenderer>().color = Color.red;
                    highlight.transform.localScale = Vector3.one * 1.1f;
                }
                Debug.Log("Knight : " + nextPossibleRow + " " + nextPossibleColumn);
                continue;
             }
             ChessBoardPlacementHandler.Instance.Highlight(nextPossibleRow, nextPossibleColumn);
            
        }
    }
}
