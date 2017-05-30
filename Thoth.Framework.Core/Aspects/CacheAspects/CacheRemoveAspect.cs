﻿using System;
using Thoth.Framework.Core.CrossCuttingConcern.Caching.Microsoft;
using PostSharp.Aspects;

namespace Thoth.Framework.Core.Aspects.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private readonly string _pattern;

        public CacheRemoveAspect()
        {
        }

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
        }

        public CacheRemoveAspect(Type typeManager)
        {
            _pattern = string.Format("{0}.{1}.*", typeManager.ReflectedType.Namespace, typeManager.ReflectedType.Name);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var cacheManager = new MemoryCacheManager();

            cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
                ? string.Format("{0}.{1}.*", args.Method.ReflectedType.Namespace, /*args.Method.ReflectedType.Name*/args.Instance.ToString())
                : _pattern);
        }
    }
}
