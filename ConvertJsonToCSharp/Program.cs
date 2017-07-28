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
            var SharedContentDirectoryPath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MonoGameProject"));

            var imageFiles = new DirectoryInfo(SharedContentDirectoryPath)
                .GetFiles("*.*", SearchOption.AllDirectories)
                .Where(f =>
                    (f.Extension == ".png"
                    || f.Extension == ".bmp")                    
                );

            var jsonFiles = new DirectoryInfo(SharedContentDirectoryPath)
                .GetFiles("*.*", SearchOption.AllDirectories)
                .Where(f =>
                    f.Extension == ".json"
                );

            CreateCSharpFile(SharedContentDirectoryPath, imageFiles, jsonFiles);
        }

        private static void CreateCSharpFile(
            string path,
            IEnumerable<FileInfo> imageFiles,
            IEnumerable<FileInfo> jsonFiles)
        {
            var fileNamesArray = "new string[] {";
            foreach (var image in imageFiles)
            {
                if (image.Name.StartsWith("Icon"))
                    continue;

                fileNamesArray += $@" ""{Path.GetFileNameWithoutExtension(image.Name)}"",";
            }
            fileNamesArray = fileNamesArray.Remove(fileNamesArray.Length - 1);
            fileNamesArray += " }";


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
    private string[] soundNames = new string[]{{}};

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
            new AnimationFrame(""{fileName}"", X, Y, Width, Height, new Rectangle({item.frame.x}+10, {item.frame.y}+10, {item.frame.w}-20, {item.frame.h}-20)){{ RenderingLayer = Z, Flipped = Flipped }},";
                }
                rectangles = rectangles.Remove(rectangles.Length - 1);
                methods +=
$@"
    public static Animation Create_{fileName}_{group.Key.Replace(' ', '_')}(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
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
