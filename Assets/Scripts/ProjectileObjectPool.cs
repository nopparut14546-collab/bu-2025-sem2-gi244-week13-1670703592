using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int initialPoolSize = 10;

    private readonly List<GameObject> projectilePool = new();

    private void Awake()
    {

    }

    //private IEnumerator Start()
    //{
    //    for (int i = 0; i < initialPoolSize; i++)
    //    {
    //        CreateNewProjectile();
    //        if (i % 20 == 0)
    //        {
    //            yield return null;
    //        }
    //    }
    //}

    private void CreateNewProjectile()
    {
        var go = Instantiate(projectilePrefab);
        go.SetActive(false);
        projectilePool.Add(go);
    }

    public GameObject Acquire()
    {
        if (projectilePool.Count == 0)
        {
            CreateNewProjectile();
        }

        var go = projectilePool[0];
        projectilePool.RemoveAt(0);
        return null;
    }

    public void Return(GameObject projectile)
    {
        projectilePool.Add(projectile);
        projectile.SetActive(false);
    }
}
