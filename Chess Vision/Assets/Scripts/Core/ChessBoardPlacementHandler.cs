using System;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.Tilemaps;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour {
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    private GameObject[,] _chessBoard;
    //private bool[,] piecePresent = new bool[8,8];

    internal static ChessBoardPlacementHandler Instance;
    

    private void Awake() {
        Instance = this;
        GenerateArray();
    }

    private void GenerateArray() {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j)
    {
        return _chessBoard[i, j];
    }

    //internal GameObject GetPiece(int i, int j) 
    //{
    //    if (i < 0 || i >= 8 || j < 0 || j >= 8)
    //        return null;

    //    GameObject tile = _chessBoard[i, j];
    //    if (tile == null)
    //    {
    //        Debug.LogError("tiles not found");
    //    }
    //    Debug.Log(tile.name);

    //    GameObject piece = Physics2D.OverlapPoint(tile.transform.position, LayerMask.NameToLayer("Pieces")).gameObject;
    //    if (piece != null) 
    //    {
    //        Debug.Log("no piece");
    //        return piece;
    //    }
        
    //    return null;
    //}

    //internal bool isPiecePresent(int row, int col)
    //{
    //    return piecePresent[row, col];
    //}

    //internal void SetPiece(int row, int col)
    //{
    //    piecePresent[row, col] = true;
    //}

    //internal void ClearPiece(int row, int col)
    //{
    //    piecePresent[row, col] = false;
    //}

    internal GameObject Highlight(int row, int col) {
        if (row < 0 || row >= 8 || col < 0 || col >= 8)
            return null;
        var tile = GetTile(row, col).transform;
        if (tile == null) {
            Debug.LogError("Invalid row or column.");
            return null;
        }

        return Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void ClearHighlights() {
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform) {
                    if (!childTransform.CompareTag("Highlight")){
                        continue;
                    }
                    Destroy(childTransform.gameObject);
                }
            }
        }
    }


    #region Highlight Testing

    // private void Start() {
    //     StartCoroutine(Testing());
    // }

    // private IEnumerator Testing() {
    //     Highlight(2, 7);
    //     yield return new WaitForSeconds(1f);
    //
    //     ClearHighlights();
    //     Highlight(2, 7);
    //     Highlight(2, 6);
    //     Highlight(2, 5);
    //     Highlight(2, 4);
    //     yield return new WaitForSeconds(1f);
    //
    //     ClearHighlights();
    //     Highlight(7, 7);
    //     Highlight(2, 7);
    //     yield return new WaitForSeconds(1f);
    // }

    #endregion
}