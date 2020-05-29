using ExtCore.Mvc.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.Backend.Actions
{
    public class AddControllers :
        IAddMvcAction
    {
        public int Priority => 2000;

        public void Execute(IMvcBuilder mvcBuilder, IServiceProvider serviceProvider)
        {
            mvcBuilder.AddApplicationPart(typeof(AddControllers).Assembly);
        }
    }
}
