using System.Collections;
using System.Collections.Generic;
using Chess.Scripts.Core;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Camera _mainCamera;

    private void Start()
    {
        if ( Camera.main != null)
        {
            _mainCamera = Camera.main;
        }
        else
        {
            Debug.Log("No camera");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            Vector2 _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero);
            if (hit.collider != null)
            {
                ChessPlayerPlacementHandler chessPiece = hit.collider.GetComponent<ChessPlayerPlacementHandler>();
                if (chessPiece != null)
                {
                    //Debug.Log("Reached Here");
                    chessPiece.ShowPossibleMovement();
                }
            }
        }
    }
}
