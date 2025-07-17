using System;
using Chess.Scripts.Core;
using UnityEngine;

public class Rook : ChessPlayerPlacementHandler
{
    public override void ShowPossibleMovement()
    {


        // Possible movement directions
        Vector2[] directions =
        {
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(-1, 0),
            new Vector2(0, -1)
        };

        // Highlighting the directions
        foreach (var dir in directions) 
        {
            for (int i = 1; i < 8; i++) 
            {
                int nextPossibleRow = (Int32)(currentRow + dir.x * i);
                int nextPossibleColumn = (Int32)(currentColumn + dir.y * i);
                //Debug.Log(nextPossibleRow + " " + nextPossibleColumn);
                if (IsNextCellInvalid(nextPossibleRow, nextPossibleColumn))
                {
                    if (ChessBoardPlacementHandler.Instance.GetTile(nextPossibleRow, nextPossibleColumn).GetComponentInChildren<ChessPlayerPlacementHandler>().IsWhite() != IsWhite())
                    {
                        GameObject highlight = ChessBoardPlacementHandler.Instance.Highlight(nextPossibleRow, nextPossibleColumn);
                        highlight.GetComponent<SpriteRenderer>().color = Color.red;
                        highlight.transform.localScale = Vector3.one * 1.1f;
                    }
                    break;
                }
                ChessBoardPlacementHandler.Instance.Highlight(nextPossibleRow, nextPossibleColumn);
            }
        }
    }
}