using UnityEngine;

public class TileCell : MonoBehaviour
{
    private GridManager _grid;
    private Vector2Int _pos;
    private Renderer _rend;
    public Vector2Int GridPos => _pos;
    
    public void Init(GridManager owner, Vector2Int pos)
    {
        _grid = owner;
        _pos = pos;
        _rend = GetComponent<Renderer>();
        SetColor(Color.white);
    }
    
    public void SetColor(Color color)
    {
        if (!_rend) _rend = GetComponent<Renderer>();
        if (_rend && _rend.material) _rend.material.color = color;
    }
}