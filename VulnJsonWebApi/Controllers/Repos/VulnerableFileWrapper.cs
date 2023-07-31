using System.Runtime.Serialization;
using System.Security.Permissions;

namespace VulnJsonWebApi.Controllers
{
    public class VulnerableFileWrapper
    {
        public VulnerableFileWrapper() { }

        private string fullPath = string.Empty;
        public string Name
        {
            get
            {
                return fullPath;
            }
            set
            {
                fullPath = $"{Directory.GetCurrentDirectory()}\\{value}";
            }
        }

        private string content = string.Empty;
        public string Content
        {
            get { return content; }
            set 
            { 
                content  = value;
                if (!string.IsNullOrEmpty(fullPath)){
                    SaveContent();
                }
            }
        }

        public void SaveContent()
        {
            var rawContent = Convert.FromBase64String(content);
            var path = fullPath;

            File.WriteAllBytes(path, rawContent);
        }
    }

    [Serializable]
    public class OtherBadConstructs : ISerializable
    {
        public OtherBadConstructs()
        {

        }

        protected OtherBadConstructs(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetString("Name");
            this.Content = info.GetString("Content");
            SaveContent();
        }

        //[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Content", this.Content);
        }

        private string fullPath = string.Empty;

        public string Name
        {
            get
            {
                return fullPath;
            }
            set
            {
                fullPath = $"{Directory.GetCurrentDirectory()}\\{value}";
            }
        }

        private string content = string.Empty;
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
            }
        }

        public void SaveContent()
        {
            var rawContent = Convert.FromBase64String(content);
            var path = fullPath;

            File.WriteAllBytes(path, rawContent);
        }
    }
}