using System;
using Roles.BusinessLogic.Abstraction;
using Roles.ViewModels;
using EthioArt.Data.Enumerations;
using Microsoft.Extensions.Logging;
using Messages.Logging.Extensions;
using TakTec.Users.Constants;

namespace TakTec.Users.BusinessLogic
{
    public class ManageRoleTypeValidator : IManageRoleTypeValidator
    {

        

        private readonly ILogger<ManageRoleTypeValidator> _logger;
        public ManageRoleTypeValidator(ILogger<ManageRoleTypeValidator> logger) {
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(ILogger<ManageRoleTypeValidator>));
        }
        public bool Validate(RoleTypeModel roleTypes)
        {
            if (roleTypes.ObjectStatus == ObjectStatusEnum.REMOVED) {
                if (roleTypes.Level == RoleTypeConstants.RoleLevelSystemAdmin || roleTypes.Level == RoleTypeConstants.RoleLevelRetailer) {
                    _logger.AddUserError($"Can not remove user at level {roleTypes.Level}");
                    return false;
                }
            }
            if (roleTypes.ObjectStatus == ObjectStatusEnum.NEW)
            {
                if (roleTypes.Level == RoleTypeConstants.RoleLevelSystemAdmin || roleTypes.Level == RoleTypeConstants.RoleLevelRetailer ||
                    roleTypes.Level < RoleTypeConstants.RoleLevelSystemAdmin || roleTypes.Level > RoleTypeConstants.RoleLevelRetailer)
                {
                    _logger.AddUserError($"Can not create user at level {roleTypes.Level}");
                    return false;
                }
            }
            return true;
        }
    }
}
