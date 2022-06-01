﻿using System;

namespace VmsInform.Common.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
        {

        }

        public ForbiddenException(string message)
            :base(message)
        {

        }
    }
}
