namespace UnityEngine.AddressableAssets
{
    /// <summary>
    /// Adressable AnimatorController
    /// </summary>
    [System.Serializable]
    public class AssetReferenceAnimatorController : AssetReferenceT<RuntimeAnimatorController>
    {
        public AssetReferenceAnimatorController(string guid) : base(guid) {}
    }
}