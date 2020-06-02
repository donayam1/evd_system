using System.Net.Mime;
using System;
using Messages.Logging.Extensions;
using TakTec.RetailerPlans.Abstractions;
using ExtCore.Data.Abstractions;
using Microsoft.Extensions.Logging;
using TakTec.RetailerPlans.BusinessLogic.Abstraction;
using TakTec.RetailerPlans.Entities;
using System.Collections.Generic;
using TakTec.RetailerPlans.ViewModels;
using TakTec.RetailerPlans.Mapper;

namespace TakTec.RetailerPlans.BusinessLogic
{
    public class RetailerPlanService : IRetailerPlanService
    {

        private readonly IRetailerPlanRepository _retailerPlanRepository;
        private readonly ILogger<IRetailerPlanService> _logger;
        private readonly IStorage _storage;


        public RetailerPlanService(IStorage storage,ILogger<IRetailerPlanService> logger)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _retailerPlanRepository = _storage.GetRepository<IRetailerPlanRepository>()??
                                     throw new ArgumentNullException(nameof(IRetailerPlanRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public RetailerPlanViewModel CreateorUpdatePlan(RetailerPlanViewModel retailerPlanModel)
        {
            //TODO create and update
            throw new NotImplementedException();
        }

        // private RetailerPlan CreateNewPlan(RetailerPlan newPlan)
        // {
        //     RetailerPlan newRetailerPlan = new RetailerPlan("",ResourceTypes.GROUP);
        //     return newRetailerPlan;
        // }

        // private RetailerPlan UpdatePlan (RetailerPlan plan)
        // {

        // }

        public List<RetailerPlanViewModel> ListRetailerPlans(int pageNo, int ItemsPerPage)
        {
            //TODO list
            throw new NotImplementedException();
        }
    }
}
