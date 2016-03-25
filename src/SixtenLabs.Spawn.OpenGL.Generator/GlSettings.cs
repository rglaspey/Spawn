using SixtenLabs.Spawn.Utility;

namespace SixtenLabs.Spawn.OpenGL.Generator
{
	/// <summary>
	/// The code generation is controlled from this settings class.
	/// </summary>
	public class GlSettings : GeneratorSettings
	{
		public GlSettings()
			: base("Spawn.sln", "SixtenLabs.Spawn.OpenGL.Target", "gl.xml", "https://cvs.khronos.org/svn/repos/ogl/trunk/doc/registry/public/api/gl.xml", "GL_VERSION_4_5")
		{
		}
	}
}
