using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WorldTelecomFinal.Helpers
{
    public class FileHelper
    {
        public static void DeleteFile(IWebHostEnvironment env, string filename, params string[] folders)
        {
            string path = Path.Combine(env.WebRootPath);

            foreach (string folder in folders)
            {
                path = Path.Combine(path, folder);
            }

            path = Path.Combine(path, filename);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
