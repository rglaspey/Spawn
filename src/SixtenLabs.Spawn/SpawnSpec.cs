using System;
using System.Collections.Generic;
using System.Linq;

namespace SixtenLabs.Spawn
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

		public string GetTranslatedChildName(string specName, string childSpecName)
		{
			var definition = FindTypeDefinition(specName);

			if (definition == null)
			{
				throw new InvalidOperationException($"Not allowed to not have a type mapping for: {specName}");
			}
			else
			{
				var childSpec = definition.Children.Where(x => x.SpecName == childSpecName).FirstOrDefault();

				if(childSpec != null)
				{
					return childSpec.TranslatedName;
				}
				else
				{
					throw new InvalidOperationException($"Not allowed to not have a type mapping for: {childSpecName}");
				}
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
				throw new InvalidOperationException($"SpecTypeDefinition for {specTypeDefinition.SpecName} already exists.");
			}
		}

		private XmlFileLoader<T> FileLoader { get; set; }

		/// <summary>
		/// The spectree holds the class that comprise the objects that we are 
		/// generating code for. This is typically created by hand or from an xml specification
		/// and we use this property to query the Specification and setup the structure of the code to generate.
		/// </summary>
		public T SpecTree
		{
			get
			{
				return FileLoader.Registry;
			}
		}

		/// <summary>
		/// Mapping of all types we care about from the spec
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
