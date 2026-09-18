using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
namespace MCELoader.CodeGen;

[Generator]
public class BuildQNativeConverters : IIncrementalGenerator
{
    public void Initialize(Microsoft.CodeAnalysis.IncrementalGeneratorInitializationContext context)
    {
        var provider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (node, _) =>
            {
                SyntaxList<AttributeListSyntax> attributes;
                if (node is StructDeclarationSyntax structSyntax)
                    attributes = structSyntax.AttributeLists;
                if (node is ClassDeclarationSyntax classSyntax)
                    attributes = classSyntax.AttributeLists;

                if (attributes == null)
                    return false;

                foreach (var attribute in attributes.Select(static syntax => syntax.Attributes.First()))
                {
                    if (attribute.Name.ToString() == "SourceType")
                        return true;
                }


                return false;
            },
            transform: static (ctx, _) => (TypeDeclarationSyntax)ctx.Node).Where(static m => m is not null);

        var compilation = context.CompilationProvider.Combine(provider.Collect());
        context.RegisterSourceOutput(compilation, Execute);
    }
    public void Execute(SourceProductionContext context, (Compilation comp, ImmutableArray<TypeDeclarationSyntax> syntaxes) tuple)
    {
        var (comp, syntaxes) = tuple;

        string generatedMembers = "";
        foreach (TypeDeclarationSyntax syntax in syntaxes)
        {
            SyntaxList<AttributeListSyntax> attributes;
            SyntaxList<MemberDeclarationSyntax> members;
            SyntaxTree? tree = null;
            if (syntax is StructDeclarationSyntax structDeclaration)
            {
                attributes = syntax.AttributeLists;
                members = syntax.Members;
                tree = syntax.SyntaxTree;
            }

            if (syntax is ClassDeclarationSyntax classDeclaration)
            {
                attributes = syntax.AttributeLists;
                members = syntax.Members;
                tree = syntax.SyntaxTree;
            }
            if (tree == null)
                break;

#pragma warning disable CS8602
            SemanticModel model = comp.GetSemanticModel(tree);
            var declarationSymbol = model.GetDeclaredSymbol(syntax);

            var attribute = declarationSymbol.GetAttributes().First(attr => attr.AttributeClass.ToString() == "MCELoader.Shared.SourceTypeAttribute");
            var originalTypeMetadataName = attribute.ConstructorArguments[0].Value.ToString();
            var originalType = comp.GetTypeByMetadataName(originalTypeMetadataName);
            var proxyType = comp.GetTypeByMetadataName(declarationSymbol.ToString());

            var originalMembers = originalType.GetMembers().Where(member => member.Kind is SymbolKind.Field or SymbolKind.Property);
            var proxyFields = proxyType.GetMembers().Where(member => member.Kind == SymbolKind.Field).Select(field => (IFieldSymbol)field);

            string signature = $"public static {originalTypeMetadataName} ToQNative(this {declarationSymbol.ToString()} proxy)";
            Dictionary<string, ITypeSymbol> originalTypeMap = new();
            foreach (var member in originalMembers) // i spent like 3 hours figuring this out and i dont even remember why
            {
                if (member.Kind == SymbolKind.Property)
                    originalTypeMap[member.Name] = ((IPropertySymbol)member).Type;
                if (member.Kind == SymbolKind.Field)
                    originalTypeMap[member.Name] = ((IFieldSymbol)member).Type;
            }

            string body = "{\n";
            body += $"return new {originalTypeMetadataName}(){{\n";

            foreach (var proxyField in proxyFields) // GENERATION TIME RAHh!!!!
            {
                var originalFieldType = originalTypeMap[proxyField.Name];
                string rightSideAssignment = $"proxy.{proxyField.Name}.ToQNative()";
                if (proxyField.Type.TypeKind == TypeKind.Array)
                    rightSideAssignment = $"proxy.{proxyField.Name}.Select(prox => prox.ToQNative()).ToArray()";
                if (originalFieldType.SpecialType != SpecialType.None)
                    rightSideAssignment = $"proxy.{proxyField.Name}";
                if (proxyField.Type.ToString() is "int[]") // HACK fix
                    rightSideAssignment = $"proxy.{proxyField.Name}";
                if (proxyField.Type.TypeKind == TypeKind.Enum)
                    rightSideAssignment = $"proxy.{proxyField.Name}";

                body += $"{proxyField.Name} = {rightSideAssignment},\n";

                if (true)
                {
                    //                    body += $"#warning {proxyField.ContainingType}::{proxyField.Name} is {originalFieldType} being treated as {proxyField.Type}\n";
                }
            }

            body += @"};
    }
    ";


            generatedMembers += "[System.Runtime.CompilerServices.CompilerGenerated]\n" + signature + body;



        }

        string header = @"
          namespace MCELoader.Extensions;
          [System.Runtime.CompilerServices.CompilerGenerated]
          public static class GeneratedExtensions
          {
          
            ";
        string footer = "\n}";
        context.AddSource("GeneratedExtensions.g.cs", header + generatedMembers + footer);
    }

}
