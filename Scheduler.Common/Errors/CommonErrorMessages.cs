using System;

namespace Scheduler.Common.Errors
{
    public class CommonErrorMessages
    {
        public static string UNEXPECTED_ERROR_MESSAGE
            => "Unexpected error has occurred";

        public static string UNABLE_TO_OPEN_DB_CONNECTION
            => "Unable to open establish database connection";

        public static string UNABLE_TO_SET_DESERIALIZED_OBJECT
            => "Unable to set deserializedObject on taskCompletionSource";

        public static string UNABLE_TO_EXECUTE_STORED_PROCEDURE
            => $"Unable to persist object to repository";

        public static string UNABLE_TO_EXECUTE_QUERY => "Unable to execute query";

        public static string UNABLE_TO_LOCATE_SERVICE(Type type)
            => $"Unable to locate Service of Type {type} in the Container";

        public static string UNABLE_TO_CAST_OBJECT_TO_TYPE(Type type)
            => $"Unable to cast object to Type {type};";
    }
}