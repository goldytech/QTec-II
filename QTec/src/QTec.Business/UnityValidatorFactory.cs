namespace QTec.Business
{
    using System;

    using FluentValidation;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// The unity validator factory.
    /// </summary>
    public class UnityValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>
        /// The unity container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityValidatorFactory"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public UnityValidatorFactory(IUnityContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// The create instance.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IValidator"/>.
        /// </returns>
        public override IValidator CreateInstance(Type type)
        {
            return this.container.Resolve(type) as IValidator;
        }
    }
}
