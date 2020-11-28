using System.IO;
using UnityEngine;

namespace Util
{
    public abstract class Resource<T>
    {
        private static TE LoadData<TE>(string repositoryName)
        {
            // Resources.Load<TextAsset>(repositoryName);
            
            // var sr = new StreamReader(File.OpenRead(repositoryName));
            var data = JsonUtility.FromJson<TE>(Resources.Load<TextAsset>(repositoryName).text);
            // sr.Close();

            return data;
        }
        
        private static T LoadData(string repositoryName)
        {
            return LoadData<T>(repositoryName);
        }

        protected T Get(string repositoryName)
        {
            return LoadData(repositoryName);
        }

        protected TE Get<TE>(string repositoryName)
        {
            return LoadData<TE>(repositoryName);
        }

        protected void Save(string fileName, object data)
        {
            File.WriteAllText(fileName, JsonUtility.ToJson(data));
        }
    }
}