#if UNITY_5_4_OR_NEWER

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

#if !UniRxLibrary
using ObservableUnity = UniRx.Observable;
#endif

namespace UniRx
{
    using System.Threading;
    using Hash = System.Collections.Generic.Dictionary<string, string>;
    using HashEntry = System.Collections.Generic.KeyValuePair<string, string>;

    public static partial class ObservableWeb
    {
        #region GET
        public static IObservable<UnityWebRequest> GetWWW(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Get(url).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> GetWWW(string url, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Get(url), downloadProgress, null);
        }

        public static IObservable<string> Get(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return GetWWW(url, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Get(string url, IProgress<float> downloadProgress = null)
        {
            return GetWWW(url, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<byte[]> GetAndGetBytes(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return GetWWW(url, headers, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> GetAndGetBytes(string url, IProgress<float> downloadProgress = null)
        {
            return GetWWW(url, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url).SetHeaders(headers);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, uint crc, Hash headers, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url, crc).SetHeaders(headers);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, uint crc, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url, crc);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, uint version, uint crc, Hash headers, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url, version, crc).SetHeaders(headers);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, uint version, uint crc, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url, version, crc);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, Hash128 hash, uint crc, Hash headers, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url, hash, crc).SetHeaders(headers);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, Hash128 hash, uint crc, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url, hash, crc);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

#if UNITY_2017_1_OR_NEWER
        public static IObservable<AssetBundle> GetAssetBundle(string url, CachedAssetBundle cachedAssetBundle, uint crc, Hash headers, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url, cachedAssetBundle, crc).SetHeaders(headers);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, CachedAssetBundle cachedAssetBundle, uint crc, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequest.GetAssetBundle(url, cachedAssetBundle, crc);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAssetBundle)w.downloadHandler).assetBundle);
        }
#endif
        public static IObservable<Texture2D> GetTexture(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
#if UNITY_2017_1_OR_NEWER
            var www = UnityWebRequestTexture.GetTexture(url).SetHeaders(headers);
#else
            var www = UnityWebRequest.GetTexture(url).SetHeaders(headers);
#endif
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerTexture)w.downloadHandler).texture);
        }

        public static IObservable<Texture2D> GetTexture(string url, IProgress<float> downloadProgress = null)
        {
#if UNITY_2017_1_OR_NEWER
            var www = UnityWebRequestTexture.GetTexture(url);
#else
            var www = UnityWebRequest.GetTexture(url);
#endif
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerTexture)w.downloadHandler).texture);
        }

        public static IObservable<AudioClip> GetAudioClip(string url, AudioType type, Hash headers, IProgress<float> downloadProgress = null)
        {
#if UNITY_2017_1_OR_NEWER
            var www = UnityWebRequestMultimedia.GetAudioClip(url, type).SetHeaders(headers);
#else
            var www = UnityWebRequest.GetAudioClip(url, type).SetHeaders(headers);
#endif
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAudioClip)w.downloadHandler).audioClip);
        }

        public static IObservable<AudioClip> GetAudioClip(string url, AudioType type, IProgress<float> downloadProgress = null)
        {
#if UNITY_2017_1_OR_NEWER
            var www = UnityWebRequestMultimedia.GetAudioClip(url, type);
#else
            var www = UnityWebRequest.GetAudioClip(url, type);
#endif
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerAudioClip)w.downloadHandler).audioClip);
        }

#if UNITY_2017_1_OR_NEWER && UNITY_STANDALONE
        public static IObservable<MovieTexture> GetMovieTexture(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequestMultimedia.GetMovieTexture(url).SetHeaders(headers);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerMovieTexture)w.downloadHandler).movieTexture);
        }

        public static IObservable<MovieTexture> GetMovieTexture(string url, IProgress<float> downloadProgress = null)
        {
            var www = UnityWebRequestMultimedia.GetMovieTexture(url);
            return ProceedWebRequest(www, downloadProgress, null).Select(w => ((DownloadHandlerMovieTexture)w.downloadHandler).movieTexture);
        }
#endif
        #endregion GET

        #region POST

        public static IObservable<UnityWebRequest> PostWWW(string url, string postData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Post(url, postData).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PostWWW(string url, string postData, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Post(url, postData), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PostWWW(string url, WWWForm formData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Post(url, formData).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PostWWW(string url, WWWForm formData, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Post(url, formData), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PostWWW(string url, Hash formFields, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Post(url, formFields).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PostWWW(string url, Hash formFields, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Post(url, formFields), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PostWWW(string url, List<IMultipartFormSection> multipartFromSections, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Post(url, multipartFromSections).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PostWWW(string url, List<IMultipartFormSection> multipartFromSections, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Post(url, multipartFromSections), downloadProgress, null);
        }

        public static IObservable<string> Post(string url, string postData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, postData, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Post(string url, string postData, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, postData, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Post(string url, WWWForm formData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, formData, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Post(string url, WWWForm formData, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, formData, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Post(string url, Hash formFields, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, formFields, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Post(string url, Hash formFields, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, formFields, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Post(string url, List<IMultipartFormSection> multipartFromSections, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, multipartFromSections, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Post(string url, List<IMultipartFormSection> multipartFromSections, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, multipartFromSections, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, string postData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, postData, headers, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, string postData, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, postData, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, WWWForm formData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, formData, headers, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, WWWForm formData, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, formData, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, Hash formFields, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, formFields, headers, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, Hash formFields, IProgress<float> downloadProgress = null)
        {
            return PostWWW(url, formFields, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, List<IMultipartFormSection> multipartFromSections, Hash headers, IProgress<float> dowloadProgress = null)
        {
            return PostWWW(url, multipartFromSections, headers, dowloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, List<IMultipartFormSection> multipartFromSections, IProgress<float> dowloadProgress = null)
        {
            return PostWWW(url, multipartFromSections, dowloadProgress).Select(w => w.downloadHandler.data);
        }
        #endregion POST

        #region PUT
        public static IObservable<UnityWebRequest> PutWWW(string url, byte[] bodyData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Put(url, bodyData).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PutWWW(string url, byte[] bodyData, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Put(url, bodyData), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PutWWW(string url, string bodyData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Put(url, bodyData).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> PutWWW(string url, string bodyData, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Put(url, bodyData), downloadProgress, null);
        }

        public static IObservable<string> Put(string url, byte[] bodyData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PutWWW(url, bodyData, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Put(string url, byte[] bodyData, IProgress<float> downloadProgress = null)
        {
            return PutWWW(url, bodyData, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Put(string url, string bodyData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PutWWW(url, bodyData, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Put(string url, string bodyData, IProgress<float> downloadProgress = null)
        {
            return PutWWW(url, bodyData, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<byte[]> PutAndGetBytes(string url, byte[] bodyData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PutWWW(url, bodyData, headers, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PutAndGetBytes(string url, byte[] bodyData, IProgress<float> downloadProgress = null)
        {
            return PutWWW(url, bodyData, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PutAndGetBytes(string url, string bodyData, Hash headers, IProgress<float> downloadProgress = null)
        {
            return PutWWW(url, bodyData, headers, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> PutAndGetBytes(string url, string bodyData, IProgress<float> downloadProgress = null)
        {
            return PutWWW(url, bodyData, downloadProgress).Select(w => w.downloadHandler.data);
        }
        #endregion PUT

        #region HEAD
        public static IObservable<UnityWebRequest> HeadWWW(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Head(url).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<string> Head(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return HeadWWW(url, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<byte[]> HeadAndGetBytes(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return HeadWWW(url, headers, downloadProgress).Select(w => w.downloadHandler.data);
        }
        #endregion HEAD

        #region DELETE
        public static IObservable<UnityWebRequest> DeleteWWW(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Delete(url).SetHeaders(headers), downloadProgress, null);
        }

        public static IObservable<UnityWebRequest> DeleteWWW(string url, IProgress<float> downloadProgress = null)
        {
            return ProceedWebRequest(UnityWebRequest.Delete(url), downloadProgress, null);
        }

        public static IObservable<string> Delete(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return DeleteWWW(url, headers, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<string> Delete(string url, IProgress<float> downloadProgress = null)
        {
            return DeleteWWW(url, null, downloadProgress).Select(w => w.downloadHandler.text);
        }

        public static IObservable<byte[]> DeleteAndGetBytes(string url, Hash headers, IProgress<float> downloadProgress = null)
        {
            return DeleteWWW(url, headers, downloadProgress).Select(w => w.downloadHandler.data);
        }

        public static IObservable<byte[]> DeleteAndGetBytes(string url, IProgress<float> downloadProgress = null)
        {
            return DeleteWWW(url, null, downloadProgress).Select(w => w.downloadHandler.data);
        }
        #endregion DELETE

        static UnityWebRequest SetHeaders(this UnityWebRequest www, Hash headers)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    www.SetRequestHeader(header.Key, header.Value);
                }
            }
            return www;
        }

        public static IObservable<UnityWebRequest> ProceedWebRequest(UnityWebRequest www, IProgress<float> downloadProgress, IProgress<float> uploadProgress)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) => ProceedWebRequestCoroutine(www, observer, uploadProgress, downloadProgress, cancellation));
        }

        static IEnumerator ProceedWebRequestCoroutine(UnityWebRequest www, IObserver<UnityWebRequest> observer, IProgress<float> downloadProgress, IProgress<float> uploadProgress, CancellationToken cancel)
        {
            using (www)
            {
#if UNITY_2017_2_OR_NEWER
                www.SendWebRequest();
#else
                www.Send();
#endif

                while (!www.isDone)
                {
                    if (cancel.IsCancellationRequested)
                    {
                        www.Abort();
                        yield break;
                    }
                    try
                    {
                        if (downloadProgress != null)
                            downloadProgress.Report(www.downloadProgress);
                        if (uploadProgress != null)
                            uploadProgress.Report(www.uploadProgress);
                    }
                    catch (Exception e)
                    {
                        observer.OnError(e);
                        www.Abort();
                        yield break;
                    }
                    yield return null;
                }

                try
                {
                    if (downloadProgress != null)
                        downloadProgress.Report(www.downloadProgress);
                    if (uploadProgress != null)
                        uploadProgress.Report(www.uploadProgress);
                }
                catch (Exception e)
                {
                    observer.OnError(e);
                    www.Abort();
                    yield break;
                }

                if (cancel.IsCancellationRequested)
                {
                    yield break;
                }

                if (!string.IsNullOrEmpty(www.error))
                {
                    observer.OnError(new UnityWebRequestErrorException(www));
                }
                else
                {
                    observer.OnNext(www);
                    observer.OnCompleted();
                }
            }
        }
    }

    public class UnityWebRequestErrorException : Exception
    {
        public string RawErrorMessage { get; private set; }
        public bool HasResponse { get; private set; }
        public string Text { get; private set; }
        public System.Net.HttpStatusCode StatusCode { get; private set; }
        public System.Collections.Generic.Dictionary<string, string> ResponseHeaders { get; private set; }
        public UnityWebRequest WWW { get; private set; }

        // cache the text because if www was disposed, can't access it.
        public UnityWebRequestErrorException(UnityWebRequest www, string text = "")
        {
            this.WWW = www;
            this.RawErrorMessage = www.error;
            this.ResponseHeaders = www.GetResponseHeaders();
            this.HasResponse = false;
            this.Text = text;

            var splitted = RawErrorMessage.Split(' ', ':');
            if (splitted.Length != 0)
            {
                int statusCode;
                if (int.TryParse(splitted[0], out statusCode))
                {
                    this.HasResponse = true;
                    this.StatusCode = (System.Net.HttpStatusCode)statusCode;
                }
            }
        }

        public override string Message
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            var text = this.Text;
            if (string.IsNullOrEmpty(text))
            {
                return RawErrorMessage;
            }
            else
            {
                return RawErrorMessage + " " + text;
            }
        }
    }
}

#endif