using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.Video;
using UnityEngine.Audio;

namespace HISTORY
{
    public class HistoryCache
    {
        public static Dictionary<string, (object asset, int staleIndex)> loadedAsset = new Dictionary<string, (object asset, int staleIndex)>();

        public static T TryLoadObject<T>(string key)
        {
            object resource  = null;
            
            if(loadedAsset.ContainsKey(key))
                resource = (T)loadedAsset[key].asset;
            else
            {
                resource = Resources.Load(key);
                if (resource != null)
                {
                    loadedAsset[key] = (resource, 0);
                }
            }

            if (resource != null)
            {
                if (resource is T)
                    return (T)resource;
                else
                    Debug.LogWarning($"Retrieved object '{key}' wasnot the expected type!");
            }

            Debug.LogWarning($"Could not load object form cache '{key}'");
            return default (T);
        }

        public static TMP_FontAsset LoadFont(string key) => TryLoadObject<TMP_FontAsset>(key);
        public static AudioClip LoadAudio(string key) => TryLoadObject<AudioClip>(key);
        public static Texture2D LoadImage(string key) => TryLoadObject<Texture2D>(key);
        public static VideoClip LoadVideo(string key) => TryLoadObject<VideoClip>(key);
    }

}
