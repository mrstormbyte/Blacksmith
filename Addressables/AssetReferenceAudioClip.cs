namespace UnityEngine.AddressableAssets
{
    /// <summary>
    /// Adressable AudioClip
    /// </summary>
    [System.Serializable]
    public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
    {
        public AssetReferenceAudioClip(string guid) : base(guid) {}
    }
}