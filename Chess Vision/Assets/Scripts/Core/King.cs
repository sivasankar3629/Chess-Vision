using System;
using Chess.Scripts.Core;
using UnityEngine;

public class King : ChessPlayerPlacementHandler
{
    public override void ShowPossibleMovement()
    {
        

        // Possible movement directions
        Vector2[] directions =
        {
            new Vector2(1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1),
            new Vector2(-1, 1),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(-1, 0),
            new Vector2(0, -1)

        };

        // Highlighting the directions
        foreach (var dir in directions) 
        {
            
                int nextPossibleRow = (Int32)(currentRow + dir.x);
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
                continue;
                }
                ChessBoardPlacementHandler.Instance.Highlight(nextPossibleRow, nextPossibleColumn);
            
        }
    }
}