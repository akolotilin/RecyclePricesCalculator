using System;

namespace VmsInform.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            :base(message)
        {

        }
    }
}
