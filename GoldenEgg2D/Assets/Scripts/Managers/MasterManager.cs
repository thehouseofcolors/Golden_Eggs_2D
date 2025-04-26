using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class MasterManager
{
    public static GameManager Game => GameManager.Instance;
    public static LevelManager Level => LevelManager.Instance;
    public static ScoreManager Score => ScoreManager.Instance;
    public static PlayUIManager PlayUI=> PlayUIManager.Instance;
    public static AudioManager Audio => AudioManager.Instance;
}
