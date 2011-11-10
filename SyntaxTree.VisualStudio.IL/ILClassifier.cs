using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Mono.Assembler;

namespace SyntaxTree.VisualStudio.IL
{
	internal class ILClassifier : IClassifier
	{
		private readonly IStandardClassificationService _standardClassificationService;

		internal ILClassifier(IStandardClassificationService standardClassificationService)
		{
			_standardClassificationService = standardClassificationService;
		}

		public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
		{
			var result = new List<ClassificationSpan>();
			var lexer = CreateLexerFor(span.GetText());
			var begin = -1;
			var length = -1;
			IClassificationType classification = null;
			var offset = span.Start.Position;
			while (ScanTokenAndProvideInfoAboutIt(lexer, span.GetText(), ref begin, ref length, ref classification))
			{
				try
				{
					result.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, offset + begin, length), classification));
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
					break;
				}
			}
			return result;
		}

		private bool ScanTokenAndProvideInfoAboutIt(ILTokenizer lexer, string span, ref int begin, ref int length,
		                                            ref IClassificationType classification)
		{
			var location = (Location) lexer.Location.Clone();
			var token = lexer.GetNextToken();

			switch (token.TokenId)
			{
				case Token.EOF:
					return false;

				case Token.ID:
					classification = _standardClassificationService.Identifier;
					break;

				case Token.INSTR_NONE:
				case Token.INSTR_VAR:
				case Token.INSTR_I:
				case Token.INSTR_I8:
				case Token.INSTR_R:
				case Token.INSTR_BRTARGET:
				case Token.INSTR_METHOD:
				case Token.INSTR_NEWOBJ:
				case Token.INSTR_FIELD:
				case Token.INSTR_TYPE:
				case Token.INSTR_STRING:
				case Token.INSTR_SIG:
				case Token.INSTR_RVA:
				case Token.INSTR_TOK:
				case Token.INSTR_SWITCH:
				case Token.INSTR_PHI:
				case Token.INSTR_LOCAL:
				case Token.INSTR_PARAM:
					classification = _standardClassificationService.Keyword;
					break;

				case Token.K_AT:
				case Token.K_AS:
				case Token.K_IMPLICITCOM:
				case Token.K_IMPLICITRES:
				case Token.K_NOAPPDOMAIN:
				case Token.K_NOPROCESS:
				case Token.K_NOMACHINE:
				case Token.K_EXTERN:
				case Token.K_INSTANCE:
				case Token.K_EXPLICIT:
				case Token.K_DEFAULT:
				case Token.K_VARARG:
				case Token.K_UNMANAGED:
				case Token.K_CDECL:
				case Token.K_STDCALL:
				case Token.K_THISCALL:
				case Token.K_FASTCALL:
				case Token.K_MARSHAL:
				case Token.K_IN:
				case Token.K_OUT:
				case Token.K_OPT:
				case Token.K_STATIC:
				case Token.K_PUBLIC:
				case Token.K_PRIVATE:
				case Token.K_FAMILY:
				case Token.K_INITONLY:
				case Token.K_RTSPECIALNAME:
				case Token.K_STRICT:
				case Token.K_SPECIALNAME:
				case Token.K_ASSEMBLY:
				case Token.K_FAMANDASSEM:
				case Token.K_FAMORASSEM:
				case Token.K_PRIVATESCOPE:
				case Token.K_LITERAL:
				case Token.K_NOTSERIALIZED:
				case Token.K_VALUE:
				case Token.K_NOT_IN_GC_HEAP:
				case Token.K_INTERFACE:
				case Token.K_SEALED:
				case Token.K_ABSTRACT:
				case Token.K_AUTO:
				case Token.K_SEQUENTIAL:
				case Token.K_ANSI:
				case Token.K_UNICODE:
				case Token.K_AUTOCHAR:
				case Token.K_BESTFIT:
				case Token.K_IMPORT:
				case Token.K_SERIALIZABLE:
				case Token.K_NESTED:
				case Token.K_LATEINIT:
				case Token.K_EXTENDS:
				case Token.K_IMPLEMENTS:
				case Token.K_FINAL:
				case Token.K_VIRTUAL:
				case Token.K_HIDEBYSIG:
				case Token.K_NEWSLOT:
				case Token.K_UNMANAGEDEXP:
				case Token.K_PINVOKEIMPL:
				case Token.K_NOMANGLE:
				case Token.K_OLE:
				case Token.K_LASTERR:
				case Token.K_WINAPI:
				case Token.K_NATIVE:
				case Token.K_IL:
				case Token.K_CIL:
				case Token.K_OPTIL:
				case Token.K_MANAGED:
				case Token.K_FORWARDREF:
				case Token.K_RUNTIME:
				case Token.K_INTERNALCALL:
				case Token.K_SYNCHRONIZED:
				case Token.K_NOINLINING:
				case Token.K_CUSTOM:
				case Token.K_FIXED:
				case Token.K_SYSSTRING:
				case Token.K_ARRAY:
				case Token.K_VARIANT:
				case Token.K_CURRENCY:
				case Token.K_SYSCHAR:
				case Token.K_VOID:
				case Token.K_BOOL:
				case Token.K_INT8:
				case Token.K_INT16:
				case Token.K_INT32:
				case Token.K_INT64:
				case Token.K_FLOAT32:
				case Token.K_FLOAT64:
				case Token.K_ERROR:
				case Token.K_UNSIGNED:
				case Token.K_UINT:
				case Token.K_UINT8:
				case Token.K_UINT16:
				case Token.K_UINT32:
				case Token.K_UINT64:
				case Token.K_DECIMAL:
				case Token.K_DATE:
				case Token.K_BSTR:
				case Token.K_LPSTR:
				case Token.K_LPWSTR:
				case Token.K_LPTSTR:
				case Token.K_OBJECTREF:
				case Token.K_IUNKNOWN:
				case Token.K_IDISPATCH:
				case Token.K_STRUCT:
				case Token.K_SAFEARRAY:
				case Token.K_INT:
				case Token.K_BYVALSTR:
				case Token.K_TBSTR:
				case Token.K_LPVOID:
				case Token.K_ANY:
				case Token.K_FLOAT:
				case Token.K_LPSTRUCT:
				case Token.K_NULL:
				case Token.K_PTR:
				case Token.K_VECTOR:
				case Token.K_HRESULT:
				case Token.K_CARRAY:
				case Token.K_USERDEFINED:
				case Token.K_RECORD:
				case Token.K_FILETIME:
				case Token.K_BLOB:
				case Token.K_STREAM:
				case Token.K_STORAGE:
				case Token.K_STREAMED_OBJECT:
				case Token.K_STORED_OBJECT:
				case Token.K_BLOB_OBJECT:
				case Token.K_CF:
				case Token.K_CLSID:
				case Token.K_METHOD:
				case Token.K_CLASS:
				case Token.K_PINNED:
				case Token.K_MODREQ:
				case Token.K_MODOPT:
				case Token.K_TYPEDREF:
				case Token.K_TYPE:
				case Token.K_WCHAR:
				case Token.K_CHAR:
				case Token.K_FROMUNMANAGED:
				case Token.K_CALLMOSTDERIVED:
				case Token.K_BYTEARRAY:
				case Token.K_WITH:
				case Token.K_INIT:
				case Token.K_TO:
				case Token.K_CATCH:
				case Token.K_FILTER:
				case Token.K_FINALLY:
				case Token.K_FAULT:
				case Token.K_HANDLER:
				case Token.K_TLS:
				case Token.K_FIELD:
				case Token.K_PROPERTY:
				case Token.K_REQUEST:
				case Token.K_DEMAND:
				case Token.K_ASSERT:
				case Token.K_DENY:
				case Token.K_PERMITONLY:
				case Token.K_LINKCHECK:
				case Token.K_INHERITCHECK:
				case Token.K_REQMIN:
				case Token.K_REQOPT:
				case Token.K_REQREFUSE:
				case Token.K_PREJITGRANT:
				case Token.K_PREJITDENY:
				case Token.K_NONCASDEMAND:
				case Token.K_NONCASLINKDEMAND:
				case Token.K_NONCASINHERITANCE:
				case Token.K_READONLY:
				case Token.K_NOMETADATA:
				case Token.K_ALGORITHM:
				case Token.K_FULLORIGIN:
				case Token.K_ENABLEJITTRACKING:
				case Token.K_DISABLEJITOPTIMIZER:
				case Token.K_RETARGETABLE:
				case Token.K_PRESERVESIG:
				case Token.K_BEFOREFIELDINIT:
				case Token.K_ALIGNMENT:
				case Token.K_NULLREF:
				case Token.K_VALUETYPE:
				case Token.K_COMPILERCONTROLLED:
				case Token.K_REQSECOBJ:
				case Token.K_ENUM:
				case Token.K_OBJECT:
				case Token.K_STRING:
				case Token.K_TRUE:
				case Token.K_FALSE:
				case Token.K_IS:
				case Token.K_ON:
				case Token.K_OFF:
				case Token.K_CHARMAPERROR:
					classification = _standardClassificationService.Keyword;
					break;

				case Token.D_ADDON:
				case Token.D_ALGORITHM:
				case Token.D_ASSEMBLY:
				case Token.D_BACKING:
				case Token.D_BLOB:
				case Token.D_CAPABILITY:
				case Token.D_CCTOR:
				case Token.D_CLASS:
				case Token.D_COMTYPE:
				case Token.D_CONFIG:
				case Token.D_IMAGEBASE:
				case Token.D_CORFLAGS:
				case Token.D_CTOR:
				case Token.D_CUSTOM:
				case Token.D_DATA:
				case Token.D_EMITBYTE:
				case Token.D_ENTRYPOINT:
				case Token.D_EVENT:
				case Token.D_EXELOC:
				case Token.D_EXPORT:
				case Token.D_FIELD:
				case Token.D_FILE:
				case Token.D_FIRE:
				case Token.D_GET:
				case Token.D_HASH:
				case Token.D_IMPLICITCOM:
				case Token.D_LANGUAGE:
				case Token.D_LINE:
				case Token.D_XLINE:
				case Token.D_LOCALE:
				case Token.D_LOCALS:
				case Token.D_MANIFESTRES:
				case Token.D_MAXSTACK:
				case Token.D_METHOD:
				case Token.D_MIME:
				case Token.D_MODULE:
				case Token.D_MRESOURCE:
				case Token.D_NAMESPACE:
				case Token.D_ORIGINATOR:
				case Token.D_OS:
				case Token.D_OTHER:
				case Token.D_OVERRIDE:
				case Token.D_PACK:
				case Token.D_PARAM:
				case Token.D_PERMISSION:
				case Token.D_PERMISSIONSET:
				case Token.D_PROCESSOR:
				case Token.D_PROPERTY:
				case Token.D_PUBLICKEY:
				case Token.D_PUBLICKEYTOKEN:
				case Token.D_REMOVEON:
				case Token.D_SET:
				case Token.D_SIZE:
				case Token.D_STACKRESERVE:
				case Token.D_SUBSYSTEM:
				case Token.D_TITLE:
				case Token.D_TRY:
				case Token.D_VER:
				case Token.D_VTABLE:
				case Token.D_VTENTRY:
				case Token.D_VTFIXUP:
				case Token.D_ZEROINIT:
					classification = _standardClassificationService.Keyword;
					break;

				case Token.INT32:
				case Token.INT64:
				case Token.FLOAT64:
					classification = _standardClassificationService.NumberLiteral;
					break;

				case Token.QSTRING:
				case Token.SQSTRING:
					classification = _standardClassificationService.StringLiteral;
					break;

				case Token.SL_COMMENT:
					classification = _standardClassificationService.Comment;
					break;

				case Token.ML_COMMENT:
					classification = _standardClassificationService.Comment;
					return true;

				default:
					classification = _standardClassificationService.FormalLanguage;
					break;
			}

			ComputeTokenInfo(span, location, lexer.Location, out begin, out length);
			return true;
		}

		private void ComputeTokenInfo(string span, Location location, Location nextLocation, out int begin, out int length)
		{
			begin = location.column - 1;

			if (location.line == nextLocation.line && nextLocation.column != 0)
			{
				length = nextLocation.column - 1 - begin;
				span = span.Substring(begin, length);
			}
			else
				span = span.Substring(begin);


			var untrimmedLength = span.Length;
			span = span.TrimStart();

			var spanLength = span.Length;
			begin += untrimmedLength - spanLength;
			length = spanLength;
		}

		private ILTokenizer CreateLexerFor(string text)
		{
			return new ILTokenizer(new StreamReader(StreamFor(text)));
		}

		private static MemoryStream StreamFor(string text)
		{
			var stream = new MemoryStream();
			var bytes = Encoding.UTF8.GetBytes(text);
			stream.Write(bytes, 0, bytes.Length);
			stream.Position = 0;
			return stream;
		}

		public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
	}
}