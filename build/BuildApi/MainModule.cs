using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModularPipelines.Context;
using ModularPipelines.DotNet.Extensions;
using ModularPipelines.Git.Extensions;
using ModularPipelines.GitHub.Extensions;
using ModularPipelines.Modules;

namespace BuildApi
{
    public class MainModule : Module<string>
    {
        protected override async Task<string?> ExecuteAsync(
            IPipelineContext context,
            CancellationToken cancellationToken
        )
        {
            var test = context.Git();
            context.DotNet().Publish(new()
            {
                
            })
            return null;
        }
    }
}
