using System;
using System.Collections.Generic;
using System.Linq;

namespace SixtenLabs.Spawn.Utility
{
	public abstract class SpawnSpec<T> : ISpawnSpec<T> where T : class
	{
		public SpawnSpec(XmlFileLoader<T> xmlFileLoader)
		{
			FileLoader = xmlFileLoader;
		}

		public void ProcessRegistry()
		{
			FileLoader.LoadRegistry();
		}

		public string GetTranslatedName(string specName)
		{
			var definition = FindTypeDefinition(specName);

			if (definition == null)
			{
				throw new InvalidOperationException($"Not allowed to not have a type mapping for: {specName}");
			}
			else
			{
				return definition.TranslatedName;
			}
		}

		public SpecTypeDefinition FindTypeDefinition(string specName)
		{
			return AllSpecTypeDefinitions.Where(x => x.SpecName == specName).FirstOrDefault();
		}

		public void AddSpecTypeDefinition(SpecTypeDefinition specTypeDefinition)
		{
			var alreadyExists = AllSpecTypeDefinitions.Contains(specTypeDefinition);

			if (!alreadyExists)
			{
				AllSpecTypeDefinitions.Add(specTypeDefinition);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public void AddSpecType(string specName, string translatedName)
		{
			var specType = new SpecTypeDefinition() { SpecName = specName, TranslatedName = translatedName };

			var alreadyExists = AllSpecTypeDefinitions.Contains(specType);

			if (!alreadyExists)
			{
				AllSpecTypeDefinitions.Add(specType);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		private XmlFileLoader<T> FileLoader { get; set; }

		public T SpecTree
		{
			get
			{
				return FileLoader.Registry;
			}
		}

		/// <summary>
		/// Mapping of all types we care about from the vk.xml
		/// Key = Spec type name
		/// Value = Translated type name
		/// </summary>
		private IList<SpecTypeDefinition> AllSpecTypeDefinitions { get; } = new List<SpecTypeDefinition>();

		public int SpecTypeCount
		{
			get
			{
				return AllSpecTypeDefinitions.Count;
			}
		}
	}
}
