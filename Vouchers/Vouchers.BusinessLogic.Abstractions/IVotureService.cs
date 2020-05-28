using System;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVotureService
    {
        /// <summary>
        /// Returns Pages List of votures for the current user
        /// </summary>
        public void ListVoutchers();
        
        /// <summary>
        /// Updates a Voutcher. Chages its status 
        /// make it sold, used, or reserved
        /// </summary>
        public void UpdateVoutcher();




    }
}
