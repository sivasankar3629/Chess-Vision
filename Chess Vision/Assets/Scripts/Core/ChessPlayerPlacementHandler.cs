using System;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public abstract class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int currentRow, currentColumn;
        [SerializeField] private bool isWhite;

        private void Start() {
            Init();
        }

        protected virtual void Init()
        {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(currentRow, currentColumn).transform.position;
            transform.SetParent(ChessBoardPlacementHandler.Instance.GetTile(currentRow, currentColumn).transform);
            //Debug.Log(ChessBoardPlacementHandler.Instance.GetTile(currentRow, currentColumn).transform.position);
            //ChessBoardPlacementHandler.Instance.SetPiece(currentRow, currentColumn);
            //gameObject.layer = LayerMask.NameToLayer("Pieces");
        }

        protected bool IsNextCellInvalid(int row, int col)
        {
            if (row < 0 || row > 7 || col < 0 || col > 7)
                return false;
            if (ChessBoardPlacementHandler.Instance.GetTile(row, col).GetComponentInChildren<ChessPlayerPlacementHandler>() != null) 
                return true;
            return false;
        }

        public abstract void ShowPossibleMovement();

        public bool IsWhite()
        {
            return isWhite;
        }
    }
}