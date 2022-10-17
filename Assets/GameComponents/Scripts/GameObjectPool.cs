using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObjectsContainer;

    [SerializeField]
    private int _gameObjectsCount;

    private List<GameObject> _createdGameObjects;

    private protected void Initialize(GameObject prefab)
    {
        _createdGameObjects = new List<GameObject>(_gameObjectsCount);

        for (int i = 0; i < _gameObjectsCount; i++)
        {
            GameObject createdGameObject = Instantiate(prefab, _gameObjectsContainer.transform);

            createdGameObject.SetActive(false);

            _createdGameObjects.Add(createdGameObject);
        }
    }

    private protected bool TryGetGameObject(out GameObject firstCreatedGameObject)
    {
        firstCreatedGameObject = _createdGameObjects.FirstOrDefault(obj => obj.activeSelf == false);

        return firstCreatedGameObject != null;
    }
}