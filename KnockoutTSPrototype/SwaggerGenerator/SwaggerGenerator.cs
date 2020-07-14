using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KnockoutTSPrototype.Data.Entities;
using NJsonSchema;
using NJsonSchema.Generation;
using NSwag.CodeGeneration.TypeScript;

namespace SwaggerGenerator
{
    class SwaggerGenerator
    {
        public void Generate()
        {
            var settins = new JsonSchemaGeneratorSettings
            {
                //SchemaType = SchemaType.Swagger2,
                AllowReferencesWithProperties = true
            };

            var as1 = new Partner().GetType().Assembly;

            var documents = OpenApiDocumentGenerator.GetOpenApiDocumentSepareted(settins, as1);

            //var json = document.ToJson(SchemaType.Swagger2);
            //File.WriteAllText("swagger.json", json);

            var tsSettings = new TypeScriptClientGeneratorSettings
            {
                ClassName = "MyClass",

                UseTransformResultMethod = true,
                UseTransformOptionsMethod = true,
                ClientBaseClass = "MyClassBase",
                
            };

            foreach (var doc in documents)
            {
                var tsGenerator = new TypeScriptClientGenerator(doc, tsSettings);
                var tsCode = tsGenerator.GenerateFile();
                File.WriteAllText("ts\\" + Guid.NewGuid().ToString("N") + ".ts", tsCode);
            }

            var document = OpenApiDocumentGenerator.GetOpenApiDocument(settins, as1);

            var tsGenerator2 = new TypeScriptClientGenerator(document, tsSettings);
            var tsCode2 = tsGenerator2.GenerateFile();
            File.WriteAllText("ts\\api.ts", tsCode2);


        }
    }
}
