
using UnityEngine;

[CreateAssetMenu(fileName ="GameData", menuName ="Game Data", order = 1)]
public class GameData: ScriptableObject
{
    [SerializeField]
    private Vector3 _parentChickenPos = new Vector3(0, 3, 0);
    [SerializeField]
    private Vector3 _playerPos = new Vector3(0, -4, 0);
    [SerializeField]
    private int _playTimeDuration = 10;
    [SerializeField]
    private int _playerHealthStart = 3;

    // Read-only properties
    public Vector3 ParentChickenPos => _parentChickenPos;
    public Vector3 PlayerPos => _playerPos;
    public int PlayTimeDuration => _playTimeDuration;
    public int PlayerHealthStart => _playerHealthStart;

    // Properties with both getter and setter
    [SerializeField]
    private int _currentLevel = 1;
    public int CurrentLevel
    {
        get { return _currentLevel; }
        set { _currentLevel = value; }
    }

    [SerializeField]
    private int _currentScore = 0;
    public int CurrentScore
    {
        get { return _currentScore; }
        set { _currentScore = value; }
    }


}
