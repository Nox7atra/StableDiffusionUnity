using System;
using System.Collections;
using System.Text;
using DevGame.Utility;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace DevGame.StableDiffusion
{
    public class SDProcessor : MonoBehaviour
    {
        [SerializeField] private string _rootEndpoint = "http://localhost:7860";
    
        public IEnumerator ImageToImageAsync(ImgToImgConfig config, Action<Texture2D[]> OnSuccess)
        {
            var url = $"{_rootEndpoint}/sdapi/v1/img2img";
            var payload = JsonConvert.SerializeObject(config, Formatting.Indented);
            Debug.Log($"Try send request {url}");
            using (var request = new UnityWebRequest(url, "POST"))
            {
                request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(payload));
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("accept", "application/json");
                request.SetRequestHeader("Content-Type", "application/json");
          
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Success!");
                    var response = JsonConvert.DeserializeObject<ImgToImgResponse>(request.downloadHandler.text);
                    var textures = new Texture2D[response.images.Length];
                    for (int i = 0; i < textures.Length; i++)
                    {
                        textures[i] = response.images[i].Base64ToTexture2D(config.width, config.height);
                    }
                    OnSuccess?.Invoke(textures);
                }
                else
                {
                    Debug.LogError(request.error);
                    Debug.LogError(request.downloadHandler.text);
                }
            }
        }
        
        public IEnumerator TextToImageAsync(SDConfig config, Action<Texture2D[]> OnSuccess)
        {
            var url = $"{_rootEndpoint}/sdapi/v1/txt2img";
            var payload = JsonConvert.SerializeObject(config, Formatting.Indented);
            Debug.Log($"Try send request {url}");
            using (var request = new UnityWebRequest(url, "POST"))
            {
                request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(payload));
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("accept", "application/json");
                request.SetRequestHeader("Content-Type", "application/json");
          
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Success!");
                    var response = JsonConvert.DeserializeObject<ImgToImgResponse>(request.downloadHandler.text);
                    var textures = new Texture2D[response.images.Length];
                    for (int i = 0; i < textures.Length; i++)
                    {
                        textures[i] = response.images[i].Base64ToTexture2D(config.width, config.height);
                    }
                    OnSuccess?.Invoke(textures);
                }
                else
                {
                    Debug.LogError(request.error);
                    Debug.LogError(request.downloadHandler.text);
                }
            }
        }
    }

}
