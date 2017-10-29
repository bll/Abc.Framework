using System;
using System.Linq;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.ValidationAspect
{
    [Serializable] // compile time da serileştirilebilmesi için
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }


        //OnEntry metod girişinde devreye girecek
        public override void OnEntry(MethodExecutionArgs args)
        {

            var validator = (IValidator)Activator.CreateInstance(_validatorType);// instance oluştur

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);

            }
        }
    }
}
