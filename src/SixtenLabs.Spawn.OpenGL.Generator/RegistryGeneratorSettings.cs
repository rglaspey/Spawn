using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.OpenGL.Generator
{
  /// <summary>
  /// The code generation is controlled from this settings class.
  /// </summary>
  public class RegistryGeneratorSettings
  {
    public RegistryGeneratorSettings()
    {
      SetRootDirectory();
    }

    private void SetRootDirectory()
    {
      DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

      while(directory != null && !File.Exists(Path.Combine(directory.FullName, "OpenNetGL.sln")))
      {
        directory = directory.Parent;

        if(directory != null)
        {
          RootDirectory = directory.FullName;
        }
      }
    }

    public RegistryLoadMethod LoadMethod { get; set; } = RegistryLoadMethod.FromFile;

    public string FileName { get; set; } = "gl.xml";

    public string WebUri { get; set; } = @"https://cvs.khronos.org/svn/repos/ogl/trunk/doc/registry/public/api/gl.xml";

    public string RootDirectory { get; set; }

    public string TargetGlDirectory { get; set; }

    public string TargetGlesDirectory { get; set; }

    public string RootNameSpace { get; set; }

    public OpenGlVersion VersionToGenerate { get; set; } = OpenGlVersion.GL_VERSION_4_5;
  }
}
