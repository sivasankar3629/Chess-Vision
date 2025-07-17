using System;
using Chess.Scripts.Core;
using UnityEngine;

public class WhitePawn : ChessPlayerPlacementHandler
{
    public override void ShowPossibleMovement()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();

        // Possible movement directions
        Vector2[] directions =
        {
            new Vector2(1, 0)
        };

        // Highlighting the directions
        foreach (var dir in directions) 
        {
                int nextPossibleRow = (Int32)(currentRow + dir.x);
                int nextPossibleColumn = (Int32)(currentColumn + dir.y);
                //Debug.Log(nextPossibleRow + " " + nextPossibleColumn);
                if (IsNextCellInvalid(nextPossibleRow, nextPossibleColumn))
                {
                    break;
                }
                ChessBoardPlacementHandler.Instance.Highlight(nextPossibleRow, nextPossibleColumn);
            
        }
    }
}