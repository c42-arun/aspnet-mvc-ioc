using System;

namespace MvcIoC.Models
{
    public class DebugMessageService : IDebugMessageService
    {
        public string Message => DateTime.Now.ToString();
    }
}