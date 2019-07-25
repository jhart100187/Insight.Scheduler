using System;
using System.Linq;
using System.Collections.Generic;
using Scheduler.Common.Types;
using Scheduler.Common.Repository;
using Scheduler.Common.Errors;
using Microsoft.Extensions.Logging;

namespace Scheduler.Common.Extensions
{
    public static class IPersistableDataExtensions
    {
        public static T CastToIEXType<T>(this IPersistable data,
            ILogger<IRepository> logger) where T: new()
        {
            try
            {
                return (T)data;
            }
            catch(Exception ex)
            {
                if (ex.GetType() == typeof(InvalidCastException))
                    logger.LogCritical(ex, CommonErrorMessages.UNABLE_TO_CAST_OBJECT_TO_TYPE(typeof(T)));
                else
                    logger.LogCritical(ex, CommonErrorMessages.UNEXPECTED_ERROR_MESSAGE);

                return default(T);
            }
        }
    }
}