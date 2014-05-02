// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The auto mapper config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Business
{
    using System.Collections.Generic;

    using QTec.Business.ViewModels;
    using QTec.Core.Model;

    /// <summary>
    /// The auto mapper config.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// The register mappings.
        /// </summary>
        public static void RegisterMappings()
       {
           AutoMapper.Mapper.CreateMap<Employee, EmployeeViewModel>();
           AutoMapper.Mapper.CreateMap<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>();
       }
    }
}
