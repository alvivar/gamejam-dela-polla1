using System.Collections;
using UnityEngine;
namespace GeNa.Core
{
    /// <summary>
    /// Decorator for modifying Bounds of Object when Spawning
    /// </summary>
    public class GeNaBoundsDecorator : MonoBehaviour, IDecorator
    {
        //BoundsModifier = Worker
        [SerializeField] protected BoundsModifier m_boundsModifier = new BoundsModifier();
        public BoundsModifier BoundsModifier => m_boundsModifier;
        public bool UnpackPrefab => false;
        public void OnIngest(Resource resource)
        {
            resource.AddColliderToAabb = false;
        }
        public IEnumerator OnSelfSpawned(Resource resource)
        {
            AabbManager aabbManager = GeNaManager.Instance.AabbManager;
            AabbObject aabbObject = BoundsModifier?.GetAabbObject(transform.position, transform.rotation);
            if (aabbObject != null)
                aabbManager.AddAabbObject(aabbObject);
            yield break;
        }
        public void OnChildrenSpawned(Resource resource)
        {
            GeNaEvents.Destroy(this);
        }
    }
}