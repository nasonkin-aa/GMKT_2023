using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    private List<BaseEnemy> _allEnemiesOnLvl = new List<BaseEnemy>();
    private int _enemyCount;
    private bool _isAccessPermitted = false;
    private bool _isPlayerOnLeaveZone = false;
    private LeaveZone _leaveZone;

    public int GetCountOfEnemiesAlive()
    {
        return _enemyCount;
    }
    void Start()
    {
        _allEnemiesOnLvl.AddRange(FindObjectsOfType<BaseEnemy>());
        _allEnemiesOnLvl.ForEach(el => el.OnDie.AddListener(OnEnemyDie));
        _enemyCount = _allEnemiesOnLvl.Count;
        _leaveZone = GetComponentInChildren<LeaveZone>();
        if (_leaveZone != null)
        {
            _leaveZone.OnPlayerEnter.AddListener(OnPlayerEnterLeaveZone);
            _leaveZone.OnPlayerExit.AddListener(OnPlayerCameOutLeaveZone);
        }

        if (_enemyCount == 0)
        {
            _isAccessPermitted = true;
        }
    }

    private void OnEnemyDie()
    {
        _enemyCount--;
        if (_enemyCount <= 0)
        {
            if(_isPlayerOnLeaveZone)
                SceneManagers.SceneNext();

            _isAccessPermitted = true;
        }
    }

    private void OnPlayerEnterLeaveZone()
    {
        _isPlayerOnLeaveZone = true;
        if (_isAccessPermitted)
            SceneManagers.SceneNext();
    }

    private void OnPlayerCameOutLeaveZone()
    {
        _isPlayerOnLeaveZone = false;
    }
}
