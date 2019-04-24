using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJockey_v4
{
    public static class JockeyUtilities
    {
        public static int GetBPMdeltaTime(int _bpm)
        {
            return Mathf.RoundToInt(_bpm * Time.deltaTime * 60f);
        }

        public static GameObject FindAssetByName(GameObject[] _list, string _name)
        {
            GameObject _returnGameObject = null;

            foreach(var _gameObject in _list)
            {
                if (_gameObject.name == _name)
                    _returnGameObject = _gameObject;
            }

            return _returnGameObject;
        }
    }
}
