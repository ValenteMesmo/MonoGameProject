using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Collections.Generic;

namespace ConvertJsonToCSharp
{
    public class Program
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Main(string[] args)
        {
            var MainProjectDirectoryPath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MonoGameProject"));
            var SharedContentDirectoryPath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\SharedContent"));

            var imageFiles = new DirectoryInfo(MainProjectDirectoryPath)
                .GetFiles("*.*", SearchOption.AllDirectories)
                .Where(f =>
                    (f.Extension == ".png"
                    || f.Extension == ".bmp")                    
                );

            var jsonFiles = new DirectoryInfo(MainProjectDirectoryPath)
                .GetFiles("*.*", SearchOption.AllDirectories)
                .Where(f =>
                    f.Extension == ".json"
                );

            var wavFiles = new DirectoryInfo(MainProjectDirectoryPath)
              .GetFiles("*.*", SearchOption.AllDirectories)
              .Where(f =>
                  f.Extension == ".wav"
              );

            CreateCSharpFile(SharedContentDirectoryPath, imageFiles, jsonFiles, wavFiles);
        }

        private static string GetFilesNamesAsStringfiedArray(IEnumerable<FileInfo> files)
        {
            var fileNamesArray = "new string[] {";
            foreach (var image in files)
            {
                if (image.Name.StartsWith("Icon"))
                    continue;

                fileNamesArray += $@" ""{Path.GetFileNameWithoutExtension(image.Name)}"",";
            }
            fileNamesArray = fileNamesArray.Remove(fileNamesArray.Length - 1);
            fileNamesArray += " }";
            return fileNamesArray;
        }

        private static void CreateCSharpFile(
            string path,
            IEnumerable<FileInfo> imageFiles,
            IEnumerable<FileInfo> jsonFiles,
            IEnumerable<FileInfo>  wavFiles)
        {
            var fileNamesArray = GetFilesNamesAsStringfiedArray(imageFiles);
            var soundFileNamesArray = GetFilesNamesAsStringfiedArray(wavFiles);

            var methods = "";
            foreach (var file in jsonFiles)
            {
                methods += GetMethodsAsString(file);
            }

            var fileContent = $@"using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class GeneratedContent : ILoadContents
{{  
    private string[] spriteNames = {fileNamesArray};
    private string[] soundNames = {soundFileNamesArray};

    public IEnumerable<string> GetTextureNames()
    {{
        return spriteNames;
    }}

    public IEnumerable<string> GetSoundNames()
    {{
        return soundNames;
    }}
    {methods}
}}
";

            File.WriteAllText(Path.Combine(path, "GeneratedContent.cs"), fileContent);
        }

        private static string GetMethodsAsString(FileInfo file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file.Name);
            var groupedContent = JsonConvert.DeserializeObject<AnimationFramesFile>(File.ReadAllText(file.FullName))
                .frames
                .GroupBy(f => f.filename.Remove(f.filename.Length - 4));

            var methods = "";
            foreach (var group in groupedContent)
            {
                var rectangles = "";
                foreach (var item in group)
                {
                    rectangles += $@"
            new AnimationFrame(""{fileName}"", X, Y, Width ?? {item.frame.w}, Height ?? {item.frame.h}, new Rectangle({item.frame.x}, {item.frame.y}, {item.frame.w}, {item.frame.h})){{ Flipped = Flipped }},";
                }
                rectangles = rectangles.Remove(rectangles.Length - 1);
                methods +=
$@"
    public static Animation Create_{fileName}_{group.Key.Replace(' ', '_')}(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {{
        var animation = new Animation(
            {rectangles}
        );

        return animation;
    }}
";
            }

            return methods;
        }

    }
}