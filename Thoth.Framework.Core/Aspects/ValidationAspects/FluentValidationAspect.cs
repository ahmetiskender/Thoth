﻿using System;
using System.Linq;
using Thoth.Framework.Core.CrossCuttingConcern.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace Thoth.Framework.Core.Aspects.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private readonly Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType, Type.EmptyTypes);

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                 ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
