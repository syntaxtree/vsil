using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SyntaxTree.VisualStudio.IL
{
	[Export(typeof(IClassifierProvider))]
	[ContentType(ILContentDefinition.ILContentType)]
	class ILClassifierProvider : IClassifierProvider
	{
		[Import]
		internal IStandardClassificationService StandardClassificationService;

		//[Import]
		//internal IClassificationTypeRegistryService ClassificationRegistry;

		public IClassifier GetClassifier(ITextBuffer buffer)
		{
			return buffer.Properties.GetOrCreateSingletonProperty(() => new ILClassifier(StandardClassificationService));
		}
	}
}
