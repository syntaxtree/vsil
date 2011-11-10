using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SyntaxTree.VisualStudio.IL
{
	internal static class ILContentDefinition
	{
		public const string ILContentType = "IL";

		[Export]
		[Name(ILContentType)]
		[BaseDefinition("code")]
		internal static ContentTypeDefinition ILContentTypeDefinition;

		[Export]
		[FileExtension(".il")]
		[ContentType(ILContentType)]
		internal static FileExtensionToContentTypeDefinition ILFileExtensionDefinition;
	}

	static class ILClassificationDefinitions
	{
		[Export]
		[Name("ILDeclaration")]
		internal static ClassificationTypeDefinition ILDeclaration;
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "ILDeclaration")]
	[UserVisible(true)]
	[Name("ILDeclaration")]
	[Order(After = Priority.Default)]
	sealed class BooPrimitiveFormat : ClassificationFormatDefinition
	{
		public BooPrimitiveFormat()
		{
			DisplayName = "IL - Declaration";
			ForegroundColor = Color.FromArgb(255, 1, 128, 148);
		}
	}
}
