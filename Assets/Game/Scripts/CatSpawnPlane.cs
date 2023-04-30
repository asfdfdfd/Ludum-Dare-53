using UnityEngine;
using DG.Tweening;

public class CatSpawnPlane : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCat;
    
    private void OnCollisionEnter(Collision other)
    {
        var gameObject = other.gameObject;
        var rhythmItemController = gameObject.GetComponent<RhythmItemController>();
        if (rhythmItemController != null && rhythmItemController.IsFakeCat)
        {
            var catPosition = gameObject.transform.position;
            catPosition.y = 30.0f;
            
            GameObject gameObjectCat = Instantiate(_prefabCat, catPosition, gameObject.transform.rotation);

            gameObjectCat.transform.DOMoveY(gameObject.transform.position.y, 0.3f).OnComplete(() =>
            {
                gameObject.transform.DOMoveY(-30, 0.3f).OnComplete(() =>
                {
                    Destroy(gameObject); 
                });
            });
        }
    }
}
