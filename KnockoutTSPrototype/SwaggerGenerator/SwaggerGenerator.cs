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

            Partner p = new Partner();
            var as1 = p.GetType().Assembly;

            var document = OpenApiDocumentGenerator.GetOpenApiDocumentSepareted(settins, as1);

            //var json = document.ToJson(SchemaType.Swagger2);

            //File.WriteAllText("swagger.json", json);

            var tsSettings = new TypeScriptClientGeneratorSettings
            {
                ClassName = "MyClass",

                UseTransformResultMethod = true,
                UseTransformOptionsMethod = true,
                ClientBaseClass = "MyClassBase",

            };

            foreach (var doc in document)
            {
                var tsGenerator = new TypeScriptClientGenerator(doc, tsSettings);
                var tsCode = tsGenerator.GenerateFile();
                File.WriteAllText("ts\\" + Guid.NewGuid().ToString("N") + ".ts", tsCode);
            }

        }
    }
}
