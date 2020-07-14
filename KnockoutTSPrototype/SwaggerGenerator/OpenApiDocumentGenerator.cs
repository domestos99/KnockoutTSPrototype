using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NJsonSchema;
using NJsonSchema.Generation;
using NJsonSchema.Infrastructure;
using NSwag;
using NSwag.AssemblyLoader;
using NSwag.AssemblyLoader.Utilities;

namespace SwaggerGenerator
{
    public class OpenApiDocumentGenerator
    {
        public static OpenApiDocument GetOpenApiDocument(JsonSchemaGeneratorSettings settings, params string[] assemblyDllPaths)
        {
            string currentDirectory = DynamicApis.DirectoryGetCurrentDirectory();

            Assembly[] assemblies = PathUtilities.ExpandFileWildcards(assemblyDllPaths)
                .Select(path => Assembly.LoadFrom(PathUtilities.MakeAbsolutePath(path, currentDirectory))).ToArray();
            return GetOpenApiDocument(settings, assemblies);
        }

        public static OpenApiDocument GetOpenApiDocument(JsonSchemaGeneratorSettings settings, params Assembly[] assemblies)
        {
            List<string> allExportedClassNames =
                           assemblies.SelectMany(a => a.ExportedTypes)
                           .Select(t => t.FullName).ToList();
            return GetOpenApiDocument(settings, assemblies, allExportedClassNames);
        }

        private static OpenApiDocument GetOpenApiDocument(JsonSchemaGeneratorSettings settings, Assembly[] assemblies, List<string> classNames)
        {
            var document = new OpenApiDocument();
            var generator = new JsonSchemaGenerator(settings);
            var schemaResolver = new OpenApiSchemaResolver(document, settings);

            //IEnumerable<string> matchedClassNames = ClassNames
            //    .SelectMany(n => PathUtilities.FindWildcardMatches(n, allExportedClassNames, '.'))
            //    .Distinct();

            foreach (var className in classNames)
            {
                var type = assemblies.Select(a => a.GetType(className)).FirstOrDefault(t => t != null);
                generator.Generate(type, schemaResolver);
            }

            //SchemaType outputType = SchemaType.Swagger2;
            //return document.ToJson(outputType);

            return document;
        }


        public static List<OpenApiDocument> GetOpenApiDocumentSepareted(JsonSchemaGeneratorSettings settings, params Assembly[] assemblies)
        {
            List<string> allExportedClassNames =
                assemblies.SelectMany(a => a.ExportedTypes)
                    .Select(t => t.FullName).ToList();
            return GetOpenApiDocumentSepareted(settings, assemblies, allExportedClassNames);
        }

        private static List<OpenApiDocument> GetOpenApiDocumentSepareted(JsonSchemaGeneratorSettings settings, Assembly[] assemblies, List<string> classNames)
        {
            List<OpenApiDocument> result = new List<OpenApiDocument>();

            foreach (var className in classNames)
            {
                var document = new OpenApiDocument();
                var generator = new JsonSchemaGenerator(settings);
                var schemaResolver = new OpenApiSchemaResolver(document, settings);
                var type = assemblies.Select(a => a.GetType(className)).FirstOrDefault(t => t != null);
                generator.Generate(type, schemaResolver);
                result.Add(document);
            }

            return result;
        }


        public static string GetSwaggerJson(JsonSchemaGeneratorSettings settings, params string[] assemblyPaths)
        {
            return GetOpenApiDocument(settings, assemblyPaths).ToJson(SchemaType.Swagger2);
        }

        public static string GetSwaggerJson(JsonSchemaGeneratorSettings settings, params Assembly[] assemblies)
        {
            return GetOpenApiDocument(settings, assemblies).ToJson(SchemaType.Swagger2);
        }

        private static string GetSwaggerJson(JsonSchemaGeneratorSettings settings, Assembly[] assemblies, List<string> classNames)
        {
            return GetOpenApiDocument(settings, assemblies, classNames).ToJson(SchemaType.Swagger2);
        }




    }
}
