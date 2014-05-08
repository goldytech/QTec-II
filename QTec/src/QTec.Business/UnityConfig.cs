// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityConfig.cs" company="">
//   
// </copyright>
// <summary>
//   Specifies the Unity configuration for the main container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Business
{
    using System;

    using FluentValidation;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    using QTec.Business.Validators;
    using QTec.Business.ViewModels;
    using QTec.Data;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        /// <summary>
        /// The Unity container.
        /// </summary>
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        /// <returns>
        /// The <see cref="IUnityContainer"/>.
        /// </returns>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            
            // container.LoadConfiguration();

            // register by convention

            //container.RegisterTypes(
            //    AllClasses.FromLoadedAssemblies(),
            //    WithMappings.FromMatchingInterface,
            //    WithName.Default,
            //    WithLifetime.ContainerControlled);

            // TODO: Register your types here


            // this registration is required if you are injecting dependencies in your validator objects.
            container.RegisterType<IValidatorFactory, UnityValidatorFactory>(new ContainerControlledLifetimeManager());

            // singleton registration
            container.RegisterType<IQTecUnitOfWork, QTecUnitOfWork>(new ContainerControlledLifetimeManager());
            
            // transient registration , when ever resolve is requested a new instance is returned.
            container.RegisterType<IEmployeeManager, EmployeeManager>();

            container.RegisterType<IDesignationManager, DesignationManager>();

            container.RegisterType<IValidator<EmployeeViewModel>, EmployeeViewModelValidator>();
            
            // setup service locator
            var provider = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => provider);

           
        }
    }
}
