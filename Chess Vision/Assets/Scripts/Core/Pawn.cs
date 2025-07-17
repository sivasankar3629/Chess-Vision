using System;
using Chess.Scripts.Core;
using UnityEngine;

public class Pawn : ChessPlayerPlacementHandler
{
    public override void ShowPossibleMovement()
    {

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

        // Enemy detection
        Vector2[] attackDirections =
        {
            new Vector2(1,1),
            new Vector2(1,-1)
        };

        foreach (var dir in attackDirections)
        {
            int attackDirectionRow = (Int32)(currentRow + dir.x);
            int attackDirectionCol = (Int32)(currentColumn + dir.y);
            if (attackDirectionRow < 0 || attackDirectionRow >= 8 || attackDirectionCol < 0 || attackDirectionCol >= 8)
                continue;
            ChessPlayerPlacementHandler playerPlacement = ChessBoardPlacementHandler.Instance.GetTile(attackDirectionRow, attackDirectionCol).GetComponentInChildren<ChessPlayerPlacementHandler>();

            if (playerPlacement != null && playerPlacement.IsWhite() != IsWhite())
            {
                GameObject highlight = ChessBoardPlacementHandler.Instance.Highlight(attackDirectionRow, attackDirectionCol);
                highlight.GetComponent<SpriteRenderer>().color = Color.red;
                highlight.transform.localScale = Vector3.one * 1.1f;
            }
        }
    }
}