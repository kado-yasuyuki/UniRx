#if UNITY_5_4_OR_NEWER

using System;
using UnityEngine.Networking;

namespace UniRx
{
    using Hash = System.Collections.Generic.Dictionary<string, string>;

    public static partial class ObservableWeb
    {
        static string contentTypeJson = "application/json; charset=UTF-8";

        static IObservable<string> JsonWWW(string url, string method, string json, Hash headers, IProgress<float> downloadProgress = null)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            var uploadHandler = new UploadHandlerRaw(bytes);
            uploadHandler.contentType = contentTypeJson;
            var www = new UnityWebRequest(url, method, new DownloadHandlerBuffer(), uploadHandler);
            return ProceedWebRequest(www.SetHeaders(headers), downloadProgress, null).Select(w => w.downloadHandler.text);
        }

        static IObservable<byte[]> JsonWWW(string url, string method, byte[] json, Hash headers, IProgress<float> downloadProgress = null)
        {
            var uploadHandler = new UploadHandlerRaw(json);
            uploadHandler.contentType = contentTypeJson;
            var www = new UnityWebRequest(url, method, new DownloadHandlerBuffer(), uploadHandler);
            return ProceedWebRequest(www.SetHeaders(headers), downloadProgress, null).Select(w => w.downloadHandler.data);
        }

        #region POST

        public static IObservable<string> PostJson(string url, string json, Hash headers, IProgress<float> downloadProgress = null)
        {
            return JsonWWW(url, UnityWebRequest.kHttpVerbPOST, json, headers, downloadProgress);
        }

        public static IObservable<string> PostJson(string url, string json, IProgress<float> downloadProgress = null)
        {
            return JsonWWW(url, UnityWebRequest.kHttpVerbPOST, json, null, downloadProgress);
        }

        public static IObservable<byte[]> PostJson(string url, byte[] json, Hash headers, IProgress<float> downloadProgress = null)
        {
            return JsonWWW(url, UnityWebRequest.kHttpVerbPOST, json, headers, downloadProgress);
        }

        public static IObservable<byte[]> PostJson(string url, byte[] json, IProgress<float> downloadProgress = null)
        {
            return JsonWWW(url, UnityWebRequest.kHttpVerbPOST, json, null, downloadProgress);
        }

        #endregion POST

        #region PUT

        public static IObservable<string> PutJson(string url, string json, Hash headers, IProgress<float> downloadProgress = null)
        {
            return JsonWWW(url, UnityWebRequest.kHttpVerbPUT, json, headers, downloadProgress);
        }

        public static IObservable<string> PutJson(string url, string json, IProgress<float> downloadProgress = null)
        {
            return JsonWWW(url, UnityWebRequest.kHttpVerbPUT, json, null, downloadProgress);
        }

        public static IObservable<byte[]> PutJson(string url, byte[] json, Hash headers, IProgress<float> downloadProgress = null)
        {
            return JsonWWW(url, UnityWebRequest.kHttpVerbPUT, json, headers, downloadProgress);
        }

        public static IObservable<byte[]> PutJson(string url, byte[] json, IProgress<float> downloadProgress = null)
        {
            return JsonWWW(url, UnityWebRequest.kHttpVerbPUT, json, null, downloadProgress);
        }

        #endregion PUT
    }
}
#endif