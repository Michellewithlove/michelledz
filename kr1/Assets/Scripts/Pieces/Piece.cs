using System.Collections.Generic;
using UnityEngine;

public enum PieceType {King, Queen, Bishop, Knight, Rook, Pawn};

public abstract class Piece : MonoBehaviour
{
    public PieceType type;

    protected Vector2Int[] RookDirections = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};
    protected Vector2Int[] BishopDirections = {Vector2Int.right + Vector2Int.up, Vector2Int.right + Vector2Int.down, Vector2Int.left + Vector2Int.down, Vector2Int.left + Vector2Int.up};

    public abstract List<Vector2Int> MoveLocations(Vector2Int gridPoint);
}
